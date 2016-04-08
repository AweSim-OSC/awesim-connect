using System;
using System.Collections.Specialized;
using OSCConnect.Properties;

namespace OSCConnect.Models
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
        //
        // Note:    StringCollection throws and catches an internal FileNotFound exception here.
        //          I tried to get rid of it but it's apparently known behavior. It may be wise
        //          to find a way to replace StringCollection with some other data structure.
        //          I'm not sure if that's possible in this case.
        //          http://stackoverflow.com/questions/3494886/filenotfoundexception-in-applicationsettingsbase
        //
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

        // This should be true if there is a new version available.
        internal bool NewerVersionAvailable()
        {
            return Settings.Default.NewerVersionAvailable;
        }

        // Set the option if there is a new version available.
        internal void SetNewerVersionAvailable(bool isNewerVersion)
        {
            Settings.Default.NewerVersionAvailable = isNewerVersion;
            Settings.Default.Save();
        }

        // This should be true to automatically check for new versions.
        internal bool AutoCheckNewVersion()
        {
            return Settings.Default.AutoCheckNewVersion;
        }

        // Set the option to enable or diable auto version checks.
        internal void SetAutoCheckNewVersion(bool autoCheckNewVersion)
        {
            Settings.Default.AutoCheckNewVersion = autoCheckNewVersion;
            Settings.Default.Save();
        }

        // This should be true if the app location is writeable.
        internal bool IsWriteableUser()
        {
            return Settings.Default.WriteableUser;
        }

        // Set the option if the app is being run from a writable location.
        internal void SetWriteableUser(bool isWriteableUser)
        {
            Settings.Default.WriteableUser = isWriteableUser;
            Settings.Default.Save();
        }

        // Set the value of the VNC Quality (1-100)
        internal void SetVNCQuality(int quality)
        {
            if (quality >= 0 && quality <= 100)
            {
                Settings.Default.VNCQuality = quality;
                Settings.Default.Save();
            }
        }

        // Return the VNC quality value.
        internal int GetVNCQuality()
        {
            return Settings.Default.VNCQuality;
        }
    }
}
