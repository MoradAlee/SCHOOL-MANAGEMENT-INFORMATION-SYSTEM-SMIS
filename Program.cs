using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using School_Management_System.UI;
using School_Management_System.Reporting;

namespace School_Management_System
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
            Application.Run(new Gov__High_School_Topsin  ());
        }
    }
}
