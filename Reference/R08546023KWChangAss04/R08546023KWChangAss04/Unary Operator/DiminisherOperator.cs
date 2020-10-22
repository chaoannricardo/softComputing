using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class DiminisherOperator : UnaryFSOperator
    {
        public DiminisherOperator()
        {
            Title = "Diminisher";
        }
        public override double Calculate(double x)
        {
            if (x < 0.5)
            {
                return Math.Pow((0.5 * x), 0.5);
            }
            else if (x == 0.5)
            {
                return 0.5;
            }
            else
            {
                return ((-1) * (Math.Pow(0.5 * (1 - x), 0.5))) + 1;
            }
        }
    }
}
