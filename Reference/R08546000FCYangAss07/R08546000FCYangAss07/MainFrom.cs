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

namespace R08546000FCYangAss07
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        int NumberOfJobs;
        double[,] SetupTimes;
        int[] solution;
        bool[] jobsAssigned;

        int[] bestSolution;
        double minimalObjective;

        private void OpenABenchmark(object sender, EventArgs e)
        {
            if( dlgOpen.ShowDialog() == DialogResult.OK  )
            {
                char[] seps = new char[3] { ' ', ',', '\t' };

                StreamReader sr = new StreamReader(dlgOpen.FileName);
                string str =  sr.ReadLine();
                NumberOfJobs =  Convert.ToInt32(str);
                SetupTimes = new double[NumberOfJobs, NumberOfJobs];
                for (int i = 0; i < NumberOfJobs; i++)
                {
                    str = sr.ReadLine();
                    string[] items = str.Split(seps, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < NumberOfJobs; j++)
                        SetupTimes[i,j] = Convert.ToDouble(items[j]);
                }
                sr.Close();

                solution = new int[NumberOfJobs];
                jobsAssigned = new bool[NumberOfJobs];
            }
        }

        int cnt = 0;
        private void btnFindAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            DateTime startTime = DateTime.Now;
            cnt = 1;
            listBox1.Items.Clear();

            for (int i = 0; i < NumberOfJobs; i++) jobsAssigned[i] = false;
            RecursiveConstruct( 0 );


            Cursor = Cursors.Default;
            DateTime endTime = DateTime.Now;
            TimeSpan delt = endTime - startTime;
            labStatus.Text = $"Start at {startTime}  End at {endTime}  Time Spent {delt}";

        }

        private void RecursiveConstruct(int pos)
        {
            // loop through all jobs try assign a non-assigned job to machine pos
            for( int jid = 0; jid < NumberOfJobs; jid++ )
            {
                if (jobsAssigned[jid]) continue;
                // set job jid to machine pos
                solution[pos] = jid;
                jobsAssigned[jid] = true;
                if (pos < NumberOfJobs - 1)
                    RecursiveConstruct(pos + 1); // 下一棒
                else
                {
                    // A solution is constructed, report 
                    listBox1.Items.Add($"{cnt++.ToString("0000000")} solution = {GetSolution()} obj = {GetObjective()}");
                }
                jobsAssigned[jid] = false;
            }

        }

        string GetSolution()
        {
            string s = "";
            for (int i = 0; i < NumberOfJobs; i++)
                s += $"{solution[i]} ";
            return s;
        }
        double GetObjective()
        {
            double obj = 0;
            for (int i = 0; i < NumberOfJobs; i++)
                obj += SetupTimes[solution[i], i];

            // check whether the obj can replace the minimal object
            return obj;
        }
    }
}
