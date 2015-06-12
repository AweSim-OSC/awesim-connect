using System;
using System.Collections.Generic;
using System.Text;
using AweSimConnect.Controllers;

namespace AweSimConnect.Models
{
    class AdvancedSettings
    {
        public void SaveUsername(string userName)
        {
            Properties.Settings.Default.Username = userName;
            Properties.Settings.Default.Save();
        }

        public string GetUsername()
        {
            string name = "";
            try
            {
                name = Properties.Settings.Default.Username;
            }
            catch (Exception)
            {
                
            }
            return name;
        }

        public void RememberUser(bool remember)
        {
            Properties.Settings.Default.IsPassSaved = remember;
            Properties.Settings.Default.Save();
        }

        public bool IsUserSaved()
        {
            return Properties.Settings.Default.IsPassSaved;
        }

        // Encrypts the password and saves to settings
        public void SavePassword(string password)
        {
            Properties.Settings.Default.Userpass = PasswordEncryption.Encrypt(password);
            Properties.Settings.Default.Save();
        }

        // Returns the decrypted user password from the settings
        internal string GetPassword()
        {
            try
            {
                return PasswordEncryption.Decrypt(Properties.Settings.Default.Userpass);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void SaveSSHHostCode(OSCCluster cluster)
        {
            Properties.Settings.Default.SSHHost = cluster.Code;
            Properties.Settings.Default.Save();
        }

        public string GetSSHHostCode()
        {
            return Properties.Settings.Default.SSHHost;
        }

    }
}
