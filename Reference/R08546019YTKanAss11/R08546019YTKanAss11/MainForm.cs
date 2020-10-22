using COP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyGALibrary;


namespace R08546019YTKanAss11
{
    public partial class MainForm : Form
    {      
        ParticleSwarmOptimizer PSOSolver;
        RealNumberGA RealNumberGASolver;
        COPBenchmark theProblem;
        
        public MainForm()
        {
            InitializeComponent();
            btnCreateSolver.Enabled = false;
            btnReset.Enabled = false;
            btnRunOneIteration.Enabled = false;
            btnRunToEnd.Enabled = false;

            rbtnPSO.Checked = true;
            ckxRealTimeUpdate.Checked = true;
            ckxShowSolutions.Checked = false;
        }

        private void OpenABenchmark(object sender, EventArgs e)
        {            
            theProblem = COPBenchmark.LoadAProblemFromAFile();

            theProblem.DisplayOnPanel(splitContainer1.Panel1);
            theProblem.DisplayObjectiveGraphics(pagObjective);

            btnCreateSolver.Enabled = true;
            btnReset.Enabled = false;
            btnRunOneIteration.Enabled = false;
            btnRunToEnd.Enabled = false;
        }

        OptimizationType optimizationType;
        MyGALibrary.OptimizationType type;
        private void btnCreateSolver_Click(object sender, EventArgs e)
        {                                 
            if (rbtnPSO.Checked == true)
            {
                if (theProblem.OptimizationGoal == COP.OptimizationType.Maximization)
                {
                    optimizationType = OptimizationType.Maximization;
                }
                else if (theProblem.OptimizationGoal == COP.OptimizationType.Minimization)
                {
                    optimizationType = OptimizationType.Minimization;
                }
                //COP.OptimizationType.GoalMatching

                //OptimizationType type = theProblem.OptimizationGoal == COP.OptimizationType.Maximization ?
                //    OptimizationType.Maximization : OptimizationType.Minimization; 

                PSOSolver = new ParticleSwarmOptimizer(theProblem.Dimension, theProblem.LowerBound, 
                    theProblem.UpperBound, optimizationType, theProblem.GetObjectiveValue);
                ppgTarget.SelectedObject = PSOSolver;
            }
            else if (rbtnGA.Checked == true)
            {
                if (theProblem.OptimizationGoal == COP.OptimizationType.Maximization)
                {
                    type = MyGALibrary.OptimizationType.Maximization;
                }
                else if (theProblem.OptimizationGoal == COP.OptimizationType.Minimization)
                {
                    type = MyGALibrary.OptimizationType.Minimization;
                }

                RealNumberGASolver = new RealNumberGA(theProblem.Dimension, type,
                    theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound);
                ppgTarget.SelectedObject = RealNumberGASolver;
                RealNumberGASolver.GeneBasedMutation = false;
            }

            btnReset.Enabled = true;
            btnRunOneIteration.Enabled = false;
            btnRunToEnd.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ltbSolutions.Items.Clear();

            if (rbtnPSO.Checked == true)
            {
                PSOSolver.Reset();
                theProblem.DisplaySolutionsOnGraphics(PSOSolver.Solutions);

                pgbStatus.Maximum = PSOSolver.IterationLimit;

                if (ckxShowSolutions.Checked == true)
                {
                    for (int i = 0; i < PSOSolver.NumberOfParticles; i++)
                    {
                        string strSolutions = "";
                        string strIndividualBestSolutions = "";
                        foreach (double variables in PSOSolver.Solutions[i])
                        {
                            strSolutions += $"{variables.ToString("0.0000")} ";
                        }
                        foreach (double variables in PSOSolver.IndividualBestSolutions[i])
                        {
                            strIndividualBestSolutions += $"{variables.ToString("0.0000")} ";
                        }
                        ltbSolutions.Items.Add($"Solution {i.ToString("0000")} = {strSolutions} Individual Best = {strIndividualBestSolutions}");
                    }
                }
            }
            else if (rbtnGA.Checked == true)
            {
                RealNumberGASolver.Reset();
                theProblem.DisplaySolutionsOnGraphics(RealNumberGASolver.Chromosomes);

                pgbStatus.Maximum = RealNumberGASolver.IterationLimit;

                if (ckxShowSolutions.Checked == true)
                {
                    for (int i = 0; i < RealNumberGASolver.PopulationSize; i++)
                    {
                        string strSolutions = "";                        
                        foreach (double variables in RealNumberGASolver.Chromosomes[i])
                        {
                            strSolutions += $"{variables.ToString("0.0000")} ";
                        }                       
                        ltbSolutions.Items.Add($"Solution {i.ToString("0000")} = {strSolutions}");
                    }
                }
            }

            mainChart.Series[0].Points.Clear();
            mainChart.Series[1].Points.Clear();
            mainChart.Series[2].Points.Clear();

            labSoFarTheBestObjectiveValue.Text = $"So Far The Best Objective Value : ";
            labSoFarTheBestSolution.Text = $"So Far The Best Solution : ";
            rtbSoFarTheBestSolution.Clear();

            pgbStatus.Minimum = 0;
            pgbStatus.Value = 0;
            pgbStatus.Step = 1;

            btnRunOneIteration.Enabled = true;
            btnRunToEnd.Enabled = true;
        }

        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            if (rbtnPSO.Checked == true)
            {
                ltbSolutions.Items.Clear();

                PSOSolver.RunOneIteration();
                //update lines of objectives
                mainChart.Series[0].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationAverageObjectiveValue);
                mainChart.Series[1].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationBestObjectiveValue);
                mainChart.Series[2].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjectiveValue);

                //display solution on graphics                
                theProblem.DisplaySolutionsOnGraphics(PSOSolver.Solutions);

                if (ckxShowSolutions.Checked == true)
                {
                    for (int i = 0; i < PSOSolver.NumberOfParticles; i++)
                    {
                        string strSolutions = "";
                        string strIndividualBestSolutions = "";
                        foreach (double variables in PSOSolver.Solutions[i])
                        {
                            strSolutions += $"{variables.ToString("0.0000")} ";
                        }
                        foreach (double variables in PSOSolver.IndividualBestSolutions[i])
                        {
                            strIndividualBestSolutions += $"{variables.ToString("0.0000")} ";
                        }
                        ltbSolutions.Items.Add($"Solution {i.ToString("0000")} = {strSolutions} Individual Best = {strIndividualBestSolutions}");
                    }
                }

                labSoFarTheBestObjectiveValue.Text = $"So Far The Best Objective Value : {PSOSolver.SoFarTheBestObjectiveValue.ToString("0.0000")}";
                rtbSoFarTheBestSolution.Text = "";
                for (int i = 0; i < theProblem.Dimension; i++)
                {
                    rtbSoFarTheBestSolution.Text += $"{PSOSolver.SoFarTheBestSolution[i].ToString("0.0000")} ";
                }

                pgbStatus.PerformStep();
            }
            else if (rbtnGA.Checked == true)
            {
                ltbSolutions.Items.Clear();

                RealNumberGASolver.RunOneIteration();
                //update lines of objectives
                mainChart.Series[0].Points.AddXY(RealNumberGASolver.IterationCount, RealNumberGASolver.IterationAverageObjectiveValue);
                mainChart.Series[1].Points.AddXY(RealNumberGASolver.IterationCount, RealNumberGASolver.IterationBestObjectiveValue);
                mainChart.Series[2].Points.AddXY(RealNumberGASolver.IterationCount, RealNumberGASolver.SoFarTheBestObjectiveValue);

                //display solution on graphics                
                theProblem.DisplaySolutionsOnGraphics(RealNumberGASolver.Chromosomes);

                if (ckxShowSolutions.Checked == true)
                {
                    for (int i = 0; i < RealNumberGASolver.PopulationSize; i++)
                    {
                        string strSolutions = "";
                        foreach (double variables in RealNumberGASolver.Chromosomes[i])
                        {
                            strSolutions += $"{variables.ToString("0.0000")} ";
                        }
                        ltbSolutions.Items.Add($"Solution {i.ToString("0000")} = {strSolutions}");
                    }
                }

                labSoFarTheBestObjectiveValue.Text = $"So Far The Best Objective Value : {RealNumberGASolver.SoFarTheBestObjectiveValue.ToString("0.0000")}";
                rtbSoFarTheBestSolution.Text = "";
                for (int i = 0; i < theProblem.Dimension; i++)
                {
                    rtbSoFarTheBestSolution.Text += $"{RealNumberGASolver.SoFarTheBestSolution[i].ToString("0.0000")} ";
                }

                pgbStatus.PerformStep();
            }
        }

        private void btnRunToEnd_Click(object sender, EventArgs e)
        {
            if (rbtnPSO.Checked == true)
            {
                Cursor = Cursors.WaitCursor;

                DateTime startTime = DateTime.Now;
                labStatus.Text = $"Start at : {startTime}";

                if (ckxRealTimeUpdate.Checked)
                {
                    do
                    {
                        ltbSolutions.Items.Clear();

                        PSOSolver.RunOneIteration();
                        //update lines of objectives
                        mainChart.Series[0].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationAverageObjectiveValue);
                        mainChart.Series[1].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationBestObjectiveValue);
                        mainChart.Series[2].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjectiveValue);
                        mainChart.Update();

                        //display solution on graphics
                        theProblem.DisplaySolutionsOnGraphics(PSOSolver.Solutions);

                        if (ckxShowSolutions.Checked == true)
                        {
                            for (int i = 0; i < PSOSolver.NumberOfParticles; i++)
                            {
                                string strSolutions = "";
                                string strIndividualBestSolutions = "";
                                foreach (double variables in PSOSolver.Solutions[i])
                                {
                                    strSolutions += $"{variables.ToString("0.0000")} ";
                                }
                                foreach (double variables in PSOSolver.IndividualBestSolutions[i])
                                {
                                    strIndividualBestSolutions += $"{variables.ToString("0.0000")} ";
                                }
                                ltbSolutions.Items.Add($"Solution {i.ToString("0000")} = {strSolutions} Individual Best = {strIndividualBestSolutions}");
                            }
                            ltbSolutions.Refresh();
                        }

                        labSoFarTheBestObjectiveValue.Text = $"So Far The Best Objective Value : {PSOSolver.SoFarTheBestObjectiveValue.ToString("0.0000")}";
                        rtbSoFarTheBestSolution.Text = "";
                        for (int i = 0; i < theProblem.Dimension; i++)
                        {
                            rtbSoFarTheBestSolution.Text += $"{PSOSolver.SoFarTheBestSolution[i].ToString("0.0000")} ";
                        }

                        labSoFarTheBestObjectiveValue.Refresh();
                        rtbSoFarTheBestSolution.Refresh();

                        pgbStatus.PerformStep();
                    }
                    while (PSOSolver.IterationCount < PSOSolver.IterationLimit);

                    if (PSOSolver.IterationCount == PSOSolver.IterationLimit)
                    {
                        labSoFarTheBestObjectiveValue.Text = $"So Far The Best Objective Value : {PSOSolver.SoFarTheBestObjectiveValue.ToString("0.0000")}";
                        rtbSoFarTheBestSolution.Text = "";
                        for (int i = 0; i < theProblem.Dimension; i++)
                        {
                            rtbSoFarTheBestSolution.Text += $"{PSOSolver.SoFarTheBestSolution[i].ToString("0.0000")} ";
                        }
                    }
                }
                else
                {
                    do
                    {
                        ltbSolutions.Items.Clear();

                        PSOSolver.RunOneIteration();
                        mainChart.Series[0].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationAverageObjectiveValue);
                        mainChart.Series[1].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationBestObjectiveValue);
                        mainChart.Series[2].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjectiveValue);

                        if (ckxShowSolutions.Checked == true)
                        {
                            for (int i = 0; i < PSOSolver.NumberOfParticles; i++)
                            {
                                string strSolutions = "";
                                string strIndividualBestSolutions = "";
                                foreach (double variables in PSOSolver.Solutions[i])
                                {
                                    strSolutions += $"{variables.ToString("0.0000")} ";
                                }
                                foreach (double variables in PSOSolver.IndividualBestSolutions[i])
                                {
                                    strIndividualBestSolutions += $"{variables.ToString("0.0000")} ";
                                }
                                ltbSolutions.Items.Add($"Solution {i.ToString("0000")} = {strSolutions} Individual Best = {strIndividualBestSolutions}");
                            }
                            ltbSolutions.Refresh();
                        }

                        pgbStatus.PerformStep();
                    }
                    while (PSOSolver.IterationCount < PSOSolver.IterationLimit);

                    if (PSOSolver.IterationCount == PSOSolver.IterationLimit)
                    {               
                        labSoFarTheBestObjectiveValue.Text = $"So Far The Best Objective Value : {PSOSolver.SoFarTheBestObjectiveValue.ToString("0.0000")}";
                        rtbSoFarTheBestSolution.Text = "";
                        for (int i = 0; i < theProblem.Dimension; i++)
                        {
                            rtbSoFarTheBestSolution.Text += $"{PSOSolver.SoFarTheBestSolution[i].ToString("0.0000")} ";
                        }

                        theProblem.DisplaySolutionsOnGraphics(PSOSolver.Solutions);
                    }
                }

                Cursor = Cursors.Default;
                btnRunOneIteration.Enabled = false;
                btnRunToEnd.Enabled = false;

                DateTime endTime = DateTime.Now;
                TimeSpan delta = endTime - startTime;
                labStatus.Text = $"Start at : {startTime} End at : {endTime} Time Spent : {delta}";
            }
            else if (rbtnGA.Checked == true)
            {
                Cursor = Cursors.WaitCursor;

                DateTime startTime = DateTime.Now;
                labStatus.Text = $"Start at : {startTime}";

                if (ckxRealTimeUpdate.Checked)
                {
                    do
                    {
                        ltbSolutions.Items.Clear();

                        RealNumberGASolver.RunOneIteration();
                        //update lines of objectives
                        mainChart.Series[0].Points.AddXY(RealNumberGASolver.IterationCount, RealNumberGASolver.IterationAverageObjectiveValue);
                        mainChart.Series[1].Points.AddXY(RealNumberGASolver.IterationCount, RealNumberGASolver.IterationBestObjectiveValue);
                        mainChart.Series[2].Points.AddXY(RealNumberGASolver.IterationCount, RealNumberGASolver.SoFarTheBestObjectiveValue);
                        mainChart.Update();

                        //display solution on graphics
                        //display solution on graphics                
                        theProblem.DisplaySolutionsOnGraphics(RealNumberGASolver.Chromosomes);

                        if (ckxShowSolutions.Checked == true)
                        {
                            for (int i = 0; i < RealNumberGASolver.PopulationSize; i++)
                            {
                                string strSolutions = "";
                                foreach (double variables in RealNumberGASolver.Chromosomes[i])
                                {
                                    strSolutions += $"{variables.ToString("0.0000")} ";
                                }
                                ltbSolutions.Items.Add($"Solution {i.ToString("0000")} = {strSolutions}");
                            }
                            ltbSolutions.Refresh();
                        }

                        labSoFarTheBestObjectiveValue.Text = $"So Far The Best Objective Value : {RealNumberGASolver.SoFarTheBestObjectiveValue.ToString("0.0000")}";
                        rtbSoFarTheBestSolution.Text = "";
                        for (int i = 0; i < theProblem.Dimension; i++)
                        {
                            rtbSoFarTheBestSolution.Text += $"{RealNumberGASolver.SoFarTheBestSolution[i].ToString("0.0000")} ";
                        }

                        labSoFarTheBestObjectiveValue.Refresh();
                        rtbSoFarTheBestSolution.Refresh();

                        pgbStatus.PerformStep();
                    }
                    while (RealNumberGASolver.IterationCount < RealNumberGASolver.IterationLimit);

                    if (RealNumberGASolver.IterationCount == RealNumberGASolver.IterationLimit)
                    {
                        labSoFarTheBestObjectiveValue.Text = $"So Far The Best Objective Value : {RealNumberGASolver.SoFarTheBestObjectiveValue.ToString("0.0000")}";
                        rtbSoFarTheBestSolution.Text = "";
                        for (int i = 0; i < theProblem.Dimension; i++)
                        {
                            rtbSoFarTheBestSolution.Text += $"{RealNumberGASolver.SoFarTheBestSolution[i].ToString("0.0000")} ";
                        }
                    }
                }
                else
                {
                    do
                    {
                        ltbSolutions.Items.Clear();

                        RealNumberGASolver.RunOneIteration();                        
                        mainChart.Series[0].Points.AddXY(RealNumberGASolver.IterationCount, RealNumberGASolver.IterationAverageObjectiveValue);
                        mainChart.Series[1].Points.AddXY(RealNumberGASolver.IterationCount, RealNumberGASolver.IterationBestObjectiveValue);
                        mainChart.Series[2].Points.AddXY(RealNumberGASolver.IterationCount, RealNumberGASolver.SoFarTheBestObjectiveValue);

                        if (ckxShowSolutions.Checked == true)
                        {
                            for (int i = 0; i < RealNumberGASolver.PopulationSize; i++)
                            {
                                string strSolutions = "";
                                foreach (double variables in RealNumberGASolver.Chromosomes[i])
                                {
                                    strSolutions += $"{variables.ToString("0.0000")} ";
                                }
                                ltbSolutions.Items.Add($"Solution {i.ToString("0000")} = {strSolutions}");
                            }
                            ltbSolutions.Refresh();
                        }

                        pgbStatus.PerformStep();
                    }
                    while (RealNumberGASolver.IterationCount < RealNumberGASolver.IterationLimit);

                    if (RealNumberGASolver.IterationCount == RealNumberGASolver.IterationLimit)
                    {
                        labSoFarTheBestObjectiveValue.Text = $"So Far The Best Objective Value : {RealNumberGASolver.SoFarTheBestObjectiveValue.ToString("0.0000")}";
                        rtbSoFarTheBestSolution.Text = "";
                        for (int i = 0; i < theProblem.Dimension; i++)
                        {
                            rtbSoFarTheBestSolution.Text += $"{RealNumberGASolver.SoFarTheBestSolution[i].ToString("0.0000")} ";
                        }

                        theProblem.DisplaySolutionsOnGraphics(RealNumberGASolver.Chromosomes);
                    }
                }

                Cursor = Cursors.Default;
                btnRunOneIteration.Enabled = false;
                btnRunToEnd.Enabled = false;

                DateTime endTime = DateTime.Now;
                TimeSpan delta = endTime - startTime;
                labStatus.Text = $"Start at : {startTime} End at : {endTime} Time Spent : {delta}";
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            COPBenchmark newProblem = COP.COPBenchmark.CreateANewProblemAndShowEditor();
        }
    }
}

