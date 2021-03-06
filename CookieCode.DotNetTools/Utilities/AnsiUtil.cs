using System;
using System.Linq;

namespace CookieCode.DotNetTools.Utilities
{
    public static class AnsiUtil
    {
        public static string UserColor = Ansi.FGreen;

        public static ConsoleKey Ask(string askText, params ConsoleKey?[] validKeys)
        {
            Console.Write(askText);

            while (true)
            {
                var key = Console.ReadKey(true);
                if (validKeys.Contains(key.Key))
                {
                    WriteUserResponse(key.Key);
                    return key.Key;
                }
                else
                {
                    Console.Beep();
                }
            }
        }

        public static bool Confirm(string confirmText, bool? defaultValue)
        {
            var choice = Ask(
                confirmText,
                ConsoleKey.Y,
                ConsoleKey.N,
                defaultValue.HasValue ? ConsoleKey.Enter : null);

            switch (choice)
            {
                case ConsoleKey.Y:
                    WriteUserResponse(choice);
                    return true;

                case ConsoleKey.N:
                    WriteUserResponse(choice);
                    return false;

                case ConsoleKey.Enter:
                    WriteUserResponse(defaultValue.Value ? ConsoleKey.Y : ConsoleKey.N);
                    return defaultValue.Value;

                default:
                    throw new NotImplementedException();
            }
        }

        public static void WriteShortPathProgress(string path)
        {
            var shortPath = PathUtil.GetShortPath(path);
            WriteProgress(shortPath);
        }

        public static void WriteProgress(string text)
        {
            Console.WriteLine($"\r{text}{Ansi.ClearLineRight}");
        }

        private static void WriteUserResponse(ConsoleKey consoleKey)
        {
            Console.WriteLine($"{UserColor}{consoleKey}{Ansi.Reset}");
        }
    }
}
