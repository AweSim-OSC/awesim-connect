using AweSimConnect.Controllers;
using AweSimConnect.Models;
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
        
        String hostName;
        int redirectPort;
        
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

            pc.InstallPlink();

            //This is here in case the user wants to modify the file name to edit settings. Depricated.
            this.fileName = getFileName();
            setupClusterBox();
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

        // If the filename includes "OAK", "RBY", or "OPT", set the combobox, else select oakley.
        private void setCluster()
        {
            foreach (Cluster cluster in clc.GetClusterList())
            {
                if (this.fileName.Contains(cluster.Code))
                {
                    clc.SetCluster(cluster);
                    cbCluster.SelectedIndex = cbCluster.FindStringExact(cluster.Name);
                    break;
                }
                else
                {
                    cbCluster.SelectedIndex = 0;
                }
            }
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
            //TODO: More robust validation for passwords.
            pc.startPuttyProcess(tbPassword.Text);
        }

        //Use this to see if a particluar file is available on the path
        public static bool ExistsOnPath(String filename)
        {
            if (GetFullPath(filename) != null)
            {
                return true;
            }
            return false;
        }

        //Use this to get the full path of a file
        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
            {
                return Path.GetFullPath(fileName);
            }

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(';'))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }
            return null;
        }

        //Set the username when the user enters text.
        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            pc.UserName = tbUserName.Text;
        }

        //Set the cluster when the user changes the box.
        private void cbCluster_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setCluster();
        }

        // Open a browser window to Awesim Dashboard when user clicks the logo.
        private void pbAweSimLogo_Click(object sender, EventArgs e)
        {
            Process.Start(AWESIM_DASHBOARD_URL);
        }
    }
}
