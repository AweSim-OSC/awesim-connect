using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AweSimConnect.Controllers
{
    class ProcessController
    {


        public static bool IsProcessRunning(String processName)
        {
            Process[] pname = Process.GetProcessesByName(processName);
            return ((pname.Length != 0) ? true : false);
        }

        public static bool IsProcessRunning(int processID)
        {
            try
            {
                Process pname = Process.GetProcessById(processID);
                //This should always return true, exception is thrown if process not found
                return (pname != null);
            }
            catch (Exception)
            {
                return (false);
            }
        }

        public static void KillProcess(Process process)
        {
            
        }

    }
}
