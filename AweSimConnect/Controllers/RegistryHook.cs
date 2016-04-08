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
        private static string URI_PREFIX = "osc://";
        private static string CONNECT_REG_PROTOCOL = "osc";
        private static string CONNECT_REG_POS = "Software\\Classes\\" + CONNECT_REG_PROTOCOL;

        // The URL handler for this app
        // TODO: This is here for backwards compatibility
        private static string URI_PREFIX_AWESIM = "awesim://";
        private static string CONNECT_REG_PROTOCOL_AWESIM = "awesim";
        private static string CONNECT_REG_POS_AWESIM = "Software\\Classes\\" + CONNECT_REG_PROTOCOL_AWESIM;

        private bool _installed;

        public RegistryHook()
        {
            _installed = installHook(CONNECT_REG_PROTOCOL, CONNECT_REG_POS) && installHook(CONNECT_REG_PROTOCOL_AWESIM, CONNECT_REG_POS_AWESIM);
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

        private static bool installHook(string keyProtocol, string keyPosition)
        {
            try
            {
                RegistryKey rKey = Registry.CurrentUser.CreateSubKey(keyPosition);
                rKey.SetValue("", "URL: " + keyProtocol + " Protocol");
                rKey.SetValue("URL Protocol", "");
                rKey.CreateSubKey("DefaultIcon").SetValue("", "\"" + Application.ExecutablePath + "\",0");
                rKey.CreateSubKey(@"shell\open\command").SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);

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
            newString = Regex.Replace(newString, RegistryHook.URI_PREFIX, "", RegexOptions.IgnoreCase);
            // TODO the second replace is here because we are maintaining backwards compatibility
            newString = Regex.Replace(newString, RegistryHook.URI_PREFIX_AWESIM, "", RegexOptions.IgnoreCase);
            return newString;
        }

        // Return true if a string contains the URI prefix
        internal static bool ContainsPrefix(string candidate)
        {
            return candidate.Contains(URI_PREFIX) || candidate.Contains(URI_PREFIX_AWESIM);
        }

        // true if the registry key has installed successfully
        public bool IsHookInstalled()
        {
            return _installed;
        }

    }
}
