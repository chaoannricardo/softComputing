using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class YagerTOperator : BinaryFSOperator
    {
        public YagerTOperator()
        {
            parameters = new double[1];
            parameters[0] = 1;
            Title = "Yager T-norm";
        }
        //define property for alpha
        //attribute
        [Category("Parameters"), Description("Omega must be not less than 1.")]
        public double Omega
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
            return 1 - Math.Min(1, Math.Pow(Math.Pow(1 - x, parameters[0]) + Math.Pow(1 - y, parameters[0]), 1 / parameters[0]));
        }
    }
}

