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

        private PuTTYController pc;
        private VncController vc;
        private ClipboardController cbc;
        private ClusterController clc;

        //This is here in case we use the file name for settings.
        private String fileName;

        String userName;        
        String hostName;
        int redirectPort;
        Cluster cluster;
        
        public AweSimMain()
        {
            InitializeComponent();
        }

        // On application load
        private void AweSimMain_Load(object sender, EventArgs e)
        {
            //Initialize controllers.
            pc = new PuTTYController();
            vc = new VncController();
            cbc = new ClipboardController();
            clc = new ClusterController();

            // Installs the plink app if it isn't already there.
            pc.InstallPlink();

            // Adds the Clusters to the Combobox
            setupClusterBox();

            label1.Text = cbc.CheckClipboardForAweSim().ToString();

            if (cbc.CheckClipboardForAweSim())
            {
                Connection clipData = cbc.GetClipboardCluster();
                UpdateData(clipData);
            }                       
            
        }

        private void UpdateData(Connection connection)
        {
            tbUserName.Text = connection.UserName;
            this.userName = connection.UserName;
            tbRedirect.Text = connection.RedirectPort.ToString();
            this.redirectPort = connection.RedirectPort;
            tbHost.Text = connection.PUAServer;
            this.hostName = connection.PUAServer;
            //Oakley for now.
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

        // Select the first one on the list. Oakley now.
        private void setCluster()
        {
            cbCluster.SelectedIndex = 0;            
        }
        
        // When the user modifies the host box, the variable gets set
        private void tbHost_TextChanged(object sender, EventArgs e)
        {
            this.hostName = tbHost.Text;
        }
        
        // When the user modifies the redirect port box, set the variable, change label to red if not a valid integer
        private void tbRedirect_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.redirectPort = int.Parse(tbRedirect.Text);
                lRedirect.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                lRedirect.ForeColor = Color.Red;
            }
        }

        //Handles the connect button action.
        private void bConnect_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(tbUserName) && Validator.IsPresent(tbHost) && Validator.IsInt32(tbRedirect) && Validator.IsPresent(cbCluster) && Validator.IsPresent(tbPassword))
            {
                pc.UserName = this.userName;
                pc.SshHost = this.cluster.Domain;
                pc.RedirectPort = this.redirectPort;            
                pc.HostName = this.hostName;
                pc.StartPlinkProcess(tbPassword.Text);
            }                        
        }

        //Set the username when the user enters text.
        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            this.userName = tbUserName.Text;
        }

        //Set the cluster when the user changes the box.
        private void cbCluster_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cluster = clc.GetClusterList()[cbCluster.SelectedIndex];
        }

        // Open a browser window to Awesim Dashboard when user clicks the logo.
        private void pbAweSimLogo_Click(object sender, EventArgs e)
        {
            Process.Start(AWESIM_DASHBOARD_URL);
        }
    }
}
