using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AweSimConnect.Controllers;
using AweSimConnect.Models;

namespace AweSimConnect.Views
{
    /* 
    * TODO Wishlist
    *  
    * -Fix for vis nodes 
    * -Allow user to save password. (External prefs file, encode in base64?)
    * -Save external file locations in prefs to speed up startup.
    * -Hide putty window(s) inside the app (figure out with authentication detection)
    * -Allow disconnecting based on port
    * -Detect TurboVNC installation
    * -Make sure all network stuff runs async
    * -Disable connect button if already connected on a port.
    * -Antialiased Font
    * -URI Parsing
    * -Manage multiple tunnels
    * -See if we can tweak ggivnc encoding settings for better performance
    * -Move magic strings to resources
    * 
    * /

   /*
    * AweSim Connect
    *  
    * A windows native app for SSH tunneling to Ohio Supercomputer Center services.
    * 
    * Brian McMichael: bmcmichael@osc.edu
    */
    public partial class AweSimMain2 : Form
    {
        // The version number. The first and second numbers are set in the assembly info. 
        // The third number is the number of days since the year 2000
        // The fourth number is the number of seconds since midnight divided by 2.
        static readonly String ClientVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        static readonly String ClientTitle = "AweSim Connect v." + ClientVersion;
        static String AWESIM_DASHBOARD_URL = "http://apps.awesim.org/devapps/";
        static long START_TIME = DateTime.Now.Ticks;
        
        Connection connection;

        private List<ProcessData> processes;

        private bool network_available = false;
        private bool tunnel_available = false;

        private int secondsElapsed = 0;

        IntPtr nextClipboardViewer;
        private bool sftp_available;
        private AboutFrm abtFrm;
        
        public AweSimMain2()
        {
            
            InitializeComponent();
            this.Text = ClientTitle;
            
        }

        

        private void AweSimMain2_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.AcceptButton = bConnect;
        }
        
        private void bDashboard_Click(object sender, EventArgs e)
        {

        }
    }
}
