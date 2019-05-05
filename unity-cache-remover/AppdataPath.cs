using System;
using System.IO;

namespace unity_cache_remover
{
    static class AppDataPath
    {
        public static string Local
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            }
        }

        public static string LocalLow
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow");
            }
        }

        public static string Roaming
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }
    }
}
