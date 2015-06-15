using System;
using Newtonsoft.Json;
using System.Windows.Forms;
using AweSimConnect.Models;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// This controller is used to manage clipboard actions and parsing. 
    /// All flags are optional
    /// JSON object tags are based on the Connection Model.
    /* 
       Example json:
     
        {
            'PUAServer': 'n0580.ten.osc.edu',
            'LocalPort': '5901',
            'RemotePort': '5901',
            'SSHHost': 'oakley.osc.edu',
            'UserName': 'bmcmichael',
            'VNCPassword': 'XXXXXXXX'
        }  
      
     * Minified option:
     
        {
            'H': 'n0580.ten.osc.edu',
            'R': '5901',                        
            'U': 'bmcmichael',
            'V': 'XXXXXXXX'
        } 
     
        For example, the web app can output the following string for this work:
            {'H':'n0580.ten.osc.edu','R':'5901','U':'bmcmichael','V':'XXXXXXXX'}
     * 
     */
    /// </summary>
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
                    string json = Clipboard.GetText().Trim();

                    // Attempt to parse the clipboard text.
                    try
                    {
                        Connection connection = JsonConvert.DeserializeObject<Connection>(json);
                        
                        // Set the local Connection object.
                        connectionData = connection;

                        // If we've made it this far, it's a valid json.
                        isValid = true;
                    }
                    catch (ArgumentException)
                    {
                        isValid = false;
                    }
                }
                catch (ArgumentException)
                {
                    isValid = false;
                }
                catch (Exception)
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
        public Connection GetClipboardConnection()
        {
            if (IsValid())
            {
                isValid = false;
                return connectionData;
            }
            else
                return new Connection();
        }
    }
}
