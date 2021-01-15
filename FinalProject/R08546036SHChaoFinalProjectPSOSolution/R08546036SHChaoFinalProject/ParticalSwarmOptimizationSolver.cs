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

    class PSOBasedType
    {
        #region variables
        protected double[][] solutions;
        protected double[][] solutionBestIndividual;
        protected double[] solutionBest;
        protected double[] objectives;
        protected double[] objectivesBestIndividual;
        protected double[] solutionLowerBound;
        protected double[] solutionUpperBound;

        protected int particleNum = 10;
        protected int iterationLimit = 100;
        protected int iterationCount = 0;
        protected int numberOfVariables;
        protected double socialFactor = 0.5;
        protected double cognitionFactor = 0.5;
        protected double soFarTheBestObjective;
        protected double soFarTheBestObjectiveIteration;
        protected double iterationAverage;
        protected double alphaValue;
        protected double betaValue;
        protected bool isReset = false;
        protected Random randomizer = new Random();
        #endregion

        #region basedTypeProperties
        public virtual bool IsReset { get; internal set; }
        public virtual int IterationCount { get; set; }
        public virtual double SoFarTheBestObjective { get; internal set; }
        public virtual double[] SolutionBest { get; internal set; }
        public virtual double[][] Solutions { get; internal set; }
        public virtual double SoFarTheBestObjectiveIteration { get; internal set; }
        public virtual double IterationAverage { get; set; }
        public virtual int IterationLimit { get; set; }
        #endregion

        #region basedTypeFunctions
        public virtual void Reset()
        {
            throw new NotImplementedException();
        }

        public virtual void RunOneIteration()
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    class ParticalSwarmOptimizationSolver : PSOBasedType
    {
        #region properties
        public override double[][] Solutions { get => solutions;}
        public OptimizationType OptimizationMethod { get; set; } = OptimizationType.Minimization;
        public ObjectiveFunction ObjFunction { get; }
        public int ParticleNum { get => particleNum; set => particleNum = value; }
        public double SocialFactor { get => socialFactor; set => socialFactor = value; }
        public double CognitionFactor { get => cognitionFactor; set => cognitionFactor = value; }
        public double[] SolutionLowerBound { get => solutionLowerBound; set => solutionLowerBound = value; }
        public double[] SolutionUpperBound { get => solutionUpperBound; set => solutionUpperBound = value; }
        public override int IterationLimit { get => iterationLimit; set => iterationLimit = value; }
        public override int IterationCount { get => iterationCount; set => iterationCount = value; }
        // only get
        public int NumberOfVariables { get => numberOfVariables; }
        public double[] ObjectivesBestIndividual { get => objectivesBestIndividual; }
        public override double SoFarTheBestObjective { get => soFarTheBestObjective; }
        public override double[] SolutionBest { get => solutionBest; }
        public override double IterationAverage { get => iterationAverage; }
        public override double SoFarTheBestObjectiveIteration { get => soFarTheBestObjectiveIteration;}
        [Browsable(false)]
        public override bool IsReset { get => isReset; }

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

        public override void Reset() {
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

        public override void RunOneIteration() {
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

    class PredatorPreyPSO : PSOBasedType
    {
        #region properties
        public override double[][] Solutions { get => solutions; }
        public OptimizationType OptimizationMethod { get; set; } = OptimizationType.Minimization;
        public ObjectiveFunction ObjFunction { get; }
        public int ParticleNum { get => particleNum; set => particleNum = value; }
        public double SocialFactor { get => socialFactor; set => socialFactor = value; }
        public double CognitionFactor { get => cognitionFactor; set => cognitionFactor = value; }
        public double[] SolutionLowerBound { get => solutionLowerBound; set => solutionLowerBound = value; }
        public double[] SolutionUpperBound { get => solutionUpperBound; set => solutionUpperBound = value; }
        public override int IterationLimit { get => iterationLimit; set => iterationLimit = value; }
        public override int IterationCount { get => iterationCount; set => iterationCount = value; }
        // only get
        public int NumberOfVariables { get => numberOfVariables; }
        public double[] ObjectivesBestIndividual { get => objectivesBestIndividual; }
        public override double SoFarTheBestObjective { get => soFarTheBestObjective; }
        public override double[] SolutionBest { get => solutionBest; }
        public override double IterationAverage { get => iterationAverage; }
        public override double SoFarTheBestObjectiveIteration { get => soFarTheBestObjectiveIteration; }
        [Browsable(false)]
        public override bool IsReset { get => isReset; }

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

        public override void Reset()
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

        public override void RunOneIteration()
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

        public  void ComputeObjectiveValueAndUpdate()
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

    class HuntingSearchPSO : PSOBasedType
    {
        #region properties
        public override double[][] Solutions { get => solutions; }
        public OptimizationType OptimizationMethod { get; set; } = OptimizationType.Minimization;
        public ObjectiveFunction ObjFunction { get; }
        public int ParticleNum { get => particleNum; set => particleNum = value; }
        public double SocialFactor { get => socialFactor; set => socialFactor = value; }
        public double CognitionFactor { get => cognitionFactor; set => cognitionFactor = value; }
        public double[] SolutionLowerBound { get => solutionLowerBound; set => solutionLowerBound = value; }
        public double[] SolutionUpperBound { get => solutionUpperBound; set => solutionUpperBound = value; }
        public override int IterationLimit { get => iterationLimit; set => iterationLimit = value; }
        public override int IterationCount { get => iterationCount; set => iterationCount = value; }
        // only get
        public int NumberOfVariables { get => numberOfVariables; }
        public double[] ObjectivesBestIndividual { get => objectivesBestIndividual; }
        public override double SoFarTheBestObjective { get => soFarTheBestObjective; }
        public override double[] SolutionBest { get => solutionBest; }
        public override double IterationAverage { get => iterationAverage; }
        public override double SoFarTheBestObjectiveIteration { get => soFarTheBestObjectiveIteration; }
        [Browsable(false)]
        public override bool IsReset { get => isReset; }

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

        public override void Reset()
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

        public override void RunOneIteration()
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

    class AnimalFoodChainBasedPSO : PSOBasedType
    {
        #region properties
        public override double[][] Solutions { get => solutions; }
        public OptimizationType OptimizationMethod { get; set; } = OptimizationType.Minimization;
        public ObjectiveFunction ObjFunction { get; }
        public int ParticleNum { get => particleNum; set => particleNum = value; }
        public double SocialFactor { get => socialFactor; set => socialFactor = value; }
        public double CognitionFactor { get => cognitionFactor; set => cognitionFactor = value; }
        public double[] SolutionLowerBound { get => solutionLowerBound; set => solutionLowerBound = value; }
        public double[] SolutionUpperBound { get => solutionUpperBound; set => solutionUpperBound = value; }
        public override int IterationLimit { get => iterationLimit; set => iterationLimit = value; }
        public override int IterationCount { get => iterationCount; set => iterationCount = value; }
        // only get
        public int NumberOfVariables { get => numberOfVariables; }
        public double[] ObjectivesBestIndividual { get => objectivesBestIndividual; }
        public override double SoFarTheBestObjective { get => soFarTheBestObjective; }
        public override double[] SolutionBest { get => solutionBest; }
        public override double IterationAverage { get => iterationAverage; }
        public override double SoFarTheBestObjectiveIteration { get => soFarTheBestObjectiveIteration; }
        [Browsable(false)]
        public override bool IsReset { get => isReset; }

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

        public override void Reset()
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

        public override void RunOneIteration()
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
