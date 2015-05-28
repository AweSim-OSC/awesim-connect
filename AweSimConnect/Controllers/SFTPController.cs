using AweSimConnect.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// This class handles the SFTP client.
    /// </summary>
    class SFTPController
    {
        private static String FILEZILLA_PROCESS = "filezilla";
        private static String FILEZILLA_FILE = "filezilla.exe";

        private static String SFTP_PORT = "22";
        
        // TODO: Add default filezilla install paths.
        private static String FILEZILLA_CURRENT_DIR = Path.Combine(Directory.GetCurrentDirectory(), FILEZILLA_FILE);

        //The arguments for filezilla
        private static String FILEZILLA_ARGS = "sftp://{0}:{1}@{2}:{3}";

        private Connection connection;
        private Process process;
        
        // command line string.
        private String BuildCommandString()
        {
            return FILEZILLA_CURRENT_DIR + FILEZILLA_ARGS;
        }
        
        public SFTPController(Connection connection)
        {
            this.connection = connection;
        }

        //Launch sftp client with a password
        public void StartSFTPProcess(String password)
        {
            //TODO This will probably break if the password is empty.
            String sftpCommand = FILEZILLA_CURRENT_DIR;
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

        public Process GetThisProcess()
        {
            return process;
        }
    }
}
