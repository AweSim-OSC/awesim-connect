using System;

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
        private String _vncPassword;
        public String VNCPassword
        {
            get
            {
                if (_vncPassword.Length > 8)
                {
                    throw new ArgumentException("VNC Passwords are 8 characters");
                }
                return _vncPassword;
            }
            set
            {
                    _vncPassword = value;                
            }
        }

        public bool SetValidVNCPassword(String pass)
        {
            if (pass.Length == 8)
            {
                _vncPassword = pass;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
