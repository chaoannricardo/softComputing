using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class SugenoComplementOperator : UnaryFSOperator
    {
        
        public SugenoComplementOperator()
        {
            parameters = new double[1];
            parameters[0] = 0.5;
            Title = "Sugeno Complement";
        }

        [Category("Parameters"), Description("Lamda must greater than -1.")]
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

        public override double Calculate(double x)
        {
            return (1 - x) / (1 + parameters[0] * x);
        }
    }
}
