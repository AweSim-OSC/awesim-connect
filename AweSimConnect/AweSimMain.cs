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
        private String fileName;
        String hostName;
        int redirectPort;
        ClusterController cc = new ClusterController();
        
        public AweSimMain()
        {
            InitializeComponent();
        }

        // On application load
        private void AweSimMain_Load(object sender, EventArgs e)
        {
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
            foreach (Cluster cluster in cc.GetClusterList())
            {
                cbCluster.Items.Add(cluster);
            }
            setCluster();
        }

        // If the filename includes "OAK", "RBY", or "OPT", set the combobox, else select oakley.
        private void setCluster()
        {
            foreach (Cluster cluster in cc.GetClusterList())
            {
                if (this.fileName.Contains(cluster.Code))
                {
                    cc.SetCluster(cluster);
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
               

        // Launch PuTTY
        private void startPuttyProcess()
        {
            //TODO fix this to get the user's directory
            //TODO fix this to get the slected ssh server
            //TODO move putty stuff to a separate class
            String puttyCommand = String.Format(@"C:\Program Files (x86)\PuTTY\putty.exe"); // -ssh -L {0}:{1} -C -N -T {2}@{3} -l {4} -pw {5}", this.redirectPort, this.hostName, tbUserName.Text, "oakley.osc.edu", tbUserName.Text, tbPassword.Text);
            ProcessStartInfo info = new ProcessStartInfo(puttyCommand);
            info.Arguments = String.Format("-ssh -L {0}:{1} -C -N -T {2}@{3} -l {4} -pw {5}", this.redirectPort, this.hostName, tbUserName.Text, "oakley.osc.edu", tbUserName.Text, tbPassword.Text);
            info.UseShellExecute = false;
            info.WindowStyle = ProcessWindowStyle.Minimized;

            try
            {
                Process.Start(info);
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            startPuttyProcess();
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
    }
}
