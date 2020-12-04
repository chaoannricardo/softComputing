using System;
using System.Linq;
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
        double solutionObjValue = 0;
        #endregion

        #region properties
        public enum UpdateType { Original, RankedAntSystem, AntColonySystem };
        public enum SelectionType { Deterministic, Stochastic };
        public enum OptimizationType { Maximization, Minimization };

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
        public double PheromoneUpdateAmount { get; set; } = 0.0001;
        public double[,] FromToDistance { get; }
        public UpdateType PheromoneUpdateMode { set; get; } = UpdateType.Original;
        public SelectionType SelectionMode { set; get; } = SelectionType.Deterministic;
        public OptimizationType OptimizationMethod { set; get; } = OptimizationType.Minimization;
        #endregion

        // methods
        public AntColonySystemForTSP(int numberOfCities, ObjectiveFuction objFuction, double[,] fromToDistance)
        {
            this.NumberOfCities = numberOfCities;
            this.FromToDistance = fromToDistance;
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

            soFarTheBestSolution = TSPBenchmark.TSPBenchmarkProblem.GetGreedyShortestRoute();
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

            // other properties and variables reset
            soFarTheBestObjective = 0;
            soFarTheBestSolution = new int[NumberOfCities];
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
            fitness = new double[NumberOfAnts];
            objectiveValues = new double[NumberOfAnts];

            // create solution for each ant
            for (int i = 0; i < NumberOfAnts; i++)
            {
                /*
                 * Initial Step
                 */

                // reset all city, fitness array
                for (int j = 0; j < NumberOfCities; j++)
                {
                    availableCityIDs[j] = j;
                }
                numberCandidates = NumberOfCities;
                Array.Clear(fitness, 0, fitness.Length);

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
                        switch (SelectionMode)
                        {
                            case SelectionType.Deterministic:
                                itaValue = heuristicValues[s, j];
                                break;
                            case SelectionType.Stochastic:
                                // random number based on from to distance
                                itaValue = heuristicValues[s, j] * randomizer.NextDouble();
                                break;
                        }

                        // calculate fitness value
                        // todo: * power of alpha
                        // bug!
                        fitness[j] = Math.Pow(pheromoneMap[currentCityID, candidateID], itaValue); // need to be done

                        // check if best
                        switch (OptimizationMethod)
                        {
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

                    // add to fitnessSum
                    fitness[i] += fitness[pos];

                    // clear up the position
                    availableCityIDs[pos] = availableCityIDs[NumberOfCities - 1];

                    // add pheromone if segment pheromone dropping is enabled
                    // to do: add pheromone
                    pheromoneMap[currentCityID, nextCityID] += 0;

                    currentCityID = nextCityID;

                }

                int startCity;
                int arrivedCity;

                // calculate the objSumValue
                for (int s = 0; s < NumberOfCities; s++)
                {
                    if (s != 0)
                    {
                        startCity = solutions[i][s - 1];
                        arrivedCity = solutions[i][s];
                        objectiveValues[i] += FromToDistance[startCity, arrivedCity];
                    }
                }
            }
        }

        private void UpdatePheromoneMap()
        {
            int startCity;
            int arrivedCity;
            int[] indexArray;

            // filter out first 10 ants
            int rankNum = 10;

            indexArray = objectiveValues.Take(rankNum)
           .Select((value, index) => new { value, index })
           .OrderByDescending(item => item.value)
           .Select(item => item.index)
           .ToArray();

            for (int i = 0; i < numberOfAnts; i++)
            {
                bool inRanked = false;
                if (indexArray.Contains(i)) inRanked = true;

                for (int j = 0; j < NumberOfCities; j++)
                {

                    startCity = solutions[i][j - 1];
                    arrivedCity = solutions[i][j];

                    switch (PheromoneUpdateMode)
                    {
                        case UpdateType.Original:
                            if (j != 0)
                            {
                                // pheromone is add by add-up value/fitnessValue
                                pheromoneMap[startCity, arrivedCity] += (PheromoneUpdateAmount * fitness[i]);
                            }
                            break;
                        case UpdateType.RankedAntSystem:

                            // add pheromone by elite ant
                            for (int rank = 0; rank < indexArray.Length; rank++) {
                                if (indexArray[rank] == i) {
                                    // pheromone is add by add-up value/fitnessValue
                                    pheromoneMap[startCity, arrivedCity] += ((rankNum - rank) * PheromoneUpdateAmount * fitness[i]);
                                }
                            }

                            break;
                        case UpdateType.AntColonySystem:


                            break;
                    }


                }
            }

        }

        private void ComputeObjectiveValueAndUpdateSoFarTheBest()
        {
            int[] indexArray = objectiveValues.Take(1)
           .Select((value, index) => new { value, index })
           .OrderByDescending(item => item.value)
           .Select(item => item.index)
           .ToArray();

            switch (OptimizationMethod) {
                case OptimizationType.Minimization:
                    if (objectiveValues[indexArray[0]] < this.soFarTheBestObjective) {
                        this.soFarTheBestObjective = objectiveValues[indexArray[0]];
                        this.soFarTheBestSolution = solutions[indexArray[0]];
                    }
                    break;
                case OptimizationType.Maximization:
                    if (objectiveValues[indexArray[0]] > this.soFarTheBestObjective)
                    {
                        this.soFarTheBestObjective = objectiveValues[indexArray[0]];
                        this.soFarTheBestSolution = solutions[indexArray[0]];
                    }
                    break;
            }
        }


    }
}
