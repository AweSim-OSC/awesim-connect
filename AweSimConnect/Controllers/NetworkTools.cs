using System;
using System.Net.Sockets;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// Static tools for checking network connections.
    /// </summary>
    class NetworkTools
    {
        private static int TELNET_PORT = 22;

        //Checks for connectivity to Default server (currently Oakley). Use for diagnostic.
        public static bool CanTelnetToDefault()
        {
            string oakley = new OSCClusterController().ClusterDomain();
            return CanTelnetToHost(oakley);
        }

        // Checks the localhost for an open port.
        public static bool IsPortOpenOnLocalHost(int port)
        {
            return IsPortOpen("localhost", port);
        }

        public static bool CanTelnetToHost(string hostname)
        {
            return IsPortOpen(hostname, TELNET_PORT);
        }

        // Checks to see if a port is open at a host address.
        public static bool IsPortOpen(String host, int port)
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                try
                {
                    socket.Connect(host, port);
                    return true;
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.ConnectionRefused)
                    {
                        return false;
                    }
                }
            return false;
        }
    }
}
