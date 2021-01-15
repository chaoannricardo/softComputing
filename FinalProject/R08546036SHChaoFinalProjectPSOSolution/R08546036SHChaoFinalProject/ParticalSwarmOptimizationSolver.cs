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

        protected int particleNum = 50;
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

    class PredatorPreyPSO : PSOBasedType
    {
        #region ownVars
        double fearProb = 0.5;
        double fearFactor = 0.5;
        double preycoefficient = 0.3;
        double distanceCoefficientA = 0.5;
        double distanceCoefficientB = 0.5;
        double preySwarmRatio = 0.7;
        double velocityWeight = 0.5;
        double[][] velocities;

        // not properties
        double[] velocitiesMax;
        double[] solutionBestPrey;
        int preyNums;
        double soFarTheBestObjectivePrey;
        double nearestPredatorDistance;
        double temp;
        #endregion

        #region properties
        public override double[][] Solutions { get => solutions; }
        public OptimizationType OptimizationMethod { get; set; } = OptimizationType.Minimization;
        public ObjectiveFunction ObjFunction { get; }
        public int ParticleNum { get => particleNum; set => particleNum = value; }
        public double SocialFactor { get => socialFactor; set => socialFactor = value; }
        public double CognitionFactor { get => cognitionFactor; set => cognitionFactor = value; }
        public double[] SolutionLowerBound { get => solutionLowerBound;}
        public double[] SolutionUpperBound { get => solutionUpperBound;}
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

        // new properties
        public double FearProb { get => fearProb; set => fearProb = value; }
        public double FearFactor { get => fearFactor; set => fearFactor = value; }
        public double PreySwarmRatio { get => preySwarmRatio; set => preySwarmRatio = value; }
        public double Preycoefficient { get => preycoefficient; set => preycoefficient = value; }
        public double DistanceCoefficientA { get => distanceCoefficientA; set => distanceCoefficientA = value; }
        public double DistanceCoefficientB { get => distanceCoefficientB; set => distanceCoefficientB = value; }
        public double VelocityWeight { get => velocityWeight; set => velocityWeight = value; }
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

            // additional part
            velocities = new double[particleNum][];
            velocitiesMax = new double[numberOfVariables];
            preyNums = Convert.ToInt32(particleNum * preySwarmRatio);

            // initiate solution and objectives
            for (int i = 0; i < solutions.Length; i++)
            {
                solutions[i] = new double[numberOfVariables];
                solutionBestIndividual[i] = new double[numberOfVariables];

                // additional part
                velocities[i] = new double[numberOfVariables];
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

                    // initiate velocity part
                    velocities[i][j] = distanceCoefficientA *
                        (randomizer.NextDouble() * (solutionUpperBound[j] - solutionLowerBound[j]));

                    if (velocities[i][j] > velocitiesMax[j]) velocitiesMax[j] = velocities[i][j];

                }

                objectives[i] = ObjFunction(solutions[i]);

                switch (OptimizationMethod)
                {
                    case OptimizationType.Minimization:
                        if (objectives[i] < soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];

                            // set up solution best of prey
                            if (i < preyNums)
                            {
                                solutionBestPrey = solutions[i];
                                soFarTheBestObjectivePrey = objectives[i];
                            }
                        }
                        break;
                    case OptimizationType.Maximization:
                        if (objectives[i] > soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];

                            // set up solution best of prey
                            if (i < preyNums)
                            {
                                solutionBestPrey = solutions[i];
                                soFarTheBestObjectivePrey = objectives[i];
                            }
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
                // check if it's predator or prey
                if (i < preyNums)
                {
                    // prey part
                    alphaValue = cognitionFactor * randomizer.NextDouble();
                    betaValue = socialFactor * randomizer.NextDouble();

                    // calculate euclidean distance between prey and predator
                    nearestPredatorDistance = double.MaxValue;
                    for (int predindex = preyNums; predindex < particleNum; predindex++)
                    {
                        temp = 0;
                        for (int varindex = 0; varindex < numberOfVariables; varindex++)
                        {
                            temp += Math.Abs(solutions[predindex][varindex] - solutions[i][varindex]);
                        }
                        if (temp < nearestPredatorDistance) nearestPredatorDistance = temp;
                    }

                    // update solution
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        // update velocity
                        if (randomizer.NextDouble() <= fearProb)
                        {




                            velocities[i][j] = velocityWeight * velocities[i][j]
                                + (alphaValue * (solutionBestIndividual[i][j] - solutions[i][j])
                                + betaValue * (solutionBest[j] - solutions[i][j]))
                                + fearFactor * randomizer.NextDouble() * (DistanceCoefficientA * Math.Exp(-(DistanceCoefficientB * nearestPredatorDistance)));

                        }
                        else
                        {
                            velocities[i][j] = velocityWeight * velocities[i][j] +
                                (alphaValue * (solutionBestIndividual[i][j] - solutions[i][j])
                        + betaValue * (solutionBest[j] - solutions[i][j]));
                        }

                        // update solution
                        solutions[i][j] += velocities[i][j];

                        // check if solution excess the boundary
                        if (solutions[i][j] > solutionUpperBound[j]) solutions[i][j] = solutionUpperBound[j];
                        else if (solutions[i][j] < solutionLowerBound[j]) solutions[i][j] = solutionLowerBound[j];
                    }
                }
                else
                {
                    // predator part
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        // update velocity
                        velocities[i][j] = (randomizer.NextDouble() * (velocitiesMax[j] - 0) + 0) *
                            (soFarTheBestObjectivePrey - objectives[i]);

                        // update solution
                        solutions[i][j] += velocities[i][j];

                        // check if solution excess the boundary
                        if (solutions[i][j] > solutionUpperBound[j]) solutions[i][j] = solutionUpperBound[j];
                        else if (solutions[i][j] < solutionLowerBound[j]) solutions[i][j] = solutionLowerBound[j];
                    }
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

                            // set up solution best of prey
                            if (i < preyNums)
                            {
                                solutionBestPrey = solutions[i];
                                soFarTheBestObjectivePrey = objectives[i];
                            }
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

                            // set up solution best of prey
                            if (i < preyNums)
                            {
                                solutionBestPrey = solutions[i];
                                soFarTheBestObjectivePrey = objectives[i];
                            }
                        }
                        break;
                }
            }
        }

    }

    class HuntingSearchPSO : PSOBasedType
    {
        #region ownVars
        double maximumMovement = 0.5;
        double divergenceThreshold = 0.05;
        double reorganizeConstantA = 0.5;
        double reorganizeConstantB = 0.5;
        // not properties
        double swarmSoFarTheWorstObjective;
        double[] swarmsolutionBest;
        double swarmsoFarTheBestObjective;
        int reorganizeCount = 0;
        #endregion

        #region properties
        public override double[][] Solutions { get => solutions; }
        public OptimizationType OptimizationMethod { get; set; } = OptimizationType.Minimization;
        public ObjectiveFunction ObjFunction { get; }
        public int ParticleNum { get => particleNum; set => particleNum = value; }
        public double[] SolutionLowerBound { get => solutionLowerBound;}
        public double[] SolutionUpperBound { get => solutionUpperBound;}
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
        // additional properties
        public double MaximumMovement { get => maximumMovement; set => maximumMovement = value; }
        public double DivergenceThreshold { get => divergenceThreshold; set => divergenceThreshold = value; }
        public double ReorganizeConstantA { get => reorganizeConstantA; set => reorganizeConstantA = value; }
        public double ReorganizeConstantB { get => reorganizeConstantB; set => reorganizeConstantB = value; }

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
                    swarmSoFarTheWorstObjective = double.MinValue;
                    swarmsoFarTheBestObjective = double.MaxValue;
                    break;
                case OptimizationType.Maximization:
                    soFarTheBestObjective = double.MinValue;
                    soFarTheBestObjectiveIteration = double.MaxValue;
                    swarmsoFarTheBestObjective = double.MinValue;
                    swarmSoFarTheWorstObjective = double.MaxValue;
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
                            swarmsoFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                    case OptimizationType.Maximization:
                        if (objectives[i] > soFarTheBestObjective)
                        {
                            soFarTheBestObjective = objectives[i];
                            swarmsoFarTheBestObjective = objectives[i];
                            solutionBest = solutions[i];
                        }
                        break;
                }

            }

        }

        public override void RunOneIteration()
        {
            iterationCount += 1;
            ComputeObjectiveValueAndUpdate();
            UpdateSolution();
        }

        public void ReorganizeSolution()
        {
            for (int i = 0; i < particleNum; i++)
            {
                if (objectives[i] != swarmsoFarTheBestObjective)
                {
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        solutions[i][j] = solutionLowerBound[j] +
                        (randomizer.NextDouble() * (solutionUpperBound[j] - solutionLowerBound[j]))
                        + reorganizeConstantA * Math.Exp(-(reorganizeConstantB * reorganizeCount));
                    }
                }
            }
        }

        public void UpdateSolution()
        {

            for (int i = 0; i < particleNum; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    // update solution
                    solutions[i][j] += randomizer.NextDouble() * maximumMovement * (swarmsolutionBest[j] - solutions[i][j]);

                    // check if solution excess the boundary
                    if (solutions[i][j] > solutionUpperBound[j]) solutions[i][j] = solutionUpperBound[j];
                    else if (solutions[i][j] < solutionLowerBound[j]) solutions[i][j] = solutionLowerBound[j];
                }
            }

            // check if reorganization is needed
           if (Math.Abs(swarmsoFarTheBestObjective - swarmSoFarTheWorstObjective) <= divergenceThreshold) ReorganizeSolution();
        }

        public void ComputeObjectiveValueAndUpdate()
        {
            // reset swarm best and swarm worst solution
            switch (OptimizationMethod)
            {
                case OptimizationType.Minimization:
                    swarmSoFarTheWorstObjective = double.MinValue;
                    swarmsoFarTheBestObjective = double.MaxValue;
                    swarmsolutionBest = new double[numberOfVariables];
                    break;
                case OptimizationType.Maximization:
                    swarmsoFarTheBestObjective = double.MinValue;
                    swarmSoFarTheWorstObjective = double.MaxValue;
                    swarmsolutionBest = new double[numberOfVariables];
                    break;
            }

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
                        if (objectives[i] > swarmSoFarTheWorstObjective) swarmSoFarTheWorstObjective = objectives[i];
                        if (objectives[i] < swarmsoFarTheBestObjective)
                        {
                            swarmsoFarTheBestObjective = objectives[i];
                            swarmsolutionBest = solutions[i];
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
                        if (objectives[i] < swarmSoFarTheWorstObjective) swarmSoFarTheWorstObjective = objectives[i];
                        if (objectives[i] > swarmsoFarTheBestObjective)
                        {
                            swarmsoFarTheBestObjective = objectives[i];
                            swarmsolutionBest = solutions[i];
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
        public double[] SolutionLowerBound { get => solutionLowerBound;}
        public double[] SolutionUpperBound { get => solutionUpperBound;}
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
