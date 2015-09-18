using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SpaceInvaders
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
		/// STAThreadAttribute indicates that the COM threading model 
		/// for the application is single-threaded apartment. 
		/// This attribute must be present on the entry point
		///  of any application that uses Windows Forms; 
		/// if it is omitted, the Windows components might not work correctly. 
		/// If the attribute is not present, the application uses the multithreaded apartment model, 
		/// which is not supported for Windows Forms.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm());
        }
    }
}
