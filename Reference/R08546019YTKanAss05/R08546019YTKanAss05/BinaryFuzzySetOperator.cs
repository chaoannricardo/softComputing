using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class BinaryFuzzySetOperator
    {
        protected double[] parameterValues;
        protected string title;

        // events
        public event EventHandler OperatorParameterChanged;  //use default event handling delegate
        protected void FireOperatorParameterChangedEvent()
        {
            if (OperatorParameterChanged != null)      
                OperatorParameterChanged(this, null);  //(Object, EventArg)(EventHandler樣式)
        }

        // properties
        public string Title
        {
            get => title;
            set
            {
                title = value;
            }
        }
        public virtual double Calculate(double x,double y)  //binary:x,y
        {
            return 0.0;
        }
    }
}
