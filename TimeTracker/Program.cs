using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;

namespace TimeTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitializeLogging();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TimeTracker.MainForm());
        }

        private static void InitializeLogging()
        {
           // XmlConfigurator.Configure(new System.IO.FileInfo(AssemblyLoadEventArgs[0]))

        }
    }
}
