using OSCConnect.Controllers;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace OSCConnect.Views
{
    public partial class AboutFrm : Form
    {
        private string CLIENT_VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        Assembly assembly;
        static string RESOURCE_NAME = "OSCConnect.LICENSE.txt";
        static string AWESIM_SITE = "http://www.osc.edu";

        public AboutFrm()
        {
            InitializeComponent();
        }

        private void AboutFrm_Load(object sender, EventArgs e)
        {

            labelAboutTitle.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
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
            WebTools.LaunchBrowser(AWESIM_SITE);
        }
    }
}
