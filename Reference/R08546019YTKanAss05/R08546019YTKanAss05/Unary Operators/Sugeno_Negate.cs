using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class Sugeno_Negate : UnaryFuzzySetOperator
    {
        // constructer
        public Sugeno_Negate(double s)
        {
            parameterValues = new double[1];
            parameterValues[0] = s;
            title = "Sugeno Negate ";
        }
        // define propeerty for Lambda
        [Category("Parameters"), Description("Must be greater than -1.")]
        public double Lambda
        {
            get
            {
                return parameterValues[0];
            }
            set
            {
                //guarding
                if (value >= -1)
                {
                    parameterValues[0] = value;
                    FireOperatorParameterChangedEvent();
                }
            }
        }
        public override double Calculate(double x)
        {
            return (1 - x) / (1 - x * parameterValues[0]);
        }
    }
}
