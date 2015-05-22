using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using AweSimConnect.Models;

namespace AweSimConnect.Controllers
{
    //TODO Reference JSON.NET in about. MIT license.  http://www.newtonsoft.com/json

    /*
     * This controller is used to manage clipboard actions and parsing. 
     * 
       Example json:
     
        { 
            'PUAServer': 'n0580.ten.osc.edu:5901',
            'RedirectPort': '5901',
            'SSHHost': 'oakley.osc.edu',
            'UserName': 'bmcmichael',
            'VNCPassword: 'XXXXXXXX'
        }
     
     */
    class ClipboardController
    {
        Connection connectionData;
        bool isValid;

        //Checks the clipboard for valid data and returns true if found.
        public bool CheckClipboardForAweSim()
        {

            if (Clipboard.ContainsText())
            {
                try
                {
                    // Get the text from the clipboard.
                    String json = Clipboard.GetText();

                    // Attempt to parse the clipboard text.
                    Connection connection = JsonConvert.DeserializeObject<Connection>(json);

                    // Set the local Connection object.
                    connectionData = connection;

                    // If we've made it this far, it's a valid json.
                    isValid = true;

                }
                catch (Exception ex)
                {
                    // If we get an error, it's not a valid json string.
                    isValid = false;
                }
            }
            else
            {
                //No text on clipboard.
                isValid = false;
            }

            return isValid;
        }

        // App has valid data from the clipboard ready for use.
        public bool IsValid()
        {
            return isValid;
        }

        // If the app has connection data in the clipboard, mark as invalid so we 
        // don't keep returning the same data, then return what we've got.
        public Connection GetClipboardCluster()
        {
            if (IsValid())
            {
                isValid = false;
                return connectionData;
            }
            else
                return null;
        }
    }
}
