using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmLibrary
{
    public class RealNumberGASolver : GeneticAlgorithm<double>
    {
        double[] LowerBounds;
        double[] UpperBounds;

        public RealNumberGASolver(int numberOfVariables, OptimizationType type, double[] lowerBounds, double[] upperBounds, ObjectiveFunction<double> theMethod)
           : base(numberOfVariables, type, theMethod)
        {

        }
    }
}
