using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGALibrary
{
    public enum PermutationCrossoverType {  PartialMapX, OrdersX, PositionBaseX, OrderBaseX }
    public enum PermutationMutationType {  Inversion, Swap }

    public class PermutationGA : GeneticAlgorithm<int>
    {
        public PermutationCrossoverType CrossoverOperator { set; get; } = PermutationCrossoverType.PartialMapX;
        public PermutationMutationType MutationOperator { set; get; } = PermutationMutationType.Inversion;

        public PermutationGA(int numberOfGenes, OptimizationType type, ObjectiveFunction<int> obj) :
            base (numberOfGenes, type, obj)
        {

        }

        public override void InitializePopulationChromosomes()
        {
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < numberOfGenes; j++)
                {
                    chromosomes[i][j] = j;
                }
                ShfulleIntegerArray(chromosomes[i], numberOfGenes);
            }
        }

        void PMX(int father, int mother, int child1, int child2)
        {

        }

        protected override void GenerateAPairOfCrossoveredChildren(int father, int mother, int child1, int child2)
        {
            switch( CrossoverOperator )
            {
                case PermutationCrossoverType.PartialMapX:
                    PMX(father, mother, child1, child2);
                    break;
            }
            
        }

        protected override void GenerateAMutatedChild(int parent, int child)
        {
            base.GenerateAMutatedChild(parent, child);
        }
    }

}
