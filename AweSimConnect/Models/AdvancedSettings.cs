using System;
using System.Collections.Generic;
using System.Text;

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

        /*
        // Check the user settings for a username and encrypted password and fill the text boxes.
        private void checkForUserSettings()
        {
            if ((bool)Settings.Default["IsPassSaved"])
            {
                label1.Text = Settings.Default["UserName"].ToString();
                checkSavePassword.Checked = true;
                string userName = Settings.Default["UserName"].ToString();
                string userPass = Settings.Default["UserPass"].ToString();
                tbUserName.Text = userName;
                tbPassword.Text = PasswordEncryption.Decrypt(userPass);

            }
        }

        // If true, save the choice to the Settings. If false, change user settings to reflect.
        private void SaveUserSettings(bool userSettings)
        {
            Settings.Default["IsPassSaved"] = userSettings;
            string userName = tbUserName.Text;
            string userPass = tbPassword.Text;

            //If we're saving the settings, encrypt the password and save to settings. Else save blanks.
            if (userSettings) {
                Settings.Default["UserName"] = userName;
                string encryptedUserPass = PasswordEncryption.Encrypt(userPass);
                Settings.Default["UserPass"] = encryptedUserPass;
            }
            else
            {
                Settings.Default["UserName"] = userName;
                Settings.Default["UserPass"] = "";
            }
            Settings.Default.Save();

        }

        */
    }
}
