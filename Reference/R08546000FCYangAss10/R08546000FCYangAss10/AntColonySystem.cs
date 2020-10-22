using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546000FCYangAss10
{
    public delegate double ObjectiveFunction(int[] solution);
    public delegate double HeuristicValueCalculationFunction(int i, int j);
    partial class AntColonySystem
    {
        Random rnd = new Random();

        int[][] solutions;
        double[] objectiveValues;
        int numberOfAnts = 40;
        int numberOfObjects;
        double[,] pheromone;
        double[,] heuristics;

        int[] soFarTheBestSolution;
        [Browsable(false)]
        public int[] SoFarTheBestSolution { get => soFarTheBestSolution; }
        double soFarTheBestObjective;

        double[] fitness;
        int[] indices;

        ObjectiveFunction objFunction;
        HeuristicValueCalculationFunction heuristicFun;
        public AntColonySystem(int numberOfObjects, ObjectiveFunction objFun, HeuristicValueCalculationFunction huristicF )
        {
            this.numberOfObjects = numberOfObjects;
            objFunction = objFun;
            heuristicFun = huristicF;

            fitness = new double[numberOfObjects];
            indices = new int[numberOfObjects];
            pheromone = new double[numberOfObjects, numberOfObjects];
        }

        public AntColonySystem( int numberOfObjects, ObjectiveFunction objFun, double[,] heuristicMatrix )
        {
            this.numberOfObjects = numberOfObjects;
            objFunction = objFun;
            heuristics = heuristicMatrix;
            fitness = new double[numberOfObjects];
            indices = new int[numberOfObjects];
            pheromone = new double[numberOfObjects, numberOfObjects];

        }

        public void Reset()
        {

        }

        public void RunOneIteration()
        {
            antsConstructSolutions();
            computeObjectiveValuesAndUpdateSoFarTheBest();
            updatePheromoneMatrix();
        }

        void antsConstructSolutions()
        {
            // double heruisticValue = MainForm[ii,]
            for( int k =0; k< numberOfAnts;k++)
            {
                for (int p = 0; p < numberOfObjects; p++) indices[p] = p;
                int last = numberOfObjects - 1;
                int pos = rnd.Next(numberOfObjects); // starting object indices[i];
                solutions[k][0] = indices[pos];
                indices[pos] = indices[last];
                last--;
                for( int step = 1; step < numberOfObjects; step++)
                {
                    for( int j = 0; j < last; j++ )
                    {
                       // fitness[j] = 
                    }
                }
            }
        }

        void computeObjectiveValuesAndUpdateSoFarTheBest()
        {

        }
        
        void updatePheromoneMatrix()
        {


        }
        public void RunToEnd()
        {

        }

 
    }
}
