using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546036_SHChaoAss07
{
    public partial class Mainform : Form
    {
        JobAssignmentProblem theProblem;

        public Mainform()
        {
            InitializeComponent();
            theProblem = new JobAssignmentProblem();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            labMessage.Text = "";
            labMessage.Width = 500;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            theProblem.OpenFile(dlgOpen.FileName);

        }

        int[] assignments;
        bool[] flags;

        private void btnBrutalForceMethod_Click(object sender, EventArgs e)
        {
            assignments = new int[theProblem.NumberOfJobs];
            flags = new bool[theProblem.NumberOfJobs];
            for (int i = 0; i < flags.Length; i++)
            {
                flags[i] = false;
            }
            DateTime startTime = DateTime.Now;
            RecursiveMethod(0);
            DateTime endTime = DateTime.Now;
            TimeSpan delta = endTime - startTime;
            labMessage.Text = $"start {startTime}, endtime {endTime}, delta {delta}";
           
        }

        // recursive method
        void RecursiveMethod(int id)
        {
            for (int i = 0; i < flags.Length; i++)
            {
                if (flags[i] == true)
                {
                    continue;
                }
                flags[i] = true;
                assignments[id] = i;
                if (id == flags.Length - 1)
                {
                    // done for this assignment
                    string answer = "";
                    foreach (int job in assignments) {
                        answer += $"{job} ";
                    }
                    double objective = theProblem.GetTotalSetupTimeForAnAssignment(assignments);
                    richTextBox1.AppendText($"{answer} = {objective}\n");
                }
                else
                {
                    RecursiveMethod(id + 1);
                }
                flags[i] = false;
            }
        }

       
    }
}
