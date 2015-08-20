FMSL | Freedom's Minimal and Stylish Logger
=================================================================================

Created by Freedom (https://www.youtube.com/user/FreedomDesignsz)  

Brief Summary
=================================================================================

This project aims to provide the ability to have a easy and simple way to log
messages/data to either log to CLI [Command-Line Interface] or/and to log file.    

**[Download](https://github.com/FreedomDesigns/FMSL/releases/latest)**

Threads
=================================================================================

* `ConsoleColour(string Message, int Type = 0)`

    | [Int] Type | Tag            | Colour  |
    |:----------:|:--------------:|:-------:|
    | 0          | Low Importance | Cyan    |
    | 1          | Warning        | Yellow  |
    | 2          | Error          | Red     |
    | 3          | Debug          | Green   |
    | 4          | Info           | Magenta |

  * Example
   ```c#
   using FMSL;
   
   private void Example()
   {
      Console_Logger.ConsoleColour("Hello World", 3);
   }
   ```
   
* `Log_To_File = [true/false]`

  * Enables if messages are logged to file

    * Example
   ```c#
   using FMSL;
   
   Console_Logger.Log_To_File = true; // Enables Logging To File.
   ```
