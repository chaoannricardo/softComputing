using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class BoundedProduct : BinaryFuzzySetOperator
    {
        public BoundedProduct()
        {
            title = "Bounded Product ";
        }
        public override double Calculate(double x, double y)
        {
            return Math.Max(0,(x + y - 1));
        }
    }
}
