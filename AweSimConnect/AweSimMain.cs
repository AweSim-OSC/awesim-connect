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

        private void AweSimMain_Load(object sender, EventArgs e)
        {
            this.fileName = getFileName();
            label1.Text = this.fileName;

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
    }
}
