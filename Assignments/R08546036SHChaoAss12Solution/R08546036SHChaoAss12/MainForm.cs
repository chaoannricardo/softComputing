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

namespace R08546036SHChaoAss12
{
    public partial class MainForm : Form
    {
        #region variables
        double[,] dataContent;
        double[,] yContent;
        BbackPropagationMLP theSolver;
        #endregion


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // let application to go full screen
            WindowState = FormWindowState.Maximized;

            // element initialize
            nUpDownNeuronNumbers.Visible = false;
        }

        // open file function
        private void openFromFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // dgvRules ColumnAdded
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(dlgOpen.FileName);

            // create colver and read in file
            // create solver
            theSolver = new BbackPropagationMLP((int)nUpDownHiddenLayers.Value,
                (int)nUpDownNeuronNumbers.Value);

            theSolver.ReadInDataSet(sr, (float)0.8);

            gridSolver.SelectedObject = theSolver;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            theSolver.ResetWeightsAndInitialCondition();

        }

        // value change function of neuron numbers
        private void nUpDownNeuronNumbers_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nUpDownNeuronNumbers.Visible = true;
            nUpDownNeuronNumbers.Value = Convert.ToDecimal(listBox1.GetItemText(listBox1.SelectedItem));
        }


    }
}