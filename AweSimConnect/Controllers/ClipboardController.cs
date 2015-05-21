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
     */
    class ClipboardController
    {
        String jsonString;
        
        //Checks the clipboard for valid data and returns true if found.
        public bool CheckClipboardForAweSim() {

            bool isValid;
            
            if (Clipboard.ContainsText()) {
                try {
                    String json = Clipboard.GetText();
                    Connection connection = JsonConvert.DeserializeObject<Connection>(json);

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
