using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace R08546036_SHChaoAss02
{
    class SigmoidFunction
    {
        public static string[] parametersNames = new string[2] { "a_value", "c_value" };
        public string title;
        private double[] parameters;

        public SigmoidFunction(double aValue, double cValue)
        {
            parameters = new double[2];
            parameters[0] = aValue;
            parameters[1] = cValue;

            title = $"Sigmoidal Function a_value= {aValue}, c_value = {cValue}";

        }
        public double getFunctionValue(double x)
        {

            double v = 1 / (1 + Math.Exp((-parameters[0]) * (x - parameters[1])));
            double yValue = v;
            return yValue;
        }
    }
}

