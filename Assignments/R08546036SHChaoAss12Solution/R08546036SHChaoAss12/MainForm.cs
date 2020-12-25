﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546036SHChaoAss12
{
    public partial class MainForm : Form
    {
        #region variables
        double[,] dataContent;
        double[,] yContent;
        int[] hiddenLayers;
        Series theSeriesObj;
        Series iterationBest;
        Series iterationAverage;
        BbackPropagationMLP theSolver;
        #endregion


        public MainForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            object[] pars = { ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true };

            MethodInfo setStyleMethodPanel = typeof(Panel).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
            setStyleMethodPanel.Invoke(splitContainer3.Panel2, pars);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // let application to go full screen
            WindowState = FormWindowState.Maximized;

            // element initialize
            nUpDownNeuronNumbers.Visible = false;
            nUpDownHiddenLayers.Value = 1;
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

        #region training & reset Function
        private void btnReset_Click(object sender, EventArgs e)
        {
            // return if the solver is null
            if (theSolver == null) return;

            // set up vars
            hiddenLayers = new int[lbNeurons.Items.Count];

            // initialize hidden layers number
            for (int i = 0; i < lbNeurons.Items.Count; i++)
            {
                hiddenLayers[i] = Convert.ToInt32(lbNeurons.Items[i].ToString());
            }

            // configure & reset
            theSolver.ConfigureNeuralNetwork(hiddenLayers);
            theSolver.ResetWeightsAndInitialCondition();

            // refresh property grid
            gridSolver.Refresh();


            // chart reset part
            chartSolution.Series.Clear();

            theSeriesObj = new Series("RMSE");
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

        private void TrainAnEpoch() {

            theSolver.TrainAnEpoch();

            // add numbers to chart
            chartSolution.Series[0].Points.AddXY(theSolver.IterationCount, theSolver.RootMeanSquareError);

            gridSolver.Refresh();
            chartSolution.Update();
        }


        private void btnTrainAnEpoch_Click(object sender, EventArgs e)
        {
            if (theSolver == null) return;
            
            TrainAnEpoch();
        }

        private void btnTrainToEnd_Click(object sender, EventArgs e)
        {
            if (theSolver == null) return;

            for (int i = theSolver.IterationCount; i < theSolver.TrainingLimit; i++)
            {
                TrainAnEpoch();
            }

        }
        #endregion


        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {
            if (theSolver != null) theSolver.DrawMLP(e.Graphics, e.ClipRectangle);
        }

        private void pDocNN_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            theSolver.DrawMLP(e.Graphics, e.PageBounds);
        }

        private void dlgPreview_Click(object sender, EventArgs e)
        {

        }

        private void printNNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgPreview.ShowDialog() == DialogResult.OK)
            {
                pDocNN.Print();
            }
        }

        // value change function of neuron numbers
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nUpDownNeuronNumbers.Visible = true;
                nUpDownNeuronNumbers.Value = Convert.ToDecimal(lbNeurons.GetItemText(lbNeurons.SelectedItem));
            }
            catch (System.FormatException Exception)
            {
                return;
            }
        }

        private void nUpDownNeuronNumbers_ValueChanged(object sender, EventArgs e)
        {
            lbNeurons.Items[lbNeurons.SelectedIndex] = nUpDownNeuronNumbers.Value;
        }

        private void nUpDownHiddenLayers_ValueChanged(object sender, EventArgs e)
        {
            lbNeurons.Items.Clear();
            for (int i = 0; i < Convert.ToInt32(nUpDownHiddenLayers.Value); i++)
            {
                lbNeurons.Items.Add("4");
            }

        }

        #region Demo Graph Function
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = button1.CreateGraphics();
            Draw(g, button1.ClientRectangle);
            Draw(splitContainer3.Panel2.CreateGraphics(), splitContainer3.Panel2.ClientRectangle);

        }

        void Draw(Graphics g, Rectangle bound)
        {
            Rectangle rect = Rectangle.Empty;
            rect.X = 10;
            rect.Y = 5;
            rect.Width = 100;
            rect.Height = 50;
            g.FillEllipse(Brushes.Gold, rect);
            g.DrawEllipse(Pens.Red, rect);
            Pen myPen = new Pen(Color.Blue, 3);
            Point p1 = new Point(0, 0);
            Point p2 = new Point(button1.Width, button1.Height);
            g.DrawLine(myPen, p1, p2);
            g.DrawString("NTU IIE", this.Font, Brushes.Green, new PointF(0.0f, 0.0f));
            Font myFont = new Font("Arial", 36.0f);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString("National Taiwan University", myFont, Brushes.Magenta, button1.ClientRectangle, sf);

        }
        #endregion

    }
}