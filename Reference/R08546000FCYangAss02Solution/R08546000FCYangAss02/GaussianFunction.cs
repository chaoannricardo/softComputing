using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546000FCYangAss02
{
    class GaussianFunction
    {
        // data fields
        double[] parameters;
        public static string[] parameterNames;

        // constructors
        static GaussianFunction()
        {
            parameterNames = new string[2];
            parameterNames[0] = "Center";
            parameterNames[1] = "Standard Deviation";
        }

        public GaussianFunction( double center, double std)
        {
            parameters = new double[2];
            parameters[0] = center;
            parameters[1] = std;
        }

        // functions 
        public double GetFunctionValue(double x)
        {
           return Math.Exp(-0.5 * (x - parameters[0]) * (x - parameters[0]) / 
               (parameters[1] * parameters[1]));
        }
    }
}
