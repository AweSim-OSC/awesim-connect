using System.Collections.Generic;
using System.Diagnostics;

namespace AweSimConnect.Models
{
    /// <summary>
    /// Use this class to keep track of the connection information for running processes.
    /// </summary>
    class ProcessData
    {
        // The running process
        public Process Process { get; set; }

        // The connection information associated with the process.
        public Connection Connection { get; set; }

        public ProcessData(Process process, Connection connection)
        {
            Process = process;
            Connection = connection;
        }

        // True if program has not exited.
        public bool IsRunning()
        {
            return !Process.HasExited;
        }

        // Kill the process.
        public void Kill()
        {
            Process.Kill();
        }

        //Static method to check for local ports.
        public static bool LocalPortExists(List<ProcessData> list, int port)
        {
            if (list.Count > 0)
            {
                foreach (ProcessData data in list)
                {
                    if (data.Connection.LocalPort == port)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
