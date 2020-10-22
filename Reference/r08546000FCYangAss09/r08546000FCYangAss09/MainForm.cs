using MyGALibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace r08546000FCYangAss09
{
    public partial class MainForm : Form
    {
        double[,] setupTimes;
        int numberOfJobs = 8;
        BinaryGA binSolver;
        PermutationGA permuSolver;


        double GetBinaryGAObjectiveValue( byte[] aSolution )
        {
            // calculate violation amount
            // get penalty value

            return 0.0;
        }
        double GetPermutationGAObjectiveValue( int[] aSolution )
        {
            return 0.0;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            binSolver = new BinaryGA(numberOfJobs * numberOfJobs, OptimizationType.minimization, GetBinaryGAObjectiveValue);
            propertyGrid1.SelectedObject = binSolver;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            permuSolver = new PermutationGA(numberOfJobs * numberOfJobs, OptimizationType.minimization, GetPermutationGAObjectiveValue);
            propertyGrid1.SelectedObject = permuSolver;
        }
   
    }
}
