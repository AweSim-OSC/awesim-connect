using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AweSimConnect.Controllers
{
    /// <summary>
    /// Static tools for getting file locations on disk.
    /// </summary>
    class FileController
    {
        public static String FindExecutableInProgramFiles(String filename)
        {
            String programsPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            DirectoryInfo dirInfo = new DirectoryInfo(programsPath);
            FileInfo[] files = dirInfo.GetFiles(filename, SearchOption.AllDirectories);
            if (files.Length > 0)
            {
                return files[0].FullName.ToString();
            }
            else
                return "";
        }

        public static String SearchProgramFileFoldersForExecutableWithFolderPatternMatch(String fileName, String folderPattern)
        {
            String programsPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            DirectoryInfo dirInfo = new DirectoryInfo(programsPath);
            foreach (DirectoryInfo subDirInfo in dirInfo.GetDirectories())
            {
                bool contains = subDirInfo.FullName.ToString().IndexOf(folderPattern, StringComparison.CurrentCultureIgnoreCase) >= 0;
                if (contains) {
                    FileInfo[] files = subDirInfo.GetFiles(fileName, SearchOption.AllDirectories);
                    if (files.Length > 0) {
                        return files[0].FullName.ToString();
                    }
                }
            }
            return "";
        }

        public static bool IsProcessRunning(String processName) {
            Process[] pname = Process.GetProcessesByName(processName);
            return ((pname.Length != 0) ? true : false);
        }
        
        public static bool ExistsOnPath(String fileName)
        {
            if (GetFullPath(fileName) != null)
            {
                return true;
            }
            return false;
        }

        public static String GetFullPath(String fileName)
        {
            if (File.Exists(fileName))
            {
                return Path.GetFullPath(fileName);
            }

            String values = Environment.GetEnvironmentVariable("Path");

            foreach (String path in values.Split(';'))
            {
                try
                {
                    String fullPath = Path.Combine(path.Trim(), fileName);
                    if (File.Exists(fullPath))
                    {
                        return fullPath;
                    }
                }
                catch (Exception)
                {

                }
            }
            return null;
        }
    }
}
