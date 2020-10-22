using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546023KWChangAss05
{
    // C/C++ pointer, function pointer
    // C# delegate // 委派 function pointer collection

    //define event function
    //public delegate int FunctionTakesOneIntAndReturnInt(int input1);
    //public delegate void FunctionTakeNoArgumentReturnNothing();

    static class Program
    {

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Form1());

            Application.Run(new MainForm());
        }
    }
}
