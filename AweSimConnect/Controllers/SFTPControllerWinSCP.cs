using System;
using System.Diagnostics;
using System.IO;
using AweSimConnect.Models;
using AweSimConnect.Properties;

namespace AweSimConnect.Controllers
{
    class SFTPControllerWinSCP
    {
        //WinSCP - GPLv2 License.
        private static string WINSCP_PROCESS = "winscp";
        private static string WINSCP_FOLDER_CONTAINS = "WinSCP";
        private static string WINSCP_FILE = "winscp.exe";
        private string WinSCPPath = "";
        
        internal Connection Connection { get; set; }
        private Process _process;
        private bool _processKilled;

        private static string SFTP_PORT = "22";

        //The arguments for WinSCP
        private static string WINSCP_ARGS = "sftp://{0}:{1}@{2}:{3} /noupdate";

        public SFTPControllerWinSCP(Connection connection, bool admin)
        {
            this.WinSCPPath = InstallWinSCP(admin);
            this.Connection = connection;
        }

        //Installs winscp.exe to current or temp directory if it isn't there.
        public String InstallWinSCP(bool admin)
        {
            String path = "";
            FileController.DeployResource(getWinSCP(), WINSCP_FILE, admin);
            if (admin)
            {
                path = Path.Combine(FileController.FILE_FOLDER_PATH_ADMIN, WINSCP_FILE);
            }
            else
            {
                path = Path.Combine(FileController.FILE_FOLDER_PATH_TEMP, WINSCP_FILE);
            }
            return path;
        }

        //Gets exe from the embedded resources.
        private byte[] getWinSCP()
        {
            return Resources.WinSCP;
        }

        //Launch app
        public void StartSFTPProcess(string password)
        {
            //TODO This will probably break if the password is empty.
            ProcessStartInfo info = new ProcessStartInfo(this.WinSCPPath);
            info.Arguments = String.Format(WINSCP_ARGS, this.Connection.UserName, password, OSCClusterController.SFTP_CLUSTER.Domain, SFTP_PORT);
            info.UseShellExecute = true;

            try
            {
                this._process = Process.Start(info);
            }
            catch (Exception)
            {
                //TODO probably should put up a message here.
            }
        }

        // Check to see if TurboVNC exists in the AweSim connect folder.
        internal bool IsWinSCPInstalled()
        {
            return FileController.ExistsOnPath(WINSCP_FILE);
        }

        // Check to see if plink is in the running processes.
        internal bool IsSFTPRunning()
        {
            if (!_processKilled)
            {
                return ProcessController.IsProcessRunning(WINSCP_PROCESS);
            }
            else
            {
                return _processKilled;
            }
        }
        
        /*
        public void DetectSFTPPath()
        {
            this.WinSCPPath = FileController.SearchProgramFileFoldersForExecutableWithFolderPatternMatch(WINSCP_FILE, WINSCP_FOLDER_CONTAINS);
        }

        public bool IsSFTPInstalled()
        {
            if (WinSCPPath != "")
            {
                return true;
            }
            return false;
        }
        */

        internal Process GetThisProcess()
        {
            return _process;
        }

        internal void KillProcess()
        {
            _processKilled = ProcessController.KillProcess(_process);
            _process = null;
        }
    }
}
