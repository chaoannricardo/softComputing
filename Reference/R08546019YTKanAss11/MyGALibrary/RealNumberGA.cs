using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGALibrary
{
    public enum RealNumberCrossoverOperator { Convex, Affine, Linear, LargeValueDivided,
        SmallValueDivided, MiddleAndOneEndSegments, TwoEndSegments, ForwardAndBackwardMiddleSegment }
    public enum RealNumberMutationOperator { Dynamic }
    public class RealNumberGA : GeneticAlgorithm<double>
    {
        double[] lowerBounds;
        double[] upperBounds;

        [Category("GA Setting"), Description("True：以基因個數為基的突變率(Gene Based Mutation)。\nFalse：以染色體個數為基的突變率(Population Based Mutation)。")]
        public bool GeneBasedMutation  //PopulationBasedMutation
        {
            get
            {
                return geneBasedMutation;
            }
            set
            {
                if (value == false) geneBasedMutation = value;
            }
        }       
        [Category("RealNumber GA Setting")]
        public RealNumberCrossoverOperator CrossoverOperator
        { get; set; } = RealNumberCrossoverOperator.Convex;
        [Category("RealNumber GA Setting")]
        //public RealNumberMutationOperator MutationOperator
        //{ get; set; } = RealNumberMutationOperator.Dynamic;

        public RealNumberGA(int numberOfGenes, OptimizationType type, ObjectiveFunction<double> obj, double[] lows, double[] ups)
            : base(numberOfGenes, type, obj)
        {
            lowerBounds = lows;
            upperBounds = ups;
        }

        public override void InitializePopulationChromosomes()
        {
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < numberOfGenes; j++)
                {
                    chromosomes[i][j] = lowerBounds[j] + rnd.NextDouble() * (upperBounds[j] - lowerBounds[j]);
                }              
            }            
        }

        protected override void GenerateAPairOfCrossoveredChildren(int father, int mother, int child1, int child2)
        {
            switch (CrossoverOperator)
            {
                case RealNumberCrossoverOperator.Convex:
                    Convex(father, mother, child1, child2);
                    break;
                case RealNumberCrossoverOperator.Affine:
                    Affine(father, mother, child1, child2);
                    break;
                case RealNumberCrossoverOperator.Linear:
                    Linear(father, mother, child1, child2);
                    break;
                case RealNumberCrossoverOperator.LargeValueDivided:
                    LVD(father, mother, child1, child2);
                    break;
                case RealNumberCrossoverOperator.SmallValueDivided:
                    SVD(father, mother, child1, child2);
                    break;
                case RealNumberCrossoverOperator.MiddleAndOneEndSegments:
                    MOESCrossover(father, mother, child1, child2);
                    break;
                case RealNumberCrossoverOperator.TwoEndSegments:
                    TESCrossover(father, mother, child1, child2);
                    break;
                case RealNumberCrossoverOperator.ForwardAndBackwardMiddleSegment:
                    FBMSCrossover(father, mother, child1, child2);
                    break;
            }
        }

        void Convex(int father, int mother, int child1, int child2)
        {    
            for (int i = 0; i < numberOfGenes; i++)
            {
                double alpha = rnd.NextDouble();
                double beta = 1 - alpha;
                chromosomes[child1][i] = alpha * chromosomes[father][i] + beta * chromosomes[mother][i];
                chromosomes[child2][i] = beta * chromosomes[father][i] + alpha * chromosomes[mother][i];
            }
        }

        void Affine(int father, int mother, int child1, int child2)
        {           
            for (int i = 0; i < numberOfGenes; i++)
            {
                double alpha = rnd.NextDouble() * (upperBounds[i] - lowerBounds[i]);
                double beta = 1 - alpha;
                chromosomes[child1][i] = alpha * chromosomes[father][i] + beta * chromosomes[mother][i];
                chromosomes[child2][i] = beta * chromosomes[father][i] + alpha * chromosomes[mother][i];
            }
        }

        void Linear(int father, int mother, int child1, int child2)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                double alpha = rnd.NextDouble() * (upperBounds[i] - lowerBounds[i]);
                double beta = rnd.NextDouble() * (upperBounds[i] - lowerBounds[i]);
                chromosomes[child1][i] = alpha * chromosomes[father][i] + beta * chromosomes[mother][i];
                chromosomes[child2][i] = beta * chromosomes[father][i] + alpha * chromosomes[mother][i];
            }
        }

        void LVD(int father, int mother, int child1, int child2)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                double max = chromosomes[father][i];
                if (chromosomes[mother][i] > max) max = chromosomes[mother][i];
                double alpha = rnd.NextDouble();
                chromosomes[child1][i] = alpha * lowerBounds[i] + (1 - alpha) * max;
                chromosomes[child2][i] = alpha * max + (1 - alpha) * upperBounds[i];
            }
        }

        void SVD(int father, int mother, int child1, int child2)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                double min = chromosomes[father][i];
                if (chromosomes[mother][i] < min) min = chromosomes[mother][i];
                double alpha = rnd.NextDouble();
                chromosomes[child1][i] = alpha * lowerBounds[i] + (1 - alpha) * min;
                chromosomes[child2][i] = alpha * min + (1 - alpha) * upperBounds[i];
            }
        }

        void MOESCrossover(int father, int mother, int child1, int child2)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                double max = chromosomes[father][i];
                if (chromosomes[mother][i] > max) max = chromosomes[mother][i];
                double min = chromosomes[father][i];
                if (chromosomes[mother][i] < min) min = chromosomes[mother][i];
                double alpha = rnd.NextDouble();
                chromosomes[child1][i] = alpha * min + (1 - alpha) * max;
                double random = rnd.NextDouble();
                if (random > 0.5)
                {
                    chromosomes[child2][i] = alpha * max + (1 - alpha) * upperBounds[i];
                }
                else
                {
                    chromosomes[child2][i] = alpha * lowerBounds[i] + (1 - alpha) * min;
                }
            }
        }

        void TESCrossover(int father, int mother, int child1, int child2)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                double max = chromosomes[father][i];
                if (chromosomes[mother][i] > max) max = chromosomes[mother][i];
                double min = chromosomes[father][i];
                if (chromosomes[mother][i] < min) min = chromosomes[mother][i];
                double alpha = rnd.NextDouble();
                chromosomes[child1][i] = alpha * lowerBounds[i] + (1 - alpha) * min;
                chromosomes[child2][i] = alpha * max + (1 - alpha) * upperBounds[i];
            }
        }

        void FBMSCrossover(int father, int mother, int child1, int child2)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                double max = chromosomes[father][i];
                if (chromosomes[mother][i] > max) max = chromosomes[mother][i];
                double min = chromosomes[father][i];
                if (chromosomes[mother][i] < min) min = chromosomes[mother][i];
                double alpha = rnd.NextDouble();
                chromosomes[child1][i] = alpha * min + (1 - alpha) * max;
                chromosomes[child2][i] = alpha * max + (1 - alpha) * min;
            }
        }

        //protected override void GenerateAMutatedChildren(int parent, int child)
        //{
        //    switch (MutationOperator)
        //    {
        //        case RealNumberMutationOperator.Dynamic:
        //            Dynamic(parent, child);
        //            break;                
        //    }
        //}

        //void Dynamic(int parent, int child)
        //{
            
        //}        
    }
}
