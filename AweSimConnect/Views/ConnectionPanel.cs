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
        private Connection connection;
        private PuTTYController pc;
        private VNCController vnc;

        private string userPass;

        public Form Parent_Form { get; set; }
        
        private int ticks = 0;
        private bool tunnel_available;
        private bool is_vnc;
        
        internal ConnectionPanel(Connection inputConnection, string userPass, Form parentForm)
        {
            InitializeComponent();
            Parent_Form = parentForm;
            connection = inputConnection;
            pc = new PuTTYController(connection);
            vnc = new VNCController(connection);
            pc.StartPlinkProcess(userPass);
            timerConnectionPanel.Start();
            is_vnc = !String.IsNullOrEmpty(connection.VNCPassword);
        }


        //Set the info box text.
        internal void SetUpConnection()
        {
            if (is_vnc)
            {
                tbConnectionInfo.Text = @"Using a VNC client, connect to localhost:" + connection.LocalPort +
                                       " and use password " + connection.VNCPassword + " or click the eye button.";
                tbTag.Text = "VNC";
                buttonConnection.BackgroundImage = Resources.eye_gray;
            }
            else
            {
                tbConnectionInfo.Text = @"Using a web browser, navigate to http://localhost:" + connection.LocalPort + " or click the button to the right to launch.";
                tbTag.Text = "COMSOL";
                buttonConnection.BackgroundImage = Resources.browser_sizes;
            }
            lSession.Text = connection.GetServerAndPort();
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
            pc.KillProcess();
            tunnel_available = false;
            if (pc.IsPlinkRunning())
            {
                pc.KillProcess();
            }
        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
            if (!is_vnc)
            {
                toolTipConnectionPanel.SetToolTip(buttonConnection, "Launch a browser connection to " + connection.GetServerAndPort());
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
                toolTipConnectionPanel.SetToolTip(buttonConnection, "Launch a VNC Connection to " + connection.GetServerAndPort());

                if (pc.IsPlinkConnected())
                {
                    vnc.StartVNCProcess();
                }
            }
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
            tunnel_available = (pc.IsPlinkConnected() && pc.IsPlinkRunning());
        }

        //TODO Move this block and associated dll calls into the panel. 

        internal void EmbedProcess()
        {
            //If the tunnel is connected and the process hasn't been embedded, pull it into the app.
            if (tunnel_available && !pc.IsProcessEmbedded())
            {
                pc.EmbedProcess();

                //TODO: This is the only place these are used right now. Move them up or out if we need to.
                //int MAXIMIZE_WINDOW = 3;
                int MINIMIZE_WINDOW = 6;

                // This command minimizes instead of hiding the window.
                //ShowWindow(pc.GetThisProcess().MainWindowHandle, MINIMIZE_WINDOW);

                //TODO This command will embed the putty process in the main window. 
                SetParent(pc.GetThisProcess().MainWindowHandle, panelProcesses.Handle);
            }
        }

        // Used for embedding process into the app
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr windowHandle, int command);

        // Used for embedding process into the app

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr windowChild, IntPtr windowParent);

        private void timerConnectionPanel_Tick(object sender, EventArgs e)
        {
            if (ticks == 1)
            {
                SetUpConnection();
            }

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

        private void SetTagText()
        {
            Parent_Form.Text = ((tbTag.Text != "") ? tbTag.Text+" " : "")
            +connection.GetServerAndPort();
        }

        private void tbTag_TextChanged(object sender, EventArgs e)
        {
            SetTagText();
        }

    }
}
