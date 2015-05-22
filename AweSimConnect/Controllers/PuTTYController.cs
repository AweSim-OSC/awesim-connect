using AweSimConnect.Models;
using AweSimConnect.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Text;

namespace AweSimConnect.Controllers
{
    class PuTTYController
    {
        private Connection connection;

        internal Connection Connection
        {
            get { return connection; }
            set { connection = value; }
        }
        
        //The full current path of the plink executable.
        private static String PLINK_CURRENT_DIR = Path.Combine(Directory.GetCurrentDirectory(), "plink.exe");

        // PuTTY/Plink command line argument placeholder.
        private static String PUTTY_ARGS_PASSWORD = "-ssh -L {0}:{1} -C -N -T {2}@{3} -l {4} -pw {5}";
        private static String PUTTY_ARGS_NOPASSWORD = "-ssh -L {0}:{1}:{0} -C -N -T {2}@{3} -l {4}";
                
        public PuTTYController(Connection connection)
        {
            InstallPlink();
            this.connection = connection;
        }

        //Installs plink.exe to current directory if it isn't there.
        public bool InstallPlink()
        {
            if (!IsPlinkInstalled())
            {
                using (FileStream fs = new FileStream(PLINK_CURRENT_DIR, FileMode.CreateNew, FileAccess.Write))
                {
                    byte[] bytes = getPlink();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }            
            return true;
        }

        //Gets plink.exe from the embedded resources.
        private byte[] getPlink()
        {
            return Resources.plink;
        }

        //Launch Plink without a password
        //Currently not implemented. the form validates for password.
        public void StartPlinkProcess()
        {
            String plinkCommand = String.Format(PLINK_CURRENT_DIR);
            ProcessStartInfo info = new ProcessStartInfo(plinkCommand);
            info.Arguments = String.Format(PUTTY_ARGS_NOPASSWORD, this.connection.RedirectPort, this.connection.PUAServer, this.connection.UserName, this.connection.SSHHost, this.connection.UserName);
            info.UseShellExecute = true;

            try
            {
                Process.Start(info);
            }
            catch (Exception ex)
            {

            }
        }

        //Launch Plink with a password
        public void StartPlinkProcess(String password)
        {
            String plinkCommand = String.Format(PLINK_CURRENT_DIR);
            ProcessStartInfo info = new ProcessStartInfo(plinkCommand);
            info.Arguments = String.Format(PUTTY_ARGS_PASSWORD, this.connection.RedirectPort, this.connection.PUAServer, this.connection.UserName, this.connection.SSHHost, this.connection.UserName, password);
            info.UseShellExecute = true;

            try
            {
                Process.Start(info);
            }
            catch (Exception ex)
            {

            }
        }

        // Check to see if plink exists in the AweSim connect folder.
        internal bool IsPlinkInstalled()
        {
            return FileController.ExistsOnPath("plink.exe");
        }
    }
}
