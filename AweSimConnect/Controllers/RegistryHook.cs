using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// Use this class to install the custom URI sceme to HKEY_CURRENT_USER
    /// </summary>
    class RegistryHook
    {
        // The URL handler for this app
        public static string URI_PREFIX = "awesim://";

        private static string CONNECT_REG_POS = "Software\\Classes\\awesim";
        private static string CONNECT_REG_PROTOCOL = "awesim";

        private bool installed;

        public RegistryHook()
        {
            installed = installHook();
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

        private bool installHook()
        {
            //TODO Add the DefaultIcon key. This works without it, but it's windows convention.

            try
            {
                RegistryKey rKey = Registry.CurrentUser.OpenSubKey(CONNECT_REG_POS, true);
                rKey.SetValue("", "URL: awesim Protocol");
                rKey.SetValue("URL Protocol", "");
                rKey = rKey.CreateSubKey(@"shell\open\command");
                rKey.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
            
                if (rKey != null)
                {
                    rKey.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsHookInstalled()
        {
            return installed;
        }
        
    }
}
