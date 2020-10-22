using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546036_SHChaoAss02
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static int Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // define a new obj to run by the application, while also defining the original class of Form01 "Form"

            // Original code created by Visual Studio (define the obj and run it)
            //Application.Run(new Form01());

            // Original class "Form"
            //Form myFormObj = new Form();

            // New an obj before execution (with Form01 and also Form obj type)
            Ass02Form myFormObj = new Ass02Form();
            //Form myFormObj = new Form01();

            // Run the obj
            Application.Run(myFormObj);

            // return the code after the program is completed
            int return_code = 0;
            return return_code;
        }
    }
}
