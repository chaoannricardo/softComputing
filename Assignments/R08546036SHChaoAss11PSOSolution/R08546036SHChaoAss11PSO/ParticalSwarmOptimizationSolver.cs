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
        double[][] solutionBestIndividual;
        double[] solutionBest;
        double[] objectives;

        int particleNum = 10;
        double socialFactor = 0.5;
        double cognitionFactor = 0.5;
        double soFarTheBestObjective;

        // properties
        public double[][] Solutions { get => solutions;}
        public OptimizationType OptimizationMethod { get; set; } = OptimizationType.Minimization;
        public int ParticleNum { get => particleNum; set => particleNum = value; }
        public double SocialFactor { get => socialFactor; set => socialFactor = value; }
        public double CognitionFactor { get => cognitionFactor; set => cognitionFactor = value; }
        public double SoFarTheBestObjective { get => soFarTheBestObjective; }

        public ParticalSwarmOptimizationSolver(int numberOfVariables,
            OptimizationType optimizationType, double[] lowerBounds, double[] upperBounds, ObjectiveFunction objFunction)
        {
            // set up properties based on optimization type
            switch (OptimizationMethod) {
                case OptimizationType.Minimization:
                    soFarTheBestObjective = double.MaxValue;
                    break;
                case OptimizationType.Maximization:
                    soFarTheBestObjective = double.MinValue;
                    break;
            }


        }

        public void Reset() { 
        
        }

        public void RunOneIteration() { 
        
        
        }

        public void UpdateSolution() { 
        
        
        }

        public void ComputeObjectiveValueAndUpdate() { 
        
        
        }

    }
}
