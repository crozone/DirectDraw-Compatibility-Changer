using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

[assembly: SupportedOSPlatform("windows")]
namespace DirectDrawCompatibilityChanger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
