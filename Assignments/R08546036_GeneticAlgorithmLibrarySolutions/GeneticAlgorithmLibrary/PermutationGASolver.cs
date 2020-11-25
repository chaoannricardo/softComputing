using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmLibrary
{

    /// <summary>
    /// 
    /// </summary>
    public class PermutationGASolver : GeneticAlgorithm<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public enum CrossoverType { PMX, OX, POX, OSS, OCCC, OnePointCut, TwoPointCut }

        /// <summary>
        /// 
        /// </summary>
        public enum MutationType { Swap, XXX }



        int[] temp;

        public CrossoverType CrossoverOperator { get; set; } = CrossoverType.PMX;

        public MutationType MutationOperator { set; get; } = MutationType.Swap;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfVariables"></param>
        /// <param name="type"></param>
        /// <param name="theMethod"></param>
        public PermutationGASolver(int numberOfVariables, OptimizationType type, ObjectiveFunction<int> theMethod)
           : base(numberOfVariables, type, theMethod)
        {
            temp = new int[numberOfVariables];
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

            for (int i = 0; i < numberOfGenes; i++)
            {
                // 這邊也不應該是這樣，需要改正
                chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
            }

            switch (CrossoverOperator)
            {
                case CrossoverType.PMX:

                    break;
                case CrossoverType.OX:
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
    }
}
