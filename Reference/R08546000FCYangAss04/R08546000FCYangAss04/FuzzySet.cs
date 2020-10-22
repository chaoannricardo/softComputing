using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546000FCYangAss04
{
    class FuzzySet
    {
        // static data
        static int counter = 1;
        // data 
        protected double[] parameters;
        protected Universe theUniverse;
        protected string title;

        public FuzzySet( Universe u )
        {
            theUniverse = u;
            title = $"Fuzzy Set {counter++}";
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public double GetMembershipDegree( double x )
        {
            return 0;
        }
    }
}
