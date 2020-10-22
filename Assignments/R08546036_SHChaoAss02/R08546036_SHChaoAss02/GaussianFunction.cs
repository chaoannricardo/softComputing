using System;
using System.Collections.Generic;
using System.Text;

namespace R08546036_SHChaoAss02
{
    internal class GaussianFunction
    {
        // by default the variable is private [0]: center, [1]: standard deviation
        private double[] parameters;
        public string title;

        public static string[] parametersNames = new string[2] { "Center", "Standard Deviation" };


        public GaussianFunction(double center, double std)
        {
            parameters = new double[2];
            parameters[0] = center;
            parameters[1] = std;

            title = $"Gaussian (center: {parameters[0]}, std: {parameters[1]}";
        }

        public double GetFunctionValue(double x)
        {
            double value = Math.Exp(-(x - parameters[0]) * (x - parameters[0]) * 0.5 / parameters[1]);
            return value;
        }

    }
}
