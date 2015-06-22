using AweSimConnect.Models;
using System;
using System.Diagnostics;
using System.Threading;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// This class handles the SFTP client.
    /// </summary>
    class SFTPControllerFileZilla
    {
        private static string FILEZILLA_PROCESS = "filezilla";
        private static string FILEZILLA_FOLDER_CONTAINS = "FileZilla";
        private static string FILEZILLA_FILE = "filezilla.exe";
        private string FilezillaPath = "";

        private static string SFTP_PORT = "22";
        
        //The arguments for filezilla
        private static string FILEZILLA_ARGS = "sftp://{0}:{1}@{2}:{3}";

        private Connection connection;
        private Process process;
        private bool process_embedded;
        private bool searching = true;
        
        public SFTPControllerFileZilla(Connection connection)
        {
            this.connection = connection;
        }

        //Use this constructor if we already know the path of the SFTP client.
        public SFTPControllerFileZilla(Connection connection, string path)
        {
            this.connection = connection;
            this.FilezillaPath = path;
        }

        public void DetectSFTPPath()
        {
            this.FilezillaPath = FileController.SearchProgramFileFoldersForExecutableWithFolderPatternMatch(FILEZILLA_FILE, FILEZILLA_FOLDER_CONTAINS);
        }

        public bool IsSFTPInstalled()
        {            
            if (FilezillaPath != "")
            {
                return true;
            }
            return false;
        }

        public string GetSFTPPath()
        {
            return FilezillaPath;
        }

        //Launch sftp client with a password
        public void StartSFTPProcess(string password)
        {
            //TODO This will probably break if the password is empty.
            string sftpCommand = FilezillaPath;
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
        public string DetectSFTPAsyncMethod(int callDuration, out int threadID)
        {
            threadID = Thread.CurrentThread.ManagedThreadId;
            return FileController.FindExecutableInProgramFiles(FILEZILLA_FILE);
        }
        
        private delegate string DetectSFTPAsyncMethodCaller(int callDuration, out int threadID);
        
    }
}
