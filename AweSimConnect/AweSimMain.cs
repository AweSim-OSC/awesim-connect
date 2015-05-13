using AweSimConnect.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            setupClusters();
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

        // Set up app with clusters
        private void setupClusters()
        {
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

        //If the filename includes "OAK", "RBY", or "OPT", set the combobox, else select oakley.
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

        private void tbHost_TextChanged(object sender, EventArgs e)
        {
            this.hostName = tbHost.Text;
        }

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


    }
}
