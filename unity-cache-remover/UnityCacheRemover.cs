using System;
using System.Collections.Generic;
using System.IO;

namespace unity_cache_remover
{
    class UnityCacheRemover
    {
        public readonly string unityFoldeName = "Unity";

        public void Run()
        {
            List<string> appdataPaths = new List<string>()
            {
                AppdataPath.Local,
                AppdataPath.LocalLow,
                AppdataPath.Roaming,
            };

            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var path in appdataPaths)
            {
                if (string.IsNullOrEmpty(path))
                    continue;

                string fullPath = Path.Combine(path, unityFoldeName);
                DeleteFiles(fullPath);
            }
        }

        private void DeleteFiles(string targetPath)
        {
            var targetDirectory = new DirectoryInfo(targetPath);

            foreach (var file in targetDirectory.GetFiles())
            {
                Console.WriteLine("Delete file - " + file.FullName);
                file.Delete();
            }

            foreach (var directory in targetDirectory.GetDirectories())
            {
                Console.WriteLine("Delete direcotry - " + directory.FullName);
                directory.Delete(true);
            }
        }
    }
}

