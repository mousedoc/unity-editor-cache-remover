using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Utillity;

namespace unity_cache_remover
{
    internal class UnityCacheRemover
    {
        public static readonly string UnityFolderName = "Unity";

        private readonly List<string> AppDataPaths = new List<string>()
        {
            AppDataPath.Local,
            AppDataPath.LocalLow,
            AppDataPath.Roaming,
        };

        private readonly List<string> IgnorePaths = new List<string>()
        {
            Path.Combine(AppDataPath.Local, UnityFolderName, "cache", "packages"),
        };

        private bool IsRunningUnity
        {
            get
            {
                Process[] unityProcess = Process.GetProcessesByName("unity");
                return unityProcess != null && unityProcess.Length > 0;
            }
        }

        public void Run()
        {
            if (IsRunningUnity)
            {
                Logger.Error("Unity is running. Please exit Unity");
                return;
            }

            foreach (var path in AppDataPaths)
            {
                if (string.IsNullOrEmpty(path))
                    continue;

                string fullPath = Path.Combine(path, UnityFolderName);
                DeleteFiles(fullPath);
            }
        }

        private bool IsIgnorePath(string fullPath)
        {
            foreach (var ignorePath in IgnorePaths)
            {
                if (fullPath.Contains(ignorePath) || ignorePath.Contains(fullPath))
                    return true;
            }

            return false;
        }

        private void DeleteFiles(string path)
        {
            var targetDirectory = new DirectoryInfo(path);

            foreach (var file in targetDirectory.GetFiles())
            {
                if (IsIgnorePath(file.FullName))
                    continue;

                try
                {
                    Logger.Log("Delete file - " + file.FullName);
                    file.Delete();
                }
                catch (Exception exception)
                {
                    Logger.Error("Error to delete file : {0}\r\n{1}", file.FullName, exception);
                }
            }

            foreach (var directory in targetDirectory.GetDirectories())
            {
                if (IsIgnorePath(directory.FullName))
                    continue;

                try
                {
                    Logger.Log("Delete direcotry - " + directory.FullName);
                    directory.Delete(true);
                }
                catch (Exception exception)
                {
                    Logger.Error("Error to delete direcotry : {0}\r\n{1}", directory.FullName, exception);
                }
            }
        }
    }
}