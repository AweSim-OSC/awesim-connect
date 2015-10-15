using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AweSimConnect.Controllers
{
    class VersionChecker
    {
        // The version response php is hosted here. A get response will return the format: 0.61.0.0
        public static string VERSION_RESPONSE_PAGE =
            "https://apps.awesim.org/assets/wiag/connect/latest/awesimconnectversion.php?user={0}";
        
        // The location of the latest deployed executable.
        public static string LATEST_DOWNLOAD_PAGE = @"https://apps.awesim.org/assets/wiag/connect/latest/AweSimConnect.exe";

        // The current version of the running client.
        private static string CLIENT_VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        // Gets the string of the current version of the executable at LATEST_DOWNLOAD_PAGE
        public static string GetRemoteVersion()
        {
            return GetRemoteVersion("");
        }

        public static string GetRemoteVersion(String username)
        {
            WebClient client = new WebClient();
            byte[] html = client.DownloadData(String.Format(VERSION_RESPONSE_PAGE, username));
            UTF8Encoding utf = new UTF8Encoding();
            return utf.GetString(html);
        }

        // where remoteVersion format equals: XX.XX.XX.XX
        public static bool isNewerVersion(string remoteVersion)
        {
            bool newVersion = false;
            
            // Parsing format XX.XX.XX.XX
            string[] remoteVersionArray = remoteVersion.Split('.');
            string[] localVersionArray = CLIENT_VERSION.Split('.');

            // Check the Major Version Number
            if (Int32.Parse(remoteVersionArray[0]) > Int32.Parse(localVersionArray[0]))
            {
                newVersion = true;
            }

            // Check the Minor Version Number
            if (!newVersion && (Int32.Parse(remoteVersionArray[1]) > Int32.Parse(localVersionArray[1])))
            {
                newVersion = true;
            }

            // Only the first two numbers of the file are populated, so that's all we check.
            return newVersion;
        }

        // Returns true if a newer version is detected on the remote server, otherwise false if same or connection error.
        public static bool IsNewerVersionAvailable(string username)
        {
            bool newer = false;
            try
            {
                newer = isNewerVersion(GetRemoteVersion(username));
            }
            catch (Exception)
            {
                // Error connecting.
            }
            return newer;
        }

    }
}
