using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AweSimConnect.Controllers
{
    class VersionChecker
    {
        public static string VERSION_RESPONSE_PAGE =
            @"https://apps.awesim.org/assets/wiag/connect/latest/awesimconnectversion.php";


        public static string GetVersion()
        {
            WebClient client = new WebClient();
            byte[] html = client.DownloadData(VERSION_RESPONSE_PAGE);
            UTF8Encoding utf = new UTF8Encoding();
            return utf.GetString(html);
        }


    }
}
