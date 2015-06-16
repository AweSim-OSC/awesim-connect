using System;
using System.Diagnostics;
using System.Threading;
using AweSimConnect.Models;

namespace AweSimConnect.Controllers
{
    class SFTPControllerWinSCP
    {
        private static String WINSCP_PROCESS = "winscp";
        private static String WINSCP_FOLDER_CONTAINS = "WinSCP";
        private static String WINSCP_FILE = "winscp.exe";
        private String WinSCPPath = "";

        private static String SFTP_PORT = "22";
        
        //The arguments for filezilla
        private static String FILEZILLA_ARGS = "sftp://{0}:{1}@{2}:{3}";

        private Connection connection;
        private Process process;
        private bool process_embedded;
        private bool searching = true;
        
        public SFTPControllerWinSCP(Connection connection)
        {
            this.connection = connection;
        }

        //Use this constructor if we already know the path of the SFTP client.
        public SFTPControllerWinSCP(Connection connection, String path)
        {
            this.connection = connection;
            this.WinSCPPath = path;
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

        //Launch sftp client with a password
        public void StartSFTPProcess(String password)
        {
            //TODO This will probably break if the password is empty.
            String sftpCommand = WinSCPPath;
            ProcessStartInfo info = new ProcessStartInfo(sftpCommand);
            info.Arguments = String.Format(FILEZILLA_ARGS, this.connection.UserName, password, connection.SSHHost, SFTP_PORT);
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

        internal Process GetThisProcess()
        {
            return process;
        }

        internal void EmbedProcess()
        {
            process_embedded = true;
        }

        internal bool IsProcessEmbedded()
        {
            return process_embedded;
        }

        internal void KillProcess()
        {
            process.Kill();
        }

        // Asynchronous file detection.
        public String DetectSFTPAsyncMethod(int callDuration, out int threadID)
        {
            threadID = Thread.CurrentThread.ManagedThreadId;
            return FileController.FindExecutableInProgramFiles(WINSCP_FILE);
        }
        
        private delegate String DetectSFTPAsyncMethodCaller(int callDuration, out int threadID);
    }
}
