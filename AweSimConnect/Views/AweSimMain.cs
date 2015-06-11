using AweSimConnect.Controllers;
using AweSimConnect.Models;
using AweSimConnect.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace AweSimConnect
{
    /* 
     * TODO Wishlist
     *  
     * -Fix for vis nodes 
     * -Allow user to save password. (External prefs file, encode in base64?)
     * -Save external file locations in prefs to speed up startup.
     * -Hide putty window(s) inside the app (figure out with authentication detection)
     * -Allow disconnecting based on port
     * -Detect TurboVNC installation
     * -Make sure all network stuff runs async
     * -Disable connect button if already connected on a port.
     * -Antialiased Font
     * -URI Parsing
     * -Manage multiple tunnels
     * -See if we can tweak ggivnc encoding settings for better performance
     * -Move magic strings to resources
     * 
     * /

    /*
     * AweSim Connect
     *  
     * A windows native app for SSH tunneling to Ohio Supercomputer Center services.
     * 
     * Brian McMichael: bmcmichael@osc.edu
     */
    public partial class AweSimMain : Form
    {
        
        // The version number. The first and second numbers are set in the assembly info. 
        // The third number is the number of days since the year 2000
        // The fourth number is the number of seconds since midnight divided by 2.
        static String CLIENT_VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        static String CLIENT_TITLE = "AweSim Connect";
        static String AWESIM_DASHBOARD_URL = "http://apps.awesim.org/devapps/";
        static long START_TIME = DateTime.Now.Ticks;

        private PuTTYController pc;
        private VNCControllerGGI vc;
        private SFTPController ftpc;
        private ClipboardController cbc;
        private ClusterController clc;
        Connection connection;

        private List<ProcessData> processes;

        private bool network_available = false;
        private bool tunnel_available = false;

        private int secondsElapsed = 0;

        IntPtr nextClipboardViewer;
        private bool sftp_available;
        private AboutFrm abtFrm;

        public AweSimMain()
        {
            InitializeComponent();
            // Tell the clipboard viewer to notify this app when the clipboard changes.
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
        }

        // On application load
        private void AweSimMain_Load(object sender, EventArgs e)
        {
            //GUI setup
            this.CenterToParent();
            this.AcceptButton = bConnect;
            labelWeb.Text = "";
            labelSFTP.Text = "Searching for SFTP Client";
            labelVersion.Text = CLIENT_TITLE + " Version " + CLIENT_VERSION;

            processes = new List<ProcessData>();
            connection = new Connection();
            timerConnection.Start();

            //Initialize controllers.
            cbc = new ClipboardController();
            clc = new ClusterController();
            pc = new PuTTYController(connection);
            vc = new VNCControllerGGI(connection);
            ftpc = new SFTPController(connection);
            abtFrm = new AboutFrm(CLIENT_VERSION);       

            // Adds the Clusters to the Combobox
            setupClusterBox();            

            // Check for connectivity to the servers
            LimitedConnectionPopup();

            //Check to see if there is any valid data on the clipboard on startup.
            if (cbc.CheckClipboardForAweSim())
            {
                Connection clipData = cbc.GetClipboardConnection();
                UpdateData(clipData);
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
                    tbUserName.Text = newConnection.UserName;
                    this.connection.UserName = newConnection.UserName;
                }

                if (newConnection.RemotePort != 0)
                    tbRemotePort.Text = newConnection.RemotePort.ToString();
                else
                    tbRemotePort.Text = "";
                this.connection.RemotePort = newConnection.RemotePort;
                                
                if (newConnection.LocalPort != 0)
                    tbLocalPort.Text = newConnection.LocalPort.ToString();
                else
                    tbLocalPort.Text = "";
                this.connection.LocalPort = newConnection.LocalPort;

                if (!String.IsNullOrEmpty(newConnection.PUAServer))
                {
                    tbHost.Text = newConnection.PUAServer;
                    this.connection.PUAServer = newConnection.PUAServer;
                }

                //Oakley for now.
                // TODO enable all clusters
                setCluster();

                if (!String.IsNullOrEmpty(newConnection.VNCPassword))
                {
                    tbVNCPassword.Text = newConnection.VNCPassword;
                    this.connection.VNCPassword = newConnection.VNCPassword;
                }

                tbPassword.Focus();
                this.BringMainWindowToFront();
            }
        }

        // Gets the file name without the extension
        // Arg 0 is always the file path.
        private string getFileName()
        {
            String file;
            String[] pathArgs = Environment.GetCommandLineArgs();
            file = System.IO.Path.GetFileNameWithoutExtension(pathArgs[0]);
            return file;
        }

        // Adds the ssh server locations to the combobox
        private void setupClusterBox()
        {
            foreach (Cluster cluster in clc.GetClusterList())
            {
                cbCluster.Items.Add(cluster);
            }
            setCluster();
        }

        // Select the first one on the list. Oakley for now.
        //TODO: Fix this
        private void setCluster()
        {
            cbCluster.SelectedIndex = 0;
        }

        // When the user modifies the host box, the variable gets set
        private void tbHost_TextChanged(object sender, EventArgs e)
        {
            this.connection.PUAServer = tbHost.Text;
        }

        // When the user modifies the redirect port box, set the variable, change label to red if not a valid integer
        private void tbRedirect_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.connection.LocalPort = int.Parse(tbLocalPort.Text);
                LabelColorChanger(lRedirect, true);
            }
            catch (Exception)
            {
                LabelColorChanger(lRedirect, false);
            }
        }

        //Handles the connect button action.
        private void bConnect_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(tbUserName) && Validator.IsPresent(tbPassword) && Validator.IsPresent(cbCluster) && Validator.IsInt32(tbRemotePort) && Validator.IsPresent(tbHost) && Validator.IsInt32(tbLocalPort))
            {
                pc = new PuTTYController(this.connection);
                pc.StartPlinkProcess(tbPassword.Text);
            }
        }

        //Set the username when the user enters text.
        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            this.connection.UserName = tbUserName.Text;
        }

        //Set the cluster when the user changes the box.
        private void cbCluster_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.connection.SSHHost = clc.GetClusterList()[cbCluster.SelectedIndex].Domain;
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
                vc = new VNCControllerGGI(connection);
                vc.StartVNCProcess();
            }
        }

        // The click handler for the SFTP button
        private void bSFTP_Click(object sender, EventArgs e)
        {
            if (network_available && Validator.IsPresent(tbUserName) && Validator.IsPresent(tbPassword))
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

        // Checks the password field and marks the label red if the password is invalid.
        private void tbVNCPassword_TextChanged(object sender, EventArgs e)
        {
            LabelColorChanger(labelVNCPassword, (connection.SetValidVNCPassword(tbVNCPassword.Text) ? true : false));
        }

        //Changes the color of a label
        private void LabelColorChanger(Label label, bool valid)
        {
            label.ForeColor = valid ? Color.Gray : Color.Red;
        }

        //////////////////////////////////////////////////////
        // This is the main timer loop for the app.
        // Handle timed events like connection checking.
        //////////////////////////////////////////////////////
        private void timerConnection_Tick(object sender, EventArgs e)
        {
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
                PictureBoxConnected(pbNetwork, network_available);
            }

            // Check for tunnel connectivity every 4 seconds.
            // Disable the additional connection options if can't connect through the tunnel.
            if (secondsElapsed % 4 == 0)
            {
                tunnel_available = pc.IsPlinkConnected();
                

                //If the tunnel is connected, enable the button, otherwise disable.
                EnableWeb(tunnel_available ? pc.Connection.LocalPort : 0);

                //Enable the VNC and SFTP
                EnableAdditionalOptions(tunnel_available);

                PictureBoxConnected(pbTunnel, tunnel_available);

                //If the tunnel is connected and the process hasn't been embedded, pull it into the app.
                if (tunnel_available && !pc.IsProcessEmbedded())
                {
                    ProcessData pData = new ProcessData(pc.GetThisProcess(), connection);
                    processes.Add(pData);
                    pc.EmbedProcess();

                    //TODO: This is the only place these are used right now. Move them up or out if we need to.
                    //int MAXIMIZE_WINDOW = 3;
                    int MINIMIZE_WINDOW = 6;

                    ShowWindow(pc.GetThisProcess().MainWindowHandle, MINIMIZE_WINDOW);

                    //TODO This command will embed the putty process in the main window. Hold off implementing until I can figure out how to test if tunnel is authenticated.
                    //SetParent(pc.GetThisProcess().MainWindowHandle, panelProcesses.Handle);
                }
            }

            if (secondsElapsed % 2 == 0)
            {
                sftp_available = ftpc.IsSFTPInstalled();

                EnableSFTPOptions(sftp_available && network_available);
            }

            secondsElapsed++;
        }
        
        // Enable the web button if the tunnel is available and a local port is specified
        private void EnableWeb(int port)
        {
            if ((port > 0) && tunnel_available)
            {
                labelWeb.Text = "http://localhost:" + port;
                bWeb.Enabled = true;
            }
            else
            {
                labelWeb.Text = "";
                bWeb.Enabled = false;
            }
        }

        // Red light / Green light toggle
        private void PictureBoxConnected(PictureBox picture, bool connected)
        {
            if (connected)
            {
                picture.Image = new Bitmap(AweSimConnect.Properties.Resources.check_gry);
            }
            else
            {
                picture.Image = new Bitmap(AweSimConnect.Properties.Resources.cross_gry);
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
            bVNCConnect.Enabled = enable;
        }

        // Use this to enable/disable connect button
        private void EnableTunnelOptions(bool enable)
        {
            bConnect.Enabled = enable;
        }

        private void EnableSFTPOptions(bool enable)
        {
            //TODO only enable if this actually discovers sftp client on board
            labelSFTP.Text = enable ? "SFTP Client Detected" : "SFTP Client Not Found";
            bSFTP.Enabled = enable;
        }

        // Performs an action when the text in the remote port textbox is changed.
        private void tbRemotePort_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int port = int.Parse(tbRemotePort.Text);
                this.connection.RemotePort = port;

                // In many cases we will map the remote port to the local port. 
                // This fills in the local text box. User can still modify local manually. 
                this.connection.LocalPort = port;
                tbLocalPort.Text = tbRemotePort.Text;

                LabelColorChanger(lRemotePort, true);
            }
            catch (Exception)
            {
                LabelColorChanger(lRemotePort, false);
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

        // User can click the vnc button by hittin enter in the vnc password box.
        private void tbVNCPassword_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = bVNCConnect;
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

        // Used for embedding process into the app
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr windowChild, IntPtr windowParent);

        // Used for embedding process into the app
        [DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr windowHandle, int command);

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

        private void pbAbout_Click(object sender, EventArgs e)
        {
            if (abtFrm.IsDisposed)
            {
                abtFrm = new AboutFrm(CLIENT_VERSION);
            }
            abtFrm.StartPosition = FormStartPosition.CenterScreen;
            abtFrm.Show();
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
