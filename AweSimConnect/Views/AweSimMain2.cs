using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
        public AweSimMain2()
        {
            InitializeComponent();
        }
    }
}
