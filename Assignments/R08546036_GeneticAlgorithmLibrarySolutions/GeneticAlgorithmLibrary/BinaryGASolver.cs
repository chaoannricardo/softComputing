using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmLibrary
{


    public class BinaryGASolver : GeneticAlgorithm<byte>
    {
        /// <summary>
        /// 
        /// </summary>
        public enum CrossoverType { PMX, OX, POX, OSS, OCCC, OnePointCut, TwoPointCut, N }
        public CrossoverType CrossoverOperator { set; get; } = CrossoverType.TwoPointCut;

        /// <summary>
        /// This is the constructor of creating a binary-coded GA solver
        /// </summary>
        /// <param name="numberOfVariables"> Number of variables in the Optimization Problem</param>
        /// <param name="type"> Optimization Type: maximization or minimization </param>
        /// <param name="theMethod">The objective function delegate </param>

        public BinaryGASolver(int numberOfVariables, OptimizationType type, ObjectiveFunction<byte> theMethod)
            : base(numberOfVariables, type, theMethod)
        {

        }

        public override bool CrossoverAPairOfChildren(int fatherIdx, int moderOdx, int child1Idx, int child2Idx)
        {
            switch (CrossoverOperator)
            {




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
    }
}
