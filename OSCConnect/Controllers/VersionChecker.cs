using System;
using System.Net;
using System.Text;

namespace OSCConnect.Controllers
{
    class VersionChecker
    {
        // The version response php is hosted here. A get response will return the format: 0.61.0.0
        // Username is included for usage tracking.
        public static string VERSION_RESPONSE_PAGE =
            "https://apps.awesim.org/assets/wiag/connect/latest/awesimconnectversion.php?user={0}";
        
        // The location of the latest deployed executable.
        public static string LATEST_DOWNLOAD_PAGE = @"https://apps.awesim.org/assets/wiag/connect/latest/AweSimConnect.exe";

        // The current version of the running client.
        private static readonly string CLIENT_VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        // Gets the string of the current version of the executable at LATEST_DOWNLOAD_PAGE
        public static string GetRemoteVersion(String username)
        {
            string version;
            try
            {
                WebClient client = new WebClient();
                byte[] html = client.DownloadData(String.Format(VERSION_RESPONSE_PAGE, username));
                UTF8Encoding utf = new UTF8Encoding();
                version = utf.GetString(html);
            }
            catch (Exception)
            {
                version = CLIENT_VERSION;
            }
            return version;
        }

        // Parse the data from remote and 
        // where remoteVersion format equals: XX.XX.XX.XX
        private static bool IsNewerVersion(string remoteVersion)
        {
            bool newVersion = false;

            try
            {
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
            }
            catch (Exception)
            {
                //Error in the downloaded data
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
                newer = IsNewerVersion(GetRemoteVersion(username));
            }
            catch (Exception)
            {
                // Error connecting.
            }
            return newer;
        }

    }
}
