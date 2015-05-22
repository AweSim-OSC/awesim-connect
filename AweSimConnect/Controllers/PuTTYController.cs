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
        private String hostName;

        public String HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }
        private int redirectPort;

        public int RedirectPort
        {
            get { return redirectPort; }
            set { redirectPort = value; }
        }
        private String userName;

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private String sshHost;

        public String SshHost
        {
            get { return sshHost; }
            set { sshHost = value; }
        }
        
        
        // TODO: This is the default install location, make this dynamic.
        // PuTTY is unused for now. Switched to plink.
        // private static String PUTTY_COMMAND = @"C:\Program Files (x86)\PuTTY\putty.exe";

        //The full current path of the plink executable.
        private static String PLINK_CURRENT_DIR = Path.Combine(Directory.GetCurrentDirectory(), "plink.exe");

        // PuTTY/Plink command line argument placeholder.
        private static String PUTTY_ARGS_PASSWORD = "-ssh -L {0}:{1} -C -N -T {2}@{3} -l {4} -pw {5}";
        private static String PUTTY_ARGS_NOPASSWORD = "-ssh -L {0}:{1}:{0} -C -N -T {2}@{3} -l {4}";

        public PuTTYController()
        {
            new PuTTYController("", -1, "", "");
        }
        
        public PuTTYController(String hostName, int redirectPort, String userName, String sshHost)
        {
            this.hostName = hostName;
            this.redirectPort = redirectPort;
            this.userName = userName;
            this.sshHost = sshHost;
        }

        //Installs plink.exe to current directory
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

        private byte[] getPlink()
        {
            return Resources.plink;
        }

        //Launch Plink without a password
        public void StartPlinkProcess()
        {
            String plinkCommand = String.Format(PLINK_CURRENT_DIR);
            ProcessStartInfo info = new ProcessStartInfo(plinkCommand);
            info.Arguments = String.Format(PUTTY_ARGS_NOPASSWORD, this.redirectPort, this.hostName, this.userName, this.sshHost, this.userName);
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
            info.Arguments = String.Format(PUTTY_ARGS_PASSWORD, this.redirectPort, this.hostName, this.userName, this.sshHost, this.userName, password);
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
