using System;
using System.Drawing.Text;
using System.Windows.Forms;

namespace R08546036_SHChaoAss01
{
    public partial class Ass01 : Form
    {
        public Ass01()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tFunction(object sender, EventArgs e)
        {
            // clear the chart
            theChart.Series[0].Points.Clear();
            theChart.Series[1].Points.Clear();
            theChart.Series[2].Points.Clear();

            double aValue = Convert.ToDouble(aTFunction.Text);
            double bValue = Convert.ToDouble(bTFunction.Text);
            double cValue = Convert.ToDouble(cTFunction.Text);
            double xLimitValue = Convert.ToDouble(xLimitTFunction.Text);
            double yValue;

            for (double x = 0.0; x <= xLimitValue; x += 0.1)
            {
                // chart 1: t function
                if (x <= aValue)
                {
                    yValue = 0;
                }
                else if (x <= bValue)
                {
                    yValue = (x - aValue) / (bValue - aValue);
                }
                else if (x <= cValue)
                {
                    yValue = (cValue - x) / (cValue - bValue);
                }
                else
                {
                    yValue = 0;
                }
                theChart.Series[0].Points.AddXY(x, yValue);

            }

            //MessageBox.Show("The program has been executed successfully!!!!!");

        }

        private void gFunction(object sender, EventArgs e)
        {
            // clear the chart
            theChart.Series[0].Points.Clear();
            theChart.Series[1].Points.Clear();
            theChart.Series[2].Points.Clear();

            double cValue = Convert.ToDouble(cGFunction.Text);
            double sigmaValue = Convert.ToDouble(SigmaGFunction.Text);
            double xLimitValue = Convert.ToDouble(xLimitGFunction.Text);
            double yValue;


            for (double x = 0.0; x <= xLimitValue; x += 0.1)
            {
                // chart 2: g function
                yValue = Math.Exp(-((x - cValue) * (x - cValue)) / (2 * sigmaValue * sigmaValue));
                theChart.Series[1].Points.AddXY(x, yValue);

            }

            //MessageBox.Show("The program has been executed successfully!!!!!");
        }

        private void bFunction(object sender, EventArgs e)
        {
            // clear the chart
            theChart.Series[0].Points.Clear();
            theChart.Series[1].Points.Clear();
            theChart.Series[2].Points.Clear();

            double aValue = Convert.ToDouble(aBFunction.Text);
            double bValue = Convert.ToDouble(bBFunction.Text);
            double cValue = Convert.ToDouble(cBFunction.Text);
            double xLimitValue = Convert.ToDouble(xLimitBFunction.Text);
            double yValue;

            for (double x = 0.0; x <= xLimitValue; x += 0.1)
            {

                // chart 3: b function
                yValue = 1 / (1 + Math.Pow(Math.Abs((x - cValue) / aValue), (2 * bValue)));
                theChart.Series[2].Points.AddXY(x, yValue);

            }

            //MessageBox.Show("The program has been executed successfully!!!!!");
        }
    }
}
