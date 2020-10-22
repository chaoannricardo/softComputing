using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class ValueScaleOperator : UnaryFSOperator
    {
        
        public ValueScaleOperator()
        {
            parameters = new double[1];
            parameters[0] = 0.5;
            Title = Convert.ToString(parameters[0]) + $" Scale";
        }

        [Category("Parameters"), Description("Scale must be between 0 and 1.")]
        public double Scale
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
            return x * parameters[0];
        }
    }
}
