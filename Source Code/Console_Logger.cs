/*
	===========================================
	Component: Freedom's Minimal and Stylish Logger [FMSL]
	Sub-component: Console Writer
	Purpose: Lightweight and Basic Logger

	Initial author: Freedom Designs
	Started: 2015-08-19
	===========================================
    NOTE: This Is Not Finish And Will Contain Bug's Or Issue's.
*/

using System;
using System.IO;

namespace FMSL
{
    public class Console_Logger
    {
        // This allows the user to externally set if a log file is created. 
        public static bool Log_To_File { private get; set; }

        private static string Path_Logged = @"m3demo";
        public static string Log_Path { private get { return Path_Logged; } set { Path_Logged = value; } }

        private static DateTime NOW = DateTime.Now;
        private static string Log_Name = string.Format("{0}/{1:MM-dd-yy_H.mm.ss}.log",Path_Logged ,NOW);

        public static void ConsoleColour(string Message, int Type = 0)
        {
            // Type Numbers
            // 0 = Low Importance - Cyan
            // 1 = Warning - Yellow
            // 2 = Error - Red
            // 3 = Debug - Green
            // 4 = Info - Magenta

            if (Message != null)
            {
                if (Type == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    LogWrite(string.Format("{0} - {1} {2}", NOW, "Notice:", Message));
                }
                else if (Type == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    LogWrite(string.Format("{0} - {1} {2}", NOW, "Warning:", Message));
                }
                else if (Type == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    LogWrite(string.Format("{0} - {1} {2}", NOW, "Error:", Message));
                }
                else if (Type == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    LogWrite(string.Format("{0} - {1} {2}", NOW, "Debug:", Message));
                }
                else if (Type == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    LogWrite(string.Format("{0} - {1} {2}", NOW, "Info:", Message));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    LogWrite(string.Format("{0} - {1} {2}", NOW, "Error:", "Invalid Number"));
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                LogWrite(string.Format("{0} - {1} {2}", NOW, "Error:", "Um You Need To Give Me Text!"));
            }
            Console.ResetColor();
        }

        private static void LogWrite(string Message)
        {
            // 1. Write Line To Console
            Console.WriteLine(Message);

            // 2. Check Is User Wants Message Logged, If So Send To The Right Thread.
            if (Log_To_File == true)
            {
                Console.WriteLine("I'm Loved ^^");
                WriteToFile(Message);
            }
        }

        private static void WriteToFile(string Message)
        {
            // 1. Check If Log Path Exists
            if (!File.Exists(Log_Path))
            {
                Directory.CreateDirectory(Log_Path);
            }

            // 2. Check If Log File Exists
            if (!File.Exists(Log_Name))
            {
                Console.WriteLine(Log_Name);
                File.CreateText(Log_Name);
            }

            using (StreamWriter sw = File.AppendText(Log_Name))
            {
                DateTime NOW = DateTime.Now;
                sw.WriteLine(Message);
                sw.Close();
            }
        }
    }
}
