using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGALibrary
{
    public enum OptimizationType { Minimization, Maximization }
    public enum SelectionMode { Stochastic, Deterministic }
    public delegate double ObjectiveFunction<T>(T[] solution);

    public class GeneticAlgorithm<T>
    {
        protected Random rnd = new Random();

        // data fields
        protected T[][] chromosomes;         //一維陣列[]：population size/[]：solution size
        protected double[] objectiveValues;  //max、min
        protected double[] fitnessValues;    //fitness越大、存活率越高
        protected int[] indices;             //非實質型別；參考型別(referrence type)：放記憶體位置

        protected T[][] selectedChromosomes;
        protected double[] selectedObjectiveValues;
        protected OptimizationType optimizationType = OptimizationType.Minimization;
        protected SelectionMode selectionMode = SelectionMode.Deterministic;

        protected ObjectiveFunction<T> objectiveFunction = null;
       
        protected int iterationBestIndex;
        protected double iterationBestObjectiveValue;
        protected double iterationAverageObjectiveValue;

        protected T[] soFarTheBestSolution;
        protected double soFarTheBestObjectiveValue;

        protected int populationSize = 50;
        protected int numberOfGenes;

        protected int numberOfCrossoveredChildren;
        protected int numberOfMutatedChildren;
        protected double crossoverRate = 0.8;
        protected double mutationRate = 0.2;
        protected bool geneBasedMutation = true;  //populationBasedMutation

        protected int iterationLimit = 200;
        protected int iterationCount = 0;

        protected double leastFitnessFraction = 0.1;  

        protected int[] mutatedPos;

        #region properties

        //properties
        [Category("GA Setting"), Description("染色體數量，建議值不低於變數數量的1/4。")]
        public int PopulationSize
        {
            get
            {
                return populationSize;
            }
            set
            {
                if (value > 2) populationSize = value;
            }
        }
        [Category("GA Setting"), Description("交配率，建議值0.5-0.9。")]
        public double CrossoverRate
        {
            get
            {
                return crossoverRate;
            }
            set
            {
                if (value >= 0.5 && value <= 0.9) crossoverRate = value;  
            }
        }
        [Category("GA Setting"), Description("以染色體個數為基的突變率，建議值0.1-0.6。\n以基因個數為基的突變率，建議值0.01-0.10。")]
        public double MutationRate
        {
            get
            {
                return mutationRate;
            }
            set
            {
                if (value >= 0.01 && value <= 0.6) mutationRate = value;  
            }
        }
        //[Category("GA Setting"), Description("True：以基因個數為基的突變率(Gene Based Mutation)。\nFalse：以染色體個數為基的突變率(Population Based Mutation)。")]
        //public bool GeneBasedMutation  //PopulationBasedMutation
        //{
        //    get
        //    {
        //        return geneBasedMutation;
        //    }
        //    set
        //    {
        //        geneBasedMutation = value;  
        //    }
        //}
        [Category("GA Setting"), Description("最小適應度比例，建議值大於0.0、小於0.5。")]
        public double LeastFitnessFraction
        {
            get
            {
                return leastFitnessFraction;
            }
            set
            {
                if (leastFitnessFraction > 0 &&leastFitnessFraction < 0.5) leastFitnessFraction = value;
            }
        }
        [Category("GA Setting"), Description("停止條件為演化代次上限，建議值大於1000。\n適切值應設為迄今最佳解躺平代次的2倍。")]
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
        [Category("GA Selection Setting"), Description("篩選作業使用的模式：確定型與機率比例隨機模式。")]
        public SelectionMode SelectionMode
        {
            set
            {
                selectionMode = value;
            }
            get
            {
                return selectionMode;
            }           
        }
        [Browsable(false)]
        public int IterationCount
        {
            get => iterationCount;
        }
        [Browsable(false)]
        public double SoFarTheBestObjectiveValue
        {
            get => soFarTheBestObjectiveValue;
        }
        [Browsable(false)]
        public T[] SoFarTheBestSolution
        {
            get => soFarTheBestSolution;
        }
        [Browsable(false)]
        public double IterationBestObjectiveValue
        {
            get => iterationBestObjectiveValue;
        }
        [Browsable(false)]
        public double IterationAverageObjectiveValue
        {
            get => iterationAverageObjectiveValue;
        }
        [Browsable(false)]
        public T[][] Chromosomes
        {
            get => chromosomes;
        }
        #endregion

        // public methods(UI methods)
        public GeneticAlgorithm(int numberOfGenes, OptimizationType type, ObjectiveFunction<T> obj)
        {
            this.numberOfGenes = numberOfGenes;

            //initialize data depend on number of genes            
            soFarTheBestSolution = new T[numberOfGenes];

            optimizationType = type;
            objectiveFunction = obj;
        }

        public virtual void Reset()  //保留擴充彈性
        {
            //reallocate memory which are related to population size
            int size = populationSize * 3;
            chromosomes = new T[size][];
            for (int i = 0; i < chromosomes.Length; i++)
            {
                chromosomes[i] = new T[numberOfGenes];
            }
            InitializePopulationChromosomes();  //子類別初始化

            indices = new int[size];
            objectiveValues = new double[size];
            fitnessValues = new double[size];
            
            //compute objective values of the population
            for (int i = 0; i < populationSize; i++)
            {
                objectiveValues[i] = objectiveFunction(chromosomes[i]);
            }
            numberOfCrossoveredChildren = 0;
            numberOfMutatedChildren = 0;

            //set iterationbestobjective to the worst
            if (optimizationType == OptimizationType.Maximization)
            {
                iterationBestObjectiveValue = double.MinValue;
            }
            else  //OptimizationType.minimization
            {
                iterationBestObjectiveValue = double.MaxValue;
            }

            //set sofarthebestobjective to the worst
            if (optimizationType == OptimizationType.Maximization)
            {
                soFarTheBestObjectiveValue = double.MinValue;
            }
            else  //OptimizationType.minimization
            {
                soFarTheBestObjectiveValue = double.MaxValue;
            }           

            selectedChromosomes = new T[populationSize][];
            for (int i = 0; i < selectedChromosomes.Length; i++)
            {
                selectedChromosomes[i] = new T[numberOfGenes];
            }
            selectedObjectiveValues = new double[populationSize];

            iterationCount = 0;
        }

        public virtual void InitializePopulationChromosomes()  //override
        {
            //randomly assign initial values
            throw new Exception("No Implementation !");
        }

        //protected double computeObjectiveValues()

        public virtual void RunOneIteration()  
        {
            if (iterationCount >= iterationLimit) return;

            PerformCrossoverOperation();
            //PerformMutationOperation();
            PerformSelectionOperation();

            iterationCount++;
        }

        private void PerformCrossoverOperation()
        {            
            //PermuteIndicies(populationSize);  
            ShuffleIntegerArray(indices, populationSize);  //排列組合索引位置
            numberOfCrossoveredChildren = (int)(populationSize * crossoverRate) / 2 * 2;  //確保偶數
            int pair = numberOfCrossoveredChildren / 2;
            for (int i = 0; i < pair; i++)
            {
                int cid1 = populationSize + i * 2;
                int cid2 = cid1 + 1;
                GenerateAPairOfCrossoveredChildren(indices[i * 2], indices[i * 2 + 1], cid1, cid2);  //crossovered children索引及位置(father id/ mother id /child1 id/ child2 id)

                //compute objective values of the crossovered children
                objectiveValues[cid1] = objectiveFunction(chromosomes[cid1]);
                objectiveValues[cid2] = objectiveFunction(chromosomes[cid2]);
            }
            #region
            //for (int i = populationSize; i < populationSize + numberOfCrossoveredChildren; i++)
            //{
            //    objectiveValues[i] = objectiveFunction(chromosomes[i]);
            //}
            #endregion
        }

        protected virtual void GenerateAPairOfCrossoveredChildren(int father, int mother, int child1, int child2)
        {
            throw new NotImplementedException();
        }

        //protected void PermuteIndicies(int populationSize)
        //{
        //    for (int i = 0; i < populationSize; i++)
        //    {
        //        indices[i] = i;
        //    }
        //    for (int j = populationSize - 1; j > 0; j--)
        //    {
        //        //swap交換
        //        int pos = rnd.Next(j + 1);  //小於populationSize(最大值)的非負值隨機整數
        //        int temp = indices[pos];
        //        indices[pos] = indices[j];
        //        indices[j] = temp;
        //    }
        //}

        protected void ShuffleIntegerArray(int[] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }
            for (int j = size - 1; j > 0; j--)
            {
                //swap交換
                int pos = rnd.Next(j + 1);  //小於populationSize(最大值)的非負值隨機整數
                int temp = array[pos];
                array[pos] = array[j];
                array[j] = temp;
            }
        }

        List<int> geneLocation = new List<int>();

        private void PerformMutationOperation()
        {
            if (geneBasedMutation)
            {
                // gene based
                int all = populationSize * numberOfGenes;
                int num = (int)(all * mutationRate);  //幾個基因突變
                if (num > indices.Length) num = indices.Length;
                //if (num > indices.Length - populationSize - numberOfCrossoveredChildren) num = indices.Length - populationSize - numberOfCrossoveredChildren;
                for (int i = 0; i < num; i++)
                {
                    indices[i] = rnd.Next(all);
                }
                Array.Sort(indices, 0, num);  //由小到大排序

                //indices contains locations of genes to be mutated
                numberOfMutatedChildren = 0;
                int cid = populationSize + numberOfCrossoveredChildren - 1;               
                for (int i = 0; i < populationSize; i++)
                {
                    geneLocation.Clear();
                    for (int j = 0; j < num; j++)
                    {
                        //parent i cannot be mutated
                        if (indices[j] / numberOfGenes != i) continue;
                        //parent i is mutated
                        else if (indices[j] / numberOfGenes == i)
                        {
                            if (geneLocation.Count == 0)
                            {
                                numberOfMutatedChildren++;
                                cid++;
                            }
                            geneLocation.Add(indices[j] % numberOfGenes);                           
                            GenerateAMutatedChildren(i, cid, geneLocation);
                            objectiveValues[cid] = objectiveFunction(chromosomes[cid]);
                        }                                            
                    }                                                         
                }
            }
            else 
            {
                // chromosome(population) based
                //PermuteIndicies(populationSize);
                ShuffleIntegerArray(indices, populationSize);
                numberOfMutatedChildren = (int)(populationSize * mutationRate);
                for (int i = 0; i < numberOfMutatedChildren; i++)
                {
                    int cid = populationSize + numberOfCrossoveredChildren + i;
                    GenerateAMutatedChildren(indices[i], cid);  //mutateded children索引及位置(parent id/ child id)
                    //compute objective values of the mutated children
                    objectiveValues[cid] = objectiveFunction(chromosomes[cid]);
                }                               
            }
        }
      
        protected virtual void GenerateAMutatedChildren(int parent, int child)
        {
            throw new NotImplementedException();
        }
        protected virtual void GenerateAMutatedChildren(int parent, int child, List<int> geneLocation)
        {           
            throw new NotImplementedException();
        }

        private void PerformSelectionOperation()
        {
            double omax, omin;
            omax = double.MinValue;
            omin = double.MaxValue;
            double objectiveValueSum = 0;
            iterationAverageObjectiveValue = 0;
            int total = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;
            for (int i = 0; i < total; i++)  //one path
            {               
                if (objectiveValues[i] > omax) omax = objectiveValues[i];  //objectiveValues.Max();objectiveValues.Min();objectiveValues.Average();->重新loop through3次
                if (objectiveValues[i] < omin) omin = objectiveValues[i];
                
                objectiveValueSum += objectiveValues[i];                
            }
            //update IterationAverageObjectiveValue
            iterationAverageObjectiveValue = objectiveValueSum / total;

            //compute fitness from objective values
            double minFitness = leastFitnessFraction * (omax - omin);
            if (minFitness < 1e-5) minFitness = 1e-5;  //若末代omax=omin，機率不能為0
            if (optimizationType == OptimizationType.Maximization)
            {
                for (int i = 0; i < total; i++)
                {
                    fitnessValues[i] = minFitness + objectiveValues[i] - omin;
                }
            }
            else  //OptimizationType.minimization
            {
                for (int i = 0; i < total; i++)
                {
                    fitnessValues[i] = minFitness + omax - objectiveValues[i];
                }
            }
                  
            //update the best solution and objective value of one iteration(indices[0])
            //update so far the best solution and objective value
            if (optimizationType == OptimizationType.Maximization)
            {
                iterationBestObjectiveValue = double.MinValue;
                for (int i = 0; i < total; i++)
                {
                    if (objectiveValues[i] > iterationBestObjectiveValue)
                    {
                        iterationBestObjectiveValue = objectiveValues[i];  //omax
                        iterationBestIndex = i;                                            
                    }
                }              
                if (iterationBestObjectiveValue > soFarTheBestObjectiveValue)
                {
                    soFarTheBestObjectiveValue = iterationBestObjectiveValue;
                    //gene-wise copy
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        soFarTheBestSolution[j] = chromosomes[iterationBestIndex][j];
                    }
                }              
            }
            else  //OptimizationType.minimization
            {
                iterationBestObjectiveValue = double.MaxValue;               
                for (int i = 0; i < total; i++)
                {
                    if (objectiveValues[i] < iterationBestObjectiveValue)
                    {
                        iterationBestObjectiveValue = objectiveValues[i];  //omin
                        iterationBestIndex = i;
                    }
                }               
                if (iterationBestObjectiveValue < soFarTheBestObjectiveValue)
                {
                    soFarTheBestObjectiveValue = iterationBestObjectiveValue;
                    //gene-wise copy
                    for (int j = 0; j < numberOfGenes; j++)
                    {                     
                        soFarTheBestSolution[j] = chromosomes[iterationBestIndex][j];
                    }
                }                               
            }
            #region
            //else  //OptimizationType.minimization
            //{
            //    //iterationBestObjectiveValue = double.MaxValue;
            //    for (int i = 0; i < total; i++)
            //    {
            //        if (objectiveValues[i] < iterationBestObjectiveValue)
            //        {
            //            iterationBestObjectiveValue = omin;
            //            //iterationBestObjectiveValue = objectiveValues[i];
            //            //gene-wise copy
            //            for (int j = 0; j < numberOfGenes; j++)
            //            {
            //                iterationBestSolution[j] = chromosomes[i][j];
            //            }
            //        }
            //    }
            //    //soFarTheBestObjectiveValue = double.MaxValue;
            //    if (iterationBestObjectiveValue < soFarTheBestObjectiveValue)
            //    {
            //        soFarTheBestObjectiveValue = iterationBestObjectiveValue;
            //        for (int i = 0; i < populationSize; i++)
            //        {
            //            //gene-wise copy
            //            for (int j = 0; j < numberOfGenes; j++)
            //            {
            //                soFarTheBestSolution[j] = iterationBestSolution[j];
            //            }
            //        }
            //    }
            //}
            #endregion

            //selection
            if (selectionMode == SelectionMode.Stochastic)
            {
                //assign selected indicies to indicies
                //aggregate fitness
                double fitnessSum = 0;                
                for (int i = 0; i < total; i++)
                {
                    fitnessSum += fitnessValues[i];
                }
                //cumulativeFitness
                //fitnessValues[0] = fitnessValues[0];
                for (int i = 1; i < total; i++)  
                {
                    fitnessValues[i] = fitnessValues[i - 1] + fitnessValues[i];
                }                
                //execute populationSize stochastic selection
                for (int i = 0; i < populationSize; i++)
                {
                    double qRandomValue = rnd.NextDouble() * fitnessSum;
                    for (int j = 0; j < total; j++)
                    {
                        if (qRandomValue <= fitnessValues[j])
                        {
                            indices[i] = j;
                            break;
                        }
                    }
                }
                #region
                //double fitnessSum = 0;               
                //double[] cumulativeFitness = new double[total];
                //for (int i = 0; i < total; i++)
                //{
                //    fitnessSum += fitnessValues[i];
                //}               
                //cumulativeFitness[0] = fitnessValues[0];
                //for (int i = 1; i < total; i++)
                //{
                //    cumulativeFitness[i] = cumulativeFitness[i - 1] + fitnessValues[i];
                //}
                ////execute populationSize stochastic selection
                //for (int i = 0; i < populationSize; i++)
                //{
                //    double qRandomValue = rnd.NextDouble() * fitnessSum;
                //    for (int j = 0; j < total; j++)
                //    {
                //        if (qRandomValue <= cumulativeFitness[j])
                //        {
                //            indices[i] = j;
                //            break;
                //        }                       
                //    }
                //}

                //double fitnessSum = 0;
                //double[] normalProbability = new double[total];
                //double[] cumulativeProbability = new double[total];
                //for (int i = 0; i < total; i++)
                //{
                //    fitnessSum += fitnessValues[i];
                //}
                //for (int i = 0; i < total; i++)
                //{
                //    normalProbability[i] = fitnessValues[i] / fitnessSum;
                //}
                //cumulativeProbability[0] = normalProbability[0];
                //for (int i = 1; i < total; i++)
                //{
                //    cumulativeProbability[i] = cumulativeProbability[i - 1] + normalProbability[i];
                //}
                ////execute populationSize stochastic selection
                //for (int i = 0; i < populationSize; i++)
                //{
                //    double qRandomValue = rnd.NextDouble();
                //    for (int j = 0; j < total; j++)
                //    {
                //        if (qRandomValue <= cumulativeProbability[j])
                //        {
                //            indices[i] = j;
                //            break;
                //        }
                //    }
                //}                
                #endregion
            }
            else  //SelectionMode.Deterministic
            {
                //sort fitness and indicies
                for (int i = 0; i < total; i++)
                {
                    indices[i] = i;
                }
                Array.Sort(fitnessValues, indices, 0, total);  //依照適應值由小到大排序
                Array.Reverse(fitnessValues, 0, total);        //反轉：適應值由大到小排序
                Array.Reverse(indices, 0, total);              //反轉
            }           

            //copy gene to selected buffer
            for (int i = 0; i < populationSize; i++)
            {
                //gene-wise copy
                for (int j = 0; j < numberOfGenes; j++)
                {
                    selectedChromosomes[i][j] = chromosomes[indices[i]][j];
                }
                selectedObjectiveValues[i] = objectiveValues[indices[i]];
            }
            //copy back to population
            for (int i = 0; i < populationSize; i++)
            {               
                for (int j = 0; j < numberOfGenes; j++)
                {
                    chromosomes[i][j] = selectedChromosomes[i][j];
                }
                objectiveValues[i] = selectedObjectiveValues[i];
            }
        }

        public virtual void RunToEnd()
        {
            do
            {
                RunOneIteration();
            }
            while (iterationCount < iterationLimit);
        }
        // helping functions
    }
}
