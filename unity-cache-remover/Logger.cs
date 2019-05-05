using System;

namespace Utillity
{
    public static class Logger
    {
        public static void Log(string format, params object[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(format, args);

            Reset();
        }

        public static void Warn(string format, params object[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(format, args);

            Reset();
        }

        public static void Error(string format, params object[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Re;

            Console.WriteLine(format, args);

            Reset();
        }


        private static void Reset()
        {
            Console.BackgroundColor= ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}