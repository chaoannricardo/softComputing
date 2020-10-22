using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class Dilation : UnaryFuzzySetOperator
    {
        public Dilation()
        {
            title = "Dilation(More or less) ";
        }
        public override double Calculate(double x)
        {
            return Math.Sqrt(x);
        }
    }
}
