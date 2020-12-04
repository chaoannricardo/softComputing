using System;
using System.Windows.Forms;

namespace R08546036SHChaoAss10TSP
{

    delegate double ObjectiveFuction(int[] s);

    class AntColonySystemForTSP
    {
        #region variables
        int numberOfAnts = 50;
        int[][] solutions;
        double[] objectiveValues;
        double soFarTheBestObjective;
        int[] soFarTheBestSolution;
        double[,] pheromoneMap;
        double[,] heuristicValues;
        Random randomizer = new Random();
        int[] availableCityIDs;
        double[] fitness;

        // other variables
        double itaValue = 0;
        #endregion

        #region properties
        public enum UpdateType {StepWise, RankedAntSystem, AntColonySystem};
        public enum SelectionType {Deterministic, Stochastic};
        public enum OptimizationType {Maximization, Minimization};

        // properties
        public int NumberOfAnts
        {
            set
            {
                if (value > 0 && value is int) numberOfAnts = value;
            }
            get
            {
                return numberOfAnts;
            }
        }
        public int[] SoFarTheBestSolution { get => soFarTheBestSolution; }
        public double SoFarTheBestObjective { get => soFarTheBestObjective; }
        public int NumberOfCities { get; set; } = 0;
        public double InitialPheromoneValue { set; get; } = 0.01;
        public int IterationCount { set; get; } = 100;
        public double[] Fitness { get => fitness; set => fitness = value; }
        public double DeterministicThresh { get; set; } = 0.8;
        public UpdateType PheromoneUpdateMode { set; get; } = UpdateType.StepWise;
        public SelectionType SelectionMode { set; get; } = SelectionType.Deterministic;
        public OptimizationType OptimizationMethod { set; get; } = OptimizationType.Minimization;
        #endregion

        // methods
        public AntColonySystemForTSP(int numberOfCities, ObjectiveFuction objFuction, double[,] fromToDistance)
        {
            this.NumberOfCities = numberOfCities;
            soFarTheBestSolution = new int[this.NumberOfCities];
            pheromoneMap = new double[numberOfCities, numberOfCities];
            heuristicValues = new double[numberOfCities, numberOfCities];

            for (int r = 0; r < numberOfCities; r++)
            {
                for (int c = 0; c < numberOfCities; c++)
                {
                    if (r == c) heuristicValues[r, c] = 1e10;
                    else heuristicValues[r, c] = 1.0 / fromToDistance[r, c];
                }
            }

            availableCityIDs = new int[numberOfCities];
            fitness = new double[numberOfCities];

            for (int i = 0; i < numberOfCities; i++)
            {
                soFarTheBestSolution[i] = i;
            }

            soFarTheBestSolution =  TSPBenchmark.TSPBenchmarkProblem.GetGreedyShortestRoute();
        }

        internal void Reset()
        {
            solutions = new int[numberOfAnts][];
            for (int i = 0; i < numberOfAnts; i++)
            {
                solutions[i] = new int[NumberOfCities];
            }

            // to do: randomly initialize pheromone table
            for (int r = 0; r < NumberOfCities; r++)
            {
                for (int c = 0; c < NumberOfCities; c++)
                {
                    pheromoneMap[r, c] = InitialPheromoneValue;
                }
            }

            // randomly initialize solution
            for (int i = 0; i < NumberOfAnts; i++)
            {
                for (int c = 0; c < NumberOfCities; c++)
                {
                    solutions[i][c] = c;

                }
                // shuffleIntegerArray

                // ITeration set to zero
                soFarTheBestObjective = double.MaxValue;

            }

        }

        internal void RunOneIteration()
        {
            EachAntsConstructItsSolution();
            ComputeObjectiveValueAndUpdateSoFarTheBest();
            UpdatePheromoneMap();
        }

        private void EachAntsConstructItsSolution()
        {
            int numberCandidates;
            int currentCityID;

            // create solution for each ant
            for (int i = 0; i < NumberOfAnts; i++)
            {
                /*
                 * Initial Step
                 */

                // reset all city as available 
                for (int j = 0; j < NumberOfCities; j++)
                {
                    availableCityIDs[j] = j;
                }
                numberCandidates = NumberOfCities;

                // Randomly choose city to start with
                int pos = randomizer.Next(NumberOfCities);
                // Move to city selected
                currentCityID = availableCityIDs[pos];

                // Clear-up Step: start city set as (Number of Candidate - 1)
                availableCityIDs[pos] = availableCityIDs[numberCandidates - 1];


                // Append ant solution
                solutions[i][0] = currentCityID;

                /*
                 * Full Construction Step
                 */

                // construct full solution
                // step count: start looping and create solution 
                for (int s = 1; s < NumberOfCities; s++)
                {
                    // decrease number of candidate & set initial value of pos
                    numberCandidates--;
                    pos = -1;

                    // initiate fit value
                    double maxFit = double.MinValue;

                    // caculate each city's fitness and choose best one
                    for (int j = 0; j < NumberOfCities; j++)
                    {
                        // to do: compute relative probability 
                        int candidateID = availableCityIDs[j];

                        // calculate fit value with pheromone map and ita value
                        // let ita to be smaller when iteration is higher
                        switch (SelectionMode) {
                            case SelectionType.Deterministic:
                                itaValue = heuristicValues[i, j];
                                break;
                            case SelectionType.Stochastic:
                                itaValue = randomizer.Next(i);
                                break;
                        }

                        // calculate fitness value
                        // todo: * power of alpha
                        fitness[j] = Math.Pow(pheromoneMap[currentCityID, candidateID], itaValue); // need to be done

                        // check if best
                        switch (OptimizationMethod) {
                            case OptimizationType.Maximization:
                                if (fitness[j] < maxFit) // 望大 deterministic
                                {
                                    maxFit = fitness[j];
                                    pos = j;
                                }
                                break;
                            case OptimizationType.Minimization:
                                if (fitness[j] > maxFit) // 望小 deterministic
                                {
                                    maxFit = fitness[j];
                                    pos = j;
                                }
                                break;
                        }

                        // decrease number of candidate
                        numberCandidates--;
                    }


                    double r = randomizer.NextDouble();
                    int nextCityID = -1;

                    if (r >= DeterministicThresh)
                    {
                        // stochastic
                        // randomly select city as next one
                        pos = randomizer.Next(NumberOfCities);
                    }
                    else
                    {
                        // deterministic
                        // choose city with best fitness value
                    }

                    nextCityID = availableCityIDs[pos];
                    solutions[i][s] = nextCityID;

                    // clear up the position
                    availableCityIDs[pos] = availableCityIDs[NumberOfCities - 1];

                    // add pheromone if segment pheromone dropping is enabled
                    // to do: add pheromone
                    pheromoneMap[currentCityID, nextCityID] += 0;


                    currentCityID = nextCityID;

                }



            }
        }

        private void UpdatePheromoneMap()
        {
            //solutions[]

            
            switch (PheromoneUpdateMode) {
                case UpdateType.StepWise:
                    break;
                case UpdateType.RankedAntSystem:
                    break;
                case UpdateType.AntColonySystem:
                    break;
            }



            // update so far the best solution pheromone
            int fid, tid;

            fid = SoFarTheBestSolution[0];


            for (int i = 1; i < NumberOfCities; i++)
            {
                tid = SoFarTheBestSolution[i];

                // to do: add pheromone
                pheromoneMap[fid, tid] += 0;
                fid = tid;
            }

        }

        private void ComputeObjectiveValueAndUpdateSoFarTheBest()
        {
            
        }

       
    }
}
