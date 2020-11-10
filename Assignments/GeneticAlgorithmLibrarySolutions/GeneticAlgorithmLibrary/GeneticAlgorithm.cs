using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneticAlgorithmLibrary
{

    public delegate double ObjectiveFunction<S>(S[] solution);


    public class GeneticAlgorithm<T>
    {
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
        protected T[][] selectedChromosome;
        protected double[] selectedObjectives;
        protected int[] indices;

        protected ObjectiveFunction<T> theObjectuveEvaluationMethod;

        public GeneticAlgorithm(int numberOfVariables, ObjectiveFunction<T> theMethod)
        {
            numberOfGenes = numberOfVariables;

            soFarBestSolution = new T


        }


        public int PopulationSize
        {
            get => populationSize;
            set
            {
                if (value > 2) populationSize = value;
            }
        }

        public double CrossoverRate
        {
            get => crossoverRate;
            set
            {
                if (value > 1.0) crossoverRate = 1.9;
            }
        }

        #region Public Methods
        bool Reset()
        {
            // alocate memory
            chromosomes = new T[populationSize * 3][];

            for (int i = 0; i < chromosomes.Length; i++)
            {
                chromosomes[i] = new T[numberOfGenes];
            }
            objectiveValues = new double[populationSize * 3];
            fitnessValues = new double[populationSize * 3];

            selectedChromosome = new T[populationSize][];

            for (int i = 0; i < chromosomes.Length; i++)
            {
                selectedChromosome[i] = new T[numberOfGenes];
            }

            selectedObjectives = new double[populationSize];

            indices = new int[populationSize * 3];

            // randomly assign initial gene values
            initializePopulation();

            // compute obkective values
            for (int r = 0; r < populationSize; r++)
            {
                objectiveValues[r] = theObjectuveEvaluationMethod(chromosomes[r]);
            }

            // set initiate value of iteration
            iterationCount = 0;
            return true;
        }

        public virtual bool initializePopulation()
        {
            throw new NotImplementedException();
        }

        bool RunOneIteration()
        {
            performCrossoverOperation();
            performMutationOperation();
            performSoFarTheBestObjectiveAndSolution();
        }

        private void performCrossoverOperation()
        {
            ShuffleAnIntegerArray(indices, PopulationSize);
            numberOfCrossoveredChildren = (int)(populationSize * crossoverRate);
            if (numberOfCrossoveredChildren % 2 == 1) numberOfCrossoveredChildren--;
            for (int p = 0; p < numberOfCrossoveredChildren / 2; p++)
            {
                int child1Idx = populationSize + p;
                int child2Idx = populationSize + p + 1;

                CrossoverAPairOfChildren(indices[p], indices[p + 1], child1Idx, child2Idx);
                objectiveValues[child1Idx] = theObjectuveEvaluationMethod(chromosomes[child1Idx]);
                objectiveValues[child2Idx] = theObjectuveEvaluationMethod(chromosomes[child2Idx]);
                child1Idx += 2;
                child2Idx += 2;
            }
        }

        private void performMutationOperation()
        {
            if (isGeneBasedMutation)
            {
                int pid, cid;
                int[] pos;

                MutateAChild(pid, pos, cid);
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
                    objectiveValues[ChildIIdx] = theObjectuveEvaluationMethod(chromosomes[ChildIIdx]);
                    ChildIIdx++;
                }
            }
        }

        public virtual bool CrossoverAPairOfChildren(int fatherIdx, int moderOdx, int child1Idx, int child2Idx)
        {
            throw new Exception("Not Implemented");
        }

        bool RunToEnd()
        {
            return true;
        }
        #endregion

        void ShuffleAnIntegerArray(int[] a, int len)
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
        }
    }
}
