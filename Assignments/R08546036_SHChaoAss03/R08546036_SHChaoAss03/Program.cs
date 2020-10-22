using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546036_SHChaoAss03
{

    public delegate int FunctionTakesNoArgumentReturnInt();

    static class Program
    {

        static int f()
        {
            MessageBox.Show("F()");
            return 1;

        }

        static int g()
        {
            MessageBox.Show("G()");
            return 1;

        }

        static double h()
        {
            MessageBox.Show("H()");
            return 1;

        }

        static int j(int k)
        {
            MessageBox.Show("J()");
            return 1;

        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Delegate: Assign 委派 函式指標(集合)

            FunctionTakesNoArgumentReturnInt ptr;
            //ptr = f;
            //ptr();
            //ptr = g;
            //ptr();

            ptr = f;
            ptr += g;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
