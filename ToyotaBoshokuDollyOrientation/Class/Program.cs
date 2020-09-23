using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ToyotaBoshokuDollyOrientation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///    

        public static frmGiris frmGiris;
        //public static frmMain frmMain;
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSplash());
            frmGiris = new frmGiris();
            Application.Run(frmGiris);



        }
    }
}
