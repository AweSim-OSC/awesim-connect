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
            @"https://apps.awesim.org/assets/wiag/connect/latest/awesimconnectversion.php";

        // The current version of the running client.
        private static string CLIENT_VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();


        private static string GetRemoteVersion()
        {
            WebClient client = new WebClient();
            byte[] html = client.DownloadData(VERSION_RESPONSE_PAGE);
            UTF8Encoding utf = new UTF8Encoding();
            return utf.GetString(html);
        }

        private static bool isNewerVersion(string remoteVersion)
        {
            bool newVersion = false;

            // Parsing format XX.XX.XX.XX
            string[] remoteVersionArray = remoteVersion.Split('.');
            string[] localVersionArray = CLIENT_VERSION.Split('.');

            if (Int32.Parse(remoteVersionArray[0]) > Int32.Parse(localVersionArray[0]))
            {
                newVersion = true;
            }

            if (!newVersion && (Int32.Parse(remoteVersionArray[1]) > Int32.Parse(localVersionArray[1])))
            {
                newVersion = true;
            }

            return newVersion;
        }

        public static bool IsNewerVersionAvailable()
        {
            return isNewerVersion(GetRemoteVersion());
        }

    }
}
