using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class DrasticProduct : BinaryFuzzySetOperator
    {
        public DrasticProduct()
        {
            title = "Drastic Product ";
        }
        public override double Calculate(double x, double y)
        {
            if (x == 1)  // ==
            {
                return y;
            }
            else
            {
                if (y == 1)
                {
                    return x;
                }
                else
                {
                    return 0;
                }
            }           
        }
    }
}
