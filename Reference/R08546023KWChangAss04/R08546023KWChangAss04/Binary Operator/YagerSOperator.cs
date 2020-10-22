using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class YagerSOperator : BinaryFSOperator
    {
        public YagerSOperator()
        {
            parameters = new double[1];
            parameters[0] = 1;
            Title = "Yager S-norm";
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
            return Math.Min(1, Math.Pow(Math.Pow(x, parameters[0]) + Math.Pow(y, parameters[0]), 1 / parameters[0]));
        }
    }
}
