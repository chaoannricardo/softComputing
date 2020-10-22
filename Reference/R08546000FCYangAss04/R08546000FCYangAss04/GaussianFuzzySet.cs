using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546000FCYangAss04
{
    class GaussianFuzzySet : FuzzySet 
    {
        // define properties
        public double Center
        {
            get
            {
                return parameters[0];
            }
            set
            {
                parameters[0] = value;
            }
        }
        public double STD
        {
            get
            {
                return parameters[1];
            }
            set
            {
                if( value >= 0 )
                    parameters[1] = value;
            }
        }
        public GaussianFuzzySet( Universe v ) : base( v )
        {
            parameters = new double[2];
            parameters[0] = 5;
            parameters[1] = 1;
        }
    }
}
