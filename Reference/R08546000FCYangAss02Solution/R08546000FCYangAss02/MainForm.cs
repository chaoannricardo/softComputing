using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546000FCYangAss02
{
    public partial class MainForm : Form
    {
        GaussianFunction gObj;
        public MainForm()
        {
            InitializeComponent();

            // initialize custome controls
            label1.Text = GaussianFunction.parameterNames[0];
            label2.Text = GaussianFunction.parameterNames[1];
        }

        private void btnUpdateGFunction_Click(object sender, EventArgs e)
        {
            double c = Convert.ToDouble(textBox1.Text);
            double sig = Convert.ToDouble(textBox2.Text);
            gObj = new GaussianFunction(c, sig);

            theChart.Series[0].Points.Clear();
            for( double x = 0.0; x <= 10.0; x = x + 0.1 )
            {
                double y;
                y = gObj.GetFunctionValue(x);
                theChart.Series[0].Points.AddXY(x, y);
            }
        }






    }
}
