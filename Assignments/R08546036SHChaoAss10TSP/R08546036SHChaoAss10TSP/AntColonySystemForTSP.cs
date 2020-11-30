using System;

namespace R08546036SHChaoAss10TSP
{

    delegate double ObjectiveFuction(int[] s);

    class AntColonySystemForTSP
    {


        int numberOfAnts = 50;
        int[][] solutions;
        double[] objectiveValues;
        double soFarTheBestObjective;
        int[] soFarTheBestSolution;
        double[,] pheromoneMap;
        double[,] heuristicValues;
        Random randomizer = new Random();
        bool[] cityAvailable;
        int[] availableCityIDs;
        double[] fitness;


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
        public double DeterministicThresh { get; private set; }


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

            cityAvailable = new bool[numberOfCities];
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
                IterationCount = 0;
                soFarTheBestObjective = double.MaxValue;

            }

        }

        internal void RunOneIteration()
        {
            EachAntsConstructItsSolution();
            ComputeObjectiveValueAndUpdateSoFarTheBest();
            UpdatePheromoneMap();
        }

        private void UpdatePheromoneMap()
        {
            //solutions[]

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
            throw new NotImplementedException();
        }

        private void EachAntsConstructItsSolution()
        {
            int numberCandidates = NumberOfCities;
            int currentCityID;

            for (int i = 0; i < NumberOfAnts; i++)
            {

                //for (int j = 0; j < NumberOfCities; j++) {
                //    cityAvailable[j] = true;
                //}

                for (int j = 0; j < NumberOfCities; j++)
                {
                    availableCityIDs[j] = j;
                }


                //solutions[i][0] = randomizer.Next(NumberOfCities);
                int pos = randomizer.Next(NumberOfCities);
                currentCityID = availableCityIDs[pos];

                availableCityIDs[pos] = availableCityIDs[numberCandidates - 1];

                solutions[i][0] = currentCityID;

                // step count
                for (int s = 1; s < NumberOfCities; s++)
                {
                    numberCandidates--;
                    pos = -1;
                    double maxFit = double.MinValue;

                    for (int j = 0; j < NumberOfCities; j++)
                    {
                        // to do: compute relative probability 
                        //......
                        int candidateID = availableCityIDs[j];
                        // todo: * power of alpha
                        fitness[j] = pheromoneMap[currentCityID, candidateID];  // need to be done

                        if (fitness[j] > maxFit)
                        {
                            maxFit = fitness[j];
                            pos = j;
                        }


                        numberCandidates--;

                    }

                    double r = randomizer.NextDouble();
                    int nextCityID = -1;

                    if (r >= DeterministicThresh)
                    {
                        // stochastic

                    }
                    else
                    {

                        // deterministic


                        nextCityID = availableCityIDs[pos];

                        solutions[i][s] = nextCityID;

                        availableCityIDs[pos] = availableCityIDs[NumberOfCities - 1];

                    }
                    // add pheromone if segment pheromone dropping is enabled

                    // to do: add pheromone
                    pheromoneMap[currentCityID, nextCityID] += 0;


                    currentCityID = nextCityID;

                }



            }
        }
    }
}
