using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546036_SHChaoAss03
{
    class SigmoidFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Attributes
        [Category("MemberFunctionParameters"), Description(""),
            DisplayName("Information")]

        // Parameters
        public double A_Value
        {
            set
            {
                if (value is double)
                {
                    parameters[0] = value;
                }
            }
            get
            {
                return parameters[0];
            }

        }
        public double B_Value
        {
            set
            {
                if (value is double)
                {
                    parameters[1] = value;
                }
            }
            get
            {
                return parameters[1];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            return 1 / (1 + Math.Exp((-parameters[0]) * (x - parameters[1])));
        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public override string Core => $"{theUniverse.Title}={parameters[0]}";


        public SigmoidFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum);
            parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble();

            title = $"Sigmoidal Fuzzy Set {++count}";
        }
    }
}
