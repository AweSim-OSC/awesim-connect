using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AweSimConnect.Controllers;
using AweSimConnect.Models;
using AweSimConnect.Properties;

namespace AweSimConnect.Views
{
    public partial class ConnectionPanel : UserControl
    {
        private Connection connection;
        private PuTTYController pc;
        private VNCController vnc;

        private ProcessData processData;
        private string userPass;

        private Stopwatch stopwatch;

        private int ticks = 0;
        private bool tunnel_available;
        private bool is_vnc;
        
        internal ConnectionPanel(Connection inputConnection, string userPass)
        {
            InitializeComponent();
            connection = inputConnection;
            pc = new PuTTYController(connection);
            vnc = new VNCController(connection);
            pc.StartPlinkProcess(userPass);
            timerConnectionPanel.Start();
        }

        internal void buttonDisconnect_Click(object sender, EventArgs e)
        {
            pc.KillProcess();
            timerConnectionPanel.Stop();
            tunnel_available = false;
            GetProcessData();
            if (processData.IsRunning())
            {
                processData.Process.Kill();
            }
        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(connection.VNCPassword))
            {
                labelSession.Text = "Browser";
                toolTipConnectionPanel.SetToolTip(buttonConnection, "Connect to" + connection.GetServerAndPort());
                try
                {
                    WebTools.LaunchLocalhostBrowser(connection.LocalPort);
                }
                catch (Exception)
                {
                    //TODO pop up a message or find a better way to open a browser.
                }
            }
            else
            {
                labelSession.Text = "VNC";
                toolTipConnectionPanel.SetToolTip(buttonConnection, "VNC Connection to " + connection.GetServerAndPort());

                if (pc.IsPlinkConnected())
                {
                    vnc.StartVNCProcess();
                }
            }
        }

        private void timerConnectionPanel_Tick(object sender, EventArgs e)
        {
            if ((ticks == 15) && tunnel_available)
            {
                buttonConnection_Click(sender, e);
            }

            if ((ticks % 30 == 0) || (ticks == 3))
            {
                CheckTunnel();
                EmbedProcess();
                
                //If the tunnel is connected, enable the buttons, otherwise disable.
                EnableConnectedFeatures(tunnel_available);
            }

            ticks++;
        }

        private void EnableConnectedFeatures(bool tunnel_available)
        {
            pbTunnel.Image = (tunnel_available) ? Resources.shield : Resources.cross_gry;
            toolTipConnectionPanel.SetToolTip(pbTunnel, (tunnel_available) ? "Secure Tunnel Detected" : "Secure Tunnel Disconnected");
            buttonConnection.Enabled = tunnel_available;
        }

        private void CheckTunnel()
        {

            //TODO Fix this. Keeps returning true after plink is closed.
            tunnel_available = pc.IsPlinkConnected();
        }

        internal ProcessData GetProcessData()
        {
            SetProcessData();
            return processData;
        }

        internal void SetProcessData()
        {
            processData = new ProcessData(pc.GetThisProcess(), connection);
        }

        //TODO Move this block and associated dll calls into the panel. 

        internal void EmbedProcess()
        {
            //If the tunnel is connected and the process hasn't been embedded, pull it into the app.
            if (tunnel_available && !pc.IsProcessEmbedded())
            {
                SetProcessData();
                pc.EmbedProcess();

                //TODO: This is the only place these are used right now. Move them up or out if we need to.
                //int MAXIMIZE_WINDOW = 3;
                int MINIMIZE_WINDOW = 6;

                // This command minimizes instead of hiding the window.
                ShowWindow(pc.GetThisProcess().MainWindowHandle, MINIMIZE_WINDOW);

                //TODO This command will embed the putty process in the main window. 
                //SetParent(pc.GetThisProcess().MainWindowHandle, panelProcesses.Handle);
            }
        }

        // Used for embedding process into the app
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr windowHandle, int command);

        // Used for embedding process into the app

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr windowChild, IntPtr windowParent);
    }
}
