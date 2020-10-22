using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGALibrary
{
    public enum OptimizationType { minimization, maximization}
    public enum SelectionMode {  stochastic, deterministic }

    public delegate double ObjectiveFunction<G>(G[] solution);

    public class GeneticAlgorithm<T> 
    {
        protected Random rnd = new Random();
        // data fields
        protected T[][] chromosomes;
        protected int[] indices;
        protected double[] objectiveValues;
        protected double[] fitnessValues;
        protected T[][] selectedChromosomes;
        protected double[] SelectedObjectives;
        protected OptimizationType optimiztaionType = OptimizationType.minimization;
        protected SelectionMode selectionMode = SelectionMode.deterministic;

        protected ObjectiveFunction<T> objectiveFunction = null;

        protected T[] soFarTheBestSolution;
        protected double soFarTheBestObjective;
        protected int populationSize = 50;
        protected int numberOfGenes;
        protected int numberOfCrossoveredChildren;
        protected int numberOfMutatedChildren;
        protected double crossoverRate = 0.8;
        protected double mutationRate = 0.2;
        protected bool geneBasedMutation = false;
        protected int iterationLimit = 200;

        protected int iterationCount = 0;

        // properties
        public int PopulationSize
        {
            get { return populationSize; }
            set
            {
                if (value > 2) populationSize = value;
            }
        }
        // add your own properties

        // public methods
        public GeneticAlgorithm(  int numberOfGenes, OptimizationType type, ObjectiveFunction<T> obj )
        {
            this.numberOfGenes = numberOfGenes;
            // initialize data depend on number of genes
            soFarTheBestSolution = new T[numberOfGenes];

            optimiztaionType = type;
            objectiveFunction = obj;
        }

        public virtual void Reset()
        {
            // reallocate memory which are related to populuationSize
            int size = populationSize * 3;
            chromosomes = new T[size][];
            for (int i = 0; i < chromosomes.Length; i++)
                chromosomes[i] = new T[numberOfGenes];

            InitializePopulationChromosomes();

            objectiveValues = new double[size];
            // compute objective values of the population
            for( int i = 0; i < populationSize; i++)
            {
                objectiveValues[i] = objectiveFunction(chromosomes[i]);
            }
            numberOfCrossoveredChildren = 0;
            numberOfMutatedChildren = 0;

            // set sofarthebestobjective to the worst
            if (optimiztaionType == OptimizationType.maximization)
                soFarTheBestObjective = double.MinValue;
            else
                soFarTheBestObjective = double.MaxValue;


            fitnessValues = new double[size];
            indices = new int[size];

            selectedChromosomes = new T[populationSize][];
            SelectedObjectives = new double[populationSize];
            iterationCount = 0;
        }

        

        public virtual void InitializePopulationChromosomes()
        {
            // randomly assign initial values;
            throw new Exception("No implementation!");
        }

        public virtual void RunOneIteration()
        {
            if (iterationCount >= iterationLimit) return;

            PerformCrossoverOperation();
            PerformMutationOperation();
            PerformSelectionOperation();

            iterationCount++;
        }

        double leastFitnessFraction = 0.1;
        private void PerformSelectionOperation()
        {
            double omax, omin;
            omax = double.MinValue;
            omin = double.MaxValue;
            int total = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;
            for( int i = 0; i < total; i++)
            {
                if (objectiveValues[i] > omax) omax = objectiveValues[i];
                if (objectiveValues[i] < omin ) omin = objectiveValues[i];
            }
            // compute fitness from objectives
            double min = leastFitnessFraction * (omax - omin);
            if (min < 1e-5) min = 1e-5;
            //...
            // Sort fitnesses and indices
            for (int i = 0; i < total; i++) indices[i] = i;
            Array.Sort(fitnessValues, indices, 0, total);
            Array.Reverse(fitnessValues, 0, total);
            Array.Reverse(indices, 0, total);
            // update so far the best solution and objective
            // the iteration best solution is indices[0]
            // ... if 

            // selection
            if( selectionMode == SelectionMode.stochastic )
            {
                // Reassign selected ids to indices
            }
            // copy genes to selected buffer
            for (int i = 0; i < populationSize; i++)
            {
                // gene-wise copy
                for (int j = 0; j < numberOfGenes; j++)
                {
                    selectedChromosomes[i][j] = chromosomes[indices[i]][j];
                }
                SelectedObjectives[i] = objectiveValues[indices[i]];
            }
            // copy back 
            for (int i = 0; i < populationSize; i++)
            {
                // gene-wise copy
                for (int j = 0; j < numberOfGenes; j++)
                {
                    chromosomes[i][j] = selectedChromosomes[i][j];
                }
                objectiveValues[i] = SelectedObjectives[i];
            }
        }

        private void PerformMutationOperation()
        {
            if( geneBasedMutation )
            {
                //gene based
            }
            else
            {
                // chromosome based
                PermuteIndices(populationSize);
                numberOfMutatedChildren = (int)(mutationRate * populationSize);
                for( int i = 0; i < numberOfMutatedChildren; i++ )
                {
                    int cid = populationSize + numberOfCrossoveredChildren + i;
                    GenerateAMutatedChild(indices[i], cid);
                    // compute objectives
                    objectiveValues[cid] = objectiveFunction(chromosomes[cid]);
                }
            }
        }

        protected virtual void GenerateAMutatedChild(int parent, int child)
        {
            throw new NotImplementedException();
        }

        private void PerformCrossoverOperation()
        {
            PermuteIndices( populationSize );
            numberOfCrossoveredChildren = (int)( populationSize * crossoverRate) / 2 * 2;
            int pair = numberOfCrossoveredChildren / 2;
            for( int i = 0; i< pair; i++ )
            {
                int cid1 = populationSize + i * 2;
                int cid2 = cid1 + 1;
                GenerateAPairOfCrossoveredChildren(
                    indices[i * 2], indices[i * 2 + 1], cid1, cid2);
            // compute objectives for crossovered children
                objectiveValues[cid1] = objectiveFunction(chromosomes[cid1]);
                objectiveValues[cid2] = objectiveFunction(chromosomes[cid2]);

            }
        }

        protected virtual void GenerateAPairOfCrossoveredChildren(int father, int mother, int child1, int child2)
        {
            throw new NotImplementedException();
        }

        private void PermuteIndices(int populationSize)
        {
            for (int i = 0; i < populationSize; i++)
                indices[i] = 0; 
            
            for( int j = populationSize-1; j > 1; j--)
            {
                int pos = rnd.Next(j + 1);
                int temp = indices[pos];
                indices[pos] = indices[j];
                indices[j] = temp;
            }
        }

        public virtual void RunToEnd()
        {
            do
            {
                RunOneIteration();
            } while (iterationCount < iterationLimit);
        }
        // helping functions
    }
}
