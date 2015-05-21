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
        'PUAServer': 'n0024.ten.osc.edu:5901',
        'RedirectPort': '8080',
        'SSHHost': 'oakley.osc.edu',
        'UserName': 'an0018'
        }
     
     */
    class ClipboardController
    {
        Connection connectionData;        
        
        //Checks the clipboard for valid data and returns true if found.
        public bool CheckClipboardForAweSim() {

            bool isValid;
            
            if (Clipboard.ContainsText()) {
                try {
                    // Get the text from the clipboard.
                    String json = Clipboard.GetText();

                    // Attempt to parse the clipboard text.
                    Connection connection = JsonConvert.DeserializeObject<Connection>(json);

                    // Set the local Connection object.
                    connectionData = connection;

                    // If we've made it this far, it's a valid json.
                    isValid = true;
                    
                } catch (Exception ex) {
                    //Not a valid json string.
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
    }
}
