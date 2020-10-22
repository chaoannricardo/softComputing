using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546036_SHChaoAss04
{
    class GaussianFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Attributes
        [Category("MembershipParameters"), Description("The location of the symmetric point"), 
            DisplayName("Information")]

        public double Center
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
                FireParameterChanged();
            }

        }
        [Category("MembershipParameters")]

        public double Std
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
            return Math.Exp(-0.5 * (x - parameters[0]) * (x - parameters[0]) / parameters[1] / parameters[1]);
        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public override string Core => $"x={parameters[0]}";
        public override string Support => $"(x={theUniverse.Minimum})~(x={theUniverse.Maximum})";


        public GaussianFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum);

            while (true) {
                parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble() / 10.0;

                if (Math.Abs(parameters[1]) > 1) {
                    break;
                }

            }

            title = $"Gaussian Fuzzy Set {++count}";
        }

    }
}
