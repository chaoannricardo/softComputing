using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class Diminisher : UnaryFuzzySetOperator
    {
        public Diminisher()
        {
            title = "Diminisher ";
        }
        public override double Calculate(double x)
        {
            if (x >= 0 && x <= 0.5)
            {
                return 1 - 2 * Math.Pow((1-x), 2);
            }
            else
            {
                return 2 * Math.Pow(x, 2);
            }
        }
    }
}
