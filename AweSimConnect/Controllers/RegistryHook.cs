using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// Use this class to install the custom URI sceme to HKEY_CURRENT_USER
    /// </summary>
    class RegistryHook
    {
        // The URL handler for this app
        private static string CONNECT_REG_PROTOCOL = "osc";
        
        // The URL handler for this app
        // TODO: This is here for backwards compatibility
        private static string CONNECT_REG_PROTOCOL_AWESIM = "awesim";
                
        private bool _installed;

        public RegistryHook()
        {            
            _installed = installHook(CONNECT_REG_PROTOCOL) && installHook(CONNECT_REG_PROTOCOL_AWESIM);
        }
                
        private static string getURIPrefix(string protocol)
        {
            return $"{protocol}://";
        }

        private static string getRegistryPosition(string protocol)
        {
            return $"Software\\Classes\\{protocol}";
        }

        /* Key Location:
         * 
         * HKEY_CURRENT_USER
         *      Software
         *          Classes
         *              awesim
         *                  DefaultIcon
         *                      Name: (Default)
         *                      Type: REG_SZ
         *                      Data: "[PATH]",1
         *                  Shell
         *                      open
         *                          command
         *                              Name: (Default)
         *                              Type: REG_SZ
         *                              Data: "[PATH]" "%1"
         */

        private static bool installHook(string protocol)
        {
            try
            {
                RegistryKey rKey = Registry.CurrentUser.CreateSubKey(getRegistryPosition(protocol));
                rKey.SetValue("", $"URL: {protocol} Protocol");
                rKey.SetValue("URL Protocol", "");
                rKey.CreateSubKey("DefaultIcon").SetValue("", $"\"{Application.ExecutablePath}\",0");
                rKey.CreateSubKey(@"shell\open\command").SetValue("", $"\"{Application.ExecutablePath}\" \"%1\"", RegistryValueKind.String);

                if (rKey != null)
                {
                    rKey.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Removes the uri portion of the string
        // Ex: 'osc://something' => 'something'
        internal static string RemovePrefix(string prefixedString)
        {
            string newString = prefixedString;
            newString = Regex.Replace(newString, getURIPrefix(CONNECT_REG_PROTOCOL), "", RegexOptions.IgnoreCase);
            // TODO the second replace is here because we are maintaining backwards compatibility
            newString = Regex.Replace(newString, getURIPrefix(CONNECT_REG_PROTOCOL_AWESIM), "", RegexOptions.IgnoreCase);
            return newString;
        }

        // Return true if a string contains the URI prefix
        internal static bool ContainsPrefix(string candidate)
        {
            return candidate.Contains(getURIPrefix(CONNECT_REG_PROTOCOL)) || candidate.Contains(getURIPrefix(CONNECT_REG_PROTOCOL_AWESIM));
        }

        // true if the registry key has installed successfully
        public bool IsHookInstalled()
        {
            return _installed;
        }

    }
}
