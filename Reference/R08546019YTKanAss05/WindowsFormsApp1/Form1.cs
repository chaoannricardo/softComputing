using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            surface1.Clear();

            for( int x = 0; x < surface1.NumXValues; x++ )
                for( int z = 0; z < surface1.NumZValues; z++)
                {
                    double xx, zz, yy;
                    xx = -5.0 + x * 0.1;
                    zz = -5.0 + z * 0.1;
                    yy = Math.Sin(xx) + Math.Cos(zz);
                    surface1.Add(xx, yy, zz);
                }
        }
    }
}
