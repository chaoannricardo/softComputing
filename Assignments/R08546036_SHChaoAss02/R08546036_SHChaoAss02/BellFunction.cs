using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546036_SHChaoAss02
{
    class BellFunction
    {

        private double[] parameters;
        public string title;
        public static string[] parametersNames = new string[3] {"a_value", "b_value", "c_value" };


        public BellFunction(double a_value, double b_value, double c_value) {
            parameters = new double[3];
            parameters[0] = a_value;
            parameters[1] = b_value;
            parameters[2] = c_value;

            title = $"Bell Function a_value {a_value}, b_value {b_value}, c_value {c_value}";
        }

        public double getFunctionValue(double x) {
            double yValue = 1 / (1 + Math.Pow(Math.Abs((x - parameters[2]) / parameters[0]), (2 * parameters[1])));
            return yValue;

        }

    }
}
