using AweSimConnect.Models;
using AweSimConnect.Properties;
using System;
using System.Diagnostics;
using System.IO;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// This class controls the tunneler application. Currently Plink
    /// </summary>
    class TunnelController
    {
        private static String _tunnelProcess = "plink";
        private static String _tunnelFile = "plink.exe";
        private readonly String _tunnelPath;

        //Gets plink.exe from the embedded resources.
        private byte[] GetTunneler()
        {
            return Resources.plink;
        }

        private Connection _connection;
        private Process _process;

        private bool _processEmbedded, _processKilled;

        internal Connection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        //The full current path of the tunnel executable.
        //private static String TUNNEL_CURRENT_PATH = Path.Combine(FileController.FILE_FOLDER_PATH_ADMIN, TUNNEL_FILE);

        // PuTTY/Plink command line argument placeholder.
        // TODO Compression should be a toggleable option.
        // SSH Compression On
        //private static String _tunnelArgsPassword = "-ssh -L {0}:{1} -C -N -T {2}@{3} -l {4} -pw {5}";
        // SSH Compression Off
        private static String _tunnelArgsPassword = "-ssh -L {0}:{1} -N -T {2}@{3} -l {4} -pw {5}";

        public TunnelController(Connection connection, bool admin)
        {
            _tunnelPath = InstallTunneler(admin);
            _connection = connection;
        }

        //Installs tunneler to current directory if it isn't there.
        public String InstallTunneler(bool admin)
        {
            FileController.DeployResource(GetTunneler(), _tunnelFile, admin);
            var path = Path.Combine(admin ? FileController.FILE_FOLDER_PATH_ADMIN : FileController.FILE_FOLDER_PATH_TEMP, _tunnelFile);
            return path;
        }

        //Launch TUNNEL with a password
        public void StartTunnelerProcess(string password)
        {
            //TODO This will probably break if the password is empty, but the view currently prevents that.
            String tunnelCommand = String.Format(_tunnelPath);
            ProcessStartInfo info = new ProcessStartInfo(tunnelCommand)
            {
                Arguments =
                    String.Format(_tunnelArgsPassword, _connection.LocalPort, _connection.GetServerAndPort(),
                        _connection.UserName, _connection.SSHHost, _connection.UserName, password),
                UseShellExecute = true
            };

            //info.RedirectStandardError = true;
            //info.RedirectStandardOutput = true;
            //info.RedirectStandardInput = true;
            //info.CreateNoWindow = true;
            //info.UseShellExecute = false;

            try
            {
                _process = Process.Start(info);
            }
            catch (Exception)
            {
                //TODO probably should put up a message or throw another exception here.
            }
        }

        // Check to see if TUNNEL exists in the AweSim connect folder.
        internal bool IsTunnelerInstalled()
        {
            return FileController.ExistsOnPath(_tunnelFile);
        }

        // Check to see if tunneler is in the running processes.
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
            return Process.GetProcessesByName(_tunnelProcess);
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
            _processEmbedded = true;
        }

        public bool IsProcessEmbedded()
        {
            return _processEmbedded;
        }

        public bool IsProcessRunning()
        {
            return ProcessController.IsProcessRunning(_process);
        }

        public void KillProcess()
        {
            _processKilled = ProcessController.KillProcess(_process);
            _process = null;
        }
    }
}
