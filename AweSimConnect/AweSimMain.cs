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
        String fileName;

        public AweSimMain()
        {
            InitializeComponent();
        }

        // On application load
        private void AweSimMain_Load(object sender, EventArgs e)
        {
            this.fileName = getFileName();
            label1.Text = "Debug: " + this.fileName;
            setClusterBox();
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
        private void setClusterBox()
        {
            cbCluster.Items.Add("Oakley");
            cbCluster.SelectedIndex = 0;
        }


                
    }
}
