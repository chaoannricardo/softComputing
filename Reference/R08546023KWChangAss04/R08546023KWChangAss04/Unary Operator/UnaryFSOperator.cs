using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546023KWChangAss05
{
    class UnaryFSOperator //Unary family
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
        [Category("Class"), Description("The title of unary fuzzy set.")]
        public virtual string Title
        {
            get => title;
            set
            {
                title = value;
            }
        }

        


        //function
        //input one double and output one double
        //virtual : 子類別可加以定義 usually public
        public virtual double Calculate(double x)
        {
            return 0.0;
        }
    }
}
