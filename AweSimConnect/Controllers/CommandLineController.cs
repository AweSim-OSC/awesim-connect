using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using AweSimConnect.Models;
using Microsoft.VisualBasic.ApplicationServices;

namespace AweSimConnect.Controllers
{
    class CommandLineController
    {
        private static AdvancedSettings _settings = new AdvancedSettings();

        public static string GetFirstCommandLineArg(StartupEventArgs eventArgs)
        {
            string args = "";
            if (eventArgs.CommandLine.Count > 1)
            {
                args += eventArgs.CommandLine[1];
            }
            return args;
        }

        public static string GetFirstCommandLineArg(StartupNextInstanceEventArgs eventArgs)
        {
            string args = "";
            if (eventArgs.CommandLine.Count > 1)
            {
                args += eventArgs.CommandLine[1];
            }
            return args;
        }
        
        // Saves a readonly collection of string arguments to the settings 
        // and updates settings to show commandline has been updated.
        public static bool SaveArgsToSettings(ReadOnlyCollection<string> commandLine)
        {
            StringCollection collection = new StringCollection();
            bool argsChanged = false;

            foreach (var commandLineArg in commandLine)
            {
                collection.Add(commandLineArg);
            }
            // The first argument of a command line array is always the file name
            // We only want to process the collection if there's more than one element.
            if (collection.Count > 1)
            {
                _settings.SetArgStringCollection(collection);
                _settings.SetArgsChanged();
                argsChanged = true;
            }
            return argsChanged;
        }

        public static StringCollection GetArgsFromSettings()
        {
            _settings.SetArgsChanged(false);
            return _settings.GetArgStringCollection();
        }

        public static bool IsArgsChanged()
        {
            return _settings.GetArgsChanged();
        }

        internal static Connection ProcessStringCollection(StringCollection collection)
        {
            //If there is more than one item, then there were some command line args passed in.
            if (collection.Count > 1)
            {
                Connection newConnection = new Connection();

                try
                {
                    string connectionString = collection[1];

                    if (connectionString.Contains("@"))
                    {

                        int index = connectionString.IndexOf("@", StringComparison.Ordinal);
                        string vncInfo = connectionString.Substring(0, index);
                        newConnection.UserName = vncInfo.Split(':')[0];
                        newConnection.VNCPassword = vncInfo.Split(':')[1];
                        string hostInfo = connectionString.Substring(index);
                        newConnection.PUAServer = hostInfo.Split(':')[0];
                        newConnection.RemotePort = int.Parse(hostInfo.Split(':')[1]);
                    }
                    else
                    {
                        newConnection.PUAServer = connectionString.Split(':')[0];
                        newConnection.RemotePort = int.Parse(connectionString.Split(':')[1]);
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Unable to process argument: \n\n"+ex.Message);
                }
                return newConnection;
            }
            else
            {
                return new Connection();
            }
        }
    }
}
