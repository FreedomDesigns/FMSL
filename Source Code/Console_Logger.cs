/*
	===========================================
	Component: Freedom's Minimal and Stylish Logger [FMSL]
	Sub-component: Console Writer
	Purpose: Lightweight and Basic Logger

	Initial author: Freedom Designs
    "Never Judge A Coder By Their Code."
	Started: 2015-08-19
	===========================================
    NOTE: This Is Not Finish And Will Contain Bug's Or Issue's.
*/

using Freedom_Logger;
using System;
using System.IO;

namespace FMSL
{
    public class Console_Logger
    {
        private static string Path_Logged = @"m3demo";  // Sets Default Path For The Storage Of Logs.
        private static DateTime NOW = DateTime.Now;     // Gets Time Of Current PC/User.

        // This allows the user to externally set select options. 
        public static bool Log_To_File { private get; set; }                                                // Allows The User To Create Log Files Of Messages That Pass Though This [Default = FALSE].
        public static string Log_Path { private get { return Path_Logged; } set { Path_Logged = value; } }  // Allows The User To Change The Location Of Where Log Files Are Stored [Default = FALSE].

        // TODO: Have a look at changing the time format [Removing the seconds].
        private static string Log_Name = string.Format("{0}/{1:MM-dd-yy_H.mm}.log", Path_Logged, NOW); // Sets The Name Of Log Files.

        // Type Numbers
        // ------------
        // Low Importance - Cyan
        // Warning - Yellow
        // Error - Red
        // Debug - Green
        // Info - Magenta

        public static void ConsoleColour(string Message, LogLevel Level)
        {
            string LogLine = null;

            if (Message != null)
            {
                switch (Level)
                {
                    case LogLevel.Low:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        LogLine = string.Format("{0} - {1} {2}", NOW, "Notice:", Message);
                        break;
                    case LogLevel.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        LogLine = string.Format("{0} - {1} {2}", NOW, "Warning:", Message);
                        break;
                    case LogLevel.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        LogLine = string.Format("{0} - {1} {2}", NOW, "Error:", Message);
                        break;
                    case LogLevel.Debug:
                        Console.ForegroundColor = ConsoleColor.Green;
                        LogLine = string.Format("{0} - {1} {2}", NOW, "Debug:", Message);
                        break;
                    case LogLevel.Info:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        LogLine = string.Format("{0} - {1} {2}", NOW, "Info:", Message);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        LogLine = string.Format("{0} - {1} {2}", NOW, "Error:", "Invalid Number");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                LogLine = string.Format("{0} - {1} {2}", NOW, "Error:", "Um You Need To Give Me Text!");
            }
            LogWrite(LogLine);
            Console.ResetColor();
        }

        /* ----------------------------------------------------------
           * All Threads Below Should Not Display Any Console Text. *
           ---------------------------------------------------------- */

        private static void LogWrite(string Message)
        {
            // 1. Write Line To Console
            Console.WriteLine(Message);

            // 2. Check Is User Wants Message Logged, If So Send To The Right Thread.
            if (Log_To_File == true)
            {
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
                File.CreateText(Log_Name);
            }

            // 3. Write To File
            StreamWriter sw = new StreamWriter(Log_Name, true);
            sw.WriteLine(Message);
            sw.Close();
        }
    }
}
