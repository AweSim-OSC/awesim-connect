using System;
using System.Collections.Generic;

namespace AweSimConnect.Models
{
    /// <summary>
    /// Maintains data for a connection.
    /// 
    /// H = PUA server Hostname
    /// R = The remote port
    /// L = The local port (not needed since the app generally maps to an open port)
    /// U = The username
    /// V = The VNC Password
    /// 
    /// </summary>
    class Connection
    {
        public static int COMSOL_SERVER_PORT = 2036;
        public static int VNC_DISPLAY_DEFAULT = 5901;

        //TODO: Add some handling to ensure inputs at least look valid.
        //TODO: PUA server regex match ten.osc.edu?
        //TODO: SSHHost match *.osc.edu?

        // EX: nxxxx.ten.osc.edu
        public string PUAServer { get; set; }

        public string H
        {
            get { return PUAServer; }
            set { PUAServer = value; }
        }

        public string GetServerAndPort()
        {
            String host = PUAServer + ":" + RemotePort;
            return host;
        }

        // 2036 for comsol
        // 5901-n for vnc
        public int RemotePort { get; set; }

        public int R
        {
            get { return RemotePort; }
            set { RemotePort = value; }
        }

        // EX: 8080
        public int LocalPort { get; set; }

        public int L
        {
            get { return LocalPort; }
            set { LocalPort = value; }
        }

        // EX: oakley.osc.edu
        public string SSHHost { get; set; }

        public string S
        {
            get { return SSHHost; }
            set { SSHHost = value; }
        }

        // EX: an0018
        public string UserName { get; set; }

        public string U
        {
            get { return UserName; }
            set { UserName = value; }
        }

        // EX: XD4F893S
        public string VNCPassword { get; set; }

        public string V
        {
            get { return VNCPassword; }
            set { VNCPassword = value; }
        }

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
