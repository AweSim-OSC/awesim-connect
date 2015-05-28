using System;
using System.Collections.Generic;
using System.Text;

namespace AweSimConnect.Models
{
    /// <summary>
    /// Maintains data for a connection.
    /// </summary>
    class Connection
    {
        //TODO: Add some handling to ensure inputs at least look valid.
        //TODO: PUA server regex match ten.osc.edu?
        //TODO: SSHHost match *.osc.edu?

        // EX: nxxxx.ten.osc.edu
        public String PUAServer { get; set; }

        public String GetServerAndPort()
        {
            String host = PUAServer + ":" + RemotePort;
            return host;
        }

        // 2036 for comsol
        // 5901 for vnc
        public int RemotePort { get; set; }

        // EX: 8080
        public int LocalPort { get; set; }

        // EX: oakley.osc.edu
        public String SSHHost { get; set; }

        // EX: an0018
        public String UserName { get; set; }

        // EX: XD4F893S
        // Design by contract enforces an 8-char password for VNC. 
        // 8 char pass is specified in RFB protocol.
        private string vncPassword;
        public String VNCPassword
        {

            get
            {
                return vncPassword;
            }
            set
            {
                if (value.Length != 8)
                {
                    vncPassword = null;
                    throw new ArgumentException("VNC passwords must be 8 characters.");
                }
                vncPassword = value;
            }
        }
    }
}
