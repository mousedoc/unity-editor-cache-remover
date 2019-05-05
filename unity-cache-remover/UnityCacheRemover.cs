using System;
using System.Collections.Generic;
using System.IO;
using Utillity;

namespace unity_cache_remover
{
    internal class UnityCacheRemover
    {
        public readonly string UnityFolderName = "Unity";

        private readonly IEnumerable<string> pathsToRemove = new List<string>()
        {
            AppDataPath.Local,
            AppDataPath.LocalLow,
            AppDataPath.Roaming,
        };

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var path in pathsToRemove)
            {
                if (string.IsNullOrEmpty(path))
                    continue;

                string fullPath = Path.Combine(path, UnityFolderName);
                DeleteFiles(fullPath);
            }
        }

        private void DeleteFiles(string path)
        {
            var targetDirectory = new DirectoryInfo(path);

            foreach (var file in targetDirectory.GetFiles())
            {
                try
                {
                    Logger.Log("Delete file - " + file.FullName);
                    file.Delete();
                }
                catch (Exception exception)
                {
                    Logger.Log("Error to delete file : {0}\r\n{1}", file.FullName, exception);
                }
            }

            foreach (var directory in targetDirectory.GetDirectories())
            {
                try
                {
                    Logger.Log("Delete direcotry - " + directory.FullName);
                    directory.Delete(true);
                }
                catch (Exception exception)
                {
                    Logger.Log("Error to delete direcotry : {0}\r\n{1}", directory.FullName, exception);
                }
            }
        }
    }
}