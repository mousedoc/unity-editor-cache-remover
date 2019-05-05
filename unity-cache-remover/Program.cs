using System;
using Utillity;

namespace unity_cache_remover
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new UnityCacheRemover().Run();

            Logger.Warn("Press a key");
            Console.ReadKey();
        }
    }
}