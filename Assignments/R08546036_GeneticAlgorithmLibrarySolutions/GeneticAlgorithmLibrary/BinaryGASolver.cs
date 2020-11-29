using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmLibrary
{


    public class BinaryGASolver : GeneticAlgorithm<byte>
    {
        #region variables
        private double penaltyFactor = 100.0;
        byte[] bestSolutionAnswer;
        int[] indexArrayParent;
        int[] indexArrayChild;
        double objValue;
        double bestSolutionValue;
        double iterationBest;

        // other variables
        byte[] temp;
        int[] temp_1;
        int[] temp_2;
        int[] mapping;
        int index_1;
        int index_2;
        int temp_num;
        int temp_num_2;
        byte[][] tempTemp;

        // for run one iteration
        int pid1;
        int pid2;
        int cid1;
        int cid2;
        #endregion

        // properties
        public enum CrossoverType { PMX, OX, POX, OSS, OCCC, OnePointCut, TwoPointCut, N }
        public CrossoverType CrossoverOperator { set; get; } = CrossoverType.TwoPointCut;

        public double PenaltyFactor
        {
            get
            {
                return penaltyFactor;
            }
            set
            {
                if (value is double && value > 0) penaltyFactor = value;
            }
        }

        public byte[][] Chromosome
        {
            get
            {
                return chromosomes;
            }
        }

        public byte[] BestSolutionAnswer { get => bestSolutionAnswer; }

        public double BestSolutionValue { get => bestSolutionValue; }
        public double IterationBest { get => iterationBest; }

        // functions

        /// <summary>
        /// This is the constructor of creating a binary-coded GA solver
        /// </summary>
        /// <param name="numberOfVariables"> Number of variables in the Optimization Problem</param>
        /// <param name="type"> Optimization Type: maximization or minimization </param>
        /// <param name="theMethod">The objective function delegate </param>

        public BinaryGASolver(int numberOfVariables, OptimizationType type, ObjectiveFunction<byte> theMethod)
            : base(numberOfVariables, type, theMethod)
        {
            // default section
            optimizationType = type;
            numberOfGenes = numberOfVariables;
            //soFarBestSolution = new T[numberOfGenes];
            theObjectiveEvaluationMethod = theMethod;
            mutatedPositions = new int[numberOfGenes];
        }

        public override bool CrossoverAPairOfChildren(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            switch (CrossoverOperator)
            {
                case CrossoverType.OnePointCut:
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i < temp_num)
                        {
                            chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                            chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
                        }
                        else
                        {
                            chromosomes[child2Idx][i] = chromosomes[fatherIdx][i];
                            chromosomes[child1Idx][i] = chromosomes[motherIdx][i];
                        }

                    }
                    break;
                case CrossoverType.TwoPointCut:
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i < temp_num)
                        {
                            chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                            chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
                        }
                        else if (temp_num < i && i < temp_num_2)
                        {
                            chromosomes[child2Idx][i] = chromosomes[fatherIdx][i];
                            chromosomes[child1Idx][i] = chromosomes[motherIdx][i];
                        }
                        else
                        {
                            chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                            chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
                        }

                    }
                    break;
            }

            return true;
        }

        public override void MutateAChild(int pid, int cid, int[] pos, int numberOfLocations)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                chromosomes[cid][i] = chromosomes[pid][i];
            }

            for (int i = 0; i < numberOfLocations; i++)
            {
                if (chromosomes[cid][pos[i]] == 1)
                {
                    chromosomes[cid][pos[i]] = 0;
                }
                else if (chromosomes[cid][pos[i]] == 0)
                {
                    chromosomes[cid][pos[i]] = 1;
                }
            }
        }

        public override void UpdateSoFarTheBestObjectiveAndSolution()
        {
            for (int i = 0; i < populationSize * 3; i++)
            {
                objValue = 0;
                for (int j = 0; j < numberOfGenes; j++)
                {
                    objValue += chromosomes[i][j] * MachineJobWeight[j];
                    if (chromosomes[i][j] == 1) temp_num += 1;
                }
                
                // panalty function
                temp_num = (int)Math.Sqrt(numberOfGenes);
                
                for (int j = 0; j < temp_num; j++) {

                    temp_num_2 = 0;

                    for (int k = 0; k < temp_num; k++) {
                        if (chromosomes[i][j + k] == 1) temp_num_2 += 1;

                        if (j == k && chromosomes[i][j + k] == 1) temp_num_2 += 1;
                    }

                    switch (optimizationType) {
                        case OptimizationType.Maximization:
                            if (temp_num_2 - 1  >= 0) objValue -= (temp_num_2 - 1) * penaltyFactor;
                            else objValue += (temp_num_2 - 1) * penaltyFactor;
                            break;
                        case OptimizationType.Minimization:
                            if (temp_num_2 - 1 >= 0) objValue += (temp_num_2 - 1) * penaltyFactor;
                            else objValue -= (temp_num_2 - 1) * penaltyFactor;
                            break;
                    }
                }

                objectiveValues[i] = objValue;
            }

            switch (OptimizationType)
            {
                case OptimizationType.Maximization:
                    if (bestSolutionValue < objectiveValues.Max())
                    {
                        bestSolutionValue = objectiveValues.Max();
                        for (int i = 0; i < populationSize * 3; i++)
                        {
                            if (objectiveValues[i] == bestSolutionValue)
                            {
                                bestSolutionAnswer = chromosomes[i];
                                break;
                            }
                        }
                    }
                    iterationBest = objectiveValues.Max();
                    break;
                case OptimizationType.Minimization:
                    if (bestSolutionValue > objectiveValues.Min())
                    {
                        bestSolutionValue = objectiveValues.Min();
                        for (int i = 0; i < populationSize * 3; i++)
                        {
                            if (objectiveValues[i] == bestSolutionValue)
                            {
                                bestSolutionAnswer = chromosomes[i];
                                break;
                            }
                        }
                    }
                    iterationBest = objectiveValues.Min();
                    break;
            }

        }


        public override bool initializePopulation()
        {
            for (int r = 0; r < populationSize; r++)
            {
                for (int c = 0; c < numberOfGenes; c++)
                {
                    chromosomes[r][c] = (byte)randomizer.Next(2);
                }
            }

            if (OptimizationType == OptimizationType.Maximization) bestSolutionValue = double.MinValue;

            if (OptimizationType == OptimizationType.Minimization) bestSolutionValue = double.MaxValue;

            return true;
        }

        public override void PerformSelectionOperation()
        {
            switch (SelectionMode)
            {
                case SelectionType.Best:
                    switch (optimizationType)
                    {
                        case OptimizationType.Maximization:
                            indexArrayParent = objectiveValues.Take(populationSize)
                           .Select((value, index) => new { value, index })
                           .OrderByDescending(item => item.value)
                           .Select(item => item.index)
                           .ToArray();

                            indexArrayChild = objectiveValues.Skip(populationSize)
                                   .Select((value, index) => new { value, index })
                                   .OrderByDescending(item => item.value)
                                   .Select(item => item.index)
                                   .ToArray();
                            break;
                        case OptimizationType.Minimization:
                            indexArrayParent = objectiveValues.Take(populationSize)
                           .Select((value, index) => new { value, index })
                           .OrderBy(item => item.value)
                           .Select(item => item.index)
                           .ToArray();

                            indexArrayChild = objectiveValues.Skip(populationSize)
                                   .Select((value, index) => new { value, index })
                                   .OrderBy(item => item.value)
                                   .Select(item => item.index)
                                   .ToArray();
                            break;
                    }

                    //ShuffleAnIntegerArray(indexArrayParent, indexArrayParent.Count());
                    //ShuffleAnIntegerArray(indexArrayChild, indexArrayChild.Count());

                    temp = new byte[numberOfGenes];
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        temp[j] = (byte)randomizer.Next(2);
                    }

                    for (int i = 0; i < (indexArrayParent.Count() / 2); i++)
                    {
                        chromosomes[i] = chromosomes[indexArrayParent[i]];
                    }

                    for (int i = 0; i < (indexArrayChild.Count() / 2); i++)
                    {
                        temp_num = 0;

                        if (!(chromosomes.Take(populationSize).Contains(chromosomes[indexArrayChild[i]])))
                        {
                            chromosomes[(populationSize / 2) + i] = chromosomes[indexArrayChild[i]];

                        }
                        else
                        {
                            while (true)
                            {
                                if (!(chromosomes.Take(populationSize).Contains(chromosomes[randomizer.Next(populationSize * 3)])))
                                {
                                    chromosomes[(populationSize / 2) + i] = chromosomes[randomizer.Next(populationSize * 3)];
                                    break;
                                }
                                temp_num++;

                                if (temp_num == populationSize)
                                {
                                    chromosomes[(populationSize / 2) + i] = temp.OrderBy(x => randomizer.Next()).ToArray();
                                }
                            }

                        }
                    }

                    for (int i = 0; i < populationSize * 3; i++)
                    {
                        tempTemp = chromosomes.Take(i).ToArray();
                        if (tempTemp.Contains(chromosomes[i]))
                        {
                            chromosomes[i] = temp.OrderBy(x => randomizer.Next()).ToArray();
                        }
                    }
                    break;
                case SelectionType.Deterministic:
                    switch (optimizationType)
                    {
                        case OptimizationType.Maximization:
                            indexArrayParent = objectiveValues.Take(populationSize)
                           .Select((value, index) => new { value, index })
                           .OrderByDescending(item => item.value)
                           .Select(item => item.index)
                           .ToArray();

                            indexArrayChild = objectiveValues.Skip(populationSize)
                                   .Select((value, index) => new { value, index })
                                   .OrderByDescending(item => item.value)
                                   .Select(item => item.index)
                                   .ToArray();
                            break;
                        case OptimizationType.Minimization:
                            indexArrayParent = objectiveValues.Take(populationSize)
                           .Select((value, index) => new { value, index })
                           .OrderBy(item => item.value)
                           .Select(item => item.index)
                           .ToArray();

                            indexArrayChild = objectiveValues.Skip(populationSize)
                                   .Select((value, index) => new { value, index })
                                   .OrderBy(item => item.value)
                                   .Select(item => item.index)
                                   .ToArray();
                            break;
                    }

                    //ShuffleAnIntegerArray(indexArrayParent, indexArrayParent.Count());
                    //ShuffleAnIntegerArray(indexArrayChild, indexArrayChild.Count());

                    temp = new byte[numberOfGenes];
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        temp[j] = (byte)randomizer.Next(2);
                    }

                    for (int i = 0; i < (indexArrayParent.Count() / 2); i++)
                    {
                        chromosomes[i] = chromosomes[indexArrayParent[i]];
                    }

                    for (int i = 0; i < (indexArrayChild.Count() / 2); i++)
                    {
                        temp_num = 0;

                        if (!(chromosomes.Take(populationSize).Contains(chromosomes[indexArrayChild[i]])))
                        {
                            chromosomes[(populationSize / 2) + i] = chromosomes[indexArrayChild[i]];

                        }
                        else
                        {
                            while (true)
                            {
                                if (!(chromosomes.Take(populationSize).Contains(chromosomes[randomizer.Next(populationSize * 3)])))
                                {
                                    chromosomes[(populationSize / 2) + i] = chromosomes[randomizer.Next(populationSize * 3)];
                                    break;
                                }
                                temp_num++;

                                if (temp_num == populationSize)
                                {
                                    chromosomes[(populationSize / 2) + i] = temp.OrderBy(x => randomizer.Next()).ToArray();
                                }
                            }

                        }
                    }

                    for (int i = 0; i < populationSize * 3; i++)
                    {
                        tempTemp = chromosomes.Take(i).ToArray();
                        if (tempTemp.Contains(chromosomes[i]))
                        {
                            chromosomes[i] = temp.OrderBy(x => randomizer.Next()).ToArray();
                        }
                    }
                    break;
                case SelectionType.Stochastic:
                    switch (optimizationType)
                    {
                        case OptimizationType.Maximization:
                            indexArrayParent = objectiveValues.Take(populationSize)
                           .Select((value, index) => new { value, index })
                           .OrderByDescending(item => item.value)
                           .Select(item => item.index)
                           .ToArray();

                            indexArrayChild = objectiveValues.Skip(populationSize)
                                   .Select((value, index) => new { value, index })
                                   .OrderByDescending(item => item.value)
                                   .Select(item => item.index)
                                   .ToArray();
                            break;
                        case OptimizationType.Minimization:
                            indexArrayParent = objectiveValues.Take(populationSize)
                           .Select((value, index) => new { value, index })
                           .OrderBy(item => item.value)
                           .Select(item => item.index)
                           .ToArray();

                            indexArrayChild = objectiveValues.Skip(populationSize)
                                   .Select((value, index) => new { value, index })
                                   .OrderBy(item => item.value)
                                   .Select(item => item.index)
                                   .ToArray();
                            break;
                    }

                    //ShuffleAnIntegerArray(indexArrayParent, indexArrayParent.Count());
                    //ShuffleAnIntegerArray(indexArrayChild, indexArrayChild.Count());

                    temp = new byte[numberOfGenes];
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        temp[j] = (byte)randomizer.Next(2);
                    }

                    for (int i = 0; i < (indexArrayParent.Count() / 2); i++)
                    {
                        chromosomes[i] = chromosomes[indexArrayParent[i]];
                    }

                    for (int i = 0; i < (indexArrayChild.Count() / 2); i++)
                    {
                        temp_num = 0;

                        if (!(chromosomes.Take(populationSize).Contains(chromosomes[indexArrayChild[i]])))
                        {
                            chromosomes[(populationSize / 2) + i] = chromosomes[indexArrayChild[i]];

                        }
                        else
                        {
                            while (true)
                            {
                                if (!(chromosomes.Take(populationSize).Contains(chromosomes[randomizer.Next(populationSize * 3)])))
                                {
                                    chromosomes[(populationSize / 2) + i] = chromosomes[randomizer.Next(populationSize * 3)];
                                    break;
                                }
                                temp_num++;

                                if (temp_num == populationSize)
                                {
                                    chromosomes[(populationSize / 2) + i] = temp.OrderBy(x => randomizer.Next()).ToArray();
                                }
                            }

                        }
                    }

                    for (int i = 0; i < populationSize * 3; i++)
                    {
                        tempTemp = chromosomes.Take(i).ToArray();
                        if (tempTemp.Contains(chromosomes[i]))
                        {
                            chromosomes[i] = temp.OrderBy(x => randomizer.Next()).ToArray();
                        }
                    }
                    break;
                case SelectionType.Hybrid:
                    switch (optimizationType)
                    {
                        case OptimizationType.Maximization:
                            indexArrayParent = objectiveValues.Take(populationSize)
                           .Select((value, index) => new { value, index })
                           .OrderByDescending(item => item.value)
                           .Select(item => item.index)
                           .ToArray();

                            indexArrayChild = objectiveValues.Skip(populationSize)
                                   .Select((value, index) => new { value, index })
                                   .OrderByDescending(item => item.value)
                                   .Select(item => item.index)
                                   .ToArray();
                            break;
                        case OptimizationType.Minimization:
                            indexArrayParent = objectiveValues.Take(populationSize)
                           .Select((value, index) => new { value, index })
                           .OrderBy(item => item.value)
                           .Select(item => item.index)
                           .ToArray();

                            indexArrayChild = objectiveValues.Skip(populationSize)
                                   .Select((value, index) => new { value, index })
                                   .OrderBy(item => item.value)
                                   .Select(item => item.index)
                                   .ToArray();
                            break;
                    }

                    //ShuffleAnIntegerArray(indexArrayParent, indexArrayParent.Count());
                    //ShuffleAnIntegerArray(indexArrayChild, indexArrayChild.Count());

                    temp = new byte[numberOfGenes];
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        temp[j] = (byte)randomizer.Next(2);
                    }

                    for (int i = 0; i < (indexArrayParent.Count() / 2); i++)
                    {
                        chromosomes[i] = chromosomes[indexArrayParent[i]];
                    }

                    for (int i = 0; i < (indexArrayChild.Count() / 2); i++)
                    {
                        temp_num = 0;

                        if (!(chromosomes.Take(populationSize).Contains(chromosomes[indexArrayChild[i]])))
                        {
                            chromosomes[(populationSize / 2) + i] = chromosomes[indexArrayChild[i]];

                        }
                        else
                        {
                            while (true)
                            {
                                if (!(chromosomes.Take(populationSize).Contains(chromosomes[randomizer.Next(populationSize * 3)])))
                                {
                                    chromosomes[(populationSize / 2) + i] = chromosomes[randomizer.Next(populationSize * 3)];
                                    break;
                                }
                                temp_num++;

                                if (temp_num == populationSize)
                                {
                                    chromosomes[(populationSize / 2) + i] = temp.OrderBy(x => randomizer.Next()).ToArray();
                                }
                            }

                        }
                    }

                    for (int i = 0; i < populationSize * 3; i++)
                    {
                        tempTemp = chromosomes.Take(i).ToArray();
                        if (tempTemp.Contains(chromosomes[i]))
                        {
                            chromosomes[i] = temp.OrderBy(x => randomizer.Next()).ToArray();
                        }
                    }
                    break;
            }




        }


        public override bool RunOneIteration()
        {
            // crossover operation
            for (int i = 0; i < (populationSize / 2); i++)
            {
                cid1 = populationSize + i;
                cid2 = populationSize + (populationSize / 2) + i;

                pid1 = randomizer.Next(populationSize);

                while (true)
                {
                    pid2 = randomizer.Next(populationSize);
                    if (pid1 != pid2) break;
                }

                while (true)
                {
                    temp_num = randomizer.Next(numberOfGenes);
                    temp_num_2 = randomizer.Next(numberOfGenes);

                    if (temp_num_2 > (temp_num + 3)) break;
                }

                CrossoverAPairOfChildren(pid1, pid2, cid1, cid2);
            }

            // mutate operation
            for (int i = 0; i < (populationSize / 2); i++)
            {
                cid1 = populationSize * 2 + i;
                cid2 = populationSize * 2 + (populationSize / 2) + i;

                temp_num = (int)Math.Round(numberOfGenes * mutationRate);
                temp_1 = new int[temp_num];

                for (int j = 0; j < temp_num; j++)
                {
                    temp_1[j] = randomizer.Next(numberOfGenes);
                }

                MutateAChild((cid1 - populationSize), cid1, temp_1, temp_num);
                MutateAChild((cid2 - populationSize), cid2, temp_1, temp_num);

            }

            UpdateSoFarTheBestObjectiveAndSolution();

            PerformSelectionOperation();

            return true;
        }
    }
}