using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546036_SHChaoAss07
{
    class JobAssignmentProblem
    {
        int numberOfJobs;
        double[,] SetupTimes;
        string fileName;

        public void OpenFile(string path)
        {
            fileName = path;
            StreamReader sr = new StreamReader(fileName);
            string str;
            string[] items;
            str = sr.ReadLine();
            numberOfJobs = Convert.ToInt32(str);
            SetupTimes = new double[numberOfJobs, numberOfJobs];
            for (int r = 0; r < numberOfJobs; r++)
            {
                str = sr.ReadLine();
                items = str.Split(' ');

                for (int c = 0; c < numberOfJobs; c++)
                {
                    SetupTimes[r, c] = Convert.ToDouble(items[c]);

                }
            }



            sr.Close();
        }
    }
}
