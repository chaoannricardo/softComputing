using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmLibrary
{


    public class BinaryGASolver : GeneticAlgorithm<byte>
    {
        private double penaltyFactor = 100.0;
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

        public int[] BestSolutionAnswer { get => bestSolutionAnswer; }

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
                        else if (temp_num < i && i < temp_num_2) {
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

        public override bool initializePopulation()
        {
            for (int r = 0; r < populationSize; r++)
            {
                for (int c = 0; c < numberOfGenes; c++)
                {
                    chromosomes[r][c] = (byte)randomizer.Next(2);
                }
            }
            return true;
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

                while (true) {
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

                MutateAChild((cid1 - populationSize), cid1);
                MutateAChild((cid2 - populationSize), cid2);

            }

            UpdateSoFarTheBestObjectiveAndSolution();

            PerformSelectionOperation();

            return true;
        }
    }
}
