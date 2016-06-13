using System;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace OSCConnect.Controllers
{
    class WebTools
    {
        private static string HTTP_LOCALHOST = @"http://localhost:";

        // Custom tool to launch web browsers since .Net 2.0 and Win8 don't agree.
        public static Process LaunchBrowser(string url)
        {
            bool launched = false;
            Process browserProcess = new Process();
            

            try
            {
                browserProcess = Process.Start("explorer.exe", url);
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
                    browserProcess = Process.Start("IEXPLORE", url);
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
                    browserProcess = Process.Start(url);
                    launched = true;
                }
                catch (Exception)
                {
                    //Another way to try the default browser.
                }
            }
            
            //TODO if we get here without launching, I may want to add an embedded browser.

            return browserProcess;
        }

        // Perform a GET request and return the contents as string.
        /// <exception cref="System.Net.Sockets.SocketException">Thrown when the host is unknown.</exception>
        /// <exception cref="System.Net.WebException">Thrown when the host can not be resolved.</exception>
        public static string GET(string url)
        {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            byte[] html = client.DownloadData(url);
            UTF8Encoding utf = new UTF8Encoding();
            return utf.GetString(html);
        }

        // Launch the custom browser launcher on a specified port.
        public static Process LaunchLocalhostBrowser(int port)
        {
            string url = HTTP_LOCALHOST + port;
            return LaunchBrowser(url);
        }
    }
}
