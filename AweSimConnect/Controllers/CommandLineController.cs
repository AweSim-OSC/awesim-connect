using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
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

        internal static Connection ProcessCommandLineString(string commandArgString)
        {
            Connection newConnection = new Connection();

            try
            {
                string connectionString = commandArgString;

                // If the user used the URI as the command line string, remove the prefix.
                connectionString = Regex.Replace(connectionString, RegistryHook.URI_PREFIX, "", RegexOptions.IgnoreCase);
                // Windows adds an extra slash to the end of the URI args, remove it.
                connectionString = Regex.Replace(connectionString, "/", "");

                if (connectionString.Contains("@"))
                {

                    int index = connectionString.IndexOf("@", StringComparison.Ordinal);
                    string vncInfo = connectionString.Substring(0, index);
                    if (vncInfo.Contains(":"))
                    {
                        newConnection.UserName = vncInfo.Split(':')[0];
                        newConnection.VNCPassword = vncInfo.Split(':')[1];
                    }
                    else
                    {
                        newConnection.UserName = vncInfo;
                    }
                    string hostInfo = connectionString.Substring(index + 1);
                    if (hostInfo.Contains(":"))
                    {
                        newConnection.PUAServer = hostInfo.Split(':')[0];
                        newConnection.RemotePort = int.Parse(hostInfo.Split(':')[1]);
                    }
                    else
                    {
                        throw new ArgumentException("Host must follow format <host>:<port>");
                    }

                }
                else
                {
                    newConnection.PUAServer = connectionString.Split(':')[0];
                    newConnection.RemotePort = int.Parse(connectionString.Split(':')[1]);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            return newConnection;
        }

        internal static Connection ProcessStringCollection(StringCollection collection)
        {
            //If there is more than one item, then there were some command line args passed in.
            if (collection.Count > 1)
            {
                return ProcessCommandLineString(collection[1]);
            }
            else
            {
                return new Connection();
            }
        }
    }
}
