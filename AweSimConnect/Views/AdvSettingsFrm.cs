using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AweSimConnect.Views
{
    public partial class AdvSettingsFrm : Form
    {
        private string CLIENT_VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public AdvSettingsFrm()
        {
            InitializeComponent();
        }

        private void AdvSettingsFrm_Load(object sender, EventArgs e)
        {
            labelVersion.Text = CLIENT_VERSION;
        }
    }
}
