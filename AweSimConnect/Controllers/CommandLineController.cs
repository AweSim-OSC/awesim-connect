using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;

namespace AweSimConnect.Controllers
{
    class CommandLineController
    {
        public static string GetCommandLineArgs(StartupEventArgs eventArgs)
        {
            string args = "";
            if (eventArgs.CommandLine.Count > 1)
            {
                args += eventArgs.CommandLine[1];
            }
            return args;
        }

        public static string GetCommandLineArgs(StartupNextInstanceEventArgs eventArgs)
        {
            string args = "";
            if (eventArgs.CommandLine.Count > 1)
            {
                args += eventArgs.CommandLine[1];
            }
            return args;
        }
    }
}
