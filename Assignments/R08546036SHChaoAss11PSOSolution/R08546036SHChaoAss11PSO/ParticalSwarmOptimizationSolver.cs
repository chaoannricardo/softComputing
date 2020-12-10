using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546036SHChaoAss11PSO
{
    public enum OptimizationType { Minimization, Maximization };
    public delegate double ObjectiveFunction(double[] solution);

    class ParticalSwarmOptimizationSolver
    {
        // data fields
        double[][] solutions;

        // properties
        public double[][] Solutions { get => solutions;}

        public ParticalSwarmOptimizationSolver(int numberOfVariables,
            OptimizationType optimizationType, double[] lowerBounds, double[] upperBounds, ObjectiveFunction objFunction)
        {

        }

    }
}
