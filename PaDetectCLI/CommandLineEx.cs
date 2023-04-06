using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaDetectCLI {
    internal static class CommandLineEx {
        private static readonly object locker = new object();

        internal enum PrintType {
            None,
            Verbose,
            Question,
            Info,
            Warning,
            Error
        }

        internal static bool Decision(string message, PrintType pType = PrintType.Question) {
            ConsoleKey response;
            while (true) {
                ColorizeStatusInfo(pType);
                Console.Write(message + " [y/n]:");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter) {
                    Console.WriteLine();
                    continue;
                }
                if (response == ConsoleKey.Y || response == ConsoleKey.N)
                    return response == ConsoleKey.Y;
            }
        }

        internal static void PrintLine(string message, PrintType pType = PrintType.None, bool pDate = false, bool delLine = false) {
            Print(message + Environment.NewLine, pType, pDate, delLine);
        }

        internal static void Print(string message, PrintType pType = PrintType.None, bool pDate = false, bool delLine = false) {
            lock (locker) {
                if (delLine) ClearLine();
                if (pDate) Console.Write(DateTime.Now.ToString("[dd/MM/yyyy hh:mm:ss]"));
                ColorizeStatusInfo(pType);
                Console.Write(message);
            }
        }

        internal static void ClearLine() {
            lock (locker) {
                int cLineCur = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, cLineCur);
            }
        }

        internal static void PrintProgressBar(long current, long max, string msg = "", int progLen = 25) {
            if (current > max || max < 1) return;
            if (progLen < 1 || progLen > 25) progLen = 25;
            lock (locker) {
                StringBuilder b = new StringBuilder();
                b.Append('[');
                double perce = current * 100 / max;
                for (int i = 0; i < progLen; i++) {
                    double writtenPerce = i * 100 / progLen;
                    b.Append(writtenPerce >= perce ? " " : "=");
                }
                b.Append("] " + Math.Round(perce, 2).ToString() + "%" + (string.IsNullOrEmpty(msg) ? "" : " [" + msg + "]"));
                ClearLine();
                Console.Write(b.ToString());
            }
        }

        private static void ColorizeStatusInfo(PrintType pType) {
            switch (pType) {
                case PrintType.None:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[ ]: ");
                    break;
                case PrintType.Verbose:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("[*]: ");
                    break;
                case PrintType.Info:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[i]: ");
                    break;
                case PrintType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow; ;
                    Console.Write("[!]: ");
                    break;
                case PrintType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[x]: ");
                    break;
                case PrintType.Question:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("[?]: ");
                    break;
            }
            Console.ResetColor();
        }
    }
}
