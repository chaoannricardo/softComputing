using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGALibrary
{
    public class BinaryGA : GeneticAlgorithm<byte>
    {
        int numberOfCuts = 1;
        [Category("Binary GA Setting"), Description("交配演算的切點數，建議值大於1。")]
        public int CrossoverCuts
        {
            get => numberOfCuts;
            set
            {
                if(numberOfCuts > 0 && numberOfCuts < numberOfGenes) numberOfCuts = value;
            }
        }        
        [Category("GA Setting"), Description("True：以基因個數為基的突變率(Gene Based Mutation)。\nFalse：以染色體個數為基的突變率(Population Based Mutation)。")]
        public bool GeneBasedMutation  //PopulationBasedMutation
        {
            get
            {
                return geneBasedMutation;
            }
            set
            {
                geneBasedMutation = value;
            }
        }

        public BinaryGA(int numberOfGenes, OptimizationType type, ObjectiveFunction<byte> obj)
            : base(numberOfGenes, type, obj)
        {

        }
        public override void InitializePopulationChromosomes()
        {
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < numberOfGenes; j++)
                {
                    chromosomes[i][j] = (byte)rnd.Next(2); //(byte)rnd.Next(2) == 0 ? (byte)0 : (byte)1; 
                }
            }
        }
        protected override void GenerateAPairOfCrossoveredChildren(int father, int mother, int child1, int child2)
        {
            //one-point cut
            if (numberOfCuts == 1)
            {
                int pos = rnd.Next(numberOfGenes);
                for (int j = 0; j < numberOfGenes; j++)
                {
                    if (j < pos)
                    {
                        chromosomes[child1][j] = chromosomes[father][j];
                        chromosomes[child2][j] = chromosomes[mother][j];
                    }
                    else //j >= pos
                    {
                        chromosomes[child1][j] = chromosomes[mother][j];
                        chromosomes[child2][j] = chromosomes[father][j];
                    }
                }
            }
            //many-point cuts
            else if (numberOfCuts > 1)
            {
                int[] pos = new int[numberOfCuts];
                for (int i = 0; i < numberOfCuts; i++)
                {
                    pos[i] = rnd.Next(numberOfGenes);
                }
                Array.Sort(pos);
                #region
                //for (int i = 1; i < numberOfCuts; i++)
                //{
                //    if (i % 2 == 0)
                //    {
                //        for (int j = pos[i - 1]; j < pos[i]; j++)
                //        {
                //            chromosomes[child1][j] = chromosomes[father][j];
                //            chromosomes[child2][j] = chromosomes[mother][j];
                //        }
                //    }
                //}
                #endregion
                for (int j = 0; j < numberOfGenes; j++)  //
                {
                    for (int i = 1; i < numberOfCuts; i++)
                    {
                        if (i % 2 == 0)
                        {
                            if (j >= pos[i - 1] && j < pos[i])
                            {
                                chromosomes[child1][j] = chromosomes[father][j];
                                chromosomes[child2][j] = chromosomes[mother][j];
                            }
                            else 
                            {
                                chromosomes[child1][j] = chromosomes[father][j];
                                chromosomes[child2][j] = chromosomes[mother][j];
                            }
                        }
                        else if (i % 2 != 0)
                        {
                            if (j >= pos[i - 1] && j < pos[i])
                            {
                                chromosomes[child1][j] = chromosomes[mother][j];
                                chromosomes[child2][j] = chromosomes[father][j];
                            }
                            else
                            {
                                chromosomes[child1][j] = chromosomes[father][j];
                                chromosomes[child2][j] = chromosomes[mother][j];
                            }
                        }
                    }
                }
            }
        }
        
        protected override void GenerateAMutatedChildren(int parent, int child)
        {
            int pos = rnd.Next(numberOfGenes);
            for (int j = 0; j < numberOfGenes; j++)
            {
                if (j == pos)
                {
                    chromosomes[child][j] = chromosomes[parent][j] == 1 ? (byte)0 : (byte)1;
                }   
                else
                {
                    chromosomes[child][j] = chromosomes[parent][j];
                }
            }
        }

        protected override void GenerateAMutatedChildren(int parent, int child, List<int> geneLocation)
        {           
            for (int j = 0; j < numberOfGenes; j++)
            {
                if (geneLocation.Contains(j))  //list功能
                    chromosomes[child][j] = chromosomes[parent][j] == 1 ? (byte)0 : (byte)1;
                else
                    chromosomes[child][j] = chromosomes[parent][j];
            }
        }
    }
}
