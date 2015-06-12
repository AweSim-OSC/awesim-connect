using AweSimConnect.Models;
using AweSimConnect.Properties;
using System;
using System.Diagnostics;
using System.IO;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// This class controls the ggivnc application. 
    /// </summary>
    class VNCControllerGGI
    {

        //GGIVNC - MIT License.
        private static String GGIVNC_FILE = "ggivnc.exe";
        private static string GGIVNC_PROCESS = "ggivnc";

        private Connection connection;
        private Process process;

        internal Connection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        //The full current path of the plink executable.
        private static String GGIVNC_CURRENT_DIR = Path.Combine(Directory.GetCurrentDirectory(), GGIVNC_FILE);

        //The arguments for ggivnc
        private static String GGI_ARGS = "-p {0} localhost::{1}";
        private bool process_killed;

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
            string localhost = String.Format(GGI_ARGS, WritePasswordFile(), Connection.LocalPort);
            return localhost;
            //return GGIVNC_CURRENT_DIR + " -p " + WritePasswordFile() + " localhost:1";
        }

        public VNCControllerGGI(Connection connection)
        {
            InstallVNC();
            this.connection = connection;
        }

        //Installs ggivnc.exe to current directory if it isn't there.
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
            return Resources.vncviewer;
        }

        //Launch Plink without a password
        //Currently not implemented since the form validates for password.
        public void StartVNCProcess()
        {
            String vncCommand = BuildCommandString();
            ProcessStartInfo info = new ProcessStartInfo(GGIVNC_CURRENT_DIR);
            //TODO
            info.Arguments = String.Format(GGI_ARGS, WritePasswordFile(), connection.LocalPort);
            info.UseShellExecute = true;

            try
            {
                process = Process.Start(info);
            }
            catch (Exception)
            {
            }
        }

        // Check to see if plink exists in the AweSim connect folder.
        internal bool IsVNCInstalled()
        {
            return FileController.ExistsOnPath(GGIVNC_FILE);
        }

        internal void KillProcess()
        {
            if (process != null)
            {
                if (!process.HasExited)
                {
                    process.Kill();
                    process_killed = true;
                }
            }
            
        }

        // Check to see if plink is in the running processes.
        internal bool IsVNCRunning()
        {
            if (!process_killed)
            {
                return FileController.IsProcessRunning(GGIVNC_PROCESS);
            }
            else
            {
                return process_killed;
            }
        }
    }
         
}
