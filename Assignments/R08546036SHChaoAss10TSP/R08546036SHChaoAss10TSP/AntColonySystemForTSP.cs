﻿using System;
using System.Collections.Generic;
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
        double[] fitnessAntSum;
        int numberOfCities;


        // other variables
        double itaValue = 0;
        double solutionObjValue = 0;
        double fitnessSum;
        double iterationBest;
        List<int> traveledCitiesID = new List<int>();
        #endregion

        #region properties
        public enum UpdateType { RankedAntSystem, AntColonySystem };
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
        public double IterationBestObjective { get => iterationBest; }
        public int NumberOfCities { get => numberOfCities;}
        public double InitialPheromoneValue { set; get; } = 0.01;
        public int IterationCount { set; get; } = 100;
        public double[] Fitness { get => fitness; set => fitness = value; }
        public double DeterministicThresh { get; set; } = 0.8;
        public double PheromoneUpdateAmount { get; set; } = 0.0001;
        public double AlphaValue { get; set; } = 3;
        public double BetaValue { get; set; } = 2;
        public double[,] FromToDistance { get; }
        public UpdateType PheromoneUpdateMode { set; get; } = UpdateType.AntColonySystem;
        public OptimizationType OptimizationMethod { set; get; } = OptimizationType.Minimization;
        #endregion

        // methods
        public AntColonySystemForTSP(int numberOfCities, ObjectiveFuction objFuction, double[,] fromToDistance)
        {
            this.numberOfCities = numberOfCities;
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


            switch (OptimizationMethod)
            {
                case OptimizationType.Minimization:
                    soFarTheBestObjective = double.MaxValue;
                    break;
                case OptimizationType.Maximization:
                    soFarTheBestObjective = double.MinValue;
                    break;
            }

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
            int currentCityID;
            objectiveValues = new double[NumberOfAnts];
            fitnessAntSum = new double[NumberOfAnts];

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
                Array.Clear(fitness, 0, fitness.Length);
                traveledCitiesID.Clear();

                // Randomly choose city to start with
                int pos = randomizer.Next(NumberOfCities);
                // Move to city selected
                currentCityID = availableCityIDs[pos];

                // Append ant solution
                solutions[i][0] = currentCityID;

                // add to traveled cities array
                traveledCitiesID.Add(currentCityID);


                /*
                 * Full Construction Step
                 */

                // construct full solution
                // step count: start looping and create solution 
                for (int s = 1; s < NumberOfCities; s++)
                {
                    // decrease number of candidate & set initial value of pos
                    pos = -1;

                    // inititate fitness value
                    fitnessSum = 0;

                    // initiate fit value
                    double maxFit = double.MinValue;

                    // caculate each city's fitness and choose best one
                    for (int j = 0; j < NumberOfCities; j++)
                    {
                        // to do: compute relative probability 
                        int candidateID = availableCityIDs[j];

                        // calculate fit value with pheromone map and ita value
                        itaValue = heuristicValues[s, j];
                        fitness[j] = Math.Pow(pheromoneMap[currentCityID, candidateID], AlphaValue) *
                            Math.Pow(pheromoneMap[currentCityID, candidateID], BetaValue);
                        fitnessSum += fitness[j];


                        if (!(traveledCitiesID.Contains(j)))
                        {
                            // determinstic checking method
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
                        }
                    }

                    // initiate next city id
                    int nextCityID = -1;

                    // decide next city id
                    switch (PheromoneUpdateMode)
                    {
                        case UpdateType.AntColonySystem:
                            if (randomizer.NextDouble() > DeterministicThresh)
                            {
                                // stochastic
                                while (true)
                                {
                                    pos = randomizer.Next(NumberOfCities);
                                    if (!(traveledCitiesID.Contains(pos))) break;
                                }

                            }
                            else
                            {
                                // deterministic
                            }
                            break;
                        case UpdateType.RankedAntSystem:
                            break;

                    }


                    nextCityID = availableCityIDs[pos];
                    solutions[i][s] = nextCityID;
                    // add to traveled city
                    traveledCitiesID.Add(nextCityID);

                    // add pheromone if segment pheromone dropping is enabled
                    // to do: add pheromone
                    pheromoneMap[currentCityID, nextCityID] += PheromoneUpdateAmount;

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
                    // continue if j == 0
                    if (j == 0) continue;

                    startCity = solutions[i][j - 1];
                    arrivedCity = solutions[i][j];

                    switch (PheromoneUpdateMode)
                    {
                        case UpdateType.AntColonySystem:
                            if (j != 0)
                            {
                                // pheromone is add by add-up value/fitnessValue
                                pheromoneMap[startCity, arrivedCity] += (PheromoneUpdateAmount * objectiveValues[i]);
                            }
                            break;
                        case UpdateType.RankedAntSystem:

                            // add pheromone by elite ant
                            for (int rank = 0; rank < indexArray.Length; rank++)
                            {
                                if (indexArray[rank] == i)
                                {
                                    // pheromone is add by add-up value/fitnessValue
                                    pheromoneMap[startCity, arrivedCity] += ((rankNum - rank) * PheromoneUpdateAmount * objectiveValues[i]);
                                }
                            }
                            break;
                    }


                }
            }

        }

        private void ComputeObjectiveValueAndUpdateSoFarTheBest()
        {
            int[] indexArray;

            switch (OptimizationMethod)
            {
                case OptimizationType.Minimization:
                    indexArray = objectiveValues.Take(1)
                        .Select((value, index) => new { value, index })
                        .OrderBy(item => item.value)
                        .Select(item => item.index)
                        .ToArray();

                    iterationBest = objectiveValues[indexArray[0]];

                    if (objectiveValues[indexArray[0]] < this.soFarTheBestObjective)
                    {
                        this.soFarTheBestObjective = objectiveValues[indexArray[0]];
                        this.soFarTheBestSolution = solutions[indexArray[0]];
                    }
                    break;
                case OptimizationType.Maximization:
                    indexArray = objectiveValues.Take(1)
                        .Select((value, index) => new { value, index })
                        .OrderByDescending(item => item.value)
                        .Select(item => item.index)
                        .ToArray();

                    iterationBest = objectiveValues[indexArray[0]];

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
