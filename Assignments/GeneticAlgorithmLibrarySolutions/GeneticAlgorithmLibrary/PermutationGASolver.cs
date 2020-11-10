using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmLibrary
{
    class PermutationGASolver : GeneticAlgorithm<int>
    {

        public PermutationGASolver(int numberOfVariables, ObjectiveFunction<int> theMethod)
           : base(numberOfVariables, theMethod)
        {

        }

        public override bool CrossoverAPairOfChildren(int fatherIdx, int moderOdx, int child1Idx, int child2Idx)
        {
            // assign chromosomes[child1Idx], ....
            return true;
        }
    }
}
