using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class AlgebraicProduct : BinaryFuzzySetOperator
    {
        public AlgebraicProduct()
        {
            title = "Algebraic Product ";
        }
        public override double Calculate(double x, double y)
        {
            return x * y;
        }
    }
}
