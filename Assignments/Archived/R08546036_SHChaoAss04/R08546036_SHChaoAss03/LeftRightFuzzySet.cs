using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546036_SHChaoAss04
{
    class LeftRightFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Parameters: Left, Peak, Right
        [Category("MembershipParameters")]
        public double ParameterA
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
        [Category("MembershipParameters")]
        public double ParameterB
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
        [Category("MembershipParameters")]
        public double ParameterC
        {
            set
            {
                if (value is double)
                {
                    parameters[2] = value;
                }
            }
            get
            {
                return parameters[2];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            if (x < parameters[2])
            {
                if (0 < (1 - Math.Pow(((parameters[2] - x) / parameters[0]), 2)))
                {
                    return (1 - Math.Pow(((parameters[2] - x) / parameters[0]), 2));
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return Math.Exp(-Math.Pow(Math.Abs((x - parameters[2]) / parameters[1]), 3));
            }
        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public override string Core => $"{theUniverse.Title}={parameters[0]}";

        public LeftRightFuzzySet(Universe u) : base(u)
        {
            parameters = new double[3];
            parameters[0] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
            parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble() + (0.5);
            parameters[2] = parameters[1] + 3;

            title = $"LeftRightFuzzySet {++count}";
        }

    }
}
