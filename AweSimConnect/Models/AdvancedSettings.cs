using System;
using System.Collections.Generic;
using System.Text;

namespace AweSimConnect.Models
{
    class AdvancedSettings
    {
        private bool _rememberUser;
        private string _lastUserName;
        private string _SshHost;

        public void SaveUserName(string userName)
        {
            Properties.Settings.Default.Username = userName;
            Properties.Settings.Default.Save();
        }

        public string GetUserName()
        {
            string name = "";
            name = Properties.Settings.Default.Username;
            return name;
        }
    }
}
