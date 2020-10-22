using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class Extremely : UnaryFuzzySetOperator
    {
        public Extremely()
        {
            title = "Extremely ";
        }
        public override double Calculate(double x)
        {
            return Math.Pow(x,8);
        }
    }
}
