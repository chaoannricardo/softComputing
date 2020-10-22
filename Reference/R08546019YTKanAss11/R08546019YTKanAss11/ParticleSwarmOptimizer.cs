using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss11
{
    public enum OptimizationType { Maximization, Minimization };  //GoalMatching
    public delegate double ObjectiveFunction(double[] solution);  //FunctionTakesADoubleArray

    public class ParticleSwarmOptimizer
    {
        Random rnd = new Random();

        // data fields
        double[][] solutions;
        double[] objectiveValues;

        double[] lowerBounds;
        double[] upperBounds;

        int numberOfParticles = 10;
        int numberOfVariables;

        double congnitionFactor = 0.5;
        double socialFactor = 0.5;

        double[][] individualBestSolutions;
        double[] individualBestObjectiveValues;

        OptimizationType optimizationType;
        ObjectiveFunction objFunction;

        int iterationBestIndex;
        double iterationBestObjectiveValue;
        double iterationAverageObjectiveValue;

        double[] soFarTheBestSolution;
        double soFarTheBestObjectiveValue;

        int iterationLimit = 500;
        int iterationCount = 0;

        // properties 
        [Category("PSO Setting"), Description("粒子團的成員數，即解建構代理人的數量。\nnumber of particles employed.")]
        public int NumberOfParticles
        {
            get
            {
                return numberOfParticles;
            }
            set
            {
                if (value > 2) numberOfParticles = value;
            }
        }
        [Category("PSO Setting"), Description("自我認知的參考係數，用以規範移步時參看自我經歷的最佳位置。\n當值=1.0時，目標為100%自我經歷的最佳位置。\nfactor for local postitions of each particle.")]
        public double CongnitionFactor
        {
            get
            {
                return congnitionFactor;
            }
            set
            {
                if (value >= 0) congnitionFactor = value;
            }
        }
        [Category("PSO Setting"), Description("社交經歷的參考係數，用以規範移步時參看迄今團體的最佳位置。\n當值=1.0時，目標為100%迄今團體的最佳位置。\nfactor for global postition among all particles.")]
        public double SocialFactor
        {
            get
            {
                return socialFactor;
            }
            set
            {
                if (value >= 0) socialFactor = value;
            }
        }
        [Category("Execution"), Description("演化代次的上限。\niteration limit.")]
        public int IterationLimit
        {
            get
            {
                return iterationLimit;
            }
            set
            {
                if (value > 5) iterationLimit = value;
            }
        }
        [Browsable(false)]
        public int IterationCount { get => iterationCount; }
        [Browsable(false)]
        public double SoFarTheBestObjectiveValue { get => soFarTheBestObjectiveValue; }
        [Browsable(false)]
        public double[] SoFarTheBestSolution { get => soFarTheBestSolution; }
        [Browsable(false)]
        public double IterationBestObjectiveValue { get => iterationBestObjectiveValue; }
        [Browsable(false)]
        public double IterationAverageObjectiveValue { get => iterationAverageObjectiveValue; }
        [Browsable(false)]
        public double[][] Solutions { get => solutions; }
        [Browsable(false)]
        public double[][] IndividualBestSolutions { get => individualBestSolutions; }


        public ParticleSwarmOptimizer(int numberOfVariables, double[] lows, double[] ups, OptimizationType type, ObjectiveFunction objectiveFunction)
        {
            this.numberOfVariables = numberOfVariables;
            lowerBounds = lows;
            upperBounds = ups;

            optimizationType = type;
            objFunction = objectiveFunction;

            //allocate memory related to number of variables           
            soFarTheBestSolution = new double[numberOfVariables];
        }

        public void Reset()
        {
            //allocate memory related to number of particles
            solutions = new double[numberOfParticles][];
            for (int i = 0; i < solutions.Length; i++)
            {
                solutions[i] = new double[numberOfVariables];
            }

            objectiveValues = new double[numberOfParticles];

            individualBestSolutions = new double[numberOfParticles][];
            for (int i = 0; i < individualBestSolutions.Length; i++)
            {
                individualBestSolutions[i] = new double[numberOfVariables];
            }

            individualBestObjectiveValues = new double[numberOfParticles];           

            //set iterationBestObjectiveValue to the worst
            if (optimizationType == OptimizationType.Maximization)
            {
                iterationBestObjectiveValue = double.MinValue;
            }
            else  //OptimizationType.Minimization
            {
                iterationBestObjectiveValue = double.MaxValue;
            }

            //set soFarTheBestObjectiveValue to the worst
            if (optimizationType == OptimizationType.Maximization)
            {
                soFarTheBestObjectiveValue = double.MinValue;
            }
            else  //OptimizationType.Minimization
            {
                soFarTheBestObjectiveValue = double.MaxValue;
            }

            //randomly assign values to solutions
            InitializeNumberOfParticlesSolutions();

            iterationCount = 0;
        }

        private void InitializeNumberOfParticlesSolutions()
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    solutions[i][j] = lowerBounds[j] + rnd.NextDouble() * (upperBounds[j] - lowerBounds[j]);
                    //第0代
                    individualBestSolutions[i][j] = solutions[i][j];
                }
                objectiveValues[i] = objFunction(solutions[i]);
                individualBestObjectiveValues[i] = objectiveValues[i];
                //individualBestObjectiveValues[i] = objFunction(solutions[i]);
            }

            if (optimizationType == OptimizationType.Maximization)
            {
                soFarTheBestObjectiveValue = double.MinValue;
                for (int i = 0; i < numberOfParticles; i++)
                {
                    if (objectiveValues[i] > soFarTheBestObjectiveValue)
                    {
                        soFarTheBestObjectiveValue = objectiveValues[i];
                        for (int j = 0; j < numberOfVariables; j++)
                        {
                            soFarTheBestSolution[j] = solutions[i][j];
                        }
                    }
                }
            }
            else  //OptimizationType.Minimization
            {
                soFarTheBestObjectiveValue = double.MaxValue;
                for (int i = 0; i < numberOfParticles; i++)
                {
                    if (objectiveValues[i] < soFarTheBestObjectiveValue)
                    {
                        soFarTheBestObjectiveValue = objectiveValues[i];
                        for (int j = 0; j < numberOfVariables; j++)
                        {
                            soFarTheBestSolution[j] = solutions[i][j];
                        }
                    }
                }
            }           
        }

        public void RunOneIteration()
        {
            if (iterationCount >= iterationLimit) return;

            moveParticlesToNewPositions();
            computeObjectiveValuesAndUpdateParticleBestAndSoFarTheBest();

            iterationCount++;
        }
        
        private void moveParticlesToNewPositions()
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                double alpha = congnitionFactor * rnd.NextDouble();
                double beta = socialFactor * rnd.NextDouble();
                for (int j = 0; j < numberOfVariables; j++)
                {
                    solutions[i][j] = solutions[i][j] + alpha * (individualBestSolutions[i][j] - solutions[i][j])
                        + beta * (soFarTheBestSolution[j] - solutions[i][j]);
                    if (solutions[i][j] > upperBounds[j])
                    {
                        solutions[i][j] = upperBounds[j];
                    }
                    else if (solutions[i][j] < lowerBounds[j])
                    {
                        solutions[i][j] = lowerBounds[j];
                    }
                    //else
                    //{
                    //    solutions[i][j] = solutions[i][j];
                    //}
                }
            }                      
        }

        private void computeObjectiveValuesAndUpdateParticleBestAndSoFarTheBest()
        {
            double objectiveValueSum = 0;
            iterationAverageObjectiveValue = 0;
            for (int i = 0; i < numberOfParticles; i++)
            {
                objectiveValues[i] = objFunction(solutions[i]);
                objectiveValueSum += objectiveValues[i];
            }
            //update iterationAverageObjectiveValue
            iterationAverageObjectiveValue = objectiveValueSum / numberOfParticles;

            //update local best and so far the best solutions and objective values
            if (optimizationType == OptimizationType.Maximization)
            {
                //for (int i = 0; i < numberOfParticles; i++)
                //{
                //    if (objectiveValues[i] > particleBestObjectiveValues[i])
                //    {
                //        particleBestObjectiveValues[i] = objectiveValues[i];
                //        for (int j = 0; j < numberOfVariables; j++)
                //        {
                //            particleBestSolutions[i][j] = solutions[i][j];
                //        }
                //    }
                //}
                iterationBestObjectiveValue = double.MinValue;
                for (int i = 0; i < numberOfParticles; i++)
                {
                    //update local best solutions and objective values for each particles
                    if (objectiveValues[i] > individualBestObjectiveValues[i])
                    {
                        individualBestObjectiveValues[i] = objectiveValues[i];
                        for (int j = 0; j < numberOfVariables; j++)
                        {
                            individualBestSolutions[i][j] = solutions[i][j];
                        }
                    }
                    //update iterationBestObjectiveValue
                    if (objectiveValues[i] > iterationBestObjectiveValue)
                    {
                        iterationBestObjectiveValue = objectiveValues[i];
                        iterationBestIndex = i;
                    }
                }
                //update so far the best solution and objective value
                if (iterationBestObjectiveValue > soFarTheBestObjectiveValue)
                {
                    soFarTheBestObjectiveValue = iterationBestObjectiveValue;
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        soFarTheBestSolution[j] = solutions[iterationBestIndex][j];
                    }
                }
            }
            else  //OptimizationType.Minimization
            {
                iterationBestObjectiveValue = double.MaxValue;
                for (int i = 0; i < numberOfParticles; i++)
                {
                    //update local best solutions and objective values for each particles
                    if (objectiveValues[i] < individualBestObjectiveValues[i])
                    {
                        individualBestObjectiveValues[i] = objectiveValues[i];
                        for (int j = 0; j < numberOfVariables; j++)
                        {
                            individualBestSolutions[i][j] = solutions[i][j];
                        }
                    }
                    //update iterationBestObjectiveValue
                    if (objectiveValues[i] < iterationBestObjectiveValue)
                    {
                        iterationBestObjectiveValue = objectiveValues[i];
                        iterationBestIndex = i;
                    }
                }
                //update so far the best solution and objective value
                if (iterationBestObjectiveValue < soFarTheBestObjectiveValue)
                {
                    soFarTheBestObjectiveValue = iterationBestObjectiveValue;
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        soFarTheBestSolution[j] = solutions[iterationBestIndex][j];
                    }
                }
            }
        }

        public void RunToEnd()
        {
            do
            {
                RunOneIteration();
            }
            while (iterationCount < iterationLimit);
        }
    }
}
