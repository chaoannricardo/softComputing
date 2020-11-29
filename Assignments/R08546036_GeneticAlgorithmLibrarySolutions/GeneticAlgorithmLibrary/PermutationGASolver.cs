using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace GeneticAlgorithmLibrary
{

    public class PermutationGASolver : GeneticAlgorithm<int>
    {
        #region variables
        int[] bestSolutionAnswer;
        int[] indexArrayParent;
        int[] indexArrayChild;
        double objValue;
        double bestSolutionValue;
        double iterationBest;

        // other variables
        int[] temp;
        int[] temp_1;
        int[] temp_2;
        int[] mapping;
        int index_1;
        int index_2;
        int temp_num;
        int temp_num_2;
        int[][] tempTemp;

        // for run one iteration
        int pid1;
        int pid2;
        int cid1;
        int cid2;
        #endregion

        public enum CrossoverType { PMX, OX, POX, OSS, OCCC, OnePointCut, TwoPointCut }

        public enum MutationType { Swap, XXX }

        // properties
        public CrossoverType CrossoverOperator { get; set; } = CrossoverType.PMX;

        public MutationType MutationOperator { set; get; } = MutationType.Swap;

        public int[][] Chromosome
        {
            get
            {
                return chromosomes;
            }
        }

        public int[] BestSolutionAnswer { get => bestSolutionAnswer; }

        public double BestSolutionValue { get => bestSolutionValue; }
        public double IterationBest { get => iterationBest; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfVariables"></param>
        /// <param name="type"></param>
        /// <param name="theMethod"></param>
        public PermutationGASolver(int numberOfVariables, OptimizationType type, ObjectiveFunction<int> theMethod)
           : base(numberOfVariables, type, theMethod)
        {
            // default section
            optimizationType = type;
            numberOfGenes = numberOfVariables;
            //soFarBestSolution = new T[numberOfGenes];
            theObjectiveEvaluationMethod = theMethod;
            mutatedPositions = new int[numberOfGenes];

        }

        public override bool initializePopulation()
        {

            int[] geneArray = new int[numberOfGenes];

            // create gene with real number
            for (int i = 0; i < numberOfGenes; i++)
            {
                geneArray[i] = i;
            }

            for (int r = 0; r < populationSize; r++)
            {
                ShuffleAnIntegerArray(geneArray, geneArray.Length);
                //geneArray = geneArray.OrderBy(x => randomizer.Next()).ToArray();

                for (int c = 0; c < numberOfGenes; c++)
                {
                    chromosomes[r][c] = geneArray[c];
                }
            }

            if (OptimizationType == OptimizationType.Maximization) bestSolutionValue = double.MinValue;

            if (OptimizationType == OptimizationType.Minimization) bestSolutionValue = double.MaxValue;

            return true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fatherIdx"></param>
        /// <param name="moderOdx"></param>
        /// <param name="child1Idx"></param>
        /// <param name="child2Idx"></param>
        /// <returns></returns>
        public override bool CrossoverAPairOfChildren(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            // assign chromosomes[child1Idx], ....

            //for (int i = 0; i < numberOfGenes; i++)
            //{
            //    // 這邊也不應該是這樣，需要改正
            //    chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
            //    chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
            //}


            switch (CrossoverOperator)
            {
                case CrossoverType.PMX:
                    // i1, i2 cut locations 
                    // m[] partial map, m[i] => the mapping target of i

                    // define two crossover map for chromosome
                    index_1 = randomizer.Next(numberOfGenes);
                    while (index_2 == index_1)
                    {
                        index_2 = randomizer.Next(numberOfGenes);
                    }
                    // swap two numbers if index_1 is larger
                    if (index_2 < index_1)
                    {
                        temp_num = index_1;
                        index_1 = index_2;
                        index_2 = temp_num;
                    }
                    // initiate mapping 
                    mapping = new int[numberOfGenes];
                    for (int i = 0; i < mapping.Length; i++) mapping[i] = -1;
                    // build up the mapping
                    for (int i = index_1; i < index_2; i++)
                    {

                        if (chromosomes[fatherIdx][i] == chromosomes[motherIdx][i]) continue;
                        if (mapping[chromosomes[fatherIdx][i]] == -1 && mapping[chromosomes[motherIdx][i]] == -1)
                        {
                            mapping[chromosomes[fatherIdx][i]] = chromosomes[motherIdx][i];
                            mapping[chromosomes[motherIdx][i]] = chromosomes[fatherIdx][i];
                        }
                        else if (mapping[chromosomes[fatherIdx][i]] == -1)
                        {
                            mapping[chromosomes[fatherIdx][i]] = mapping[chromosomes[motherIdx][i]];
                            try
                            {
                                mapping[mapping[chromosomes[motherIdx][i]]] = chromosomes[fatherIdx][i];
                            }
                            catch (System.IndexOutOfRangeException Exception)
                            {

                            }

                            mapping[chromosomes[motherIdx][i]] = -2;
                        }
                        else if (mapping[chromosomes[motherIdx][i]] == -1)
                        {
                            try
                            {
                                mapping[chromosomes[motherIdx][i]] = mapping[chromosomes[fatherIdx][i]];
                            }
                            catch (System.IndexOutOfRangeException Exception) { }
                            try
                            {
                                mapping[mapping[chromosomes[fatherIdx][i]]] = chromosomes[motherIdx][i];
                            }
                            catch (System.IndexOutOfRangeException Exception) { }
                            try
                            {
                                mapping[chromosomes[fatherIdx][i]] = -2;
                            }
                            catch (System.IndexOutOfRangeException Exception) { }
                        }
                        else
                        {
                            try
                            {
                                mapping[mapping[chromosomes[motherIdx][i]]] = mapping[chromosomes[fatherIdx][i]];
                            }
                            catch (System.IndexOutOfRangeException Exception) { }

                            try
                            {
                                mapping[mapping[chromosomes[fatherIdx][i]]] = mapping[chromosomes[motherIdx][i]];
                            }
                            catch (System.IndexOutOfRangeException Exception) { }


                            mapping[chromosomes[fatherIdx][i]] = -3;
                            mapping[chromosomes[motherIdx][i]] = -3;
                        }
                    }

                    // crossover and make two children
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (index_1 <= i && i < index_2)
                        {
                            chromosomes[child1Idx][i] = chromosomes[motherIdx][i];
                            chromosomes[child2Idx][i] = chromosomes[fatherIdx][i];
                        }
                        else
                        {
                            if (mapping[chromosomes[fatherIdx][i]] < 0) chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                            else chromosomes[child1Idx][i] = mapping[chromosomes[fatherIdx][i]];

                            if (mapping[chromosomes[motherIdx][i]] < 0) chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
                            else chromosomes[child2Idx][i] = mapping[chromosomes[motherIdx][i]];
                        }
                    }
                    // crossover finished.

                    // check if all gene are distinct, if not let other chromosome replace it 
                    for (int i = 0; i < populationSize * 3; i++)
                    {
                        temp = new int[numberOfGenes];
                        for (int j = 0; j < numberOfGenes; j++)
                        {
                            temp[j] = j;
                        }

                        if (chromosomes[i].Distinct().ToArray().Count() != numberOfGenes)
                        {
                            chromosomes[i] = temp.OrderBy(x => randomizer.Next()).ToArray();
                        }
                        else
                        {
                            break;
                        }
                    }

                    break;
                case CrossoverType.OX:
                    // order crossover
                    // define two crossover map for chromosome
                    index_1 = randomizer.Next(numberOfGenes);
                    while (index_2 == index_1)
                    {
                        index_2 = randomizer.Next(numberOfGenes);
                    }
                    // swap two numbers if index_1 is larger
                    if (index_2 < index_1)
                    {
                        temp_num = index_1;
                        index_1 = index_2;
                        index_2 = temp_num;
                    }
                    // start creating crossover children
                    temp_num = 0;
                    temp_num_2 = 0;
                    for (int i = index_1; i < index_2; i++)
                    {
                        chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                        chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
                    }
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (!(chromosomes[child1Idx].Contains(chromosomes[motherIdx][i])))
                        {
                            if (temp_num == index_1) temp_num = index_2;
                            chromosomes[child1Idx][temp_num] = chromosomes[motherIdx][i];
                            temp_num += 1;
                        }
                        if (!(chromosomes[child2Idx].Contains(chromosomes[fatherIdx][i])))
                        {
                            if (temp_num_2 == index_1) temp_num_2 = index_2;
                            chromosomes[child2Idx][temp_num] = chromosomes[fatherIdx][i];
                            temp_num_2 += 1;
                        }
                    }
                    break;
                case CrossoverType.POX:
                    // position-based crossover
                    temp_num = (int)Math.Round(numberOfGenes * crossoverRate);
                    temp_1 = new int[temp_num];
                    // create random index array
                    for (int i = 0; i < temp_num; i++)
                    {
                        temp_1[i] = randomizer.Next(numberOfGenes);
                    }
                    // crossover children
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (temp_1.Contains(i))
                        {
                            chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                            chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
                        }
                        else
                        {
                            chromosomes[child1Idx][i] = chromosomes[motherIdx][i];
                            chromosomes[child2Idx][i] = chromosomes[fatherIdx][i];
                        }

                    }
                    break;
                case CrossoverType.OSS:
                    // order-based crossover
                    temp_num = (int)Math.Round(numberOfGenes * crossoverRate);
                    temp_1 = new int[temp_num];
                    // create random value array
                    for (int i = 0; i < temp_num; i++)
                    {
                        temp_1[i] = randomizer.Next(numberOfGenes);
                    }
                    // crossover children
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (!(temp_1.Contains(chromosomes[fatherIdx][i])))
                        {
                            chromosomes[child1Idx][i] = chromosomes[motherIdx][i];
                        }
                        else {
                            chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                        }

                        if (!(temp_1.Contains(chromosomes[motherIdx][i])))
                        {
                            chromosomes[child2Idx][i] = chromosomes[fatherIdx][i];
                        }
                        else
                        {
                            chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
                        }
                    }

                    break;
                case CrossoverType.OCCC:
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

            }
        }


        public override void MutateAChild(int parentIdx, int childIdx)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                chromosomes[childIdx][i] = chromosomes[parentIdx][i];
            }

            switch (MutationOperator)
            {
                case MutationType.Swap:
                    int pos1 = randomizer.Next(numberOfGenes);
                    int pos2;
                    do pos2 = randomizer.Next(numberOfGenes); while (pos2 == pos1);
                    int temp = chromosomes[childIdx][pos1];
                    chromosomes[childIdx][pos1] = chromosomes[childIdx][pos2];
                    chromosomes[childIdx][pos1] = temp;
                    break;
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


        public override void PerformSelectionOperation()
        {

            //int limit = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;

            //switch (SelectionMode)
            //{
            //    case SelectionType.Deterministic:
            //        for (int i = 0; i < limit; i++)
            //        {
            //            indices[i] = i;
            //        }
            //        Array.Sort(fitnessValues, indices, 0, limit);
            //        Array.Reverse(indices, 0, limit);
            //        break;
            //    case SelectionType.Stochastic:
            //        // fitness

            //        break;
            //}
            //// gene-wise copy selected chromosome

            //for (int r = 0; r < populationSize; r++)
            //{
            //    selectedObjectives[r] = objectiveValues[indices[r]];
            //    for (int c = 0; c < numberOfGenes; c++)
            //    {
            //        selectedChromosomes[r][c] = chromosomes[indices[r]][c];

            //    }
            //}

            //// copy back to parent chromosome for the next generation

            //for (int r = 0; r < populationSize; r++)
            //{
            //    objectiveValues[r] = selectedObjectives[indices[r]];
            //    for (int c = 0; c < numberOfGenes; c++)
            //    {
            //        selectedChromosomes[r][c] = chromosomes[indices[r]][c];

            //    }
            //}

            switch (SelectionMode)
            {
                case SelectionType.Best:
                    /////////////////////////////////////////////
                    //indexArrayParent = objectiveValues.Take(populationSize)
                    //       .Select((value, index) => new { value, index })
                    //       .OrderByDescending(item => item.value)
                    //       .Take(populationSize / 2)
                    //       .Select(item => item.index)
                    //       .ToArray();
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

                    temp = new int[numberOfGenes];
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        temp[j] = j;
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

                    temp = new int[numberOfGenes];
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        temp[j] = j;
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

                    temp = new int[numberOfGenes];
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        temp[j] = j;
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

                    temp = new int[numberOfGenes];
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        temp[j] = j;
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

                CrossoverAPairOfChildren(pid1, pid2, cid1, cid2);
            }

            // mutate operation
            for (int i = 0; i < (populationSize / 2); i++)
            {
                cid1 = populationSize * 2 + i;
                cid2 = populationSize * 2 + (populationSize / 2) + i;

                MutateAChild((cid1 - populationSize), cid1);
                MutateAChild((cid2 - populationSize), cid2);

            }

            UpdateSoFarTheBestObjectiveAndSolution();

            PerformSelectionOperation();

            return true;
        }

    }
}
