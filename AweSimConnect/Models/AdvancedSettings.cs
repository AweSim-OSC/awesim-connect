using System;
using System.Collections.Specialized;
using AweSimConnect.Properties;

namespace AweSimConnect.Models
{
    class AdvancedSettings
    {
        // Saves the username to the settings 
        public void SaveUsername(string userName)
        {
            Settings.Default.Username = userName;
            Settings.Default.Save();
        }

        // Retreives the username from settings
        public string GetUsername()
        {
            string name = "";
            try
            {
                name = Settings.Default.Username;
            }
            catch (Exception)
            {

            }
            return name;
        }

        // Saves the 'remember me' option to settings
        public void RememberUser(bool remember)
        {
            Settings.Default.IsPassSaved = remember;
            Settings.Default.Save();
        }

        // Retrieves the 'remember me' option from settings
        public bool IsUserSaved()
        {
            return Settings.Default.IsPassSaved;
        }

        // Encrypts the password and saves to settings
        public void SavePassword(string password)
        {
            Settings.Default.Userpass = PasswordEncryption.Encrypt(password);
            Settings.Default.Save();
        }

        // Returns the decrypted user password from the settings
        internal string GetPassword()
        {
            try
            {
                return PasswordEncryption.Decrypt(Settings.Default.Userpass);
            }
            catch (Exception)
            {
                return "";
            }
        }

        // Saves the OSC Cluster code to the settings.
        public void SaveSSHHostCode(OSCCluster cluster)
        {
            Settings.Default.SSHHost = cluster.Code;
            Settings.Default.Save();
        }

        // Gets the OSC cluster code from the settings.
        public string GetSSHHostCode()
        {
            return Settings.Default.SSHHost;
        }

        // Saves the app auto-open behavior to the settings
        public void SetAutoOpenApp(bool autoOpen)
        {
            Settings.Default.AutoOpenApp = autoOpen;
            Settings.Default.Save();
        }

        // Gets app auto-open behavior from the settings.
        public bool AutoOpenApp()
        {
            return Settings.Default.AutoOpenApp;
        }

        // Saves the clipboard detection policy to settings
        public void SetDetectClipboard(bool detect)
        {
            Settings.Default.DetectClipboard = detect;
            Settings.Default.Save();
        }

        // Gets the clipboard detection policy from settings.
        public bool DetectClipboard()
        {
            return Settings.Default.DetectClipboard;
        }
        
        // Saves a StringCollection of arguments to the settings.
        // Used for passing command line arguements between process instances.
        public void SetArgStringCollection(StringCollection args)
        {
            Settings.Default.CommandLineArgsArray = args;
            Settings.Default.Save();
        }

        // Gets the command line arguments from the settings as a StringCollection.
        public StringCollection GetArgStringCollection()
        {
            return Settings.Default.CommandLineArgsArray;
        }

        // Set this when the command line arguments are changed.
        public void SetArgsChanged(bool changed)
        {
            Settings.Default.CommandLineUpdated = changed;
            Settings.Default.Save();
        }

        // Set the args changes flag to true.
        public void SetArgsChanged()
        {
            SetArgsChanged(true);
        }

        // Get the args changed status from the settings.
        public bool GetArgsChanged()
        {
            return Settings.Default.CommandLineUpdated;
        }

        // Get the settings option to launch the ssh tunnel automatically.
        internal bool LaunchTunnelAutomatically()
        {
            return Settings.Default.LaunchSSHOnImport;
        }

        // Set the option to launch the ssh tunnel automatically.
        internal void SetLaunchSSHTunnelAutomatically(bool launch)
        {
            Settings.Default.LaunchSSHOnImport = launch;
            Settings.Default.Save();
        }
    }
}
