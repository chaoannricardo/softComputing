using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class IntensificationOperator :UnaryFSOperator
    {
        public IntensificationOperator()
        {
            Title = "Intensification";
        }
        public override double Calculate(double x)
        {
            if(x <= 0.5 && x >=0)
            {
                return 2 * Math.Pow(x, 2);
            }
            else
            {
                return 1 - 2 * Math.Pow(1 - x, 2);
            }
        }
    }
}
