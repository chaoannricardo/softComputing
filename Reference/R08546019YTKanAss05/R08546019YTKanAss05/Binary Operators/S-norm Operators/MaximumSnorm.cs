using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class MaximumSnorm : BinaryFuzzySetOperator
    {
        public MaximumSnorm()
        {
            title = "Maximum S-norm ";
        }
        public override double Calculate(double x, double y)
        {
            return Math.Max(x, y);
        }
    }
}
