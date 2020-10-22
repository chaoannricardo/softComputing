using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class Sugeno_Snorm : BinaryFuzzySetOperator
    {
        // constructer
        public Sugeno_Snorm(double lambda)
        {
            parameterValues = new double[1];
            parameterValues[0] = lambda;
            title = "Sugeno S-norm ";
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
        public override double Calculate(double x, double y)
        {
            return Math.Min((x + y + parameterValues[0] * x * y),1);
        }
    }
}
