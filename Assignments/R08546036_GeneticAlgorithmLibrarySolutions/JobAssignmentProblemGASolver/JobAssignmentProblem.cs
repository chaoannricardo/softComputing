using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAssignmentProblemGASolver
{
    class JobAssignmentProblem
    {
        int numberOfJobs;
        double[,] SetupTimes;
        string fileName;

        public int NumberOfJobs { get => numberOfJobs; set => numberOfJobs = value; }

        public void OpenFile(string path)
        {
            fileName = path;
            StreamReader sr = new StreamReader(fileName);
            string str;
            string[] items;
            char[] sep = { ' ' };
            str = sr.ReadLine();
            numberOfJobs = Convert.ToInt32(str);
            SetupTimes = new double[numberOfJobs, numberOfJobs];
            for (int r = 0; r < numberOfJobs; r++)
            {
                str = sr.ReadLine();
                items = str.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                for (int c = 0; c < numberOfJobs; c++)
                {
                    SetupTimes[r, c] = Convert.ToDouble(items[c]);

                }
            }



            sr.Close();
        }


        // for brutal force method and permutation GA
        public double GetObjectiveValue(int[] ass)
        {
            double total = 0;
            
            for (int j = 0; j < numberOfJobs; j++) {
                total += SetupTimes[ass[j], j];
            
            }

            return total;

        }


        public double Penalty { set; get; } = 100;

        public double GetObjectiveValue(byte[] ass)
        {
            double total = 0;

            for (int j = 0; j < numberOfJobs; j++)
            {
                total += SetupTimes[ass[j], j];

            }

            return total;

        }
    }
}
