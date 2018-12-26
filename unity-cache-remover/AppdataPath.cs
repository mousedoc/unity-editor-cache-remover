using System;
using System.IO;

namespace unity_cache_remover
{
    static class AppdataPath
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
            // 일부러 추가 안함
            // 추가 방법 ; https://stackoverflow.com/questions/4494290/detect-the-location-of-appdata-locallow
            get { return null; }
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
