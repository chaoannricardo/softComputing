using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class DrasticSum : BinaryFuzzySetOperator
    {
        public DrasticSum()
        {
            title = "Drastic Sum ";
        }
        public override double Calculate(double x, double y)
        {
            if (x == 0)
            {
                return y;
            }
            else
            {
                if (y == 0)
                {
                    return x;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
