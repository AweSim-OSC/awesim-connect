using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using OSCConnect.Controllers;
using OSCConnect.Models;
using OSCConnect.Properties;

namespace OSCConnect.Views
{
   /*
    * AweSim Connect
    *
    * A windows native app for SSH tunneling to Ohio Supercomputer Center services.
    * 
    * Compile for .NET 2.0
    *
    * Brian McMichael: bmcmichael@osc.edu
    */
    public partial class ConnectMainForm : Form
    {
        // Configure the brand by editing OSCBrand.cs or creating a new class from the Brand interface and add it to the BrandFactory.
        private static Brand _brand = new BrandFactory(AppDomain.CurrentDomain.FriendlyName).getBrand();

        Connection _connection;
        
        // Displayed at the top of the form.
        private string CLIENT_TITLE = _brand.name() + " Connect v." + Application.ProductVersion;
        
        private static string BROWSER_ERROR = "No default browser discovered. Please navigate your web browser to: ";
        private static string LIMITED_CONNECTION_ERROR =
        "Unable to connect to " + _brand.name() + " servers.\n\nPlease check your connection or contact your system administrator to enable access.";
        private static string SFTP_NOT_DETECTED = "Supported SFTP client not detected";
        private static string CREDENTIALS_LABEL = "1. " + _brand.name() + " Credentials";
                
        private SFTPControllerWinSCP _ftpc;
        private ConsoleController _consolec;
        private ClipboardController _clipc;
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
        private GithubVersionChecker _githubVersion;
        private string _sshHost;
        
        public ConnectMainForm(string[] args)
        {
            InitializeComponent();
            
            this.Text = CLIENT_TITLE;
        }

        // Form Load
        private void AweSimMain2_Load(object sender, EventArgs e)
        {
            //GUI Setup
            this.CenterToParent();
            bConnect.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            this.AcceptButton = bConnect;
            this.Icon = _brand.icon();

            // Enable branding features
            bDashboard.BackgroundImage = _brand.dashboardButtonBackground();
            gbCredentials.Text = CREDENTIALS_LABEL;
            // The icon used in the top-left of the windows pane.
            pbLogo.BackgroundImage = _brand.logoImage();

            _processes = new List<ProcessData>();
            _connectionForms = new List<ConnectionForm>();
            _connection = new Connection();
            _settings = new AdvancedSettings();
            
            // If the app can't write out a folder to deploy helper apps,
            // it's because the user doesn't have admin access to write.
            _settings.SetWriteableUser(FileController.CreateFilesFolder());

            //Initialize controllers.
            _clipc = new ClipboardController();
            _clusterc = new OSCClusterController();
            _ftpc = new SFTPControllerWinSCP(_connection, _settings.IsWriteableUser());
            _abtFrm = new AboutFrm();
            _advFrm = new AdvSettingsFrm();
            
            _registry = new RegistryHook();
            
            _sshHost = _clusterc.GetCluster(_settings.GetSSHHostCode()).Domain;
            this._connection.SSHHost = _sshHost;

            // Check for connectivity to the servers
            LimitedConnectionPopup();

            // Tell the clipboard viewer to notify this app when the clipboard changes.
            try
            {
                _nextClipboardViewer = (IntPtr)User32.SetClipboardViewer((int)this.Handle);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            
            PopulateUserCredentials(_settings);
            DisplayGroupBoxes();
            DisplayNewVersionOptions(_settings.NewerVersionAvailable());

            if (!_settings.GetArgsChanged())
            {
                PopulateFromClipboard();
            }

            timerMain.Start();
            
        }

        // Fills in the username and password fields from the settings. 
        // Because of the listeners on the text field, we need to grab these values from 
        //  the settings before populating the fields. 
        private void PopulateUserCredentials(AdvancedSettings settings)
        {
            String username = settings.GetUsername();
            String password = settings.GetPassword();
            bool rememberme = settings.IsUserSaved();
            tbUsername.Text = username;
            tbPassword.Text = password;
            cbRememberMe.Checked = rememberme;
        }


        //////////////////////////// BUTTONS ////////////////////////////

        // Open a browser window to Awesim Dashboard when user clicks the logo.
        private void bDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                WebTools.LaunchBrowser(_brand.dashboardURI());
            }
            catch (Exception)
            {
                MessageBox.Show(BROWSER_ERROR + _brand.dashboardURI(), "Browser not found", MessageBoxButtons.OK);
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

                //Point newWindowPoint = BuildNewConnectionWindowCoordinates();
                //BuildConnectionForm(_connection, tbPassword.Text, newWindowPoint);
                BuildConnectionForm(_connection, tbPassword.Text);
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

        private void BuildConnectionForm(Connection connection, string password, Point startPoint)
        {
            Connection newConnection = ObjectCopier.Clone(connection);
            ConnectionForm connectionForm = new ConnectionForm(newConnection, password);
            connectionForm.StartPosition = FormStartPosition.Manual;
            connectionForm.Location = startPoint;
            connectionForm.Show(this);
            _connectionForms.Add(connectionForm);
        }

        private void BuildConnectionForm(Connection connection, string password)
        {
            Connection newConnection = ObjectCopier.Clone(connection);
            ConnectionForm connectionForm = new ConnectionForm(newConnection, password);
            connectionForm.StartPosition = FormStartPosition.CenterScreen;
            connectionForm.Show(this);
            _connectionForms.Add(connectionForm);
        }

        // Actions performed when the user clicks the Console button
        private void buttonConsole_Click(object sender, EventArgs e)
        {
            if (_networkAvailable && Validator.IsPresent(tbUsername) && Validator.IsPresent(tbPassword))
            {
                SaveUserSettings();

                _consolec = new ConsoleController(_connection, _settings.IsWriteableUser());
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
            LaunchSFTP();
        }

        private void LaunchSFTP()
        {
            if (_networkAvailable && Validator.IsPresent(tbUsername) && Validator.IsPresent(tbPassword))
            {
                string remote_path = "";
                if (_connection.IsSFTP())
                {
                    remote_path = _connection.SFTPPath;
                }
                SFTPControllerWinSCP winscp = new SFTPControllerWinSCP(_connection, remote_path, _settings.IsWriteableUser());
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
                if (!string.IsNullOrEmpty(newConnection.UserName))
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


                if (!string.IsNullOrEmpty(newConnection.PUAServer))
                {
                    tbHost.Text = newConnection.PUAServer;
                    _connection.PUAServer = newConnection.PUAServer;
                }
                else
                {
                    tbHost.Text = "";
                }

                if (!string.IsNullOrEmpty(newConnection.VNCPassword))
                {
                    rbVNC.Checked = true;
                    tbVNCPassword.Text = newConnection.VNCPassword;
                    _connection.VNCPassword = newConnection.VNCPassword;
                }
                else
                {
                    rbBROWSER.Checked = true;
                    tbVNCPassword.Text = "";
                    _connection.VNCPassword = null;
                }

                if (!string.IsNullOrEmpty(newConnection.SFTPPath))
                {
                    _connection.SFTPPath = newConnection.SFTPPath;
                }
                else
                {
                    _connection.SFTPPath = null;
                }

                if (tbUsername.Text == "")
                {
                    BringMainWindowToFront();
                    tbUsername.Focus();
                }
                else
                {
                    tbPassword.Focus();
                }
            }
        }

        // Actions performed when the user clicks the Connect button 
        private void ClickConnectButton()
        {
            if (_settings.LaunchTunnelAutomatically() && !string.IsNullOrEmpty(tbUsername.Text) &&
                    !string.IsNullOrEmpty(tbPassword.Text))
            {
                if (_connection.IsSFTP())
                {
                    bSFTP.PerformClick();
                }
                else if (bConnect.Enabled)
                {
                    bConnect.PerformClick();
                }
                
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

        // Changes the color of a label.
        private void LabelColorChanger(Label label, bool valid)
        {
            label.ForeColor = valid ? Color.Gray : Color.Red;
        }

        // Changes the color of a GroupBox object.
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
                bSFTP.Text = string.Empty;
            }
            else
            {
                toolTipNoDelay.SetToolTip(bSFTP, "No supported SFTP client detected.");
                bSFTP.BackgroundImage = null;
                bSFTP.Text = SFTP_NOT_DETECTED;
            }
        }

        // Uses calls to the system to bring the window to the front.
        private void BringMainWindowToFront()
        {
            int SW_RESTORE = 9; // https://msdn.microsoft.com/en-us/library/windows/desktop/ms633548(v=vs.85).aspx
            Process thisProcess = Process.GetCurrentProcess();
            IntPtr windowHandle = thisProcess.MainWindowHandle;
            User32.SetForegroundWindow(windowHandle);
            User32.ShowWindow(windowHandle, SW_RESTORE);
        }
        
        // Override of the WndProc in order to hook this app into the clipboard notification chain.
        protected override void WndProc(ref Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    PopulateFromClipboard();
                    try
                    {
                        User32.SendMessage(_nextClipboardViewer, m.Msg, m.WParam,
                            m.LParam);
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                    break;
                case WM_CHANGECBCHAIN:
                    if (m.WParam == _nextClipboardViewer)
                    {
                        _nextClipboardViewer = m.LParam;
                    }
                    else
                        try
                        {
                            User32.SendMessage(_nextClipboardViewer, m.Msg, m.WParam,
                                m.LParam);
                        }
                        catch (Win32Exception ex)
                        {
                            MessageBox.Show(ex.Message, ex.GetType().ToString());
                        }
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

        // Checks the settings for data from the command line.
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

        // Actions to perform when closing the app.
        private void AweSimMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_settings.DetectClipboard())
            {
                // Remove the app from the clipboard view chain
                try
                {
                    User32.ChangeClipboardChain(Handle, _nextClipboardViewer);
                }
                catch (Win32Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
                
            }
            
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
            FileController.DeleteFilesFolder();
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

                    if (rbVNC.Checked || rbBROWSER.Checked)
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
                        else if (rbBROWSER.Checked)
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

        // Checks for network connectivity.
        private void NetworkConnected(bool isNetworkConnected)
        {
            if (isNetworkConnected)
            {
                CheckSSHConnection(_networkChanged);
                pbIsNetworkConnected.Image = Resources.wifi;
                toolTipNoDelay.SetToolTip(pbIsNetworkConnected, "Network Available\nConnected to " + _sshHost);
                lConnectionStatus.Text = _sshHost + " available";
            }
            else
            {
                pbIsNetworkConnected.Image = Resources.cross_gry;
                toolTipNoDelay.SetToolTip(pbIsNetworkConnected, LIMITED_CONNECTION_ERROR + "\n" + _sshHost);
                lConnectionStatus.Text = _sshHost + " unavailable";
            }
        }

        // Makes an ssh connection check if the network status is changed.
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

            if (_secondsElapsed == 10)
            {
                checkForNewVersion();
            } 

            // Check for network connectivity every 15 seconds.
            // Disable the connection button if can not connect to OSC.
            if (_secondsElapsed % 15 == 0)
            {
                bool availableBeforeCheck = _networkAvailable;
                _networkChanged = (availableBeforeCheck != _networkAvailable);
                EnableTunnelOptions(_networkAvailable && _sshAvailable);
            }

            if (_secondsElapsed % 30 == 0)
            {
                _networkAvailable = NetworkTools.CanTelnetToHost(_clusterc.GetCluster(_settings.GetSSHHostCode()).Domain);
            }

            if (_secondsElapsed % 2 == 0)
            {
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

        private void checkForNewVersion()
        {
            if (_settings.AutoCheckNewVersion())
            {
                // If we already know there is a newer version out there we don't need to check again.
                if (!_settings.NewerVersionAvailable())
                {
                    _githubVersion = new GithubVersionChecker();
                    _settings.SetNewerVersionAvailable(_githubVersion.IsNewerVersionAvailable());
                }

                DisplayNewVersionOptions(_settings.NewerVersionAvailable());
            }
        }

        private void DisplayNewVersionOptions(bool newerAvailable)
        {
            linkLabelNewVersion.Visible = newerAvailable;
        }

        //This method deploys the helper apps to the helper apps folder. The objects will get garbage collected.
        private void deployHelperApps()
        {
            new SFTPControllerWinSCP(_connection, _settings.IsWriteableUser());
            new ConsoleController(_connection, _settings.IsWriteableUser());
            new TunnelController(_connection, _settings.IsWriteableUser());
            new VNCControllerTurbo(_connection, _settings.IsWriteableUser());
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
        }

        // Handle the action when the user selects the BROWSER button
        private void rbBROWSER_CheckedChanged(object sender, EventArgs e)
        {
            //tbPort.Enabled = false;
            //tbPort.Text = "" + Connection.COMSOL_SERVER_PORT.ToString();
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

        // Save the user password on change if the "remember me" box is checked.
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            SaveUserSettings();         
        }

        internal void CheckRememberBox(bool check)
        {
            cbRememberMe.Checked = check;
        }

        private void linkLabelNewVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_githubVersion == null)
            {
                _githubVersion = new GithubVersionChecker();
            }
            WebTools.LaunchBrowser(_githubVersion.getLatestBinaryPath(_brand.brandString()));
        }

        
    }
}
