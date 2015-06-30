using System;
using System.Diagnostics;
using System.IO;
using AweSimConnect.Models;
using AweSimConnect.Properties;

namespace AweSimConnect.Controllers
{
    class ConsoleController
    {
        private static String PUTTY_PROCESS = "putty";
        private static String PUTTY_FILE = "putty.exe";

        private Connection connection;
        private Process process;

        private bool process_embedded = false;
        private bool _processKilled = false;

        internal Connection Connection
        {
            get { return connection; }
            set { connection = value; }
        }
        
        //The full current path of the plink executable.
        private static String PUTTY_CURRENT_DIR = Path.Combine(Directory.GetCurrentDirectory(), PUTTY_FILE);
        
        // PuTTY/Plink command line argument placeholder.        
        private static String PUTTY_ARGS_NOPASSWORD = "-ssh {0} -l {1}";
        private static String PUTTY_ARGS_PASSWORD = "-ssh {0} -l {1} -pw {2}";

        public ConsoleController(Connection connection)
        {
            InstallPutty();
            this.connection = connection;
        }

        //Installs plink.exe to current directory if it isn't there.
        public bool InstallPutty()
        {
            if (!IsPuttyInstalled())
            {
                using (FileStream fs = new FileStream(PUTTY_CURRENT_DIR, FileMode.CreateNew, FileAccess.Write))
                {
                    byte[] bytes = getPutty();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return true;
        }

        //Gets plink.exe from the embedded resources.
        private byte[] getPutty()
        {
            return Resources.putty;
        }

        //Launch Plink without a password
        //Currently not implemented. the form validates for password.
        public void StartPuttyProcess()
        {
            String consoleCommand = String.Format(PUTTY_CURRENT_DIR);
            ProcessStartInfo info = new ProcessStartInfo(consoleCommand);
            info.Arguments = String.Format(PUTTY_ARGS_NOPASSWORD, this.connection.LocalPort, this.connection.GetServerAndPort(), this.connection.UserName, this.connection.SSHHost, this.connection.UserName);
            info.UseShellExecute = true;

            try
            {
                process = Process.Start(info);
            }
            catch (Exception)
            {
                process = new Process();
                //TODO probably should put up a message or throw another exception here.
            }
        }

        //Launch Plink with a password
        public void StartPuttyProcess(String password)
        {
            //TODO This will probably break if the password is empty, but the view currently prevents that.
            String plinkCommand = String.Format(PUTTY_CURRENT_DIR);
            ProcessStartInfo info = new ProcessStartInfo(plinkCommand);
            info.Arguments = String.Format(PUTTY_ARGS_PASSWORD, this.connection.LocalPort, this.connection.GetServerAndPort(), this.connection.UserName, this.connection.SSHHost, this.connection.UserName, password);
            info.UseShellExecute = true;

            try
            {
                this.process = Process.Start(info);
            }
            catch (Exception)
            {
                //TODO probably should put up a message or throw another exception here.
            }
        }

        // Check to see if plink exists in the AweSim connect folder.
        internal bool IsPuttyInstalled()
        {
            return FileController.ExistsOnPath(PUTTY_FILE);
        }

        // Check to see if plink is in the running processes.
        internal bool IsPuttyRunning()
        {
            if (!_processKilled)
            {
                return FileController.IsProcessRunning(PUTTY_PROCESS);
            }
            else
            {
                return _processKilled;
            }
        }

        internal Process[] GetPuttyProcesses()
        {
            return Process.GetProcessesByName(PUTTY_PROCESS);
        }

        internal bool IsPuttyConnected()
        {
            try
            {
                if (IsPuttyRunning())
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
            if (process != null)
            {
                if (!process.HasExited)
                {
                    process.Kill();
                    process = null;
                    _processKilled = true;
                }
            }
        }
    }
}
