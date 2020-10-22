using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class Concentration : UnaryFuzzySetOperator
    {
        public Concentration()
        {
            title = "Concentration(Very) ";
        }       
        public override double Calculate(double x)
        {
            return Math.Pow(x,2);
        }
    }
}
