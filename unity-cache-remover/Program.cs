using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unity_cache_remover
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new UnityCacheRemover();

            program.Run();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press a key");
            Console.ReadKey();
        }
    }
}
