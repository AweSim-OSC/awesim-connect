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
        private Process process;
        private bool _processKilled;

        private static string SFTP_PORT = "22";

        //The arguments for WinSCP
        private static string WINSCP_ARGS = "sftp://{0}:{1}@{2}:{3} /noupdate";

        //The full current path of the executable.
        private static readonly string WINSCP_CURRENT_DIR = Path.Combine(FileController.FILE_FOLDER_PATH, WINSCP_FILE);


        public SFTPControllerWinSCP(Connection connection)
        {
            InstallWinSCP();
            this.Connection = connection;
        }

        //Installs ggivnc.exe to current directory if it isn't there.
        public bool InstallWinSCP()
        {
            return FileController.DeployResourceToAweSimFilesFolder(getWinSCP(), WINSCP_FILE);
        }

        //Gets vncviewer.exe from the embedded resources.
        private byte[] getWinSCP()
        {
            return Resources.WinSCP;
        }

        //Launch TurboVNC 
        public void StartSFTPProcess(string password)
        {
            //TODO This will probably break if the password is empty.
            String sftpCommand = WinSCPPath;
            ProcessStartInfo info = new ProcessStartInfo(WINSCP_CURRENT_DIR);
            info.Arguments = String.Format(WINSCP_ARGS, this.Connection.UserName, password, Connection.SSHHost, SFTP_PORT);
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

        // Check to see if TurboVNC exists in the AweSim connect folder.
        internal bool IsWinSCPInstalled()
        {
            return FileController.ExistsOnPath(WINSCP_FILE);
        }

        internal void KillProcess()
        {
            if (process != null)
            {
                if (!process.HasExited)
                {
                    process.Close();
                    process = null;
                    //process.Kill();
                    _processKilled = true;
                }
            }

        }

        // Check to see if plink is in the running processes.
        internal bool IsSFTPRunning()
        {
            if (!_processKilled)
            {
                return FileController.IsProcessRunning(WINSCP_PROCESS);
            }
            else
            {
                return _processKilled;
            }
        }

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

        public String GetSFTPPath()
        {
            return WinSCPPath;
        }

        internal Process GetThisProcess()
        {
            return process;
        }
    }
}
