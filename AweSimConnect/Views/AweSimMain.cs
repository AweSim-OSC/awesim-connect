using AweSimConnect.Controllers;
using AweSimConnect.Models;
using AweSimConnect.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace AweSimConnect
{
    /* TODO Wishlist
     *  
     * -Add About form (for meeting license requirements)
     * -Hide putty window(s) inside the app
     * -Detect Filezilla installation
     * -Detect TurboVNC installation
     * -Verify json
     * -Make sure all network stuff runs async
     * -Disable connect button if already connected on a port.
     * -Put process data in it's own model
     * -SFTP handling
     * -Antialiased Font
     * -URI Parsing
     * -Manage multiple tunnels
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
        //AweSim Dashboard URL
        static String AWESIM_DASHBOARD_URL = "http://apps.awesim.org/devapps/";
        static long START_TIME = DateTime.Now.Ticks;

        private PuTTYController pc;
        private VNCController vc;
        private ClipboardController cbc;
        private ClusterController clc;
        Connection connection;

        private List<ProcessData> processes;

        private bool network_available = false;
        private bool tunnel_available = false;

        private int secondsElapsed = 0;

        public AweSimMain()
        {
            InitializeComponent();
        }

        // On application load
        private void AweSimMain_Load(object sender, EventArgs e)
        {
            //GUI setup
            this.CenterToParent();
            this.AcceptButton = bConnect;
            labelWeb.Text = "";

            //Initialize controllers.
            cbc = new ClipboardController();
            clc = new ClusterController();
            pc = new PuTTYController(connection);
            vc = new VNCController(connection);

            processes = new List<ProcessData>();
            connection = new Connection();
            timerConnection.Start();

            // Adds the Clusters to the Combobox
            setupClusterBox();

            // Check for connectivity to the servers
            LimitedConnectionPopup();

            //Check to see if there is any valid data on the clipboard.
            if (cbc.CheckClipboardForAweSim())
            {
                Connection clipData = cbc.GetClipboardCluster();
                UpdateData(clipData);
            }

        }

        // Throws up a popup window if the app isn't able to connect to the selected SSH host.
        private void LimitedConnectionPopup()
        {
            if (!NetworkTools.CanTelnetToOakley())
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

                if (newConnection.LocalPort != 0)
                    tbLocalPort.Text = newConnection.LocalPort.ToString();
                else
                    tbLocalPort.Text = "";
                this.connection.LocalPort = newConnection.LocalPort;


                if (newConnection.RemotePort != 0)
                    tbRemotePort.Text = newConnection.RemotePort.ToString();
                else
                    tbRemotePort.Text = "";
                this.connection.RemotePort = newConnection.RemotePort;

                if (!String.IsNullOrEmpty(newConnection.PUAServer))
                {
                    tbHost.Text = newConnection.PUAServer;
                    this.connection.UserName = newConnection.PUAServer;
                }

                //Oakley for now.
                // TODO enable all clusters
                setCluster();

                if (!String.IsNullOrEmpty(newConnection.VNCPassword))
                {
                    tbVNCPassword.Text = newConnection.VNCPassword;
                    this.connection.VNCPassword = newConnection.VNCPassword;
                }
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
                vc = new VNCController(connection);
                vc.StartVNCProcess();
            }
        }

        // Checks the password field and marks the label red if the password is invalid.
        private void tbVNCPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connection.VNCPassword = tbVNCPassword.Text;
                LabelColorChanger(labelVNCPassword, true);
            }
            catch (Exception)
            {
                LabelColorChanger(labelVNCPassword, false);
            }
        }

        //Changes the color of a label
        private void LabelColorChanger(Label label, bool valid)
        {
            label.ForeColor = valid ? Color.Black : Color.Red;
        }

        // This is the main timer loop for the app.
        // Handle timed events like connection checking.
        private void timerConnection_Tick(object sender, EventArgs e)
        {
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

            secondsElapsed++;
        }

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
            EnableSFTPButton(enable);
        }

        // Use this to enable/disable sftp button
        private void EnableSFTPButton(bool enable)
        {
            bSFTP.Enabled = enable;
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

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr windowChild, IntPtr windowParent);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr windowHandle, int command);

        //Kill the process when closing the window.
        private void AweSimMain_FormClosing(object sender, FormClosingEventArgs e)
        {
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
    }
}
