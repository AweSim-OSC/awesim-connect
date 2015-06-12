using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AweSimConnect.Views
{
    public partial class AboutFrm : Form
    {
        private string CLIENT_VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        Assembly assembly;
        StreamReader textStreamReader;
        static string RESOURCE_NAME = "AweSimConnect.LICENSE.txt";
        static string AWESIM_SITE = "http://apps.awesim.org/devapps";

        public AboutFrm()
        {
            InitializeComponent();
        }

        private void AboutFrm_Load(object sender, EventArgs e)
        {

            labelVersion.Text = "Version " + CLIENT_VERSION;
            linkAweSim.Text = AWESIM_SITE;

            // http://stackoverflow.com/questions/18108725/reading-an-embedded-text-file
            try
            {
                assembly = Assembly.GetExecutingAssembly();

                using (Stream stream = assembly.GetManifestResourceStream(RESOURCE_NAME))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string result = reader.ReadToEnd();
                        tbLicenseArea.Text = result;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error accessing license info.");
            }

        }

        private void linkAweSim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AWESIM_SITE);
        }
    }
}
