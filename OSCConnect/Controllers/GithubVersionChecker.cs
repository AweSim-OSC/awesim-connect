using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OSCConnect.Controllers
{

    class GithubVersionChecker
    {
        public class GithubAssets
        {
            public string name { get; set; }
            public string browser_download_url { get; set; }
        }

        public class GithubResponse
        {
            public string tag_name { get; set; }
            public string body { get; set; }
            public List<GithubAssets> assets { get; set; }

        }

        private string _latestBinaryPath;
        private string _latestVersion;
        private List<GithubAssets> _assetList;

        // GET Returns json response from the github api
        public static string VERSION_RESPONSE_PAGE =
            "https://api.github.com/repos/OSC/osc-connect/releases/latest";        
        
        // The current version of the running client.
        private static readonly string CLIENT_VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public GithubVersionChecker()
        {
            try
            {
                string data = WebTools.GET(VERSION_RESPONSE_PAGE);
                GithubResponse gResponse = JsonConvert.DeserializeObject<GithubResponse>(data);
                _assetList = gResponse.assets;
                _latestBinaryPath = gResponse.assets[0].browser_download_url;
                _latestVersion = gResponse.tag_name;
            }
            catch (Exception)
            {
                _latestBinaryPath = "";
                _latestVersion = CLIENT_VERSION;
            }           
        }
        
        // Located at response['assets']['browser_download_url']
        public string getLatestBinaryPath()
        {
            return _latestBinaryPath;            
        }

        public string getLatestBinaryPath(string match)
        {
            foreach (var asset in _assetList)
            {
                if (asset.name.ToLower().Contains(match))
                {
                    _latestBinaryPath = asset.browser_download_url;
                }
            }
            return _latestBinaryPath;
        }

        // Parse the data from remote and 
        // where remoteVersion format equals: XX.XX.XX.XX
        private bool IsNewerVersion(string remoteVersion)
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
        public bool IsNewerVersionAvailable()
        {
            bool newer = false;
            try
            {
                newer = IsNewerVersion(_latestVersion);
            }
            catch (Exception)
            {
                // Error connecting.
            }
            return newer;
        }
    }
}

