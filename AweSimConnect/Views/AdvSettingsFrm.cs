using System;
using System.Windows.Forms;
using AweSimConnect.Models;

namespace AweSimConnect.Views
{
    public partial class AdvSettingsFrm : Form
    {
        //TODO Come up with more advanced settings.

        private string CLIENT_VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        private AdvancedSettings _settings;

        public AdvSettingsFrm()
        {
            InitializeComponent();
            _settings = new AdvancedSettings();
        }

        private void AdvSettingsFrm_Load(object sender, EventArgs e)
        {
            labelVersion.Text = CLIENT_VERSION;
        }
    }
}
