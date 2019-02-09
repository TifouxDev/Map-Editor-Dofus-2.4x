using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.IO;

namespace ShadowEmu.Common.Logger
{
    public static class ConsoleLogger
    {
        public static object Locker = new object();
        public static bool DebugMode = true;

        public static string GetFormattedDate
        {
            get
            {
                return DateTime.Now.ToString().Replace(":", ".").Replace("\\", ".").Replace("/", ".");
            }
        }

        public static void Append(string header, string message, ConsoleColor headcolor, bool line = true)
        {
            lock (Locker)
            {
                Console.ForegroundColor = headcolor;
                Console.Write(header);
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (var c in message)
                {
                    if (c == '@')
                    {
                        if (Console.ForegroundColor == ConsoleColor.Gray)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    else
                    {
                        Console.Write(c);
                    }
                }

                if (line)
                    Console.Write("\n");
            }
        }

        public static void Infos(string message)
        {
            Append("[Infos]", message, ConsoleColor.Green);
        }

        public static void Error(string message)
        {
            Append("[Error]", message, ConsoleColor.Red);
        }

        public static void Debug(string message)
        {
            if (DebugMode)
            {
                Append("[Debug]", message, ConsoleColor.Magenta);
            }
        }

        public static void Warning(string message)
        {
            Append("[Warning]", message, ConsoleColor.Yellow);
        }

        /// <summary>
        /// For fun :p 
        /// </summary>
        public static void Header()
        {
            var text = Properties.Resources.header;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);      
        }

        public static void Stage(string stage)
        {
            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("                 ================ ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(stage);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ================ ");
            Console.Write("\n");
            Console.WriteLine();
        }
    }
}
