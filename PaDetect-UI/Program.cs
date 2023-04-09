using System.Diagnostics;

namespace PaDetect_UI {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // Don't continue if the running process is on running.
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1) return;
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}