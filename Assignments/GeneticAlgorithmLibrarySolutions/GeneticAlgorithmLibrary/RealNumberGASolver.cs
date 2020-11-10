using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmLibrary
{
    class RealNumberGASolver : GeneticAlgorithm<double>
    {
        double[] LowerBounds;
        double[] UpperBounds;

        public RealNumberGASolver(int numberOfVariables, double[] lowerBounds, double[] upperBounds, ObjectiveFunction<double> theMethod)
           : base(numberOfVariables, theMethod)
        {

        }
    }
}
