using AweSimConnect.Models;
using AweSimConnect.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// This class controls the ggivnc application. 
    /// </summary>
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

        //The arguments for ggivnc
        private static String GGI_ARGS = "-p {0} localhost:1";

        //Writes out the password file to a tmp location and returns the path of the file.
        private String WritePasswordFile()
        {
            String passPath = Path.GetTempFileName();
            using (StreamWriter passWrite = new StreamWriter(passPath, false))
            {
                passWrite.WriteLine(connection.VNCPassword);
            }
            return passPath;
        }

        // GGIVnc command line argument placeholder.
        private String BuildCommandString()
        {
            return GGIVNC_CURRENT_DIR + " -p " + WritePasswordFile() + " localhost:1";
        }

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
        //Currently not implemented since the form validates for password.
        public void StartVNCProcess()
        {
            String vncCommand = BuildCommandString();
            ProcessStartInfo info = new ProcessStartInfo(GGIVNC_CURRENT_DIR);
            //TODO
            info.Arguments = String.Format(GGI_ARGS, WritePasswordFile());
            info.UseShellExecute = true;

            try
            {
                Process.Start(info);
            }
            catch (Exception)
            {
                //TODO Put up a message that it didn't work.
            }
        }

        // Check to see if plink exists in the AweSim connect folder.
        internal bool IsVNCInstalled()
        {
            return FileController.ExistsOnPath(GGIVNC_FILE);
        }
    }
}
