using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class YagerComplementOperator : UnaryFSOperator
    {
        
        public YagerComplementOperator()
        {
            parameters = new double[1];
            parameters[0] = 0.5;
            Title = "Yager Complement";
        }

        [Category("Parameters"), Description("Omega must greater than 0.")]
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

        public override double Calculate(double x)
        {
            return Math.Pow((1 - Math.Pow(x, parameters[0])), (1 / parameters[0]));
        }
    }
}
