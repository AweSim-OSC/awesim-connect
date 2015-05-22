using AweSimConnect.Models;
using AweSimConnect.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AweSimConnect.Controllers
{
    class VNCController
    {
        //TODO Add ggi license to docs

        //GGIVNC - MIT License.
        private static String GGIVNC_FILE = "ggivnc.exe";

        private Connection connection;

        internal Connection Connection
        {
            get { return connection; }
            set { connection = value; }
        }
        
        //The full current path of the plink executable.
        private static String GGIVNC_CURRENT_DIR = Path.Combine(Directory.GetCurrentDirectory(), GGIVNC_FILE);

        // GGIVnc command line argument placeholder.
        // TODO
        private static String GGIVNC_ARGS = "";
                
        public VNCController(Connection connection)
        {
            InstallVNC();
            this.connection = connection;
        }

        //Installs plink.exe to current directory if it isn't there.
        public bool InstallVNC()
        {
            if (!IsVNCInstalled())
            {
                using (FileStream fs = new FileStream(GGIVNC_CURRENT_DIR, FileMode.CreateNew, FileAccess.Write))
                {
                    byte[] bytes = getGGIVnc();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }            
            return true;
        }

        //Gets plink.exe from the embedded resources.
        private byte[] getGGIVnc()
        {
            return Resources.ggivnc;
        }

        //Launch Plink without a password
        //Currently not implemented. the form validates for password.
        public void StartVNCProcess()
        {
            String vncCommand = String.Format(GGIVNC_CURRENT_DIR);
            ProcessStartInfo info = new ProcessStartInfo(vncCommand);
            //TODO
            //info.Arguments = String.Format(GGIVNC_ARGS, this.connection.RedirectPort, this.connection.PUAServer, this.connection.UserName, this.connection.SSHHost, this.connection.UserName);
            info.UseShellExecute = true;

            try
            {
                Process.Start(info);
            }
            catch (Exception ex)
            {

            }
        }

        // Check to see if plink exists in the AweSim connect folder.
        internal bool IsVNCInstalled()
        {
            return FileController.ExistsOnPath(GGIVNC_FILE);
        }
    }
}
