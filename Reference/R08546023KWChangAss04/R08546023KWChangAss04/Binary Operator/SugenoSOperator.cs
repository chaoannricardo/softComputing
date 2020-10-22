using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class SugenoSOperator : BinaryFSOperator
    {
        public SugenoSOperator()
        {
            parameters = new double[1];
            parameters[0] = 0.5;
            Title = " Sugeno S-norm";
        }
        //define property for alpha
        //attribute
        [Category("Parameters"), Description("Lamda must be greater than -1.")]
        public double Lamda
        {
            get
            {
                return parameters[0];
            }
            set
            {
                parameters[0] = value;
                FireOperatorParameterChangedEvent();
            }
        }

        //override return data of Calculate function in UnaryFSOperator
        public override double Calculate(double x, double y)
        {
            return Math.Min(1, x + y  + parameters[0] * x * y);
        }
    }
}
