using System;
using System.Collections.Specialized;
using AweSimConnect.Properties;

namespace AweSimConnect.Models
{
    class AdvancedSettings
    {
        public void SaveUsername(string userName)
        {
            Settings.Default.Username = userName;
            Settings.Default.Save();
        }

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

        public void RememberUser(bool remember)
        {
            Settings.Default.IsPassSaved = remember;
            Settings.Default.Save();
        }

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

        public void SaveSSHHostCode(OSCCluster cluster)
        {
            Settings.Default.SSHHost = cluster.Code;
            Settings.Default.Save();
        }

        public string GetSSHHostCode()
        {
            return Settings.Default.SSHHost;
        }

        public void SetAutoOpenApp(bool autoOpen)
        {
            Settings.Default.AutoOpenApp = autoOpen;
            Settings.Default.Save();
        }

        public bool AutoOpenApp()
        {
            return Settings.Default.AutoOpenApp;
        }

        public void SetDetectClipboard(bool detect)
        {
            Settings.Default.DetectClipboard = detect;
            Settings.Default.Save();
        }

        public bool DetectClipboard()
        {
            return Settings.Default.DetectClipboard;
        }

        public void SetUseDefaultFTPClient(bool useDefault)
        {
            Settings.Default.UseDefaultSFTP = useDefault;
            Settings.Default.Save();
        }

        public bool UseDefaultFTPClient()
        {
            return Settings.Default.UseDefaultSFTP;
        }

        public void SetArgStringCollection(StringCollection args)
        {
            Settings.Default.CommandLineArgsArray = args;
            Settings.Default.Save();
        }

        public StringCollection GetArgStringCollection()
        {
            return Settings.Default.CommandLineArgsArray;
        }

        public void SetArgsChanged(bool changed)
        {
            Settings.Default.CommandLineUpdated = changed;
            Settings.Default.Save();
        }

        public void SetArgsChanged()
        {
            SetArgsChanged(true);
        }

        public bool GetArgsChanged()
        {
            return Settings.Default.CommandLineUpdated;
        }

        internal bool LaunchTunnelAutomatically()
        {
            return Settings.Default.LaunchSSHOnImport;
        }

        internal void SetLaunchSSHTunnelAutomatically(bool launch)
        {
            Settings.Default.LaunchSSHOnImport = launch;
            Settings.Default.Save();
        }
    }
}
