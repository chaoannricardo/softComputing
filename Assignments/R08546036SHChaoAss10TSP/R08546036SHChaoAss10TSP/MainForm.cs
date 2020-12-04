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

            // refresh form
            label1.Text = "";

            //MessageBox.Show(Directory.GetCurrentDirectory());
        }

        private void Open_Click(object sender, EventArgs e)
        {
            // open
            int status = TSPBenchmarkProblem.ImportATSPFile(true, true);

            // refresh painting panel
            SPCThird.Panel2.Refresh();

            label1.Text = $"Known for the shortest length {TSPBenchmarkProblem.GlobalShorestLength4TSP}";

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

            }
            catch (System.IndexOutOfRangeException Exception)
            {
                MessageBox.Show("You should first read in the problem set.");
            }

        }

        // reset function
        private void btnReset_Click(object sender, EventArgs e)
        {
            theSolver.Reset();
        }


        // run one iteration function
        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            theSolver.RunOneIteration();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            
        }
    }
}
