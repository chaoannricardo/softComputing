using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmLibrary
{
    class BinaryGASolver : GeneticAlgorithm<byte>
    {
        public BinaryGASolver(int numberOfVariables, ObjectiveFunction<byte> theMethod) 
            : base(numberOfVariables, theMethod)
        {

        }

        public override bool initializePopulation()
        {
            for (int r = 0; r < populationSize; r++)
            {
                for (int c = 0; c < numberOfGenes; c++)
                {
                    chromosomes[r][c] = (byte) randomizer.Next(2);
                }
            }
            return true;
        }
    }
}
