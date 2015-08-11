using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AweSimConnect.Controllers;
using AweSimConnect.Models;
using AweSimConnect.Properties;

namespace AweSimConnect.Views
{
    public partial class ConnectionPanel : UserControl
    {
        private readonly Connection _connection;
        private readonly TunnelController _pc;
        private readonly AdvancedSettings _advSettings;
        private readonly VNCControllerTurbo _vnc;

        public Form Parent_Form { get; set; }
        
        private int _ticks = 0;
        private bool _tunnelAvailable;
        private readonly bool _isVnc;

        internal ConnectionPanel(Connection inputConnection, string userPass, Form parentForm)
        {
            InitializeComponent();
            Parent_Form = parentForm;
            _connection = inputConnection;
            _pc = new TunnelController(_connection);
            _advSettings = new AdvancedSettings();
            _pc.StartTunnelerProcess(userPass);
            _isVnc = !string.IsNullOrEmpty(_connection.VNCPassword);
            toolTipConnectionPanel.SetToolTip(buttonConnection, "Launch a " + SessionType() + " connection to " + _connection.GetServerAndPort());
                
            //_vnc = new VNCControllerGGI(_connection);
            _vnc = new VNCControllerTurbo(_connection);
            labelVersion.Text = "v"+ System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            timerConnectionPanel.Start();
        }

        private string SessionType()
        {
            return ((_isVnc) ? "VNC" : "Browser");
        }

        //Set the info box text.
        internal void SetUpConnection()
        {
            if (_isVnc)
            {
                tbConnectionInfo.Text = @"Using a VNC client, connect to localhost:" + _connection.LocalPort +
                                       " and use password " + _connection.VNCPassword + " or click the eye button.";
                tbTag.Text = "VNC";
                buttonConnection.BackgroundImage = Resources.eye_gray;
            }
            else
            {
                tbConnectionInfo.Text = @"Using a web browser, navigate to http://localhost:" + _connection.LocalPort + " or click the button to the right to launch.";
                tbTag.Text = "COMSOL";
                buttonConnection.BackgroundImage = Resources.browser_sizes;
            }
            tbTag.Text += " ";
            tbTag.Text += String.Format("{0:T}", DateTime.Now);
            
            lSession.Text = _connection.GetServerAndPort();
            SetTagText();
        }

        internal void buttonDisconnect_Click(object sender, EventArgs e)
        {
            KillProcess();
            if (Parent_Form != null)
            {
                Parent_Form.Close();
            }
        }

        internal void KillProcess()
        {
            _pc.KillProcess();
            _vnc.KillProcess();
            _tunnelAvailable = false;
            if (_pc.IsTunnelerRunning())
            {
                _pc.KillProcess();
            }
        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
            if (!_isVnc)
            {
                try
                {
                    WebTools.LaunchLocalhostBrowser(_connection.LocalPort);
                }
                catch (Exception)
                {
                    // Pop up a message or find a better way to open a browser.
                }
            }
            else
            {
                if (_tunnelAvailable)
                {
                    _vnc.StartVNCProcess();
                }
            }
        }

        private void EnableConnectedFeatures(bool tunnelAvailable)
        {
            pbTunnel.Image = (tunnelAvailable) ? Resources.shield : Resources.cross_gry;
            toolTipConnectionPanel.SetToolTip(pbTunnel, (tunnelAvailable) ? "Secure Tunnel Detected" : "Secure Tunnel Disconnected");
            buttonConnection.Enabled = tunnelAvailable;
        }

        private void CheckTunnel()
        {
            _tunnelAvailable = (_pc.IsTunnelerConnected() && _pc.IsTunnelerRunning());
        }
        
        internal void EmbedProcess()
        {
            //If the tunnel is connected and the process hasn't been embedded, pull it into the app.
            if (_tunnelAvailable && !_pc.IsProcessEmbedded() && (_pc.GetThisProcess() != null))
            {
                _pc.EmbedProcess();
                
                // This is the only place these are used right now. Move them up or out if we need to.
                // int MAXIMIZE_WINDOW = 3;
                // int MINIMIZE_WINDOW = 6;
                // This command minimizes instead of hiding the window.
                //ShowWindow(_pc.GetThisProcess().MainWindowHandle, MINIMIZE_WINDOW);

                // This command will embed the putty process in the main window. 
                User32.SetParent(_pc.GetThisProcess().MainWindowHandle, panelProcesses.Handle);
            }
        }
        
        private void timerConnectionPanel_Tick(object sender, EventArgs e)
        {
            _ticks++;

            if (_ticks == 1)
            {
                SetUpConnection();
            }

            if ((_ticks == 15) && _tunnelAvailable)
            {
                if (_advSettings.AutoOpenApp())
                {
                    buttonConnection_Click(sender, e);
                }
            }

            if ((_ticks % 25 == 0))
            {
                CheckTunnel();
                EmbedProcess();

                //If the tunnel is connected, enable the buttons, otherwise disable.
                EnableConnectedFeatures(_tunnelAvailable);
            }
        }

        private void SetTagText()
        {
            Parent_Form.Text = ((tbTag.Text != "") ? tbTag.Text+" " : "")
            +_connection.GetServerAndPort();
        }

        private void tbTag_TextChanged(object sender, EventArgs e)
        {
            SetTagText();
        }

    }
}
