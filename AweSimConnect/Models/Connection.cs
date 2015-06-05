using System;
using System.Collections.Generic;

namespace AweSimConnect.Models
{
    /// <summary>
    /// Maintains data for a connection.
    /// </summary>
    class Connection
    {
        public static int COMSOL_SERVER_PORT = 2036;
        public static int VNC_DISPLAY_DEFAULT = 5901;

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
        public String VNCPassword { get; set; }

        public bool SetValidVNCPassword(String pass)
        {
            if (pass.Length == 8)
            {
                VNCPassword = pass;
                return true;
            }
            else
            {
                VNCPassword = "";
                return false;
            }
        }

        //Static method to check for local ports.
        public static bool LocalPortExists(List<Connection> list, int port)
        {
            if (list.Count > 0)
            {
                foreach (Connection data in list)
                {
                    if (data.LocalPort == port)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
