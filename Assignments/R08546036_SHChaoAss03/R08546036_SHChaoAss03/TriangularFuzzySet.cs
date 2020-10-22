using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546036_SHChaoAss03
{
    class TriangularFuzzySet : FuzzySet
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
        public double Peak
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
        public double Right
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
            double yValue;
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

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public override string Core => $"{theUniverse.Title}={parameters[0]}";

        public TriangularFuzzySet(Universe u) : base(u)
        {
            parameters = new double[3];
            while (true) {
                parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum);
                parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
                parameters[2] = (u.Maximum - u.Minimum) * randomizer.NextDouble();

                if (parameters[2] > parameters[1] && parameters[1] > parameters[0]) {
                    break;
                }

            }

            title = $"Triangular Fuzzy Set {++count}";
        }
        
    }
}
