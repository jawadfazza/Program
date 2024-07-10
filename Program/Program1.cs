using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Program.SMC;

namespace Program
{
    static class Program1
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //DateTime date = new DateTime(2014, 9, 30);

            Application.Run(new Main());

        }
    }
}

