using AweSimConnect.Models;
using AweSimConnect.Properties;
using System;
using System.Diagnostics;
using System.IO;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// This class controls the plink application.
    /// </summary>
    class PuTTYController
    {
        private static String PLINK_PROCESS = "plink";
        private static String PLINK_FILE = "plink.exe";

        private Connection connection;
        private Process process;

        private bool process_embedded = false;

        internal Connection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        //The full current path of the plink executable.
        private static String PLINK_CURRENT_DIR = Path.Combine(Directory.GetCurrentDirectory(), PLINK_FILE);

        // PuTTY/Plink command line argument placeholder.        
        private static String PUTTY_ARGS_NOPASSWORD = "-ssh -L {0}:{1}:{0} -C -N -T {2}@{3} -l {4}";
        private static String PUTTY_ARGS_PASSWORD = "-ssh -L {0}:{1} -C -N -T {2}@{3} -l {4} -pw {5}";

        public PuTTYController(Connection connection)
        {
            InstallPlink();
            this.connection = connection;
        }

        //Installs plink.exe to current directory if it isn't there.
        public bool InstallPlink()
        {
            if (!IsPlinkInstalled())
            {
                using (FileStream fs = new FileStream(PLINK_CURRENT_DIR, FileMode.CreateNew, FileAccess.Write))
                {
                    byte[] bytes = getPlink();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return true;
        }

        //Gets plink.exe from the embedded resources.
        private byte[] getPlink()
        {
            return Resources.plink;
        }

        //Launch Plink without a password
        //Currently not implemented. the form validates for password.
        public void StartPlinkProcess()
        {
            String plinkCommand = String.Format(PLINK_CURRENT_DIR);
            ProcessStartInfo info = new ProcessStartInfo(plinkCommand);
            info.Arguments = String.Format(PUTTY_ARGS_NOPASSWORD, this.connection.LocalPort, this.connection.GetServerAndPort(), this.connection.UserName, this.connection.SSHHost, this.connection.UserName);
            info.UseShellExecute = true;

            try
            {
                process = Process.Start(info);
            }
            catch (Exception)
            {
                //TODO probably should put up a message here.
            }
        }

        //Launch Plink with a password
        public void StartPlinkProcess(String password)
        {
            //TODO This will probably break if the password is empty, but the view currently prevents that.
            String plinkCommand = String.Format(PLINK_CURRENT_DIR);
            ProcessStartInfo info = new ProcessStartInfo(plinkCommand);
            info.Arguments = String.Format(PUTTY_ARGS_PASSWORD, this.connection.LocalPort, this.connection.GetServerAndPort(), this.connection.UserName, this.connection.SSHHost, this.connection.UserName, password);
            info.UseShellExecute = true;

            try
            {
                this.process = Process.Start(info);
            }
            catch (Exception)
            {
                //TODO probably should put up a message here.
            }
        }

        // Check to see if plink exists in the AweSim connect folder.
        internal bool IsPlinkInstalled()
        {
            return FileController.ExistsOnPath(PLINK_FILE);
        }

        // Check to see if plink is in the running processes.
        internal bool IsPlinkRunning()
        {
            return FileController.IsProcessRunning(PLINK_PROCESS);
        }

        internal Process[] GetPlinkProcesses()
        {
            return Process.GetProcessesByName(PLINK_PROCESS);
        }

        internal bool IsPlinkConnected()
        {
            try
            {
                if (IsPlinkRunning())
                {
                    return NetworkTools.IsPortOpenOnLocalHost(connection.LocalPort);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        internal Process GetThisProcess()
        {
            return process;
        }

        internal void EmbedProcess()
        {
            process_embedded = true;
        }

        public bool IsProcessEmbedded()
        {
            return process_embedded;
        }

        public void KillProcess()
        {
            if (!process.HasExited)
            {
                process.Kill();
            }
        }
    }
}
