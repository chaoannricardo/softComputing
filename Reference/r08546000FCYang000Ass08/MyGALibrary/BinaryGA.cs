using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGALibrary
{
    public class BinaryGA : GeneticAlgorithm<byte>
    {
        int numberOfCuts = 1;
        public int NumberOfCuts
        {
            get => numberOfCuts;
            set
            {
                numberOfCuts = value;
            }
        }
        public BinaryGA(int numberOfGenes, OptimizationType type, ObjectiveFunction<byte> obj) :
            base ( numberOfGenes,  type, obj)
        {

        }

        protected override void GenerateAPairOfCrossoveredChildren(int father, int mother, int child1, int child2)
        {
            // one point cut
            int pos = rnd.Next(numberOfGenes);
            for (int j = 0; j < numberOfGenes; j++)
            {
                if (j < pos)
                {
                    chromosomes[child1][j] = chromosomes[father][j];
                    chromosomes[child1][j] = chromosomes[mother][j]; ;
                }
                else
                {
                    chromosomes[child1][j] = chromosomes[mother][j];
                    chromosomes[child1][j] = chromosomes[father][j]; ;
                }

            }
        }

        public override void InitializePopulationChromosomes()
        {
            for (int i = 0; i < populationSize; i++)
                for (int j = 0; j < numberOfGenes; j++)
                    chromosomes[i][j] = (byte)rnd.Next(2);
        }

        protected override void GenerateAMutatedChild(int parent, int child)
        {
            base.GenerateAMutatedChild(parent, child);
        }
    }
}
