using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546036SHChaoFinalProject
{
    public enum OptimizationType { Minimization, Maximization };
    public delegate double ObjectiveFunction(double[] solution);

    class ParticalSwarmOptimizationSolver
    {
        #region variables
        double[][] solutions;
        double[][] solutionBestIndividual;
        double[] solutionBest;
        double[] objectives;
        double[] objectivesBestIndividual;
        double[] solutionLowerBound;
        double[] solutionUpperBound;

        int particleNum = 10;
        int iterationLimit = 100;
        int iterationCount = 0;
        int numberOfVariables;
        double socialFactor = 0.5;
        double cognitionFactor = 0.5;
        double soFarTheBestObjective;
        double soFarTheBestObjectiveIteration;
        double iterationAverage;
        double alphaValue;
        double betaValue;
        bool isReset = false;
        Random randomizer = new Random();
        #endregion

        #region properties
        public double[][] Solutions { get => solutions;}
        public OptimizationType OptimizationMethod { get; set; } = OptimizationType.Minimization;
        public ObjectiveFunction ObjFunction { get; }
        public int ParticleNum { get => particleNum; set => particleNum = value; }
        public double SocialFactor { get => socialFactor; set => socialFactor = value; }
        public double CognitionFactor { get => cognitionFactor; set => cognitionFactor = value; }
        public double[] SolutionLowerBound { get => solutionLowerBound; set => solutionLowerBound = value; }
        public double[] SolutionUpperBound { get => solutionUpperBound; set => solutionUpperBound = value; }
        public int IterationLimit { get => iterationLimit; set => iterationLimit = value; }
        public int IterationCount { get => iterationCount; set => iterationCount = value; }
        // only get
        public int NumberOfVariables { get => numberOfVariables; }
        public double[] ObjectivesBestIndividual { get => objectivesBestIndividual; }
        public double SoFarTheBestObjective { get => soFarTheBestObjective; }
        public double[] SolutionBest { get => solutionBest; }
        public double IterationAverage { get => iterationAverage; }
        public double SoFarTheBestObjectiveIteration { get => soFarTheBestObjectiveIteration;}
        [Browsable(false)]
        public bool IsReset { get => isReset; }

        #endregion

        public ParticalSwarmOptimizationSolver(int numberOfVariables,
            OptimizationType optimizationType, double[] lowerBounds, double[] upperBounds, ObjectiveFunction objFunction)
        {
            // initiate variable value
            this.OptimizationMethod = optimizationType;
            this.numberOfVariables = numberOfVariables;
            solutionLowerBound = lowerBounds;
            solutionUpperBound = upperBounds;
            ObjFunction = objFunction;
        }

        public void Reset() {
            isReset = true;

            // reset variables
            solutions = new double[particleNum][];
            solutionBestIndividual = new double[particleNum][];
            objectives = new double[particleNum];
            objectivesBestIndividual = new double[particleNum];
            iterationCount = 0;

            // initiate solution and objectives
            for (int i = 0; i < solutions.Length; i++) {
                solutions[i] = new double[numberOfVariables];
                solutionBestIndividual[i] = new double[numberOfVariables];
            }

            // set up properties based on optimization type
            switch (OptimizationMethod)
            {
                case OptimizationType.Minimization:
                    soFarTheBestObjective = double.MaxValue;
                    soFarTheBestObjectiveIteration = double.MaxValue;
                    break;
                case OptimizationType.Maximization:
                    soFarTheBestObjective = double.MinValue;
                    soFarTheBestObjectiveIteration = double.MaxValue;
                    break;
            }

            // initialize value of solution and objectives
            for (int i = 0; i < particleNum; i++) {
                for (int j = 0; j < numberOfVariables; j++) {
                    solutions[i][j] = solutionLowerBound[j] + 
                        (randomizer.NextDouble() * (solutionUpperBound[j] - solutionLowerBound[j]));
                    solutionBestIndividual[i][j] = solutions[i][j];
                }

                objectives[i] = ObjFunction(solutions[i]);

                switch (OptimizationMethod) {
                    case OptimizationType.Minimization:
                        if (objectives[i] < soFarTheBestObjective) {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                    case OptimizationType.Maximization:
                        if (objectives[i] > soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                }

            }

        }

        public void RunOneIteration() {
            iterationCount += 1;
            UpdateSolution();
            ComputeObjectiveValueAndUpdate();
        }

        public void UpdateSolution() {
            
            for (int i = 0; i < particleNum; i++) {

                alphaValue = cognitionFactor * randomizer.NextDouble();
                betaValue = socialFactor * randomizer.NextDouble();

                for (int j = 0; j < numberOfVariables; j++) {
                    // update solution
                    solutions[i][j] += (alphaValue * (solutionBestIndividual[i][j] - solutions[i][j])
                        + betaValue * (solutionBest[j] - solutions[i][j]));
                    // check if solution excess the boundary
                    if (solutions[i][j] > solutionUpperBound[j]) solutions[i][j] = solutionUpperBound[j];
                    else if (solutions[i][j] < solutionLowerBound[j]) solutions[i][j] = solutionLowerBound[j];
                }
            }
        
        }

        public void ComputeObjectiveValueAndUpdate() {
            for (int i = 0; i < particleNum; i++) {
                objectives[i] = ObjFunction(solutions[i]);
                iterationAverage = (objectives.Sum() / objectives.Length);
                switch (OptimizationMethod) {
                    case OptimizationType.Minimization:
                        if (objectives[i] < objectivesBestIndividual[i]) objectivesBestIndividual[i] = objectives[i];
                        if (objectives[i] < soFarTheBestObjectiveIteration)
                        {
                            soFarTheBestObjectiveIteration = objectives[i];
                            solutionBestIndividual[i] = solutions[i];
                        }
                        if (objectives[i] < soFarTheBestObjective) {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                    case OptimizationType.Maximization:
                        if (objectives[i] > objectivesBestIndividual[i]) objectivesBestIndividual[i] = objectives[i];
                        if (objectives[i] > soFarTheBestObjectiveIteration)
                        {
                            soFarTheBestObjectiveIteration = objectives[i];
                            solutionBestIndividual[i] = solutions[i];
                        }
                        if (objectives[i] > soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                }
            }
        }

    }

    class PredatorPreyPSO
    {
        #region variables
        double[][] solutions;
        double[][] solutionBestIndividual;
        double[] solutionBest;
        double[] objectives;
        double[] objectivesBestIndividual;
        double[] solutionLowerBound;
        double[] solutionUpperBound;

        int particleNum = 10;
        int iterationLimit = 100;
        int iterationCount = 0;
        int numberOfVariables;
        double socialFactor = 0.5;
        double cognitionFactor = 0.5;
        double soFarTheBestObjective;
        double soFarTheBestObjectiveIteration;
        double iterationAverage;
        double alphaValue;
        double betaValue;
        bool isReset = false;
        Random randomizer = new Random();
        #endregion

        #region properties
        public double[][] Solutions { get => solutions; }
        public OptimizationType OptimizationMethod { get; set; } = OptimizationType.Minimization;
        public ObjectiveFunction ObjFunction { get; }
        public int ParticleNum { get => particleNum; set => particleNum = value; }
        public double SocialFactor { get => socialFactor; set => socialFactor = value; }
        public double CognitionFactor { get => cognitionFactor; set => cognitionFactor = value; }
        public double[] SolutionLowerBound { get => solutionLowerBound; set => solutionLowerBound = value; }
        public double[] SolutionUpperBound { get => solutionUpperBound; set => solutionUpperBound = value; }
        public int IterationLimit { get => iterationLimit; set => iterationLimit = value; }
        public int IterationCount { get => iterationCount; set => iterationCount = value; }
        // only get
        public int NumberOfVariables { get => numberOfVariables; }
        public double[] ObjectivesBestIndividual { get => objectivesBestIndividual; }
        public double SoFarTheBestObjective { get => soFarTheBestObjective; }
        public double[] SolutionBest { get => solutionBest; }
        public double IterationAverage { get => iterationAverage; }
        public double SoFarTheBestObjectiveIteration { get => soFarTheBestObjectiveIteration; }
        [Browsable(false)]
        public bool IsReset { get => isReset; }

        #endregion

        public PredatorPreyPSO(int numberOfVariables,
            OptimizationType optimizationType, double[] lowerBounds, double[] upperBounds, ObjectiveFunction objFunction)
        {
            // initiate variable value
            this.OptimizationMethod = optimizationType;
            this.numberOfVariables = numberOfVariables;
            solutionLowerBound = lowerBounds;
            solutionUpperBound = upperBounds;
            ObjFunction = objFunction;
        }

        public void Reset()
        {
            isReset = true;

            // reset variables
            solutions = new double[particleNum][];
            solutionBestIndividual = new double[particleNum][];
            objectives = new double[particleNum];
            objectivesBestIndividual = new double[particleNum];
            iterationCount = 0;

            // initiate solution and objectives
            for (int i = 0; i < solutions.Length; i++)
            {
                solutions[i] = new double[numberOfVariables];
                solutionBestIndividual[i] = new double[numberOfVariables];
            }

            // set up properties based on optimization type
            switch (OptimizationMethod)
            {
                case OptimizationType.Minimization:
                    soFarTheBestObjective = double.MaxValue;
                    soFarTheBestObjectiveIteration = double.MaxValue;
                    break;
                case OptimizationType.Maximization:
                    soFarTheBestObjective = double.MinValue;
                    soFarTheBestObjectiveIteration = double.MaxValue;
                    break;
            }

            // initialize value of solution and objectives
            for (int i = 0; i < particleNum; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    solutions[i][j] = solutionLowerBound[j] +
                        (randomizer.NextDouble() * (solutionUpperBound[j] - solutionLowerBound[j]));
                    solutionBestIndividual[i][j] = solutions[i][j];
                }

                objectives[i] = ObjFunction(solutions[i]);

                switch (OptimizationMethod)
                {
                    case OptimizationType.Minimization:
                        if (objectives[i] < soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                    case OptimizationType.Maximization:
                        if (objectives[i] > soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                }

            }

        }

        public void RunOneIteration()
        {
            iterationCount += 1;
            UpdateSolution();
            ComputeObjectiveValueAndUpdate();
        }

        public void UpdateSolution()
        {

            for (int i = 0; i < particleNum; i++)
            {

                alphaValue = cognitionFactor * randomizer.NextDouble();
                betaValue = socialFactor * randomizer.NextDouble();

                for (int j = 0; j < numberOfVariables; j++)
                {
                    // update solution
                    solutions[i][j] += (alphaValue * (solutionBestIndividual[i][j] - solutions[i][j])
                        + betaValue * (solutionBest[j] - solutions[i][j]));
                    // check if solution excess the boundary
                    if (solutions[i][j] > solutionUpperBound[j]) solutions[i][j] = solutionUpperBound[j];
                    else if (solutions[i][j] < solutionLowerBound[j]) solutions[i][j] = solutionLowerBound[j];
                }
            }

        }

        public void ComputeObjectiveValueAndUpdate()
        {
            for (int i = 0; i < particleNum; i++)
            {
                objectives[i] = ObjFunction(solutions[i]);
                iterationAverage = (objectives.Sum() / objectives.Length);
                switch (OptimizationMethod)
                {
                    case OptimizationType.Minimization:
                        if (objectives[i] < objectivesBestIndividual[i]) objectivesBestIndividual[i] = objectives[i];
                        if (objectives[i] < soFarTheBestObjectiveIteration)
                        {
                            soFarTheBestObjectiveIteration = objectives[i];
                            solutionBestIndividual[i] = solutions[i];
                        }
                        if (objectives[i] < soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                    case OptimizationType.Maximization:
                        if (objectives[i] > objectivesBestIndividual[i]) objectivesBestIndividual[i] = objectives[i];
                        if (objectives[i] > soFarTheBestObjectiveIteration)
                        {
                            soFarTheBestObjectiveIteration = objectives[i];
                            solutionBestIndividual[i] = solutions[i];
                        }
                        if (objectives[i] > soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                }
            }
        }

    }

    class HuntingSearchPSO
    {
        #region variables
        double[][] solutions;
        double[][] solutionBestIndividual;
        double[] solutionBest;
        double[] objectives;
        double[] objectivesBestIndividual;
        double[] solutionLowerBound;
        double[] solutionUpperBound;

        int particleNum = 10;
        int iterationLimit = 100;
        int iterationCount = 0;
        int numberOfVariables;
        double socialFactor = 0.5;
        double cognitionFactor = 0.5;
        double soFarTheBestObjective;
        double soFarTheBestObjectiveIteration;
        double iterationAverage;
        double alphaValue;
        double betaValue;
        bool isReset = false;
        Random randomizer = new Random();
        #endregion

        #region properties
        public double[][] Solutions { get => solutions; }
        public OptimizationType OptimizationMethod { get; set; } = OptimizationType.Minimization;
        public ObjectiveFunction ObjFunction { get; }
        public int ParticleNum { get => particleNum; set => particleNum = value; }
        public double SocialFactor { get => socialFactor; set => socialFactor = value; }
        public double CognitionFactor { get => cognitionFactor; set => cognitionFactor = value; }
        public double[] SolutionLowerBound { get => solutionLowerBound; set => solutionLowerBound = value; }
        public double[] SolutionUpperBound { get => solutionUpperBound; set => solutionUpperBound = value; }
        public int IterationLimit { get => iterationLimit; set => iterationLimit = value; }
        public int IterationCount { get => iterationCount; set => iterationCount = value; }
        // only get
        public int NumberOfVariables { get => numberOfVariables; }
        public double[] ObjectivesBestIndividual { get => objectivesBestIndividual; }
        public double SoFarTheBestObjective { get => soFarTheBestObjective; }
        public double[] SolutionBest { get => solutionBest; }
        public double IterationAverage { get => iterationAverage; }
        public double SoFarTheBestObjectiveIteration { get => soFarTheBestObjectiveIteration; }
        [Browsable(false)]
        public bool IsReset { get => isReset; }

        #endregion

        public HuntingSearchPSO(int numberOfVariables,
            OptimizationType optimizationType, double[] lowerBounds, double[] upperBounds, ObjectiveFunction objFunction)
        {
            // initiate variable value
            this.OptimizationMethod = optimizationType;
            this.numberOfVariables = numberOfVariables;
            solutionLowerBound = lowerBounds;
            solutionUpperBound = upperBounds;
            ObjFunction = objFunction;
        }

        public void Reset()
        {
            isReset = true;

            // reset variables
            solutions = new double[particleNum][];
            solutionBestIndividual = new double[particleNum][];
            objectives = new double[particleNum];
            objectivesBestIndividual = new double[particleNum];
            iterationCount = 0;

            // initiate solution and objectives
            for (int i = 0; i < solutions.Length; i++)
            {
                solutions[i] = new double[numberOfVariables];
                solutionBestIndividual[i] = new double[numberOfVariables];
            }

            // set up properties based on optimization type
            switch (OptimizationMethod)
            {
                case OptimizationType.Minimization:
                    soFarTheBestObjective = double.MaxValue;
                    soFarTheBestObjectiveIteration = double.MaxValue;
                    break;
                case OptimizationType.Maximization:
                    soFarTheBestObjective = double.MinValue;
                    soFarTheBestObjectiveIteration = double.MaxValue;
                    break;
            }

            // initialize value of solution and objectives
            for (int i = 0; i < particleNum; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    solutions[i][j] = solutionLowerBound[j] +
                        (randomizer.NextDouble() * (solutionUpperBound[j] - solutionLowerBound[j]));
                    solutionBestIndividual[i][j] = solutions[i][j];
                }

                objectives[i] = ObjFunction(solutions[i]);

                switch (OptimizationMethod)
                {
                    case OptimizationType.Minimization:
                        if (objectives[i] < soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                    case OptimizationType.Maximization:
                        if (objectives[i] > soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                }

            }

        }

        public void RunOneIteration()
        {
            iterationCount += 1;
            UpdateSolution();
            ComputeObjectiveValueAndUpdate();
        }

        public void UpdateSolution()
        {

            for (int i = 0; i < particleNum; i++)
            {

                alphaValue = cognitionFactor * randomizer.NextDouble();
                betaValue = socialFactor * randomizer.NextDouble();

                for (int j = 0; j < numberOfVariables; j++)
                {
                    // update solution
                    solutions[i][j] += (alphaValue * (solutionBestIndividual[i][j] - solutions[i][j])
                        + betaValue * (solutionBest[j] - solutions[i][j]));
                    // check if solution excess the boundary
                    if (solutions[i][j] > solutionUpperBound[j]) solutions[i][j] = solutionUpperBound[j];
                    else if (solutions[i][j] < solutionLowerBound[j]) solutions[i][j] = solutionLowerBound[j];
                }
            }

        }

        public void ComputeObjectiveValueAndUpdate()
        {
            for (int i = 0; i < particleNum; i++)
            {
                objectives[i] = ObjFunction(solutions[i]);
                iterationAverage = (objectives.Sum() / objectives.Length);
                switch (OptimizationMethod)
                {
                    case OptimizationType.Minimization:
                        if (objectives[i] < objectivesBestIndividual[i]) objectivesBestIndividual[i] = objectives[i];
                        if (objectives[i] < soFarTheBestObjectiveIteration)
                        {
                            soFarTheBestObjectiveIteration = objectives[i];
                            solutionBestIndividual[i] = solutions[i];
                        }
                        if (objectives[i] < soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                    case OptimizationType.Maximization:
                        if (objectives[i] > objectivesBestIndividual[i]) objectivesBestIndividual[i] = objectives[i];
                        if (objectives[i] > soFarTheBestObjectiveIteration)
                        {
                            soFarTheBestObjectiveIteration = objectives[i];
                            solutionBestIndividual[i] = solutions[i];
                        }
                        if (objectives[i] > soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                }
            }
        }

    }

    class AnimalFoodChainBasedPSO
    {
        #region variables
        double[][] solutions;
        double[][] solutionBestIndividual;
        double[] solutionBest;
        double[] objectives;
        double[] objectivesBestIndividual;
        double[] solutionLowerBound;
        double[] solutionUpperBound;

        int particleNum = 10;
        int iterationLimit = 100;
        int iterationCount = 0;
        int numberOfVariables;
        double socialFactor = 0.5;
        double cognitionFactor = 0.5;
        double soFarTheBestObjective;
        double soFarTheBestObjectiveIteration;
        double iterationAverage;
        double alphaValue;
        double betaValue;
        bool isReset = false;
        Random randomizer = new Random();
        #endregion

        #region properties
        public double[][] Solutions { get => solutions; }
        public OptimizationType OptimizationMethod { get; set; } = OptimizationType.Minimization;
        public ObjectiveFunction ObjFunction { get; }
        public int ParticleNum { get => particleNum; set => particleNum = value; }
        public double SocialFactor { get => socialFactor; set => socialFactor = value; }
        public double CognitionFactor { get => cognitionFactor; set => cognitionFactor = value; }
        public double[] SolutionLowerBound { get => solutionLowerBound; set => solutionLowerBound = value; }
        public double[] SolutionUpperBound { get => solutionUpperBound; set => solutionUpperBound = value; }
        public int IterationLimit { get => iterationLimit; set => iterationLimit = value; }
        public int IterationCount { get => iterationCount; set => iterationCount = value; }
        // only get
        public int NumberOfVariables { get => numberOfVariables; }
        public double[] ObjectivesBestIndividual { get => objectivesBestIndividual; }
        public double SoFarTheBestObjective { get => soFarTheBestObjective; }
        public double[] SolutionBest { get => solutionBest; }
        public double IterationAverage { get => iterationAverage; }
        public double SoFarTheBestObjectiveIteration { get => soFarTheBestObjectiveIteration; }
        [Browsable(false)]
        public bool IsReset { get => isReset; }

        #endregion

        public AnimalFoodChainBasedPSO(int numberOfVariables,
            OptimizationType optimizationType, double[] lowerBounds, double[] upperBounds, ObjectiveFunction objFunction)
        {
            // initiate variable value
            this.OptimizationMethod = optimizationType;
            this.numberOfVariables = numberOfVariables;
            solutionLowerBound = lowerBounds;
            solutionUpperBound = upperBounds;
            ObjFunction = objFunction;
        }

        public void Reset()
        {
            isReset = true;

            // reset variables
            solutions = new double[particleNum][];
            solutionBestIndividual = new double[particleNum][];
            objectives = new double[particleNum];
            objectivesBestIndividual = new double[particleNum];
            iterationCount = 0;

            // initiate solution and objectives
            for (int i = 0; i < solutions.Length; i++)
            {
                solutions[i] = new double[numberOfVariables];
                solutionBestIndividual[i] = new double[numberOfVariables];
            }

            // set up properties based on optimization type
            switch (OptimizationMethod)
            {
                case OptimizationType.Minimization:
                    soFarTheBestObjective = double.MaxValue;
                    soFarTheBestObjectiveIteration = double.MaxValue;
                    break;
                case OptimizationType.Maximization:
                    soFarTheBestObjective = double.MinValue;
                    soFarTheBestObjectiveIteration = double.MaxValue;
                    break;
            }

            // initialize value of solution and objectives
            for (int i = 0; i < particleNum; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    solutions[i][j] = solutionLowerBound[j] +
                        (randomizer.NextDouble() * (solutionUpperBound[j] - solutionLowerBound[j]));
                    solutionBestIndividual[i][j] = solutions[i][j];
                }

                objectives[i] = ObjFunction(solutions[i]);

                switch (OptimizationMethod)
                {
                    case OptimizationType.Minimization:
                        if (objectives[i] < soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                    case OptimizationType.Maximization:
                        if (objectives[i] > soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                }

            }

        }

        public void RunOneIteration()
        {
            iterationCount += 1;
            UpdateSolution();
            ComputeObjectiveValueAndUpdate();
        }

        public void UpdateSolution()
        {

            for (int i = 0; i < particleNum; i++)
            {

                alphaValue = cognitionFactor * randomizer.NextDouble();
                betaValue = socialFactor * randomizer.NextDouble();

                for (int j = 0; j < numberOfVariables; j++)
                {
                    // update solution
                    solutions[i][j] += (alphaValue * (solutionBestIndividual[i][j] - solutions[i][j])
                        + betaValue * (solutionBest[j] - solutions[i][j]));
                    // check if solution excess the boundary
                    if (solutions[i][j] > solutionUpperBound[j]) solutions[i][j] = solutionUpperBound[j];
                    else if (solutions[i][j] < solutionLowerBound[j]) solutions[i][j] = solutionLowerBound[j];
                }
            }

        }

        public void ComputeObjectiveValueAndUpdate()
        {
            for (int i = 0; i < particleNum; i++)
            {
                objectives[i] = ObjFunction(solutions[i]);
                iterationAverage = (objectives.Sum() / objectives.Length);
                switch (OptimizationMethod)
                {
                    case OptimizationType.Minimization:
                        if (objectives[i] < objectivesBestIndividual[i]) objectivesBestIndividual[i] = objectives[i];
                        if (objectives[i] < soFarTheBestObjectiveIteration)
                        {
                            soFarTheBestObjectiveIteration = objectives[i];
                            solutionBestIndividual[i] = solutions[i];
                        }
                        if (objectives[i] < soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                    case OptimizationType.Maximization:
                        if (objectives[i] > objectivesBestIndividual[i]) objectivesBestIndividual[i] = objectives[i];
                        if (objectives[i] > soFarTheBestObjectiveIteration)
                        {
                            soFarTheBestObjectiveIteration = objectives[i];
                            solutionBestIndividual[i] = solutions[i];
                        }
                        if (objectives[i] > soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                }
            }
        }

    }


}
