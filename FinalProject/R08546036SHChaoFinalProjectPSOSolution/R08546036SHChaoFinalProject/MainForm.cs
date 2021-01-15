using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using COP;

namespace R08546036SHChaoFinalProject
{
    public partial class MainForm : Form
    {
        PSOBasedType theSolver;
        COPBenchmark theProblem;
        Series theSeriesObj;
        Series iterationBest;
        Series iterationAverage;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // let application to go full screen
            WindowState = FormWindowState.Maximized;

            // initiate PSO selection
            cbPSOSelector.SelectedText = "AnimalFoodChainBasedPSO";

            // initiate data grid
            this.dataInfo.Columns.Add("Information Grid", "Information Grid");
            this.dataInfo.Columns.Add("", "");
            for (int i = 0; i < 3; i++) this.dataInfo.Rows.Add();
            dataInfo.Columns[0].Width = 100;
            dataInfo.Columns[1].Width = 250;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            theProblem = COPBenchmark.LoadAProblemFromAFile();

            if (theProblem == null) return;

            theProblem.DisplayOnPanel(spcMain.Panel1);
            theProblem.DisplayObjectiveGraphics(spcSecond.Panel2);

            //if (theSolver != null)theProblem.DisplaySolutionsOnGraphics(theSolver.Solutions);
        }

        private void btnNewProb_Click(object sender, EventArgs e)
        {
            COPBenchmark newProblem =  COPBenchmark.CreateANewProblemAndShowEditor();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OptimizationType type = theProblem.OptimizationGoal == COP.OptimizationType.Minimization ?
                OptimizationType.Minimization : OptimizationType.Maximization;

            // select solver based on selection
            switch (cbPSOSelector.SelectedIndex) {
                case 0:
                    theSolver = new ParticalSwarmOptimizationSolver(theProblem.Dimension, type,
                theProblem.LowerBound, theProblem.UpperBound, theProblem.GetObjectiveValue);
                    break;
                case 1:
                    theSolver = new PredatorPreyPSO(theProblem.Dimension, type,
                theProblem.LowerBound, theProblem.UpperBound, theProblem.GetObjectiveValue);
                    break;
                case 2:
                    theSolver = new HuntingSearchPSO(theProblem.Dimension, type,
                theProblem.LowerBound, theProblem.UpperBound, theProblem.GetObjectiveValue);
                    break;
                case 3:
                    theSolver = new AnimalFoodChainBasedPSO(theProblem.Dimension, type,
                theProblem.LowerBound, theProblem.UpperBound, theProblem.GetObjectiveValue);
                    break;
            }

            gridTheSolver.SelectedObject = theSolver;

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (theSolver == null) return;

            theSolver.Reset();

            dataInfo.Rows[0].Cells[0].Value = "Epoch";
            dataInfo.Rows[1].Cells[0].Value = "Best Objective";
            dataInfo.Rows[2].Cells[0].Value = "Best Solution";

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

        }

        private void RunOneIteration() {
            if (theSolver.IsReset == false) return;

            theSolver.RunOneIteration();
            dataInfo.Rows[0].Cells[1].Value = theSolver.IterationCount;
            dataInfo.Rows[1].Cells[1].Value = theSolver.SoFarTheBestObjective;
            dataInfo.Rows[2].Cells[1].Value = theSolver.SolutionBest;

            theProblem.DisplaySolutionsOnGraphics(theSolver.Solutions);

            // add numbers to chart
            chartSolution.Series[0].Points.AddXY(theSolver.IterationCount, theSolver.SoFarTheBestObjective);
            chartSolution.Series[1].Points.AddXY(theSolver.IterationCount, theSolver.SoFarTheBestObjectiveIteration);
            chartSolution.Series[2].Points.AddXY(theSolver.IterationCount, theSolver.IterationAverage);

            // update information grid and chart
            chartSolution.Update();
            dataInfo.Update();
        }

        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            RunOneIteration();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (theSolver == null) return;

            for (int i = 0; i < theSolver.IterationLimit; i++) {
                RunOneIteration();
            }
        }

        
    }
}
