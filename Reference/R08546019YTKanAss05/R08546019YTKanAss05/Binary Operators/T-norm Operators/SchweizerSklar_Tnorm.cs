using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class SchweizerSklar_Tnorm : BinaryFuzzySetOperator
    {
        // constructer
        public SchweizerSklar_Tnorm(double lambda)
        {
            parameterValues = new double[1];
            parameterValues[0] = lambda;
            title = "Schweizer-Sklar T-norm ";
        }

        // define propeerty for M
        [Category("Parameters")]
        public double M
        {
            get
            {
                return parameterValues[0];
            }
            set
            {
                //guarding
                {
                    parameterValues[0] = value;
                    FireOperatorParameterChangedEvent();
                }
            }
        }
        public override double Calculate(double x, double y)
        {
            double z;
            if (x < 0)
            {
                z = Math.Pow((Math.Pow(x, parameterValues[0]) + Math.Pow(y, parameterValues[0]) - 1), 
                    (1 / parameterValues[0]));
            }
            else
            {
                if (x == 0)
                {
                    z = x * y;
                }
                else
                {
                    z = Math.Pow(Math.Max(0, ((Math.Pow(x, parameterValues[0]) + Math.Pow(y, parameterValues[0]) - 1))),
                        (1 / parameterValues[0]));
                }
            }
            return z;
        }
    }
}
