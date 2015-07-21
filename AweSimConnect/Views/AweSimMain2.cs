using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AweSimConnect.Controllers;
using AweSimConnect.Models;
using AweSimConnect.Properties;

namespace AweSimConnect.Views
{
    /*
    * TODO Wishlist
    *
    * -NEED TO ASYNC THE NETWORK CALLS
    * -Antialiased Font
    * -URI Parsing
    * -Move magic strings to resources
    * 
    * /

   /*
    * AweSim Connect
    *
    * A windows native app for SSH tunneling to Ohio Supercomputer Center services.
    * 
    * Compile for .NET 2.0
    *
    * Brian McMichael: bmcmichael@osc.edu
    */
    public partial class AweSimMain2 : Form
    {
        // The version number. The first and second numbers are set in the assembly info.
        // The third number is the number of days since the year 2000
        // The fourth number is the number of seconds since midnight divided by 2.
        static readonly string CLIENT_VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        static readonly string CLIENT_TITLE = "AweSim Connect v." + CLIENT_VERSION;
        static string AWESIM_DASHBOARD_URL = "http://apps.awesim.org/devapps/";

        private static string BROWSER_ERROR = "No default browser discovered. Please navigate your web browser to: ";
        private static string LIMITED_CONNECTION_ERROR =
            "Unable to connect to OSC servers.\n\nPlease check your connection or contact your system administrator to enable access.";
        private static string UNABLE_TO_CONNECT =
            "Unable to Connect to AweSim Server. Check your connection or contact your system administrator.";
        private static string SFTP_NOT_DETECTED = "Supported SFTP client not detected";

        Connection _connection;

        private SFTPControllerWinSCP _ftpc;
        private ConsoleController _consolec;
        private ClipboardController _clipc;
        private CommandLineController _commandc;
        private OSCClusterController _clusterc;
        private RegistryHook _registry;

        private List<ProcessData> _processes;
        private List<ConnectionForm> _connectionForms;

        private bool _networkAvailable = false;
        private bool _sshAvailable = false;
        private bool _networkChanged = false;

        private int _secondsElapsed = 0;

        IntPtr _nextClipboardViewer;
        private bool _sftpAvailable;
        private AboutFrm _abtFrm;
        private AdvSettingsFrm _advFrm;
        private AdvancedSettings _settings;
        private string _sshHost;

        public AweSimMain2(string[] args)
        {
            InitializeComponent();
            this.Text = CLIENT_TITLE;

            // Tell the clipboard viewer to notify this app when the clipboard changes.
            _nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
        }

        // Form Load
        private void AweSimMain2_Load(object sender, EventArgs e)
        {
            //GUI Setup
            this.CenterToParent();
            this.AcceptButton = bConnect;

            _processes = new List<ProcessData>();
            _connectionForms = new List<ConnectionForm>();
            _connection = new Connection();
            FileController.CreateAweSimFilesFolder();

            //Initialize controllers.
            _clipc = new ClipboardController();
            _clusterc = new OSCClusterController();
            _ftpc = new SFTPControllerWinSCP(_connection);
            _abtFrm = new AboutFrm();
            _advFrm = new AdvSettingsFrm();
            _settings = new AdvancedSettings();
            _registry = new RegistryHook();
            
            // Check for connectivity to the servers
            LimitedConnectionPopup();

            _sshHost = _clusterc.GetCluster(_settings.GetSSHHostCode()).Domain;
            this._connection.SSHHost = _sshHost;

            tbUsername.Text = _settings.GetUsername();
            tbPassword.Text = _settings.GetPassword();
            if (_settings.IsUserSaved())
            {
                cbRememberMe.Checked = true;
            }

            DisplayGroupBoxes();

            if (!_settings.GetArgsChanged())
            {
                PopulateFromClipboard();
            }

            timerMain.Start();

        }


        //////////////////////////// BUTTONS ////////////////////////////

        // Open a browser window to Awesim Dashboard when user clicks the logo.
        private void bDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                WebTools.LaunchBrowser(AWESIM_DASHBOARD_URL);
            }
            catch (Exception)
            {
                MessageBox.Show(BROWSER_ERROR + AWESIM_DASHBOARD_URL, "Browser not found", MessageBoxButtons.OK);
            }
        }

        // Handle the connect button actions
        private void bConnect_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(tbUsername) && Validator.IsPresent(tbPassword) && Validator.IsInt32(tbPort) && Validator.IsPresent(tbHost))
            {
                //If there is AweSim data on the clipboard, clear it now 
                if (_clipc.CheckClipboardForAweSim())
                {
                    Clipboard.Clear();
                }

                // Saves user settings if checked.
                SaveUserSettings();

                // Maps the remote port to an available local port.
                MapLocalPort(_connection.RemotePort);

                // The vis nodes have public facing domain names that don't forward properly.
                // Call the remap method here to check and remap to the internal domain.
                _connection.PUAServer = new VisualizationNode().RemapPublicHostToInternalHost(_connection.PUAServer);

                Point newWindowPoint = BuildNewConnectionWindowCoordinates();
                BuildConnectionForm(_connection, tbPassword.Text, newWindowPoint);
            }
        }

        private Point BuildNewConnectionWindowCoordinates()
        {
            // The current width and height of the main application.
            int width = this.Width + SystemInformation.BorderSize.Width;
            //int width = this.Width;
            int height = this.Height + SystemInformation.BorderSize.Height;
            //int height = this.Height;

            //This is the current location of the main app window.
            Point form_location = this.Location;

            // This is the size of the user's screen.
            Rectangle screen_rectangle = Screen.FromControl(this).Bounds;

            // This gets the size of a connection form if we've already spawned one.
            int form_instance = _connectionForms.Count;
            int form_batch = form_instance/3;
            int form_offset = form_instance%3;

            int connection_form_height = 0;
            int connection_form_width = 0;
            if (_connectionForms.Count > 0)
            {
                Size connection_form_size = _connectionForms[0].Size;
                connection_form_height = connection_form_size.Height;
                connection_form_width = connection_form_size.Width + (SystemInformation.FixedFrameBorderSize.Width * 2); 
            }

            // Set the new coordinates of window.
            int new_x = (form_batch*50) + Right + (SystemInformation.FixedFrameBorderSize.Width * 2);
            int new_y = ((form_batch*50) + (form_offset*50)) + form_location.Y +
                        (form_offset*(connection_form_height + SystemInformation.FixedFrameBorderSize.Height));  
            
            // Checks to prevent new form from spawning off-screen.
            if (new_x < screen_rectangle.X)
                new_x = screen_rectangle.X;
            if (new_x > ((screen_rectangle.X + screen_rectangle.Width) - connection_form_width))
                new_x = ((screen_rectangle.X + screen_rectangle.Width) - connection_form_width);
            if (new_y < screen_rectangle.Y)
                new_y = screen_rectangle.Y;
            if (new_y > ((screen_rectangle.Y + screen_rectangle.Height) - connection_form_height))
                new_y = ((screen_rectangle.Y + screen_rectangle.Height) - connection_form_height);

            return new Point(new_x, new_y);
        }

        private void BuildConnectionForm(Connection connection, String password, Point startPoint)
        {
            Connection newConnection = ObjectCopier.Clone(connection);
            ConnectionForm connectionForm = new ConnectionForm(newConnection, password);
            connectionForm.StartPosition = FormStartPosition.Manual;
            connectionForm.Location = startPoint;
            connectionForm.Show(this);
            _connectionForms.Add(connectionForm);
        }

        private void buttonConsole_Click(object sender, EventArgs e)
        {
            if (_networkAvailable && Validator.IsPresent(tbUsername) && Validator.IsPresent(tbPassword))
            {
                SaveUserSettings();

                _consolec = new ConsoleController(_connection);
                _consolec.StartPuttyProcess(tbPassword.Text);

                //If the process started up, add it to the list of processes so we can kill it later.
                if (_consolec.GetThisProcess() != null)
                {
                    _processes.Add(new ProcessData(_consolec.GetThisProcess(), _connection));
                }
            }
        }

        // The click handler for the SFTP button
        private void buttonSFTP_Click(object sender, EventArgs e)
        {
            if (_networkAvailable && Validator.IsPresent(tbUsername) && Validator.IsPresent(tbPassword))
            {
                SFTPControllerWinSCP winscp = new SFTPControllerWinSCP(_connection);
                winscp.StartSFTPProcess(tbPassword.Text);
                if (winscp.GetThisProcess() != null)
                {
                    _processes.Add(new ProcessData(winscp.GetThisProcess(), _connection));
                }
            }
        }

        // Throws up a popup window if the app isn't able to connect to the selected SSH host.
        private void LimitedConnectionPopup()
        {
            _networkAvailable = NetworkTools.CanTelnetToHost(_clusterc.GetCluster(_settings.GetSSHHostCode()).Domain);
            if (!_networkAvailable)
            {
                MessageBox.Show(LIMITED_CONNECTION_ERROR, "Unable to Connect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                _networkChanged = true;
            }
            NetworkConnected(_networkChanged);
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
                    this._connection.UserName = newConnection.UserName;
                }

                if (newConnection.RemotePort != 0)
                {
                    tbPort.Text = newConnection.RemotePort.ToString();
                    this._connection.RemotePort = newConnection.RemotePort;
                }
                else
                    tbPort.Text = "";


                if (!String.IsNullOrEmpty(newConnection.PUAServer))
                {
                    tbHost.Text = newConnection.PUAServer;
                    _connection.PUAServer = newConnection.PUAServer;
                }
                else
                {
                    tbHost.Text = "";
                }

                if (!String.IsNullOrEmpty(newConnection.VNCPassword))
                {
                    rbVNC.Checked = true;
                    tbVNCPassword.Text = newConnection.VNCPassword;
                    _connection.VNCPassword = newConnection.VNCPassword;
                }
                else
                {
                    rbCOMSOL.Checked = true;
                    tbVNCPassword.Text = "";
                    _connection.VNCPassword = null;
                }

                tbPassword.Focus();
                BringMainWindowToFront();
            }
        }

        private void ClickConnectButton()
        {
            if (_settings.LaunchTunnelAutomatically() && !string.IsNullOrEmpty(tbUsername.Text) &&
                    !string.IsNullOrEmpty(tbPassword.Text) && bConnect.Enabled)
            {
                bConnect.PerformClick();
            }
        }

        // Recursive check and assign localport
        private int MapLocalPort(int port)
        {
            int localPort = port;

            // Check the processes this app instance has opened to see if we've already used this port.
            if (_connectionForms.Count > 0)
            {
                foreach (ConnectionForm form in _connectionForms)
                {
                    if (form.GetConnection().LocalPort == localPort)
                    {
                        localPort++;
                        return MapLocalPort(localPort);
                    }
                }
            }

            // If we don't find the port in the list of used ports, check to see if it's in use on the system.
            if (NetworkTools.IsPortOpenOnLocalHost(localPort))
            {
                localPort++;
                return MapLocalPort(localPort);
            }

            // TODO refactor this to just return the port. This is belt and suspenders.
            this._connection.LocalPort = localPort;
            return localPort;
        }

        //Changes the color of a label
        private void LabelColorChanger(Label label, bool valid)
        {
            label.ForeColor = valid ? Color.Gray : Color.Red;
        }

        private void LabelColorChanger(GroupBox groupBox, bool valid)
        {
            groupBox.ForeColor = valid ? Color.Gray : Color.Red;
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

        // True to enable the SFTP button, false to disable.
        private void EnableSFTPOptions(bool enable)
        {
            bSFTP.Enabled = enable;

            if (enable)
            {
                toolTipNoDelay.SetToolTip(bSFTP,
                    "File Transfer. A supported SFTP client has been detected. Click here to launch.");
                bSFTP.BackgroundImage = Resources.hdd_gry;
                bSFTP.Text = String.Empty;
            }
            else
            {
                toolTipNoDelay.SetToolTip(bSFTP, "No supported SFTP client detected.");
                bSFTP.BackgroundImage = null;
                bSFTP.Text = SFTP_NOT_DETECTED;
            }
        }

        private void BringMainWindowToFront()
        {
            SetForegroundWindow((int)this.Handle);
        }

        [DllImport("user32.dll")]
        public static extern Int32 SetForegroundWindow(int windowHandle);

        // Clipboard monitoring
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
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
                    SendMessage(_nextClipboardViewer, m.Msg, m.WParam,
                    m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == _nextClipboardViewer)
                    {
                        _nextClipboardViewer = m.LParam;
                    }
                    else
                        SendMessage(_nextClipboardViewer, m.Msg, m.WParam,
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
            if ((_settings != null) && _settings.DetectClipboard())
            {
                if (_clipc != null)
                {
                    if (_clipc.CheckClipboardForAweSim())
                    {
                        //Add a thread sleep while the parser finishes up.
                        Thread.Sleep(50);
                        Connection clipData = _clipc.GetClipboardConnection();
                        UpdateData(clipData);
                        DisplayGroupBoxes();
                        ClickConnectButton();
                    }
                }
            }
        }

        // Actions to perform when closing the app.
        private void AweSimMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Remove the app from the clipboard view chain
            ChangeClipboardChain(Handle, _nextClipboardViewer);

            // If the app has created any processes. (SFTP clients, for example)
            if (_processes.Count > 0)
            {
                // Close all processes that haven't already existed.hb
                foreach (ProcessData process in _processes)
                {
                    if (process.IsRunning())
                    {
                        process.Kill();
                    }
                }
            }

            //Close all child forms (this will kill associated processes)
            if (_connectionForms.Count > 0)
            {

                // Close each child form (the forms should be managing their own processes)
                foreach (var connectionForm in _connectionForms)
                {
                    connectionForm.Close();
                }
            }

            //Clean up installed files.
            FileController.DeleteAweSimFilesFolder();
        }

        // When the user changes the text in the VNC password box, check for validity.
        private void tbVNCPassword_TextChanged(object sender, EventArgs e)
        {
            //Hide the password label when there is text in the box.
            LabelColorChanger(gbVNCPassword, (_connection.SetValidVNCPassword(tbVNCPassword.Text) ? true : false));
        }

        // Provides a user workflow
        private void DisplayGroupBoxes()
        {

            if (_networkAvailable)
            {
                gbCredentials.Visible = true;

                if ((tbUsername.Text != "") && (tbPassword.Text != ""))
                {
                    gbSessionType.Visible = true;
                    bSFTP.Visible = true;
                    gbSFTP.Visible = true;
                    buttonConsole.Visible = true;
                    gbConsole.Visible = true;

                    if (rbVNC.Checked || rbCOMSOL.Checked)
                    {
                        gbSessionInfo.Visible = true;

                        if (rbVNC.Checked)
                        {
                            gbVNCPassword.Visible = true;
                            if ((tbHost.Text != "") && (tbPort.Text != "") && (tbVNCPassword.Text != ""))
                            {
                                bConnect.Visible = true;
                                gbConnect.Visible = true;
                            }
                            else
                            {
                                bConnect.Visible = false;
                                gbConnect.Visible = false;
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
                                gbConnect.Visible = true;
                            }
                            else
                            {
                                bConnect.Visible = false;
                                gbConnect.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        gbSessionInfo.Visible = false;
                        gbVNCPassword.Visible = false;
                        bConnect.Visible = false;
                        gbConnect.Visible = false;
                    }
                }
                else
                {
                    gbSessionInfo.Visible = false;
                    gbSessionType.Visible = false;
                    gbVNCPassword.Visible = false;
                    bConnect.Visible = false;
                    gbConnect.Visible = false;
                    bSFTP.Visible = false;
                    gbSFTP.Visible = false;
                    buttonConsole.Visible = false;
                    gbConsole.Visible = false;
                }
            }
            else
            {
                gbCredentials.Visible = false;
                gbSessionInfo.Visible = false;
                gbSessionType.Visible = false;
                gbVNCPassword.Visible = false;
                bConnect.Visible = false;
                gbConnect.Visible = false;
                bSFTP.Visible = false;
                gbSFTP.Visible = false;
                buttonConsole.Visible = false;
                gbConsole.Visible = false;
            }

        }

        private void NetworkConnected(bool isNetworkConnected)
        {
            CheckSSHConnection(_networkChanged);

            if (isNetworkConnected)
            {
                pbIsNetworkConnected.Image = Resources.wifi;
                toolTipNoDelay.SetToolTip(pbIsNetworkConnected, "Network Available\nConnected to " + _sshHost);
                lConnectionStatus.Text = _sshHost + " available";
            }
            else
            {
                pbIsNetworkConnected.Image = Resources.cross_gry;
                toolTipNoDelay.SetToolTip(pbIsNetworkConnected, UNABLE_TO_CONNECT + "\n" + _sshHost);
                lConnectionStatus.Text = _sshHost + " unavailable";
            }
        }

        private void CheckSSHConnection(bool networkChanged)
        {
            if (networkChanged)
            {
                _networkChanged = false;
                _sshAvailable = SSHController.CheckSSHConnectionToHost(_sshHost);
            }
        }

        //////////////////////////////////////////////////////
        // This is the main timer loop for the app.
        // Handle timed events like connection checking.
        //////////////////////////////////////////////////////
        private void timerMain_Tick(object sender, EventArgs e)
        {
            _secondsElapsed++;

            DisplayGroupBoxes();

            NetworkConnected(_networkAvailable);
            
            if (_secondsElapsed == 2)
            {
                deployHelperApps();
            }

            // Check for network connectivity every 15 seconds.
            // Disable the connection button if can not connect to OSC.
            if (_secondsElapsed % 15 == 0)
            {
                //TODO Async this
                bool availableBeforeCheck = _networkAvailable;
                _networkAvailable = NetworkTools.CanTelnetToHost(_clusterc.GetCluster(_settings.GetSSHHostCode()).Domain);
                _networkChanged = (availableBeforeCheck != _networkAvailable);
                CheckSSHConnection(_networkChanged);
                EnableTunnelOptions(_networkAvailable);

            }

            if (_secondsElapsed % 2 == 0)
            {
                //_sftpAvailable = _ftpc.IsSFTPInstalled();
                _sftpAvailable = true;
                EnableSFTPOptions(_sftpAvailable && _networkAvailable);
            }

            if (_secondsElapsed % 3 == 0)
            {
                //Checks if the state was toggled in the about form an updates main.
                if (_advFrm.AdvancedSettingsChanged())
                {
                    cbRememberMe.Checked = _settings.IsUserSaved();
                    _sshHost = _clusterc.GetCluster(_settings.GetSSHHostCode()).Domain;
                    _connection.SSHHost = _sshHost;
                }

                CheckForCommandLineUpdate();
            }
        }

        //This method deploys the helper apps to the helper apps folder. The objects will get garbage collected.
        private void deployHelperApps()
        {
            new SFTPControllerWinSCP(_connection);
            new ConsoleController(_connection);
            new PlinkController(_connection);
            new VNCControllerTurbo(_connection);
        }

        private void CheckForCommandLineUpdate()
        {
            if (CommandLineController.IsArgsChanged())
            {
                try
                {
                    StringCollection collection = CommandLineController.GetArgsFromSettings();
                    Connection commandLineConnection = CommandLineController.ProcessStringCollection(collection);
                    UpdateData(commandLineConnection);
                    DisplayGroupBoxes();
                    ClickConnectButton();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Aruments: \n\n" + ex.Message, "Invalid Arguments", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Set the username when the user enters text.
        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            _connection.UserName = tbUsername.Text;
        }

        // Attempt to parse data the user enters into the port box.
        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            // When the user modifies the redirect port box, set the variable, change label to red if not a valid integer
            try
            {
                int port = int.Parse(tbPort.Text);
                _connection.RemotePort = port;
                LabelColorChanger(lPort, true);
            }
            catch (Exception)
            {
                LabelColorChanger(lPort, false);
            }
        }

        // Set the host variable when the text changes`
        private void tbHost_TextChanged(object sender, EventArgs e)
        {
            _connection.PUAServer = tbHost.Text;
        }

        // Handle the action when the user selects the VNC button
        private void rbVNC_CheckedChanged(object sender, EventArgs e)
        {
            tbPort.Enabled = true;
            if ((tbPort.Text == Connection.COMSOL_SERVER_PORT.ToString()) || tbPort.Text == "")
            {
                tbPort.Text = "" + Connection.VNC_DISPLAY_DEFAULT;
            }
        }

        // Handle the action when the user selects the COMSOL button
        private void rbCOMSOL_CheckedChanged(object sender, EventArgs e)
        {
            tbPort.Enabled = false;
            tbPort.Text = "" + Connection.COMSOL_SERVER_PORT.ToString();
        }

        // Open the about form when the user clicks a button
        private void buttonInfo_Click(object sender, EventArgs e)
        {
            if (_abtFrm.IsDisposed)
            {
                _abtFrm = new AboutFrm();
            }
            _abtFrm.Show();
            _abtFrm.BringToFront();
        }

        private void buttonAdvanced_Click(object sender, EventArgs e)
        {
            if (_advFrm.IsDisposed)
            {
                _advFrm = new AdvSettingsFrm();
            }
            _advFrm.Show();
            _advFrm.BringToFront();
        }

        private void SaveUserSettings()
        {
            _settings.RememberUser(cbRememberMe.Checked);

            if (cbRememberMe.Checked)
            {
                _settings.SaveUsername(tbUsername.Text);
                _settings.SavePassword(tbPassword.Text);
            }
            else
            {
                _settings.SaveUsername("");
                _settings.SavePassword("");
            }
        }

        // Sets or unsets the user settings when the user clicks the checkbox
        private void cbRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            SaveUserSettings();
        }

        internal void CheckRememberBox(bool check)
        {
            cbRememberMe.Checked = check;
        }

        
    }
}
