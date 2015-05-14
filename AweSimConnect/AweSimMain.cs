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
    public partial class AweSimMain : Form
    {
        private String fileName;
        String hostName;
        int redirectPort;

        static Cluster oakley = new Cluster("OAK", "Oakley", "oakley.osc.edu");
        static Cluster ruby = new Cluster("RBY", "Ruby", "ruby.osc.edu");
        static Cluster glenn = new Cluster("OPT", "Glenn", "glenn.osc.edu");

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
            cbCluster.Items.Add(oakley);
            cbCluster.Items.Add(ruby);
            cbCluster.Items.Add(glenn);
            //cbCluster.SelectedIndex = 0;
            setCluster();
        }

        // If the filename includes "OAK", "RBY", or "OPT", set the combobox, else select oakley.
        private void setCluster()
        {
            if (this.fileName.Contains(oakley.Code)) {
                cbCluster.SelectedIndex = cbCluster.FindStringExact(oakley.Name);
            }
            else if (this.fileName.Contains(ruby.Code))
            {
                cbCluster.SelectedIndex = cbCluster.FindStringExact(ruby.Name);
            }
            else if (this.fileName.Contains(glenn.Code))
            {
                cbCluster.SelectedIndex = cbCluster.FindStringExact(glenn.Name);
            }
            else
            {
                cbCluster.SelectedIndex = cbCluster.FindStringExact(oakley.Name);
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

        private bool isPuttyInstalled()
        {
            return (GetFullPath("putty.exe") != null);
        }

        private object GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(';'))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }

        // Launch PuTTY
        private void startPuttyProcess()
        {
            //TODO fix this to get the user's directory
            //TODO fix this to get the slected ssh server
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
    }
}
