using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Configuration;
using System.Text;

namespace AweSimConnect.Controllers
{
    class WebTools
    {
        private static string HTTP_LOCALHOST = @"http://localhost:";

        // Custom tool to launch web browsers since .Net 2.0 and Win8 don't agree.
        public static void LaunchBrowser(String url)
        {
            bool launched = false;

            try
            {
                Process.Start(url);
                launched = true;
            }
            catch (Exception)
            {
                //Default browser doesn't work.
            }

            // Try using system Internet Explorer 
            if (!launched)
            {
                try
                {
                Process.Start("IEXPLORE", url);
                launched = true;
                }
                catch (Exception)
                {
                    //Internet Explorer doesn't work.
                }
            }

            // If that didn't work, try explorer in path.
            if (!launched)
            {
                try
                {
                    Process.Start("explorer.exe", url);
                    launched = true;
                }
                catch (Exception)
                {
                    //Internet Explorer doesn't work.
                }
            }

            //TODO if we get here without launching, I may want to add an embedded browser.
        }

        public static void LaunchLocalhostBrowser(int port)
        {
            string url = HTTP_LOCALHOST + port;
            LaunchBrowser(url);
        }
    }
}
