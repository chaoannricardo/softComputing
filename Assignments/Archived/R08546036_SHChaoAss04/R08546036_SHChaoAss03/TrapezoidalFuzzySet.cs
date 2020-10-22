using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546036_SHChaoAss04
{
    class TrapezoidalFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Parameters: Left, Peak, Right
        [Category("MembershipParameters")]
        public double Left
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
        public double Peak_A
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
        public double Peak_B
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
        [Category("MembershipParameters")]
        public double Right
        {
            set
            {
                if (value is double)
                {
                    parameters[3] = value;
                }
            }
            get
            {
                return parameters[3];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            if (x < parameters[0])
            {
                return 0;
            }
            else if (x < parameters[1])
            {
                return (x - parameters[0]) / (parameters[1] - parameters[0]);
            }
            else if (x < parameters[2])
            {
                return 1;
            }
            else if (x < parameters[3])
            {
                return (parameters[3] - x) / (parameters[3] - parameters[2]);
            }
            else
            {
                return 0;
            }

        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public override string Core => $"{theUniverse.Title}={parameters[0]}";

        public TrapezoidalFuzzySet(Universe u) : base(u)
        {
            parameters = new double[4];
            ;

            while (true)
            {
                parameters[0] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
                parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
                parameters[2] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
                parameters[3] = (u.Maximum - u.Minimum) * randomizer.NextDouble();

                if (parameters[3] > parameters[2] &&
                parameters[2] > (parameters[1] + 2) && parameters[1] > parameters[0])
                {
                    break;
                }

            }

            title = $"TrapezoidalFuzzySet {++count}";
        }
    }
}
