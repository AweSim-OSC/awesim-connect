using AweSimConnect.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AweSimConnect
{
    public partial class AweSimMain : Form
    {
        private String fileName;
        String hostName;
        int redirectPort;

        Cluster oakley = new Cluster("OAK", "Oakley", "oakley.osc.edu");
        Cluster ruby = new Cluster("RBY", "Ruby", "ruby.osc.edu");
        Cluster glenn = new Cluster("OPT", "Glenn", "glenn.osc.edu");
       

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
            cbCluster.SelectedIndex = 0;
        }     
    }
}
