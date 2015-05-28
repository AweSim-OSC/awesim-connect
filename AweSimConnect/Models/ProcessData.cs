using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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
            this.Process = process;
            this.Connection = connection;
        }

        // True if program has not exited.
        public bool IsRunning() {
            return !this.Process.HasExited;
        }

        // Kill the process.
        public void Kill()
        {
            this.Process.Kill();
        }
    }
}
