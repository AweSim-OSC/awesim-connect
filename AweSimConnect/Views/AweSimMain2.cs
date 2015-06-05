using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AweSimConnect.Controllers;
using AweSimConnect.Models;
using AweSimConnect.Properties;

namespace AweSimConnect.Views
{
    /* 
    * TODO Wishlist
    *  
    * -
    * -Fix for vis nodes 
    * -Allow user to save password. (External prefs file, use user encryption.)
    * -Save external file locations in prefs to speed up startup.
    * -Hide putty window(s) inside the app (figure out with authentication detection)
    * -Detect TurboVNC installation
    * -Make sure all network stuff runs async
    * -Antialiased Font
    * -URI Parsing
    * -Manage multiple tunnels
    * -See if we can tweak ggivnc encoding settings for better performance
    * -Move magic strings to resources
    * -Allow user to select other ssh host in options.
    * 
    * /

   /*
    * AweSim Connect
    *  
    * A windows native app for SSH tunneling to Ohio Supercomputer Center services.
    * 
    * Brian McMichael: bmcmichael@osc.edu
    */
    public partial class AweSimMain2 : Form
    {
        // The version number. The first and second numbers are set in the assembly info. 
        // The third number is the number of days since the year 2000
        // The fourth number is the number of seconds since midnight divided by 2.
        static readonly String CLIENT_VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        static readonly String CLIENT_TITLE = "AweSim Connect v." + CLIENT_VERSION;
        static String AWESIM_DASHBOARD_URL = "http://apps.awesim.org/devapps/";
        static long START_TIME = DateTime.Now.Ticks;
        private static String SSH_HOST = "oakley.osc.edu";
        private static String BROWSER_ERROR = "No default browser discovered. Please navigate your web browser to: ";

        
        Connection connection;

        private PuTTYController pc;
        private VNCController vc;
        private SFTPController ftpc;
        private ClipboardController cbc;
        private ClusterController clc;
        
        private List<ProcessData> processes;
        private List<ConnectionForm> connectionForms; 

        private bool network_available = false;
        private bool tunnel_available = false;

        private int secondsElapsed = 0;

        IntPtr nextClipboardViewer;
        private bool sftp_available;
        private AboutFrm abtFrm;


        public AweSimMain2()
        {
            
            InitializeComponent();
            this.Text = CLIENT_TITLE;

            // Tell the clipboard viewer to notify this app when the clipboard changes.
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
        
        }
        

        private void AweSimMain2_Load(object sender, EventArgs e)
        {

            //GUI Setup
            this.CenterToParent();
            this.AcceptButton = bConnect;

            processes = new List<ProcessData>();
            connectionForms = new List<ConnectionForm>();
            connection = new Connection();
            timerMain.Start();

            //Initialize controllers.
            cbc = new ClipboardController();
            clc = new ClusterController();
            pc = new PuTTYController(connection);
            vc = new VNCController(connection);
            ftpc = new SFTPController(connection);
            abtFrm = new AboutFrm(CLIENT_VERSION);
            
            // Check for connectivity to the servers
            LimitedConnectionPopup();

            // For now, I'm using oakley as the SSH host. I'd like to make this user-selectable.
            this.connection.SSHHost = SSH_HOST;

            // Check to see if there is any valid data on the clipboard on startup.
            if (cbc.CheckClipboardForAweSim())
            {
                Connection clipData = cbc.GetClipboardConnection();
                UpdateData(clipData);
            }
        }

        //////////////////////////// BUTTONS ////////////////////////////

        // Open a browser window to Awesim Dashboard when user clicks the logo.
        private void bDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(AWESIM_DASHBOARD_URL);
            }
            catch (Exception)
            {
                MessageBox.Show(BROWSER_ERROR + AWESIM_DASHBOARD_URL, "Browser not found", MessageBoxButtons.OK);
            }
            
        }


        private void bConnect_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(tbUsername) && Validator.IsPresent(tbPassword) && Validator.IsInt32(tbPort) && Validator.IsPresent(tbHost))
            {
                
                ConnectionForm connectionForm = new ConnectionForm(connection, tbPassword.Text);
                connectionForm.StartPosition = FormStartPosition.CenterScreen;
                connectionForms.Add(connectionForm);
                connectionForm.Show();
            }
        }

        // The click handler for the SFTP button
        private void buttonSFTP_Click(object sender, EventArgs e)
        {
            if (network_available && Validator.IsPresent(tbUsername) && Validator.IsPresent(tbPassword))
            {
                if (ftpc.IsSFTPInstalled())
                {
                    ftpc.StartSFTPProcess(tbPassword.Text);
                    if (ftpc.GetThisProcess() != null)
                    {
                        processes.Add(new ProcessData(ftpc.GetThisProcess(), connection));
                    }
                }
            }
        }

        // Throws up a popup window if the app isn't able to connect to the selected SSH host.
        private void LimitedConnectionPopup()
        {
            network_available = NetworkTools.CanTelnetToOakley();
            if (!network_available)
            {
                MessageBox.Show("Unable to connect to OSC servers.\n\nPlease check your connection or contact your system administrator to enable access.", "Unable to Connect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Update the form fields from a connection object.
        // Use this when we begin importing from link or json.
        private void UpdateData(Connection newConnection)
        {
            if (newConnection != null)
            {
                if (!String.IsNullOrEmpty(newConnection.UserName))
                {
                    tbUsername.Text = newConnection.UserName;
                    this.connection.UserName = newConnection.UserName;
                }

                if (newConnection.RemotePort != 0)
                {
                    tbPort.Text = newConnection.RemotePort.ToString();
                    MapLocalPort(newConnection.RemotePort);
                }
                else
                    tbPort.Text = "";
                this.connection.RemotePort = newConnection.RemotePort;
                
                if (!String.IsNullOrEmpty(newConnection.PUAServer))
                {
                    tbHost.Text = newConnection.PUAServer;
                    this.connection.PUAServer = newConnection.PUAServer;
                }

                if (!String.IsNullOrEmpty(newConnection.VNCPassword))
                {
                    tbVNCPassword.Text = newConnection.VNCPassword;
                    this.connection.VNCPassword = newConnection.VNCPassword;
                }

                tbPassword.Focus();
                this.BringMainWindowToFront();
            }
        }
        
        // Recursive check and assign localport
        // TODO Look over code. This isn't sticking and I think that the local port is being reset somewhere.
        private void MapLocalPort(int port)
        {
            bool exists = false;
            if (connectionForms.Count > 0)
            {
                foreach (ConnectionForm form in connectionForms)
                {
                    if (form.GetConnection().LocalPort == port)
                        exists = true;
                }
            }

            // If the port was found in the list of processes, increment up and try again.
            if (exists)
            {
                port++;
                MapLocalPort(port);
            }
            else
            {
                this.connection.LocalPort = port;
            }
        }

        // Gets the file name of the application without the extension
        // Arg 0 is always the file path.
        private string getFileName()
        {
            String file;
            String[] pathArgs = Environment.GetCommandLineArgs();
            file = System.IO.Path.GetFileNameWithoutExtension(pathArgs[0]);
            return file;
        }

        // Open a browser window to Awesim Dashboard when user clicks the logo.
        private void pbAweSimLogo_Click(object sender, EventArgs e)
        {
            Process.Start(AWESIM_DASHBOARD_URL);
        }

        // Click handler for VNC button
        private void bVNCConnect_Click(object sender, EventArgs e)
        {
            if (pc.IsPlinkConnected() && Validator.IsPresent(tbVNCPassword))
            {
                vc = new VNCController(connection);
                vc.StartVNCProcess();
            }
        }

        // The click handler for the SFTP button
        private void bSFTP_Click(object sender, EventArgs e)
        {
            if (network_available && Validator.IsPresent(tbUsername) && Validator.IsPresent(tbPassword))
            {
                if (ftpc.IsSFTPInstalled())
                {
                    ftpc.StartSFTPProcess(tbPassword.Text);
                    if (ftpc.GetThisProcess() != null)
                    {
                        processes.Add(new ProcessData(ftpc.GetThisProcess(), connection));
                    }
                }                
            }
        }

        
        //Changes the color of a label
        private void LabelColorChanger(Label label, bool valid)
        {
            label.ForeColor = valid ? Color.Gray : Color.Red;
        }

        private void LabelColorChanger(RadioButton radioButton, bool valid)
        {
            radioButton.ForeColor = valid ? Color.Gray : Color.Red;
        }

        private void LabelColorChanger(GroupBox groupBox, bool valid)
        {
            groupBox.ForeColor = valid ? Color.Gray : Color.Red;
        }
        
        
        
        // Enable the web button if the tunnel is available and a local port is specified
        private void EnableWeb(int port)
        {
            //TODO: This funtionality will be moved to panel
            if ((port > 0) && tunnel_available)
            {
                //labelWeb.Text = "http://localhost:" + port;
                //bWeb.Enabled = true;
            }
            else
            {
                //labelWeb.Text = "";
                //bWeb.Enabled = false;
            }
        }

        // Red light / Green light toggle
        private void PictureBoxConnected(PictureBox picture, bool connected)
        {
            if (connected)
            {
                picture.Image = new Bitmap(AweSimConnect.Properties.Resources.greenlight);
            }
            else
            {
                picture.Image = new Bitmap(AweSimConnect.Properties.Resources.redlight);
            }
        }

        // Use this to enable/disable non-connection related options
        private void EnableAdditionalOptions(bool enable)
        {
            EnableVNCButton(enable);
        }
        
        // Use this to enable/disable vnc button
        private void EnableVNCButton(bool enable)
        {
            rbVNC.Enabled = enable;
        }

        // Use this to enable/disable connect button
        private void EnableTunnelOptions(bool enable)
        {
            bConnect.Enabled = enable;
        }

        private void EnableSFTPOptions(bool enable)
        {
            bSFTP.Enabled = enable;

            if (enable)
            {
                toolTipNoDelay.SetToolTip(bSFTP,
                    "File Transfer. A supported SFTP client has been detected. Click here to launch.");
            }
            else
            {
                toolTipNoDelay.SetToolTip(bSFTP, "No supported SFTP client detected.");
            }
        }
        
        // Handles the click for the web button.
        private void bWeb_Click(object sender, EventArgs e)
        {
            if (connection.LocalPort > 0)
            {
                String localUrl = "http://localhost:" + connection.LocalPort;
                Process.Start(localUrl);
            }
        }

        // When the user leaves the VNC password box the focus returns to the main connect button.
        private void tbVNCPassword_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = bConnect;
        }

        private void BringMainWindowToFront()
        {
            SetForegroundWindow((int)this.Handle);
        }

        [DllImport("user32.dll")]
        public static extern Int32 SetForegroundWindow(int windowHandle);

        
        

        // Clipboard monitoring
        [DllImport("user32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        // Add the app to the chain of apps that windows notifies on clipboard updates.
        [DllImport("user32.dll")]
        public static extern bool ChangeClipboardChain(IntPtr handleWindowRemove, IntPtr handleWindowNewNext);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr handleWindow, int windowMessage, IntPtr wParam, IntPtr lParam);

        protected override void WndProc(ref Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    PopulateFromClipboard();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam,
                    m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam,
                        m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        // If the clipboard has fresh and valid dataset, populate the fields.
        private void PopulateFromClipboard()
        {
            if (cbc != null)
            {
                if (cbc.CheckClipboardForAweSim())
                {
                    UpdateData(cbc.GetClipboardConnection());
                }
            }
        }

        // Actions to perform when closing the app.
        private void AweSimMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Remove the app from the clipboard view chain
            ChangeClipboardChain(this.Handle, nextClipboardViewer);

            // If the app has created any processes.
            if (processes.Count > 0)
            {
                // Close all processes that haven't already existed.
                foreach (ProcessData process in processes)
                {
                    if (process.IsRunning())
                    {
                        process.Kill();
                    }
                }
            }
        }


        private void tbVNCPassword_TextChanged(object sender, EventArgs e)
        {
            //Hide the password label when there is text in the box.
            LabelColorChanger(gbVNCPassword, (connection.SetValidVNCPassword(tbVNCPassword.Text) ? true : false));
        }

        // Provides a user workflow
        // TODO Clean this up and eliminate duplication.
        private void displayGroupBoxes()
        {
            
            if (network_available)
            {
                gbCredentials.Visible = true;

                if ((tbUsername.Text != "") && (tbPassword.Text != ""))
                {
                    gbSessionType.Visible = true;
                    bSFTP.Visible = true;

                    if (rbVNC.Checked || rbCOMSOL.Checked)
                    { 
                        gbSessionInfo.Visible = true;

                        if (rbVNC.Checked)
                        {
                            gbVNCPassword.Visible = true;
                            if ((tbHost.Text != "") && (tbPort.Text != "") && (tbVNCPassword.Text != ""))
                            {
                                bConnect.Visible = true;
                            }
                            else
                            {
                                bConnect.Visible = false;
                            }
                        }
                        else if (rbCOMSOL.Checked)
                        {
                            gbVNCPassword.Visible = false;
                            tbVNCPassword.Text = "";
                            LabelColorChanger(gbVNCPassword, true);

                            if ((tbHost.Text != "") && (tbPort.Text != ""))
                            {
                                bConnect.Visible = true;
                            }
                            else
                            {
                                bConnect.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        gbSessionInfo.Visible = false;
                        gbVNCPassword.Visible = false;
                        bConnect.Visible = false;
                    }
                }
                else
                {
                    gbSessionInfo.Visible = false;
                    gbSessionType.Visible = false;
                    gbVNCPassword.Visible = false;
                    bConnect.Visible = false;
                    bSFTP.Visible = false;
                }
            }
            else
            {
                gbCredentials.Visible = false;
                gbSessionInfo.Visible = false;
                gbSessionType.Visible = false;
                gbVNCPassword.Visible = false;
                bConnect.Visible = false;
                bSFTP.Visible = false;
            }

        }

        private void NetworkConnected(bool isNetworkConnected)
        {
            if (isNetworkConnected)
            {
                pbIsNetworkConnected.Image = Resources.check_gry;
                toolTipNoDelay.SetToolTip(pbIsNetworkConnected, "Network Available");
            }
            else
            {
                pbIsNetworkConnected.Image = Resources.cross_gry;
                toolTipNoDelay.SetToolTip(pbIsNetworkConnected, "Unable to Connect to AweSim Server. Check your connection or contact your system administrator.");
            }
        }

        //////////////////////////////////////////////////////
        // This is the main timer loop for the app.
        // Handle timed events like connection checking.
        //////////////////////////////////////////////////////
        private void timerMain_Tick(object sender, EventArgs e)
        {
            displayGroupBoxes();

            NetworkConnected(network_available);

            if (secondsElapsed == 0)
            {
                ftpc.DetectSFTPPath();
            }
            
            // Check for network connectivity every 15 seconds.
            // Disable the connection button if can not connect to OSC.
            if (secondsElapsed % 15 == 0)
            {
                network_available = NetworkTools.CanTelnetToOakley();
                EnableTunnelOptions(network_available);
            }


            if (secondsElapsed % 2 == 0)
            {
                sftp_available = ftpc.IsSFTPInstalled();

                EnableSFTPOptions(sftp_available && network_available);
            }

            secondsElapsed++;

        }

        

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            connection.UserName = tbUsername.Text;
        }

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            // When the user modifies the redirect port box, set the variable, change label to red if not a valid integer
            try
            {
                int port = int.Parse(tbPort.Text);
                connection.RemotePort = port;
                MapLocalPort(port);
                LabelColorChanger(lPort, true);
            }
            catch (Exception)
            {
                LabelColorChanger(lPort, false);
            }
        
        }

        private void tbHost_TextChanged(object sender, EventArgs e)
        {
            connection.PUAServer = tbHost.Text;
        }

        private void pbAbout_Click(object sender, EventArgs e)
        {
            if (abtFrm.IsDisposed)
            {
                abtFrm = new AboutFrm(CLIENT_VERSION);
            }
            abtFrm.Show();
        }

        private void rbVNC_CheckedChanged(object sender, EventArgs e)
        {
            tbPort.Enabled = true;
            tbPort.Text = ""+Connection.VNC_DISPLAY_DEFAULT;
        }

        private void rbCOMSOL_CheckedChanged(object sender, EventArgs e)
        {
            tbPort.Enabled = false;
            tbPort.Text = ""+Connection.COMSOL_SERVER_PORT.ToString();
        }



        /*  Upcoming password save feature 

        // Check the user settings for a username and encrypted password and fill the text boxes.
        private void checkForUserSettings()
        {
            if ((bool)Settings.Default["IsPassSaved"])
            {
                label1.Text = Settings.Default["UserName"].ToString();
                checkSavePassword.Checked = true;
                string userName = Settings.Default["UserName"].ToString();
                string userPass = Settings.Default["UserPass"].ToString();
                tbUserName.Text = userName;
                tbPassword.Text = PasswordEncryption.Decrypt(userPass);
                
            }
        }
        
        // If true, save the choice to the Settings. If false, change user settings to reflect.
        private void SaveUserSettings(bool userSettings)
        {
            Settings.Default["IsPassSaved"] = userSettings;
            string userName = tbUserName.Text;
            string userPass = tbPassword.Text;

            //If we're saving the settings, encrypt the password and save to settings. Else save blanks.
            if (userSettings) {
                Settings.Default["UserName"] = userName;
                string encryptedUserPass = PasswordEncryption.Encrypt(userPass);
                Settings.Default["UserPass"] = encryptedUserPass;
            }
            else
            {
                Settings.Default["UserName"] = userName;
                Settings.Default["UserPass"] = "";
            }
            Settings.Default.Save();
            
        }
         
        */
    }
}
