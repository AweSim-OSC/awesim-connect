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


        
        //TODO: Make this dynamic.
        private static String PUTTY_COMMAND = @"C:\Program Files (x86)\PuTTY\putty.exe";
        private static String PLINK_CURRENT_DIR = Path.Combine(Directory.GetCurrentDirectory(), "plink.exe");
        
        
        private static String PUTTY_ARGS_PASSWORD = "-ssh -L {0}:{1} -C -N -T {2}@{3} -l {4} -pw {5}";
        private static String PUTTY_ARGS_NOPASSWORD = "-ssh -L {0}:{1} -C -N -T {2}@{3} -l {4}";

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
                    byte[] bytes = Resources.GetPlink();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            
            return true;
        }

        // Launch PuTTY
        public void startPuttyProcess(String password)
        {
            //TODO fix this to get the user's directory
            //TODO fix this to get the slected ssh server
            //TODO move putty stuff to a separate class
            String puttyCommand = String.Format(PUTTY_COMMAND); // -ssh -L {0}:{1} -C -N -T {2}@{3} -l {4} -pw {5}", this.redirectPort, this.hostName, tbUserName.Text, "oakley.osc.edu", tbUserName.Text, tbPassword.Text);
            ProcessStartInfo info = new ProcessStartInfo(puttyCommand);
            info.Arguments = String.Format(PUTTY_ARGS_PASSWORD, this.redirectPort, this.hostName, this.userName, this.sshHost, this.userName, password);
            info.UseShellExecute = false;
            info.WindowStyle = ProcessWindowStyle.Minimized;

            try
            {
                Process.Start(info);
            }
            catch (Exception ex)
            {
                
            }
        }

        internal bool IsPlinkInstalled()
        {
            return FileController.ExistsOnPath("plink.exe");
        }
    }
}
