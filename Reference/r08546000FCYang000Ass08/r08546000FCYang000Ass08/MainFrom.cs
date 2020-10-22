using MyGALibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace r08546000FCYang000Ass08
{
    class MY<TT,SS>
    {
        TT[] tary;
        SS sobj;
        public MY( TT[] t, SS so )
        {
            tary = t;
            sobj = so;
        }
        public string getSObj()
        {
            return sobj.ToString();
        }

    }
    public partial class MainFrom : Form
    {
        BinaryGA gasolver;

        public MainFrom()
        {
            InitializeComponent();
            gasolver = new BinaryGA(8, OptimizationType.minimization, GetSetupTimeTotal);
        }

        public double GetSetupTimeTotal( byte[] solution )
        {
            return 0.0;
        }
    }
}
