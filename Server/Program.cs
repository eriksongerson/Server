using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Server
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
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainF());

            Server.set_isEnabled(false);

            MainF.WorkingThread.Abort();

            while (MainF.WorkingThread.IsAlive) ;

            Environment.Exit(1);

        }
    }
}
