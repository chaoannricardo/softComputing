using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546036_SHChaoAss02
{
    class TriangularFunction
    {
        private double[] parameters;
        public string title;

        public static string[] parametersNames = new string[3] { "left", "peak", "right" };

        public TriangularFunction(double left, double peak, double right)
        {
            parameters = new double[3];
            parameters[0] = left;
            parameters[1] = peak;
            parameters[2] = right;

            // create title of plot
            title = $"Triangular Function left {left}, peak {peak}, right {right}";

        }

        public double getFunctionValue(double x)
        {
            // initialize y value
            double yValue = 0;

            if (x <= parameters[0])
            {
                yValue = 0;
            }
            else if (x <= parameters[1])
            {
                yValue = (x - parameters[0]) / (parameters[1] - parameters[0]);
            }
            else if (x <= parameters[2])
            {
                yValue = (parameters[2] - x) / (parameters[2] - parameters[1]);
            }
            else
            {
                yValue = 0;
            }
            return yValue;

        }

    }
}
