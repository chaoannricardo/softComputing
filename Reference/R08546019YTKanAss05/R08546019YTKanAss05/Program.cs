using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546019YTKanAss05
{
    //C、C++：pointer(function pointer)
    //定用事件需準備method、function(告訴你我定用這個事件，麻煩你認識我這個function(樣式、需要幾個參數))
    //事件與function息息相關
    //C#：delegate(委派)-骨子裡為function pointer的collection(集合)
    //5種datatype的其中一種(class、interface)

    //public delegate void FunctionTakeNoArgumentReturnNothing();  //沒有接受任何參數return void
    //public delegate int FunctionTakesOneIntAndReturnInt(int input1);  
    //函式宣告(像沒有body的function)  //命名(datatype)：FunctionTakesOneIntAndReturnInt  //()樣式  
    
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
            Application.Run(new MainForm());
        }
    }
}
