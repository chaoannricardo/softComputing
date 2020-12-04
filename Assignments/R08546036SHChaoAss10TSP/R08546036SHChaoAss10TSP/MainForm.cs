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
using TSPBenchmark;

namespace R08546036SHChaoAss10TSP
{
    public partial class MainForm : Form
    {
        AntColonySystemForTSP theSolver;
        bool initiateFlag;
        int epochRunOneIteration;

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

        }

        private void Open_Click(object sender, EventArgs e)
        {
            // open
            int status = TSPBenchmarkProblem.ImportATSPFile(true, true);

            // refresh painting panel
            SPCThird.Panel2.Refresh();

            lbKnownShortestPath.Text = $"Known for the shortest length: {TSPBenchmarkProblem.GlobalShorestLength4TSP}";

        }

        // painting function to pain on panel 2
        private void splitContainer4_Panel2_Paint(object sender, PaintEventArgs e)
        {
            TSPBenchmarkProblem.DrawCitesAndARoute(e.Graphics, SPCThird.Panel2.Width,
               SPCThird.Panel2.Height, null);

            if (theSolver != null) TSPBenchmarkProblem.DrawCitiesOptimalRouteAndARoute(e.Graphics, SPCThird.Panel2.Width,
               SPCThird.Panel2.Height, theSolver.SoFarTheBestSolution);
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
            theSolver.Reset();

            // update label information
            lbSoFarShortestLength.Text = $"So Far Shortest Length: {theSolver.SoFarTheBestObjective}";

            // update variables
            epochRunOneIteration = 0;
        }


        // run one iteration function
        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            theSolver.RunOneIteration();

            SPCThird.Panel2.Refresh();

            // update label information & variables
            epochRunOneIteration++;
            lbSoFarShortestLength.Text = $"So Far Shortest Length: {theSolver.SoFarTheBestObjective}";
            lbIterationCount.Text = $"Epoch: {epochRunOneIteration}";
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < theSolver.IterationCount; i++)
            {
                theSolver.RunOneIteration();

                // update label informations.
                lbIterationCount.Text = $"Epoch: {theSolver.IterationCount}";
                lbSoFarShortestLength.Text = $"So Far Shortest Length: {theSolver.SoFarTheBestObjective}";
            }
        }
    }
}
