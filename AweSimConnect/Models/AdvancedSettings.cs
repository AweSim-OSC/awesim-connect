using System;
using System.Collections.Generic;
using System.Text;

namespace AweSimConnect.Models
{
    class AdvancedSettings
    {
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

        public void RememberUser(bool remember)
        {
            Properties.Settings.Default.IsPassSaved = remember;
            Properties.Settings.Default.Save();
        }

        public bool IsUserSaved()
        {
            return Properties.Settings.Default.IsPassSaved;
        }
    }
}
