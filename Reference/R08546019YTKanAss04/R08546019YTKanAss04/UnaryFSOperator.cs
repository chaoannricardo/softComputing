using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss04
{
    class UnaryFSOperator
    {
        protected double[] parameters;
        public string Title { set; get; }
        public virtual double Calculate(double x)
        {
            return 0.0;
        }
    }

    class Negate : UnaryFSOperator
    {
        public Negate()
        {
            Title = "Negate";
        }
        public override double Calculate(double x)
        {
            return 1 - x;
        }
    }
    class AlphaCut : UnaryFSOperator
    {
        public AlphaCut()
        {
            parameters = new double[1];
            parameters[0] = 0.5;
            Title = "AlphaCut";
        }

        public AlphaCut( double alpha )
        {
            parameters = new double[1];
            parameters[0] = alpha;
        }

        // define property for alpha

        public override double Calculate(double x)
        {
            return x > parameters[0] ? parameters[0] : x;
        }
    }
}
