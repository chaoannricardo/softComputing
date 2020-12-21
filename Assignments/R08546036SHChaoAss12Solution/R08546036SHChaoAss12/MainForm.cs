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
            if (theSolver == null) return;

        }

        private void btnReconfigure_Click(object sender, EventArgs e)
        {
            theSolver.ConfigureNeuralNetwork(new int[] { 3, 4 });
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
            if (dlgPreview.ShowDialog() == DialogResult.OK) {
                pDocNN.Print();
            }
        }
    }
}