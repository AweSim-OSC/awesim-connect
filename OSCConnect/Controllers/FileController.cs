using System;
using System.IO;
using System.Windows.Forms;

namespace OSCConnect.Controllers
{
    /// <summary>
    /// Static tools for getting file locations on disk.
    /// </summary>
    class FileController
    {
        public static string FILE_FOLDER = "AweSimFiles";
        //public static string FILE_FOLDER_PATH = Path.Combine(Directory.GetCurrentDirectory(), FILE_FOLDER);
        public static string FILE_FOLDER_PATH_ADMIN = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), FILE_FOLDER);
        public static string FILE_FOLDER_PATH_TEMP = Path.Combine(Path.GetTempPath(), FILE_FOLDER);
        
        // Create an empty AweSim files folder.
        public static bool CreateAweSimFilesFolder()
        {
            try
            {
                Directory.CreateDirectory(FILE_FOLDER_PATH_ADMIN);
            }
            catch (Exception)
            {
                Directory.CreateDirectory(FILE_FOLDER_PATH_TEMP);
                return false;
            }
            return true;
        }

        // Delete the AweSim files folder recursively.
        public static void DeleteAweSimFilesFolder()
        {
            try
            {
                Directory.Delete(FILE_FOLDER_PATH_ADMIN, true);
                Directory.Delete(FILE_FOLDER_PATH_TEMP, true);
            }
            catch (Exception)
            {
                //Attempt to clean up folder failed.
                //TODO Maybe add an error log.
            }
        }

        public static void DeleteAweSimFilesFolder(bool admin)
        {
            
            try
            {
                if (admin)
                {
                    Directory.Delete(FILE_FOLDER_PATH_ADMIN, true);
                }
                else
                {
                    Directory.Delete(FILE_FOLDER_PATH_TEMP, true);
                }
            }
            catch (Exception)
            {
                //Attempt to clean up folder failed.
                //TODO Maybe add an error log.
            }
        }

        public static bool DeployResource(byte[] resource, string fileName, bool admin)
        {
            return admin
                ? DeployResourceToAweSimFilesFolder(resource, fileName)
                : DeployResourceToTempFolder(resource, fileName);
        }

        public static bool DeployResourceToAweSimFilesFolder(byte[] resource, string fileName)
        {
            try
            {
                if (!IsResourceInstalledInAweSimFolder(fileName))
                    {
                        string path = Path.Combine(FILE_FOLDER_PATH_ADMIN, fileName);
                        using (FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
                        {
                            fs.Write(resource, 0, resource.Length);
                        }
                    }
            }
            catch (DirectoryNotFoundException)
            {
                return false;
            }
            return true;
        }
        public static bool DeployResourceToTempFolder(byte[] resource, string fileName)
        {
            try
            {
                if (!IsResourceInstalledInTempFolder(fileName))
                {
                    string path = Path.Combine(FILE_FOLDER_PATH_TEMP, fileName);
                    using (FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
                    {
                        fs.Write(resource, 0, resource.Length);
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                return false;
            }
            return true;
        }

        public static bool IsResourceInstalledInAweSimFolder(string fileName)
        {
            return ExistsOnPath(Path.Combine(FILE_FOLDER_PATH_ADMIN, fileName));
        }

        public static bool IsResourceInstalledInTempFolder(string fileName)
        {
            return ExistsOnPath(Path.Combine(FILE_FOLDER_PATH_TEMP, fileName));
        }

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
            if (!programsPath.Contains("x86"))
            {
                programsPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + " (x86)";
                try
                {
                    dirInfo = new DirectoryInfo(programsPath);
                    foreach (DirectoryInfo subDirInfo in dirInfo.GetDirectories())
                    {
                        bool contains = subDirInfo.FullName.ToString().IndexOf(folderPattern, StringComparison.CurrentCultureIgnoreCase) >= 0;
                        if (contains)
                        {
                            FileInfo[] files = subDirInfo.GetFiles(fileName, SearchOption.AllDirectories);
                            if (files.Length > 0)
                            {
                                return files[0].FullName.ToString();
                            }
                        }
                    }
                }
                catch
                {
                    
                }
                
            }
            return "";
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

            if (File.Exists(Path.Combine(FILE_FOLDER, fileName)))
            {
                return Path.GetFullPath(Path.Combine(FILE_FOLDER, fileName));
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
