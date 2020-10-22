using System;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546036_SHChaoAss02
{
    public partial class Ass02Form : Form
    {

        // random number object
        Random myRnd = new Random();


        public Ass02Form()
        {
            InitializeComponent();

            // Set default selection of selection box
            lsbSelection.SelectedIndex = 0;
        }


        private void lsbSelection_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int idx = lsbSelection.SelectedIndex;

            // Label: x Limit
            labPar0.Visible = true;
            labPar4.Visible = true;
            nudPar0.Visible = true;
            nudPar4.Visible = true;
            labPar0.Text = "x Limit Value";
            nudPar0.Value = (decimal)10.0;
            labPar4.Text = "x Start Value";
            nudPar4.Value = (decimal)-10.0;

            switch (idx)
            {
                case 0:
                    // Triangular Function
                    // visibility
                    labPar1.Visible = true;
                    labPar2.Visible = true;
                    labPar3.Visible = true;

                    nudPar1.Visible = true;
                    nudPar2.Visible = true;
                    nudPar3.Visible = true;

                    // Text
                    // Access params name from Triangular Function parametersNames array
                    labPar1.Text = TriangularFunction.parametersNames[0];
                    labPar2.Text = TriangularFunction.parametersNames[1];
                    labPar3.Text = TriangularFunction.parametersNames[2];

                    // assign random value to nudPars
                    nudPar1.Value = decimal.Round((decimal)(myRnd.NextDouble() * 3.0), 2, MidpointRounding.AwayFromZero);
                    nudPar2.Value = decimal.Round((decimal)(myRnd.NextDouble() * 4.0), 2, MidpointRounding.AwayFromZero);
                    nudPar3.Value = decimal.Round((decimal)(myRnd.NextDouble() * 5.0), 2, MidpointRounding.AwayFromZero);

                    // add pic inside picture box
                    pictureboxAddPic(idx);

                    break;
                case 1: // Bell Function
                    // visibility
                    labPar1.Visible = true;
                    labPar2.Visible = true;
                    labPar3.Visible = true;

                    nudPar1.Visible = true;
                    nudPar2.Visible = true;
                    nudPar3.Visible = true;

                    // Text 
                    labPar1.Text = BellFunction.parametersNames[0];
                    labPar2.Text = BellFunction.parametersNames[1];
                    labPar3.Text = BellFunction.parametersNames[2];

                    // assign random value to nudPars
                    nudPar1.Value = myRnd.Next(-5, 6);
                    nudPar2.Value = myRnd.Next(-5, 6);
                    nudPar3.Value = myRnd.Next(-5, 6);

                    // add pic inside picture box
                    pictureboxAddPic(idx);


                    break;
                case 2: // Gaussian Function

                    // visibility
                    labPar1.Visible = true;
                    labPar2.Visible = true;
                    labPar3.Visible = false;

                    nudPar1.Visible = true;
                    nudPar2.Visible = true;
                    nudPar3.Visible = false;

                    // Text
                    // Access params name from Gaussian Function parametersNames array
                    //labPar1.Text = "Center";
                    //labPar2.Text = "Standard Deviation";
                    labPar1.Text = GaussianFunction.parametersNames[0];
                    labPar2.Text = GaussianFunction.parametersNames[1];

                    // assign random value to nudPars
                    nudPar1.Value = myRnd.Next(-5, 6);
                    nudPar2.Value = myRnd.Next(1, 6);

                    // add pic inside picture box
                    pictureboxAddPic(idx);

                    break;
                case 3: // Sigmoid Function

                    // visibility
                    labPar1.Visible = true;
                    labPar2.Visible = true;
                    labPar3.Visible = false;

                    nudPar1.Visible = true;
                    nudPar2.Visible = true;
                    nudPar3.Visible = false;

                    // Text
                    labPar1.Text = SigmoidFunction.parametersNames[0];
                    labPar2.Text = SigmoidFunction.parametersNames[1];

                    // assign random value to nudPars
                    nudPar1.Value = myRnd.Next(-5, 6);
                    nudPar2.Value = myRnd.Next(-5, 6);

                    // add pic inside picture box
                    pictureboxAddPic(idx);

                    break;

            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            double left, peak, right, a_value, b_value, c_value;
            double xLimitValue = (double)(nudPar0.Value);
            double xStartValue = (double)(nudPar4.Value);

            switch (lsbSelection.SelectedIndex)
            {
                case 0:
                    // Triangular Function
                    left = (double)(nudPar1.Value);
                    peak = (double)(nudPar2.Value);
                    right = (double)(nudPar3.Value);

                    TriangularFunction myTriangular = new TriangularFunction(left: left, peak: peak, right: right);
                    Series chartSeriesTriangular = new Series(Name = myTriangular.title);

                    // config theChart Series
                    chartSeriesTriangular.ChartType = SeriesChartType.Line;
                    chartSeriesTriangular.BorderWidth = 3;

                    for (double x = xStartValue; x <= xLimitValue; x += 0.1)
                    {
                        double y = myTriangular.getFunctionValue(x);
                        chartSeriesTriangular.Points.AddXY(x, y);
                    }

                    // show graph function
                    addGraphSeries(chartSeriesTriangular);
                    break;
                case 1:
                    // Bell Function
                    a_value = (double)nudPar1.Value;
                    b_value = (double)nudPar2.Value;
                    c_value = (double)nudPar3.Value;

                    BellFunction myBell = new BellFunction(a_value, b_value, c_value);
                    Series chartSeriesBell = new Series(Name = myBell.title);

                    // Config chart type of theChart Series
                    chartSeriesBell.ChartType = SeriesChartType.Line;
                    chartSeriesBell.BorderWidth = 3;

                    for (double x = xStartValue; x <= xLimitValue; x += 0.1)
                    {
                        double y = myBell.getFunctionValue(x);
                        chartSeriesBell.Points.AddXY(x, y);
                    }

                    // show graph function
                    addGraphSeries(chartSeriesBell);

                    break;
                case 2:
                    // Gaussian Function
                    // define variables
                    double center = (double)(nudPar1.Value);
                    double std = (double)(nudPar2.Value);

                    GaussianFunction myGaussian = new GaussianFunction(center, std);
                    Series chartSeriesGaussian = new Series(Name = myGaussian.title);

                    // Config chart type of theChart Series
                    chartSeriesGaussian.ChartType = SeriesChartType.Line;
                    // Config border width of theChart
                    chartSeriesGaussian.BorderWidth = 3;

                    for (double x = xStartValue; x <= xLimitValue; x += 0.1)
                    {
                        double y = myGaussian.GetFunctionValue(x);
                        chartSeriesGaussian.Points.AddXY(x, y);
                    }

                    // show graph function
                    addGraphSeries(chartSeriesGaussian);

                    break;
                case 3:
                    a_value = (double)nudPar1.Value;
                    c_value = (double)nudPar2.Value;
                    SigmoidFunction mySigmoid = new SigmoidFunction(a_value, c_value);
                    Series chartSeriesSigmoid = new Series(Name = mySigmoid.title);
                    // chart appearance config
                    chartSeriesSigmoid.ChartType = SeriesChartType.Line;
                    chartSeriesSigmoid.BorderWidth = 3;


                    for (double x = xStartValue; x <= xLimitValue; x += 0.1)
                    {
                        double y = mySigmoid.getFunctionValue(x);
                        chartSeriesSigmoid.Points.AddXY(x, y);

                    }

                    // show graph function
                    addGraphSeries(chartSeriesSigmoid);
                    break;
            }

        }


        private void btnClearGraph_Click(object sender, EventArgs e)
        {

            int index = 0;
            while (true)
            {
                // try to clear the graph panel, break when there's no more graph to clear.
                try
                {
                    theChart.Series[index].Points.Clear();
                    theChart.Series[index].IsVisibleInLegend = false;
                    index++;
                }
                catch (System.ArgumentOutOfRangeException exception)
                {
                    break;
                }

            }
        }

        private void addGraphSeries(Series graphSeries)
        {
            try
            {
                theChart.Series.Add(graphSeries);
            }
            catch (System.ArgumentException exception)
            {
                MessageBox.Show("The chart already existed, skipped.");
            }
        }

        private void pictureboxAddPic(int index)
        {
            // show pictures inside picture box

            string imageFilePath = "";

            switch (index)
            {
                case 0:
                    imageFilePath = "../../../pictures/TriangleFunction.PNG";
                    break;
                case 1:
                    imageFilePath = "../../../pictures/BellFunction.PNG";
                    break;
                case 2:
                    imageFilePath = "../../../pictures/GaussianFunction.PNG";
                    break;
                case 3:
                    imageFilePath = "../../../pictures/SigmoidFunction.PNG";
                    break;
            }

            picBoxFunc.Image = Image.FromFile(imageFilePath);
            picBoxFunc.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void Ass02Form_Load(object sender, EventArgs e)
        {

        }
    }
}
