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

        //This is here in case we use the file name for settings.
        private String fileName;
        private int secondsElapsed = 0;

        Connection connection;

        public AweSimMain()
        {
            InitializeComponent();
        }

        // On application load
        private void AweSimMain_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.AcceptButton = bConnect;

            //Initialize controllers.
            cbc = new ClipboardController();
            clc = new ClusterController();
            pc = new PuTTYController(connection);
            vc = new VNCController(connection);

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
            tbUserName.Text = newConnection.UserName;
            this.connection.UserName = newConnection.UserName;
            if (newConnection.LocalPort != 0)
                tbLocalPort.Text = newConnection.LocalPort.ToString();
            else
                tbLocalPort.Text = "";
            this.connection.LocalPort = newConnection.LocalPort;
            tbHost.Text = newConnection.PUAServer;
            this.connection.UserName = newConnection.PUAServer;
            //Oakley for now.
            // TODO enable all clusters
            setCluster();
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                LabelColorChanger(labelVNCPassword, false);
            }
        }

        //Changes the color of a label
        private void LabelColorChanger(Label label, bool valid)
        {
            label.ForeColor = valid ? Color.Black : Color.Red;
        }

        private void timerConnection_Tick(object sender, EventArgs e)
        {
            // Check for network connectivity every 15 seconds.
            // Disable the connection button if can not connect to OSC.
            if (secondsElapsed % 15 == 0)
                EnableTunnelOptions(NetworkTools.CanTelnetToOakley());
                        
            // Check for tunnel connectivity every 3 seconds.
            // Disable the additional connection options if can't connect through the tunnel.
            if (secondsElapsed % 3 == 0)
                EnableAdditionalOptions(NetworkTools.IsPortOpenOnLocalHost(connection.LocalPort));



            secondsElapsed++;
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

        private void EnableTunnelOptions(bool enable)
        {
            bConnect.Enabled = enable;
        }
        
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
            catch (Exception ex)
            {
                LabelColorChanger(lRemotePort, false);
            }
        }
    }
}
