using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class BoundedSum : BinaryFuzzySetOperator
    {
        public BoundedSum()
        {
            title = "Bounded Sum ";
        }
        public override double Calculate(double x, double y)
        {
            return Math.Min(1, (x + y));
        }
    }
}
