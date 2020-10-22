using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class MinimumTnorm : BinaryFuzzySetOperator
    {
        public MinimumTnorm()
        {
            title = "Minimum T-norm ";
        }
        public override double Calculate(double x, double y)
        {
            return Math.Min(x, y);
        }
    }
}
