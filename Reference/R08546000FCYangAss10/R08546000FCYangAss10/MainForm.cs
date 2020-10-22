using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSPBenchmark;

namespace R08546000FCYangAss10
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        int[] mybestSolution;
        AntColonySystem theSolver;
        double[,] heuristicTerms;


        public double CalculateHeuristicValue( int i, int j )
        {
            return 1.0 /  TSPBenchmarkProblem.FromToDistanceMatrix[i, j];
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            TSPBenchmarkProblem.ImportATSPFile(true, true);
            rtbPblem.Text = TSPBenchmarkProblem.FileContents;

            mybestSolution =  TSPBenchmarkProblem.GetGreedyShortestRoute();

            pagCityNRoute.Refresh();

            heuristicTerms = new double[TSPBenchmarkProblem.NumberOfCities, TSPBenchmarkProblem.NumberOfCities];
            for (int i = 0; i < TSPBenchmarkProblem.NumberOfCities; i++)
            {
                for (int j = 0; j < TSPBenchmarkProblem.NumberOfCities; j++)
                {
                    heuristicTerms[i, j] = 1.0 / TSPBenchmarkProblem.FromToDistanceMatrix[i, j];
                }
            }
            //TSPBenchmarkProblem.DrawCitiesOptimalRouteAndARoute(pagCityNRoute.CreateGraphics(), pagCityNRoute.Width,
            //    pagCityNRoute.Height, mybestSolution);
             
        }

        private void pagCityNRoute_Paint(object sender, PaintEventArgs e)
        {
            if (theSolver == null) return;
            TSPBenchmarkProblem.DrawCitiesOptimalRouteAndARoute( e.Graphics  , e.ClipRectangle.Width, e.ClipRectangle.Height,
                 theSolver.SoFarTheBestSolution);

 

        }

        private void btnCreateACS_Click(object sender, EventArgs e)
        {

            theSolver = new AntColonySystem(TSPBenchmarkProblem.NumberOfCities,
                TSPBenchmarkProblem.ComputeObjectiveValue, heuristicTerms);

            theSolver = new AntColonySystem(TSPBenchmarkProblem.NumberOfCities,
                TSPBenchmarkProblem.ComputeObjectiveValue, CalculateHeuristicValue);



        }
    }
}
