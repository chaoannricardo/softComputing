using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class AlphaCut : UnaryFuzzySetOperator
    {
        // constructor
        // 兩種做法
        //public AlphaCut()
        //{
        //    parameterValues = new double[1];
        //    parameterValues[0] = 0.5;
        //}
        public AlphaCut(double alpha)
        {
            parameterValues = new double[1];
            parameterValues[0] = alpha;
            title = "Alpha-Cut ";
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
            return x > parameterValues[0] ? parameterValues[0] : x;  //當x>aphla ? 值為aphla : 其餘值為x
        }
    }
}
