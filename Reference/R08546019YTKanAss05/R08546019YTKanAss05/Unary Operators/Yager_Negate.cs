using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class Yager_Negate : UnaryFuzzySetOperator
    {
        // constructer
        public Yager_Negate(double w)
        {
            parameterValues = new double[1];
            parameterValues[0] = w;
            title = "Yager Negate ";
        }
        //define propeerty for P
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
        public override double Calculate(double x)
        {
            return Math.Pow((1 - Math.Pow(x, parameterValues[0])),1/ parameterValues[0]);
        }
    }
}
