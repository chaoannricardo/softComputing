using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546023KWChangAss05.Binary_Operator
{
    class BinaryFSOperator
    {
        //data
        protected double[] parameters;

        protected string title;

        public event EventHandler OperatorParameterChanged;
        protected void FireOperatorParameterChangedEvent()
        {
            if (OperatorParameterChanged != null)
            {
                OperatorParameterChanged(this, null);
            }
        }


        //define properties
        //attribute
        [Category("Class"), Description("The title of binary fuzzy set.")]
        public virtual string Title
        {
            get => title;
            set
            {
                title = value;
                //update series's title
                
            }
        }


        //function
        //input two double and output one double
        //virtual : 子類別可加以定義 usually public
        public virtual double Calculate(double x, double y)
        {
            return 0.0;
        }
    }
}
