using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithmLibrary
{

    public enum OptimizationType { Minimization, Maximization };

    public enum SelectionType { Deterministic, Stochastic, Hybrid };

    public delegate double ObjectiveFunction<S>(S[] solution);

    // Create a method for a delegate.

    public class GeneticAlgorithm<T>
    {

        protected OptimizationType optimizationType = OptimizationType.Minimization;

        // template class
        protected Random randomizer = new Random();

        protected T[][] chromosomes;
        protected double[] objectiveValues;
        protected double[] fitnessValues;
        protected T[] soFarBestSolution;
        protected double soFarTheBestObjectiveValue;
        protected double iterationAverageObj;
        protected double iterationBestObj;
        int iterationCount;

        protected int numberOfGenes; // number of genes in a chromosome
        protected int populationSize = 100;
        protected double crossoverRate = 0.8;
        protected bool isGeneBasedMutation = true; // gene-based chromosome-base
        protected bool isMinimization = true;
        protected double mutationRate = 0.05;

        protected int numberOfCrossoveredChildren;
        protected int numberOfMutatedChildren;
        protected T[][] selectedChromosomes;
        protected double[] selectedObjectives;
        protected int[] indices;
        protected int[] mutatedPositions;

        protected ObjectiveFunction<T> theObjectiveEvaluationMethod;
        // other variables
        int iterationLimit = 100;
        private int numberOfVariables;
        private ObjectiveFunction<double> theMethod;
        double iterationObjective, iterationAverageObjective;
        double[] machineJobsWeight;


        // properties
        public SelectionType SelectionMode { set; get; } = SelectionType.Deterministic;

        public int PopulationSize
        {
            get => populationSize;
            set
            {
                if (value is int && value > 2) populationSize = value;
            }
        }

        public double CrossoverRate
        {
            get => crossoverRate;
            set
            {
                if (value > 1.0)
                    crossoverRate = 1.0;
                else if (value > 0)
                    crossoverRate = value;
            }
        }

        public int IterationLimit
        {
            set
            {
                if (value is int && value > 2) iterationLimit = value;
            }
            get
            {
                return iterationLimit;
            }
        }

        public double IterationBestObjective { get; }

        public double SoFarTheBestObjectiveValue { get; set; }

        public double[] MachineJobWeight
        {
            get
            {
                return machineJobsWeight;
            }
            set
            {
                if (value is double[]) machineJobsWeight = value;
            }
        }

        public OptimizationType OptimizationType
        {
            get
            {
                return optimizationType;
            }
            set
            {
                if (value is OptimizationType) optimizationType = value;
            }
        }

        [Browsable(false)]
        public int IterationCount { get => iterationCount; }


        public GeneticAlgorithm(int numberOfVariables, OptimizationType type, ObjectiveFunction<T> theMethod)
        {
            optimizationType = type;
            numberOfGenes = numberOfVariables;
            soFarBestSolution = new T[numberOfGenes];
            theObjectiveEvaluationMethod = theMethod;
            mutatedPositions = new int[numberOfGenes];
        }

        public GeneticAlgorithm(int numberOfVariables, ObjectiveFunction<double> theMethod)
        {
            this.numberOfVariables = numberOfVariables;
            this.theMethod = theMethod;
        }


        #region Public Methods
        public bool Reset()
        {
            // alocate memory
            //  population genes, crossovered genes, mutated genes 
            chromosomes = new T[populationSize * 3][];

            for (int i = 0; i < chromosomes.Length; i++)
            {
                chromosomes[i] = new T[numberOfGenes];
            }
            objectiveValues = new double[populationSize * 3];
            fitnessValues = new double[populationSize * 3];

            selectedChromosomes = new T[populationSize][];

            for (int i = 0; i < selectedChromosomes.Length; i++)
            {
                selectedChromosomes[i] = new T[numberOfGenes];
            }

            selectedObjectives = new double[populationSize];

            indices = new int[populationSize * 3];

            // randomly assign initial gene values
            initializePopulation();

            // compute objective values
            for (int r = 0; r < populationSize; r++)
            {
                objectiveValues[r] = theObjectiveEvaluationMethod(chromosomes[r]);
                //MessageBox.Show(objectiveValues[r].ToString());
            }

            // ...
            // set initiate value of iteration
            iterationCount = 0;
            return true;
        }

        public virtual bool initializePopulation()
        {
            throw new NotImplementedException();
        }

        public virtual bool RunOneIteration()
        {
            PerformCrossoverOperation();
            PerformMutationOperation();
            UpdateSoFarTheBestObjectiveAndSolution();
            PerformSelectionOperation();
            return true;
        }

        public virtual void PerformSelectionOperation()
        {
            // calculate fitness
            CalculateFitnessValues();

            int limit = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;

            switch (SelectionMode)
            {
                case SelectionType.Deterministic:
                    for (int i = 0; i < limit; i++)
                    {
                        indices[i] = i;
                    }
                    Array.Sort(fitnessValues, indices, 0, limit);
                    Array.Reverse(indices, 0, limit);
                    break;
                case SelectionType.Stochastic:
                    // fitness

                    break;
            }
            // gene-wise copy selected chromosome

            for (int r = 0; r < populationSize; r++)
            {
                selectedObjectives[r] = objectiveValues[indices[r]];
                for (int c = 0; c < numberOfGenes; c++)
                {
                    selectedChromosomes[r][c] = chromosomes[indices[r]][c];

                }
            }

            // copy back to parent chromosome for the next generation

            for (int r = 0; r < populationSize; r++)
            {
                objectiveValues[r] = selectedObjectives[indices[r]];
                for (int c = 0; c < numberOfGenes; c++)
                {
                    selectedChromosomes[r][c] = chromosomes[indices[r]][c];

                }
            }
        }

        private void CalculateFitnessValues()
        {
            if (optimizationType == OptimizationType.Minimization)
            {
                //minization //
                double objmin = double.MaxValue;
                double objmax = double.MinValue;
                for (int i = 0; i < populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren; i++)
                {
                    fitnessValues[i] = objectiveValues[i];
                    //自己改...
                    if (objectiveValues[i] > objmax)
                    {
                        objmax = objectiveValues[i];
                    }
                    else if (objectiveValues[i] < objmin)
                    {
                        objmin = objectiveValues[i];
                    }
                }
                double alpha = 0.3; //介在0~0.5之間
                double b = Math.Max(alpha * (objmax - objmin), 1 / 100000);
                for (int i = 0; i < populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren; i++)
                {
                    if (optimizationType == OptimizationType.Maximization)
                    {
                        fitnessValues[i] = objectiveValues[i] - objmin;
                    }
                    else if (optimizationType == OptimizationType.Minimization)
                    {
                        fitnessValues[i] = objmax - objectiveValues[i];
                    }

                }
            }
            else if (optimizationType == OptimizationType.Maximization)
            {


            }
        }

        public virtual void UpdateSoFarTheBestObjectiveAndSolution()
        {
            iterationAverageObj = 0.0;

            //iterationBestObj = optimizationType == OptimizationType.Maximization ? double.MinValue;

            if (optimizationType == OptimizationType.Maximization) iterationBestObj = double.MinValue; else iterationBestObj = double.MaxValue;


            int limit = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;

            for (int i = 0; i < limit; i++)
            {
                iterationAverageObj += objectiveValues[i];
            }

            iterationAverageObj /= limit;

            // do not use implemented method
            double d = objectiveValues.Min();
            double avg = objectiveValues.Average();

            // if new so far the best solution happens
            // gene-wise copy the chromsome value to soFarTheBestSolution
        }

        private void PerformCrossoverOperation()
        {
            ShuffleAnIntegerArray(indices, PopulationSize);
            numberOfCrossoveredChildren = (int)(populationSize * crossoverRate);
            if (numberOfCrossoveredChildren % 2 == 1) numberOfCrossoveredChildren--;
            for (int p = 0; p < numberOfCrossoveredChildren / 2; p++)
            {
                int child1Idx = populationSize + p;
                int child2Idx = populationSize + p + 1;

                CrossoverAPairOfChildren(indices[p], indices[p + 1], child1Idx, child2Idx);
                objectiveValues[child1Idx] = theObjectiveEvaluationMethod(chromosomes[child1Idx]);
                objectiveValues[child2Idx] = theObjectiveEvaluationMethod(chromosomes[child2Idx]);
                child1Idx += 2;
                child2Idx += 2;
            }
        }

        private void PerformMutationOperation()
        {
            if (isGeneBasedMutation)
            {
                int pid = 0;
                int cid = 0;
                int numberOfPositions = 0;

                MutateAChild(pid, cid, mutatedPositions, numberOfPositions);
            }
            else
            {
                // chromosome-based
                numberOfCrossoveredChildren = (int)(populationSize * mutationRate);

                if (numberOfMutatedChildren > populationSize) numberOfMutatedChildren = populationSize;
                ShuffleAnIntegerArray(indices, populationSize);

                int ChildIIdx = populationSize + numberOfMutatedChildren;

                for (int i = 0; i < numberOfMutatedChildren; i++)
                {
                    MutateAChild(indices[i], ChildIIdx);
                    objectiveValues[ChildIIdx] = theObjectiveEvaluationMethod(chromosomes[ChildIIdx]);
                    ChildIIdx++;
                }
            }
        }

        public virtual void MutateAChild(int pid, int cid, int[] pos, int numberOfLocations)
        {
            throw new NotImplementedException();
        }

        public virtual void MutateAChild(int v, int childIIdx)
        {
            throw new NotImplementedException();
        }

        public virtual bool CrossoverAPairOfChildren(int fatherIdx, int moderOdx, int child1Idx, int child2Idx)
        {
            throw new Exception("Not Implemented");
        }

        public virtual bool RunToEnd()
        {
            return true;
        }
        #endregion

        public int[] ShuffleAnIntegerArray(int[] a, int len)
        {
            if (a.Length < len) throw new Exception("Length is not correct");

            for (int i = 0; i < len; i++)
            {
                a[i] = i;
            }

            for (int c = len - 1; c > 1; c--)
            {
                int pos = randomizer.Next(c + 1);
                int temp = a[c];
                a[c] = a[pos];
                a[pos] = temp;
            }

            return a;
        }

        
    }


}
