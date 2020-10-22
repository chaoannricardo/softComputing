using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class Negate : UnaryFuzzySetOperator
    {
        public Negate()
        {
            title = "Negate ";
        }
        public override double Calculate(double x)
        {
            return 1 - x;
        }
    }
}
