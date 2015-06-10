using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using AweSimConnect.Models;
using AweSimConnect.Properties;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// This class controls the TurboVNC vncviewer application. 
    /// </summary>
    class VNCControllerTurbo
    {
        //TurboVNC - GPLv2 License.
        private static String TURBOVNC_FILE = "vncviewer.exe";

        internal Connection Connection { get; set; }

        //The full current path of the executable.
        private static String TURBOVNC_CURRENT_DIR = Path.Combine(Directory.GetCurrentDirectory(), TURBOVNC_FILE);

        //The arguments for ggivnc
        private static String GGI_ARGS = "-p {0} localhost::{1}";
        
        public VNCControllerTurbo(Connection connection)
        {
            InstallVNC();
            this.Connection = connection;
        }

        //Writes out the password file to a tmp location and returns the path of the file.
        private String WritePasswordFile()
        {
            String passPath = Path.GetTempFileName();
            using (StreamWriter passWrite = new StreamWriter(passPath, false))
            {
                passWrite.WriteLine(Connection.VNCPassword);
            }
            return passPath;
        }

        // GGIVnc command line argument placeholder.
        private String BuildCommandString()
        {
            string localhost = String.Format(GGI_ARGS, WritePasswordFile(), Connection.LocalPort);
            return localhost;
            //return GGIVNC_CURRENT_DIR + " -p " + WritePasswordFile() + " localhost:1";
        }

        

        //Installs ggivnc.exe to current directory if it isn't there.
        public bool InstallVNC()
        {
            if (!IsVNCInstalled())
            {
                using (FileStream fs = new FileStream(TURBOVNC_CURRENT_DIR, FileMode.CreateNew, FileAccess.Write))
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
            ProcessStartInfo info = new ProcessStartInfo(TURBOVNC_CURRENT_DIR);
            //TODO
            info.Arguments = String.Format(GGI_ARGS, WritePasswordFile(), Connection.LocalPort);
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
            return FileController.ExistsOnPath(TURBOVNC_FILE);
        }
    }
    
}
