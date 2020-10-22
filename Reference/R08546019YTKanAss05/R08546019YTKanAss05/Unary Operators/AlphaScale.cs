using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class AlphaScale : UnaryFuzzySetOperator
    {
        // constructer
        public AlphaScale(double alpha)
        {
            parameterValues = new double[1];
            parameterValues[0] = alpha;
            title = "Alpha-Scale ";
        }

        // define propeerty for Alpha
        [Category("Parameters"), Description("Must be greater than 0 \nand less than 1.")]
        public double Alpha
        {
            get
            {
                return parameterValues[0];
            }
            set
            {
                //guarding
                if (value >= 0 && value <= 1)
                {
                    parameterValues[0] = value;
                    FireOperatorParameterChangedEvent();
                }
            }
        }
        public override double Calculate(double x)
        {
            return x * parameterValues[0];
        }
    }
}
