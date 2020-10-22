using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class DilationOperator :UnaryFSOperator
    {
        public DilationOperator()
        {
            Title = "Dilation";
        }
        public override double Calculate(double x)
        {
            return Math.Pow(x, 0.5);
        }
    }
}
