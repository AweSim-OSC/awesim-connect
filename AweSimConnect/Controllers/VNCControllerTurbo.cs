using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
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

        internal Connection Connection { get; set; }
        private Process _process;
        private bool _processKilled;

        //The full current path of the executable.
        private static readonly String TURBOVNC_CURRENT_DIR = Path.Combine(FileController.FILE_FOLDER_PATH, TURBOVNC_FILE);

        //The arguments for turbovnc
        private static String TURBO_ARGS = "/password {0} localhost::{1}";

        public VNCControllerTurbo(Connection connection)
        {
            InstallVNC();
            this.Connection = connection;
        }

        //Installs ggivnc.exe to current directory if it isn't there.
        public bool InstallVNC()
        {
            return FileController.DeployResourceToAweSimFilesFolder(getTurboVnc(), TURBOVNC_FILE);
        }

        //Gets vncviewer.exe from the embedded resources.
        private byte[] getTurboVnc()
        {
            return Resources.vncviewer;
        }

        //Launch TurboVNC 
        public Process StartVNCProcess()
        {
            ProcessStartInfo info = new ProcessStartInfo(TURBOVNC_CURRENT_DIR);
            info.Arguments = String.Format(TURBO_ARGS, Connection.VNCPassword, Connection.LocalPort);
            info.UseShellExecute = true;

            try
            {
                _process = Process.Start(info);
            }
            catch (Exception ex)
            {
                _process = new Process();
            }
            return _process;
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
