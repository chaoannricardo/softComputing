using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class SugenoTOperator : BinaryFSOperator
    {
        public SugenoTOperator()
        {
            parameters = new double[1];
            parameters[0] = 0;
            Title = "Sugeno T-norm";
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
            if(parameters[0] == 1)
            {
                if (x == 1)
                {
                    return y;
                }
                else
                {
                    if (y == 1)
                    {
                        return x;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
            {
                return Math.Max(0, (x + y - 1 + parameters[0] * x * y) / (1 + parameters[0]));
            }
        }
    }
}
