using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546000FCYangAss01
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gold;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for( double x = -7.0; x <= 7.0; x += 0.1 )
            {
                double y = Math.Sin(x);
                chart1.Series[0].Points.AddXY(x, y);
            }
        }

        private void btnUpdateG_Click(object sender, EventArgs e)
        {
            double a = 0, b = 0 , c =0; // a < b < c
            double center;
            double standardDeviation;
            // get c and sig from UI
            center = Convert.ToDouble( txbGC.Text );
            standardDeviation = Convert.ToDouble(txbGSig.Text);

            chart1.Series[1].Points.Clear();
            if (true )
            {
                MessageBox.Show("parameter error! ....", "yyyy", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            for( double x = 0.0; x <= 10.0; x = x +0.1 )
            {
                double y;
                //if( x < a)
                //{
                //    y = xxx;
                //}
                //else
                //{
                //    if( x < b )
                //    {
                //        y = xxx;
                //    }
                //    else
                //    {
                //        if( x < c )
                //        {
                //            y = xxx;
                //        }
                //        else
                //        {
                //            y = xxxx;
                //        }
                //    }
                //}
                y = Math.Exp( (- 0.5 * ( x-center ) * (x-center)) / ( standardDeviation * standardDeviation  )   );
                chart1.Series[1].Points.AddXY(x, y);
            }
        }
    }
}
