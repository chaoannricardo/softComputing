using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TSPBenchmark;

namespace R08546036SHChaoAss10TSP
{
    public partial class MainForm : Form
    {
        AntColonySystemForTSP theSolver;
        bool initiateFlag;
        int epochRunOneIteration;
        Series theSeriesObj;
        Series iterationBest;
        Series iterationAverage;

        //TSPBenchmarkProblem theProblem;

        public MainForm()
        {
            InitializeComponent();

            //TSPBenchmarkProblem.
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // let application to go full screen
            WindowState = FormWindowState.Maximized;

            //MessageBox.Show(Directory.GetCurrentDirectory());

            // initiate data grid
            this.informationDataGrid.Columns.Add("Information Grid", "Information Grid");
            this.informationDataGrid.Columns.Add("", "");
            for (int i = 0; i < 3; i++) this.informationDataGrid.Rows.Add();
            informationDataGrid.Columns[0].Width = 200;
            informationDataGrid.Columns[1].Width = 250;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            // open
            int status = TSPBenchmarkProblem.ImportATSPFile(true, true);

            // refresh painting panel
            SPCThird.Panel2.Refresh();

            informationDataGrid.Rows[0].Cells[0].Value = "Known for the shortest length:";
            informationDataGrid.Rows[0].Cells[1].Value = TSPBenchmarkProblem.GlobalShorestLength4TSP.ToString();

            // attempt to clear datagrid pheromone
            datagridPheromone.CancelEdit();
            datagridPheromone.Columns.Clear();
            datagridPheromone.DataSource = null;

        }

        // painting function to pain on panel 2
        private void splitContainer4_Panel2_Paint(object sender, PaintEventArgs e)
        {
            TSPBenchmarkProblem.DrawCitesAndARoute(e.Graphics, SPCThird.Panel2.Width,
               SPCThird.Panel2.Height, null);

            try
            {
                if (theSolver != null) TSPBenchmarkProblem.DrawCitiesOptimalRouteAndARoute(e.Graphics, SPCThird.Panel2.Width,
               SPCThird.Panel2.Height, theSolver.SoFarTheBestSolution);
            }
            catch (System.IndexOutOfRangeException Excetption)
            {
                return;
            }
        }

        // create ASP solver
        private void btnCreateACSSolver_Click(object sender, EventArgs e)
        {
            try
            {
                theSolver = new AntColonySystemForTSP(TSPBenchmarkProblem.NumberOfCities,
                TSPBenchmarkProblem.ComputeRouteLength, TSPBenchmarkProblem.FromToDistanceMatrix);

                // refresh painting panel
                SPCThird.Panel2.Refresh();

                // property gird
                gridTheProblemSolver.SelectedObject = theSolver;

                // add to datagrid pheromone
                for (int i = 0; i <= theSolver.NumberOfCities; i++) {
                    if (i == 0) {
                        this.datagridPheromone.Columns.Add("PheromoneMap", "PheromoneMap");
                        this.datagridPheromone.Columns.Add($"City {i}", $"City {i}");
                        this.datagridPheromone.Columns[i].Width = 100;
                        continue;
                    }
                    this.datagridPheromone.Columns.Add($"City {i}", $"City {i}");
                    this.datagridPheromone.Columns[i].Frozen = false;
                    this.datagridPheromone.Columns[i].Width = 60;
                    this.datagridPheromone.Rows.Add();
                    datagridPheromone.Rows[i].Cells[0].Value = $"City {i}";
                }

                for (int i = 0; i <= theSolver.NumberOfCities; i++)
                {
                    datagridPheromone.Rows[i].Cells[0].Value = $"City {i}";
                }

            }
            catch (System.IndexOutOfRangeException Exception)
            {
                MessageBox.Show("You should first read in the problem set.");
            }
            catch (System.OutOfMemoryException Exception)
            {
                MessageBox.Show("System Error: Out of Memory\nProcess Terminated.");
                return;
            }

        }

        // reset function
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                theSolver.Reset();

                // update label information
                informationDataGrid.Rows[2].Cells[0].Value = "So Far Shortest Length:";
                informationDataGrid.Rows[2].Cells[1].Value = theSolver.SoFarTheBestObjective.ToString();

                // update variables
                epochRunOneIteration = 0;

                // clear chart
                chartSolution.Series.Clear();

                theSeriesObj = new Series("SoFarTheBest");
                theSeriesObj.ChartType = SeriesChartType.Line;
                theSeriesObj.Color = Color.Red;
                theSeriesObj.BorderWidth = 3;
                chartSolution.Series.Add(theSeriesObj);

                iterationBest = new Series("IterationBest");
                iterationBest.ChartType = SeriesChartType.Line;
                iterationBest.Color = Color.Orange;
                iterationBest.BorderWidth = 3;
                chartSolution.Series.Add(iterationBest);

                iterationAverage = new Series("IterationAverage");
                iterationAverage.ChartType = SeriesChartType.Line;
                iterationAverage.Color = Color.Green;
                iterationAverage.BorderWidth = 3;
                chartSolution.Series.Add(iterationAverage);

                // clear pheromone pane;
                for (int i = 0; i < theSolver.NumberOfCities; i++)
                {
                    for (int j = 0; j < theSolver.NumberOfCities; j++)
                    {
                        datagridPheromone.Rows[i].Cells[j + 1].Value = 0;
                    }
                }

            }
            catch (System.NullReferenceException Exception)
            {
                MessageBox.Show("You have to create solver first.");
                return;
            }
        }

        // run one iteration function
        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            try
            {
                theSolver.RunOneIteration();

                SPCThird.Panel2.Refresh();

                // update label information & variables
                epochRunOneIteration++;
                informationDataGrid.Rows[1].Cells[0].Value = "Epoch:";
                informationDataGrid.Rows[1].Cells[1].Value = epochRunOneIteration.ToString();
                informationDataGrid.Rows[2].Cells[0].Value = "So Far Shortest Length:";
                informationDataGrid.Rows[2].Cells[1].Value = theSolver.SoFarTheBestObjective.ToString();

                // add numbers to chart
                chartSolution.Series[0].Points.AddXY(epochRunOneIteration, theSolver.SoFarTheBestObjective);
                chartSolution.Series[1].Points.AddXY(epochRunOneIteration, theSolver.IterationBestObjective);
                chartSolution.Series[2].Points.AddXY(epochRunOneIteration, theSolver.IterationAverage);

                // update pheromone grid
                UpdatePheromoneGrid(theSolver);

            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Initate the solver first.");
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                // initiate time
                DateTime startTime = DateTime.Now;

                for (int i = 0; i < theSolver.IterationCount; i++)
                {
                    theSolver.RunOneIteration();


                    // update label informations.
                    informationDataGrid.Rows[1].Cells[0].Value = "Epoch:";
                    informationDataGrid.Rows[1].Cells[1].Value = i.ToString();
                    informationDataGrid.Rows[2].Cells[0].Value = "So Far Shortest Length:";
                    informationDataGrid.Rows[2].Cells[1].Value = theSolver.SoFarTheBestObjective.ToString();

                    // add numbers to chart
                    chartSolution.Series[0].Points.AddXY(epochRunOneIteration, theSolver.SoFarTheBestObjective);
                    chartSolution.Series[1].Points.AddXY(epochRunOneIteration, theSolver.IterationBestObjective);
                    chartSolution.Series[2].Points.AddXY(epochRunOneIteration, theSolver.IterationAverage);

                    // refresh graph panel
                    SPCThird.Panel2.Refresh();
                }

                // refresh graph panel
                SPCThird.Panel2.Refresh();

                // update pheromone grid
                UpdatePheromoneGrid(theSolver);

                // calculate taken time
                DateTime endTime = DateTime.Now;
                TimeSpan delta = endTime - startTime;
                lbTime.Text = $"start {startTime}, endtime {endTime}, delta {delta}";
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Initate the solver first.");

            }
        }

        private void UpdatePheromoneGrid(AntColonySystemForTSP theSolver) {
            if (theSolver == null) return;
            for (int i = 0; i < theSolver.NumberOfCities; i++) {
                for (int j = 0; j < theSolver.NumberOfCities; j++) {
                    datagridPheromone.Rows[i].Cells[j + 1].Value = Math.Round(theSolver.PheromoneMap[i, j], 2);
                }
            }
        }


    }
}
