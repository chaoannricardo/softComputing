using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class Hamacher_Tnorm : BinaryFuzzySetOperator
    {
        // constructer
        public Hamacher_Tnorm(double gamma)
        {
            parameterValues = new double[1];
            parameterValues[0] = gamma;
            title = "Hamacher T-norm ";
        }

        // define propeerty for Gamma
        [Category("Parameters"), Description("Must be greater than 0.")]
        public double Gamma
        {
            get
            {
                return parameterValues[0];
            }
            set
            {
                //guarding
                if (value >= 0)
                {
                    parameterValues[0] = value;
                    FireOperatorParameterChangedEvent();
                }
            }
        }
        public override double Calculate(double x, double y)
        {
            return x * y / (parameterValues[0] + (1 - parameterValues[0]) * (x + y - x * y));
        }
    }
}

