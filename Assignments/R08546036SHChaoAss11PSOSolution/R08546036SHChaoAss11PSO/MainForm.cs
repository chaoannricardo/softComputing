using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COP;

namespace R08546036SHChaoAss11PSO
{
    public partial class MainForm : Form
    {
        ParticalSwarmOptimizationSolver theSolver;
        // you could also include your ga solver
        COPBenchmark theProblem;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // let application to go full screen
            WindowState = FormWindowState.Maximized;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            theProblem = COPBenchmark.LoadAProblemFromAFile();

            if (theProblem == null) return;

            theProblem.DisplayOnPanel(spcMain.Panel1);
            theProblem.DisplayObjectiveGraphics(spcSecond.Panel2);

            if (theSolver != null)theProblem.DisplaySolutionsOnGraphics(theSolver.Solutions);
        }

        private void btnNewProb_Click(object sender, EventArgs e)
        {
            COPBenchmark newProblem =  COPBenchmark.CreateANewProblemAndShowEditor();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OptimizationType type = theProblem.OptimizationGoal == COP.OptimizationType.Minimization ?
                OptimizationType.Minimization : OptimizationType.Maximization;

            theSolver = new ParticalSwarmOptimizationSolver(theProblem.Dimension, type,
                theProblem.LowerBound, theProblem.UpperBound, theProblem.GetObjectiveValue);

            gridTheSolver.SelectedObject = theSolver;



        }
    }
}
