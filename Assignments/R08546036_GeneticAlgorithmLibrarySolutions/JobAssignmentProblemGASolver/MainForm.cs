using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneticAlgorithmLibrary;

namespace JobAssignmentProblemGASolver
{
    public partial class MainForm : Form
    {
        JobAssignmentProblem theProblem;
        PermutationGASolver thePermutationGA;
        BinaryGASolver theBinaryGA;
        
        public MainForm()
        {
            InitializeComponent();

            theProblem = new JobAssignmentProblem();

            double[] fit = { 3, 4, 1, 2, 7, 8, 4.5, 1.2, 4.3, 2.2 };
            int[] id = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            Array.Sort(fit);
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txbPenalty.Text = theProblem.Penalty.ToString();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            
            if (dlg.ShowDialog() != DialogResult.OK) return;

            theProblem.OpenFile(dlg.FileName);

            thePermutationGA = new PermutationGASolver(theProblem.NumberOfJobs, 
                OptimizationType.Minimization,
                theProblem.GetObjectiveValue);
        }

        private void btnCreateGASolver_Click(object sender, EventArgs e)
        {
            thePermutationGA = new PermutationGASolver(theProblem.NumberOfJobs,
                OptimizationType.Minimization,
                theProblem.GetObjectiveValue);

            theBinaryGA = new BinaryGASolver(theProblem.NumberOfJobs * theProblem.NumberOfJobs,
                OptimizationType.Maximization,
                theProblem.GetObjectiveValue);
            gridGA.SelectedObject = thePermutationGA;
        }

        private void txbPenalty_TextChanged(object sender, EventArgs e)
        {
            theProblem.Penalty = Convert.ToDouble(txbPenalty.Text);
        }
    }
}
