using AweSimConnect.Models;
using AweSimConnect.Properties;
using System;
using System.Diagnostics;
using System.IO;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// This class controls the tunneler application. Currently PuTTY
    /// </summary>
    class TunnelController
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
        private static String PUTTY_CURRENT_PATH = Path.Combine(FileController.FILE_FOLDER_PATH, PUTTY_FILE);

        // PuTTY/Plink command line argument placeholder.        
        private static String PUTTY_ARGS_PASSWORD = "-ssh -L {0}:{1} -C -N -T {2}@{3} -l {4} -pw {5}";

        public TunnelController(Connection connection)
        {
            InstallTunneler();
            _connection = connection;
        }

        //Installs putty.exe to current directory if it isn't there.
        public bool InstallTunneler()
        {
            return FileController.DeployResourceToAweSimFilesFolder(getTunneler(), PUTTY_FILE);
        }

        //Gets putty.exe from the embedded resources.
        private byte[] getTunneler()
        {
            return Resources.putty;
        }

        //Launch putty with a password
        public void StartTunnelerProcess(string password)
        {
            //TODO This will probably break if the password is empty, but the view currently prevents that.
            String puttyCommand = String.Format(PUTTY_CURRENT_PATH);
            ProcessStartInfo info = new ProcessStartInfo(puttyCommand);
            info.Arguments = String.Format(PUTTY_ARGS_PASSWORD, _connection.LocalPort, _connection.GetServerAndPort(), _connection.UserName, _connection.SSHHost, _connection.UserName, password);
            //info.UseShellExecute = true;

            //info.RedirectStandardError = true;
            //info.RedirectStandardOutput = true;
            //info.RedirectStandardInput = true;
            //info.CreateNoWindow = true;
            info.UseShellExecute = false;

            try
            {
                _process = Process.Start(info);
            }
            catch (Exception)
            {
                //TODO probably should put up a message or throw another exception here.
            }
        }

        // Check to see if putty exists in the AweSim connect folder.
        internal bool IsTunnelerInstalled()
        {
            return FileController.ExistsOnPath(PUTTY_FILE);
        }

        // Check to see if putty is in the running processes.
        internal bool IsTunnelerRunning()
        {
            if (!_processKilled)
            {
                //return ProcessController.IsProcessRunning(PLINK_PROCESS);
                return ProcessController.IsProcessRunning(_process.Id);
            }
            else
            {
                return _processKilled;
            }
        }

        internal Process[] GetTunnelerProcesses()
        {
            return Process.GetProcessesByName(PUTTY_PROCESS);
        }

        internal bool IsTunnelerConnected()
        {
            try
            {
                if (IsTunnelerRunning())
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
