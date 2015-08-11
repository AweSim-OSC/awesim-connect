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

        private Connection _connection;
        private Process _process;

        private bool _process_embedded = false;
        private bool _processKilled = false;

        internal Connection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        //The full current path of the putty executable.
        private static String PUTTY_CURRENT_DIR = Path.Combine(FileController.FILE_FOLDER_PATH, PUTTY_FILE);

        // PuTTY command line argument placeholder.        
        //private static String PUTTY_ARGS_NOPASSWORD = "-ssh {0} -l {1}";
        private static String PUTTY_ARGS_PASSWORD = "-ssh {0} -l {1} -pw {2}";

        public ConsoleController(Connection connection)
        {
            InstallPutty();
            this._connection = connection;
        }

        //Installs putty.exe to current directory if it isn't there.
        public bool InstallPutty()
        {
            return FileController.DeployResourceToAweSimFilesFolder(getPutty(), PUTTY_FILE);
        }

        //Gets putty.exe from the embedded resources.
        private byte[] getPutty()
        {
            return Resources.putty;
        }

        //Launch Putty with a password
        public void StartPuttyProcess(string password)
        {
            //TODO This will probably break if the password is empty, but the view currently prevents that.
            String puttyCommand = String.Format(PUTTY_CURRENT_DIR);
            ProcessStartInfo info = new ProcessStartInfo(puttyCommand);
            info.Arguments = String.Format(PUTTY_ARGS_PASSWORD, this._connection.SSHHost, this._connection.UserName, password);
            info.UseShellExecute = true;

            try
            {
                this._process = Process.Start(info);
            }
            catch (Exception)
            {
                //TODO probably should put up a message or throw another exception here.
            }
        }

        // Check to see if putty exists in the AweSim connect folder.
        internal bool IsPuttyInstalled()
        {
            return FileController.ExistsOnPath(PUTTY_FILE);
        }

        // Check to see if putty is in the running processes.
        internal bool IsPuttyRunning()
        {
            if (!_processKilled)
            {
                return ProcessController.IsProcessRunning(PUTTY_PROCESS);
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
                    return NetworkTools.IsPortOpenOnLocalHost(_connection.LocalPort);
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
            return _process;
        }

        internal void EmbedProcess()
        {
            _process_embedded = true;
        }

        public bool IsProcessEmbedded()
        {
            return _process_embedded;
        }

        public void KillProcess()
        {
            _processKilled = ProcessController.KillProcess(_process);
            _process = null;
        }
    }
}
