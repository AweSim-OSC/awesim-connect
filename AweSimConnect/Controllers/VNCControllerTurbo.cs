using System;
using System.Diagnostics;
using System.IO;
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
        private static string TURBOVNC_FILE = "vncviewer.exe";
        private static string TURBOVNC_PROCESS = "vncviewer";
        private static int TURBOVNC_QUALITY_DEFAULT = 95;

        private String _vncPath = "";

        internal Connection _connection { get; set; }
        private Process _process;
        private bool _processKilled;
        private AdvancedSettings _settings = new AdvancedSettings();

        //The full current path of the executable.
        //private static readonly String TURBOVNC_CURRENT_DIR = Path.Combine(FileController.FILE_FOLDER_PATH_ADMIN, TURBOVNC_FILE);

        //The default arguments for turbovnc
        private static String TURBO_ARGS = @"/password {0} localhost::{1}";
        // Quality ranges 0-100 with '/quality {n}' flag
        private static String TURBO_ARGS_QUAL = @"/quality {0} /password {1} localhost::{2}";

        public VNCControllerTurbo(Connection connection, bool admin)
        {
            _vncPath = InstallVNC(admin);
            _connection = connection;
        }

        //Installs ggivnc.exe to current directory if it isn't there.
        public String InstallVNC(bool admin)
        {
            String path = "";
            FileController.DeployResource(getTurboVnc(), TURBOVNC_FILE, admin);
            if (admin)
            {
                path = Path.Combine(FileController.FILE_FOLDER_PATH_ADMIN, TURBOVNC_FILE);
            }
            else
            {
                path = Path.Combine(FileController.FILE_FOLDER_PATH_TEMP, TURBOVNC_FILE);
            }
            return path;
        }

        //Gets vncviewer.exe from the embedded resources.
        private byte[] getTurboVnc()
        {
            return Resources.vncviewer;
        }

        //Launch TurboVNC 
        public Process StartVNCProcess()
        {
            ProcessStartInfo info = new ProcessStartInfo(_vncPath);
            info.Arguments = buildVNCArgs();
            info.UseShellExecute = true;
            
            try
            {
                _process = Process.Start(info);
            }
            catch (Exception)
            {
                _process = new Process();
            }
            return _process;
        }

        private string buildVNCArgs()
        {
            string args;
            if (_settings.GetVNCQuality() == TURBOVNC_QUALITY_DEFAULT)
            {
                args = String.Format(TURBO_ARGS, _connection.VNCPassword.Trim(), _connection.LocalPort.ToString());
            }
            else
            {
                args = String.Format(TURBO_ARGS_QUAL, _settings.GetVNCQuality().ToString(), _connection.VNCPassword.Trim(), _connection.LocalPort.ToString());
            }
            return args;
        }

        // Check to see if TurboVNC exists in the AweSim connect folder.
        internal bool IsVNCInstalled()
        {
            return FileController.ExistsOnPath(TURBOVNC_FILE);
        }

        internal void KillProcess()
        {
            _processKilled = ProcessController.KillProcess(_process);
            _process = null;
        }

        // Check to see if plink is in the running processes.
        internal bool IsVNCRunning()
        {
            if (!_processKilled)
            {
                return ProcessController.IsProcessRunning(TURBOVNC_PROCESS);
            }
            else
            {
                return _processKilled;
            }
        }
    }

}
