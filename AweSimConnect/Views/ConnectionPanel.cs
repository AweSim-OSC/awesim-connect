using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using AweSimConnect.Controllers;
using AweSimConnect.Models;
using AweSimConnect.Properties;

namespace AweSimConnect.Views
{
    public partial class ConnectionPanel : UserControl
    {
        private readonly Connection _connection;
        private readonly TunnelController _tc;
        private readonly VNCControllerTurbo _vnc;

        public Form Parent_Form { get; set; }

        private Process _launchedProcess;
        
        private int _ticks;
        private bool _tunnelAvailable;
        private readonly bool _isVnc;

        internal ConnectionPanel(Connection inputConnection, string userPass, Form parentForm)
        {
            InitializeComponent();
            Parent_Form = parentForm;
            _connection = inputConnection;
            var advSettings = new AdvancedSettings();
            _tc = new TunnelController(_connection, advSettings.IsWriteableUser());
            _tc.StartTunnelerProcess(userPass);
            _isVnc = !string.IsNullOrEmpty(_connection.VNCPassword);
            _vnc = new VNCControllerTurbo(_connection, advSettings.IsWriteableUser());
            labelVersion.Text = $"v{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
            timerConnectionPanel.Start();
        }

        private string SessionType()
        {
            return ((_isVnc) ? "VNC" : "Browser");
        }

        //Set the info box text.
        internal void SetUpConnection()
        {
            string formTitle = "";
            if (_isVnc)
            {
                tbConnectionInfo.Text = $"Attempting to connect to a VNC session at localhost:{_connection.LocalPort} using password {_connection.VNCPassword}.";
                formTitle += "VNC";
            }
            else
            {
                tbConnectionInfo.Text = $"Attempting to connect to a browser session at http://localhost:{_connection.LocalPort}.";
                formTitle += "BROWSER";
            }
            formTitle += " ";
            formTitle += String.Format("{0:T}", DateTime.Now);
            
            lSession.Text = _connection.GetServerAndPort();
            Parent_Form.Text = formTitle;
        }

        internal void buttonDisconnect_Click(object sender, EventArgs e)
        {
            KillEverything();
        }

        internal void KillProcess()
        {
            _tc.KillProcess();
            _vnc.KillProcess();
            _tunnelAvailable = false;
            if (_tc.IsTunnelerRunning())
            {
                _tc.KillProcess();
            }
        }

        internal void KillEverything()
        {
            KillProcess();
            Parent_Form?.Close();
        }

        private void ConnectToApp()
        {
            if (!_isVnc)
            {
                try
                {
                    _launchedProcess = WebTools.LaunchLocalhostBrowser(_connection.LocalPort);
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
                    //_vnc.StartVNCProcess();
                    _launchedProcess = _vnc.StartVNCProcess();
                }
            }
        }

        private void EnableConnectedFeatures(bool tunnelAvailable)
        {
            pbTunnel.Image = (tunnelAvailable) ? Resources.shield : Resources.cross_gry;
            toolTipConnectionPanel.SetToolTip(pbTunnel, (tunnelAvailable) ? "Secure Tunnel Detected" : "Secure Tunnel Disconnected");
        }

        private void CheckTunnel()
        {
            _tunnelAvailable = (_tc.IsTunnelerConnected() && _tc.IsTunnelerRunning());
        }
        
        internal bool EmbedProcess()
        {
            bool embedded = false;

            //If the tunnel is connected and the process hasn't been embedded, pull it into the app.
            if (_tunnelAvailable && !_tc.IsProcessEmbedded() && (_tc.GetThisProcess() != null))
            {
                _tc.EmbedProcess();

                // This is the only place these are used right now. Move them up or out if we need to.
                // int MAXIMIZE_WINDOW = 3;
                // int MINIMIZE_WINDOW = 6;
                // This command minimizes instead of hiding the window.
                //ShowWindow(_pc.GetThisProcess().MainWindowHandle, MINIMIZE_WINDOW);

                // This command will embed the putty process in the main window. 
                try
                {
                    User32.SetParent(_tc.GetThisProcess().MainWindowHandle, panelProcesses.Handle);
                }
                catch (Win32Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }

                embedded = true;
            }

            return embedded;
        }
        
        // The main process loop. Handles system checks and process management.
        // 1 tick = 100 ms.
        private void timerConnectionPanel_Tick(object sender, EventArgs e)
        {
            _ticks++;

            if (_ticks == 1)
            {
                SetUpConnection();
            }

            if (_ticks % 30 == 0)
            {
                // If the tunnel process hasn't been embedded into the app, run a check for the connection.
                if (!_tc.IsProcessEmbedded())
                {
                    CheckTunnel();

                    // If the tunnel is connected, enable the buttons, otherwise disable.
                    EnableConnectedFeatures(_tunnelAvailable);

                    // If the process is successfully embedded, run the associated app and hide the window.
                    if (EmbedProcess())
                    {
                        ConnectToApp();

                        Thread.Sleep(500);

                        Parent_Form.Hide();
                    }
                }
            }

            // Every 8 seconds,
            if ((_ticks % 80) == 0)
            {
                // If the user has closed the PuTTY window without logging in...
                if (!_tc.IsProcessRunning())
                {
                    KillEverything();
                }

                // Check to see if the user has closed the process we opened.
                // If they have, disconnect the tunnel.
                if (_tc.IsProcessEmbedded() && (_launchedProcess != null))
                {
                    if (_launchedProcess.HasExited && _isVnc)
                    {
                        KillEverything();
                    }
                }
            }

            // After 24 hours (36000 ticks/hour) kill the tunnel
            if ((_ticks % 864000) == 0)
            {
                KillEverything();
            }
        }
    }
}
