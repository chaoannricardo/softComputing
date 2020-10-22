using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class Yager_Snorm : BinaryFuzzySetOperator
    {
        // constructer
        public Yager_Snorm(double lambda)
        {
            parameterValues = new double[1];
            parameterValues[0] = lambda;
            title = "Yager S-norm ";
        }

        // define propeerty for P
        [Category("Parameters"), Description("Must be greater than 0.")]
        public double P
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
            return Math.Min((Math.Pow((Math.Pow(x, parameterValues[0]) + Math.Pow(y, parameterValues[0])),
                (1 / parameterValues[0]))), 1);
        }
    }
}
