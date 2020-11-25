using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546036_SHChaoAss04
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
            try
            {
                Application.Run(new MainForm());
            }
            catch (System.OverflowException Exception) {
                MessageBox.Show("System overflowed, restart app.");
                Application.Restart();
                Environment.Exit(0);
            }
            
        }
    }
}
