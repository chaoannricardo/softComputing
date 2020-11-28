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
using GeneticAlgorithmLibrary;

namespace JobAssignmentProblemGASolver
{
    public partial class MainForm : Form
    {
        JobAssignmentProblem theProblem;
        PermutationGASolver thePermutationGA;
        BinaryGASolver theBinaryGA;
        Random randomizer = new Random();
        private bool isReset = false;
        private double[] machineJobsWeight;
        protected Series theSeriesObj;
        protected Series iterationBest;

        public MainForm()
        {
            InitializeComponent();

            theProblem = new JobAssignmentProblem();

            //double[] fit = { 3, 4, 1, 2, 7, 8, 4.5, 1.2, 4.3, 2.2 };
            //int[] id = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Array.Sort(fit);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbGAType.SelectedIndex = 0;
            lbTimeStamp.Text = "";

            // let application to go full screen
            WindowState = FormWindowState.Maximized;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() != DialogResult.OK) return;

            theProblem.OpenFile(dlg.FileName);

            thePermutationGA = new PermutationGASolver(theProblem.NumberOfJobs * theProblem.NumberOfJobs,
                OptimizationType.Minimization,
                theProblem.GetObjectiveValue);

            gridGA.SelectedObject = thePermutationGA;

            // assign job weight value
            machineJobsWeight = new double[(int)(theProblem.NumberOfJobs * theProblem.NumberOfJobs)];

            // create table in datagrid view
            dgJobsAndMachines.CancelEdit();
            dgJobsAndMachines.Columns.Clear();
            dgJobsAndMachines.DataSource = null;

            // create header of datagrid
            for (int i = 0; i < theProblem.NumberOfJobs; i++)
            {
                if (i == 0)
                {
                    dgJobsAndMachines.Columns.Add("Job/Machine", "Job/Machine");
                    dgJobsAndMachines.Columns.Add($"M{i + 1}", $"M{ i + 1}");
                }
                else
                {
                    dgJobsAndMachines.Columns.Add($"M{i + 1}", $"M{ i + 1}");
                }
                dgJobsAndMachines.Rows.Add();
            }

            int counter = 0;

            for (int i = 0; i < theProblem.NumberOfJobs; i++)
            {
                for (int j = 0; j <= theProblem.NumberOfJobs; j++)
                {
                    if (j == 0)
                    {
                        dgJobsAndMachines.Rows[i].Cells[0].Value = $"J{i + 1}";
                    }
                    else
                    {
                        dgJobsAndMachines.Rows[i].Cells[j].Value = theProblem.SettingTimes[counter];
                        machineJobsWeight[counter] = theProblem.SettingTimes[counter];
                        counter += 1;
                    }

                }
            }

            cbGAType.SelectedIndex = 1;

            MessageBox.Show("Warning:\nYou would not have to create a new GA Solver when opening a problem from the file.\nDo not Press the button 'Create a GA solver' then.");

        }

        private void btnCreateGASolver_Click(object sender, EventArgs e)
        {
            theProblem.NumberOfJobs = Convert.ToInt32(tbJobs.Text);

            // assign job weight value
            machineJobsWeight = new double[(int)(theProblem.NumberOfJobs * theProblem.NumberOfJobs)];

            if (cbGAType.SelectedIndex == 0)
            {
                theBinaryGA = new BinaryGASolver(theProblem.NumberOfJobs * theProblem.NumberOfJobs,
                    OptimizationType.Minimization,
                    theProblem.GetObjectiveValue);
                theBinaryGA.IterationLimit = Convert.ToInt32(tbIteration.Text);
                gridGA.SelectedObject = theBinaryGA;
            }
            else if (cbGAType.SelectedIndex == 1)
            {
                thePermutationGA = new PermutationGASolver(theProblem.NumberOfJobs * theProblem.NumberOfJobs,
                    OptimizationType.Minimization,
                    theProblem.GetObjectiveValue);
                thePermutationGA.IterationLimit = Convert.ToInt32(tbIteration.Text);
                gridGA.SelectedObject = thePermutationGA;
            }

            // create table in datagrid view
            dgJobsAndMachines.CancelEdit();
            dgJobsAndMachines.Columns.Clear();
            dgJobsAndMachines.DataSource = null;

            for (int i = 0; i < theProblem.NumberOfJobs; i++)
            {
                if (i == 0)
                {
                    dgJobsAndMachines.Columns.Add("Job/Machine", "Job/Machine");
                    dgJobsAndMachines.Columns.Add($"M{i + 1}", $"M{ i + 1}");
                }
                else
                {
                    dgJobsAndMachines.Columns.Add($"M{i + 1}", $"M{ i + 1}");
                }
                dgJobsAndMachines.Rows.Add();
            }

            int counter = 0;

            for (int i = 0; i < theProblem.NumberOfJobs; i++)
            {
                for (int j = 0; j <= theProblem.NumberOfJobs; j++)
                {
                    if (j == 0)
                    {
                        dgJobsAndMachines.Rows[i].Cells[0].Value = $"J{i + 1}";
                    }
                    else if (i == (j - 1))
                    {
                        dgJobsAndMachines.Rows[i].Cells[j].Value = 0;
                    }
                    else
                    {
                        double randomValue = randomizer.NextDouble();
                        double minimumValue = Convert.ToDouble(tbMinimum.Text);
                        double maximumValue = Convert.ToDouble(tbMaximum.Text);
                        double addingValue = (maximumValue - minimumValue) * randomValue;
                        dgJobsAndMachines.Rows[i].Cells[j].Value = (minimumValue + addingValue);
                        machineJobsWeight[counter] = (minimumValue + addingValue);
                        counter += 1;
                    }

                }
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            rtbPopulation.Clear();

            try
            {
                rtbPopulation.AppendText($"【Initial Parents】\n");

                switch (cbGAType.SelectedIndex)
                {
                    // binary GA
                    case 0:
                        theBinaryGA.Reset();
                        theBinaryGA.MachineJobWeight = machineJobsWeight;
                        for (int i = 0; i < theBinaryGA.PopulationSize; i++)
                        {
                            rtbPopulation.AppendText($"P Chrom {i + 1}: ");
                            for (int j = 0; j < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); j++)
                            {
                                rtbPopulation.AppendText($"{theBinaryGA.Chromosome[i][j]} ");
                            }
                            rtbPopulation.AppendText($"\n");
                        }
                        break;
                    // permutation GA
                    case 1:
                        thePermutationGA.Reset();
                        thePermutationGA.MachineJobWeight = machineJobsWeight;
                        for (int i = 0; i < thePermutationGA.PopulationSize; i++)
                        {
                            rtbPopulation.AppendText($"P Chrom {i + 1}: ");
                            for (int j = 0; j < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); j++)
                            {
                                rtbPopulation.AppendText($"{thePermutationGA.Chromosome[i][j]} ");
                            }
                            rtbPopulation.AppendText($"\n");
                        }
                        break;

                }

                rtbPopulation.AppendText($"\n");
                richTextBox_TextChanged();



            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("The GA Solver is not correctly initiatied, try agian!");
                return;
            }

            // reset flag change
            isReset = true;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            // check if reset
            if (isReset == false)
            {
                MessageBox.Show("Press reset before running the algorithm!");
                return;
            }

            rtbBestSolution.Clear();
            rtbPopulation.Clear();
            rtbBestObj.Clear();

            // clear chart 
            chart1.Series.Clear();

            theSeriesObj = new Series("SoFarTheBest");
            theSeriesObj.ChartType = SeriesChartType.Line;
            theSeriesObj.Color = Color.Red;
            theSeriesObj.BorderWidth = 3;
            chart1.Series.Add(theSeriesObj);

            iterationBest = new Series("IterationBest");
            iterationBest.ChartType = SeriesChartType.Line;
            iterationBest.Color = Color.Orange;
            iterationBest.BorderWidth = 3;
            chart1.Series.Add(iterationBest);

            // initial time
            DateTime startTime = DateTime.Now;

            // start gene algorithm
            switch (cbGAType.SelectedIndex)
            {
                // binary GA
                case 0:
                    for (int iteration = 0; iteration < theBinaryGA.IterationLimit; iteration++)
                    {
                        rtbPopulation.AppendText($"======================= Iteration {iteration + 1} =======================\n\n");

                        theBinaryGA.RunOneIteration();

                        if (iteration != 0)
                        {
                            // print parent
                            rtbPopulation.AppendText($"【Parent】\n");
                            for (int i = 0; i < theBinaryGA.PopulationSize; i++)
                            {
                                rtbPopulation.AppendText($"Parent Chrom {i + 1 }: ");
                                for (int j = 0; j < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); j++)
                                {
                                    rtbPopulation.AppendText($"{theBinaryGA.Chromosome[i][j]} ");
                                }
                                rtbPopulation.AppendText($"\n");
                            }

                            rtbPopulation.AppendText($"\n\n");

                        }

                        // print children 
                        rtbPopulation.AppendText($"【Children】\n\n");
                        for (int i = 0; i < theBinaryGA.PopulationSize; i++)
                        {
                            rtbPopulation.AppendText($"Children Chrom {i + 1 }: ");
                            for (int j = 0; j < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); j++)
                            {
                                rtbPopulation.AppendText($"{theBinaryGA.Chromosome[i + theBinaryGA.PopulationSize][j]} ");
                            }
                            rtbPopulation.AppendText($"\n");
                        }

                        // print mutated children
                        rtbPopulation.AppendText($"\n\n【Mutated Children】\n\n");
                        for (int i = 0; i < theBinaryGA.PopulationSize; i++)
                        {
                            rtbPopulation.AppendText($"Mutated Chrom {i + 1 }: ");
                            for (int j = 0; j < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); j++)
                            {
                                rtbPopulation.AppendText($"{theBinaryGA.Chromosome[i + theBinaryGA.PopulationSize * 2][j]} ");
                            }
                            rtbPopulation.AppendText($"\n");
                        }


                        for (int i = 0; i < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); i++)
                        {
                            rtbBestSolution.AppendText(theBinaryGA.BestSolutionAnswer[i].ToString() + " ");
                        }
                        rtbBestSolution.AppendText("\n");
                        rtbBestObj.AppendText(theBinaryGA.BestSolutionValue.ToString() + "\n");

                        richTextBox_TextChanged();

                        chart1.Series[0].Points.AddXY(iteration, theBinaryGA.BestSolutionValue);

                        chart1.Series[1].Points.AddXY(iteration, theBinaryGA.IterationBest);

                    }
                    break;
                // permutation GA
                case 1:
                    for (int iteration = 0; iteration < thePermutationGA.IterationLimit; iteration++)
                    {
                        rtbPopulation.AppendText($"======================= Iteration {iteration + 1} =======================\n\n");

                        thePermutationGA.RunOneIteration();

                        if (iteration != 0)
                        {
                            // print parent
                            rtbPopulation.AppendText($"【Parent】\n");
                            for (int i = 0; i < thePermutationGA.PopulationSize; i++)
                            {
                                rtbPopulation.AppendText($"Parent Chrom {i + 1 }: ");
                                for (int j = 0; j < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); j++)
                                {
                                    rtbPopulation.AppendText($"{thePermutationGA.Chromosome[i][j]} ");
                                }
                                rtbPopulation.AppendText($"\n");
                            }

                            rtbPopulation.AppendText($"\n\n");

                        }

                        // print children 
                        rtbPopulation.AppendText($"【Children】\n\n");
                        for (int i = 0; i < thePermutationGA.PopulationSize; i++)
                        {
                            rtbPopulation.AppendText($"Children Chrom {i + 1 }: ");
                            for (int j = 0; j < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); j++)
                            {
                                rtbPopulation.AppendText($"{thePermutationGA.Chromosome[i + thePermutationGA.PopulationSize][j]} ");
                            }
                            rtbPopulation.AppendText($"\n");
                        }

                        // print mutated children
                        rtbPopulation.AppendText($"\n\n【Mutated Children】\n\n");
                        for (int i = 0; i < thePermutationGA.PopulationSize; i++)
                        {
                            rtbPopulation.AppendText($"Mutated Chrom {i + 1 }: ");
                            for (int j = 0; j < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); j++)
                            {
                                rtbPopulation.AppendText($"{thePermutationGA.Chromosome[i + thePermutationGA.PopulationSize * 2][j]} ");
                            }
                            rtbPopulation.AppendText($"\n");
                        }


                        for (int i = 0; i < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); i++)
                        {
                            rtbBestSolution.AppendText(thePermutationGA.BestSolutionAnswer[i].ToString() + " ");
                        }
                        rtbBestSolution.AppendText("\n");
                        rtbBestObj.AppendText(thePermutationGA.BestSolutionValue.ToString() + "\n");

                        richTextBox_TextChanged();

                        chart1.Series[0].Points.AddXY(iteration, thePermutationGA.BestSolutionValue);

                        chart1.Series[1].Points.AddXY(iteration, thePermutationGA.IterationBest);

                    }
                    break;

            }

            // calculate taken time
            DateTime endTime = DateTime.Now;
            TimeSpan delta = endTime - startTime;
            lbTimeStamp.Text = $"start {startTime}, endtime {endTime}, delta {delta}";

            // isReset flag change
            isReset = false;
        }

        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            // check if reset
            if (isReset == false) MessageBox.Show("Press reset before running the algorithm!");
            rtbBestSolution.Clear();
            rtbPopulation.Clear();

            // initial time
            DateTime startTime = DateTime.Now;

            // start gene algorithm
            switch (cbGAType.SelectedIndex)
            {
                // binary GA
                case 0:
                    for (int i = 0; i < theBinaryGA.IterationLimit; i++)
                    {
                        theBinaryGA.RunOneIteration();
                        rtbBestSolution.Text = theBinaryGA.SoFarTheBestObjectiveValue.ToString();
                        rtbPopulation.AppendText(($"AAA = {theBinaryGA.SoFarTheBestObjectiveValue}\n"));
                    }
                    break;
                // permutation GA
                case 1:
                    thePermutationGA.RunOneIteration();

                    // print children 
                    rtbPopulation.AppendText($"【Children】\n");
                    for (int i = 0; i < thePermutationGA.PopulationSize; i++)
                    {
                        rtbPopulation.AppendText($"Children Chrom {i + 1 }: ");
                        for (int j = 0; j < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); j++)
                        {
                            rtbPopulation.AppendText($"{thePermutationGA.Chromosome[i + thePermutationGA.PopulationSize][j]} ");
                        }
                        rtbPopulation.AppendText($"\n");
                    }

                    // print mutated children
                    rtbPopulation.AppendText($"\n\n【Mutated Children】\n");
                    for (int i = 0; i < thePermutationGA.PopulationSize; i++)
                    {
                        rtbPopulation.AppendText($"Mutated Chrom {i + 1 }: ");
                        for (int j = 0; j < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); j++)
                        {
                            rtbPopulation.AppendText($"{thePermutationGA.Chromosome[i + thePermutationGA.PopulationSize * 2][j]} ");
                        }
                        rtbPopulation.AppendText($"\n");
                    }

                    rtbBestSolution.Clear();
                    for (int i = 0; i < (theProblem.NumberOfJobs * theProblem.NumberOfJobs); i++)
                    {
                        rtbBestSolution.AppendText(thePermutationGA.BestSolutionAnswer[i].ToString() + " ");
                    }

                    rtbBestObj.Clear();
                    rtbBestObj.Text = thePermutationGA.BestSolutionValue.ToString();
                    break;

            }


            // calculate taken time
            DateTime endTime = DateTime.Now;
            TimeSpan delta = endTime - startTime;
            lbTimeStamp.Text = $"start {startTime}, endtime {endTime}, delta {delta}";

            // isReset flag change
            isReset = false;
        }

        private void tbJobs_TextChanged(object sender, EventArgs e)
        {
            if (tbJobs.Text == "" || tbMinimum.Text == "" || tbMaximum.Text == "" || tbIteration.Text == "") return;

            try
            {
                double temp = Convert.ToInt32(tbJobs.Text);
                temp = Convert.ToDouble(tbMinimum.Text);
                temp = Convert.ToDouble(tbMaximum.Text);
                temp = Convert.ToInt32(tbIteration.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("You should not enter a value other than integer number!");
                tbJobs.Text = "5";
                tbMinimum.Text = "0";
                tbMaximum.Text = "5";
                tbIteration.Text = "100";
                return;
            }

            if (Convert.ToDouble(tbMaximum.Text) <= Convert.ToDouble(tbMinimum.Text))
            {
                tbMaximum.Text = (Convert.ToDouble(tbMinimum.Text) + 1).ToString();
            }

        }

        private void richTextBox_TextChanged()
        {
            // set the current caret position to the end
            rtbPopulation.SelectionStart = rtbPopulation.Text.Length;
            rtbBestSolution.SelectionStart = rtbBestSolution.Text.Length;
            rtbBestObj.SelectionStart = rtbBestObj.Text.Length;
            // scroll it automatically
            rtbPopulation.ScrollToCaret();
            rtbBestSolution.ScrollToCaret();
            rtbBestObj.ScrollToCaret();
        }

    }
}
