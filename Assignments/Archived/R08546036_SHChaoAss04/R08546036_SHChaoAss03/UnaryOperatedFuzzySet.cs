using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace R08546036_SHChaoAss04
{
    class UnaryOperatedFuzzySet : FuzzySet
    {
        // Configurations
        static int count = 0;
        UnaryFSOperator theOperator;
        FuzzySet theFS;

        public UnaryOperatedFuzzySet(FuzzySet fs, UnaryFSOperator op) : base(fs.TheUniverse)
        {
            theFS = fs;
            theOperator = op;
            
            title = op.Title + fs.Title + $"{++count}";

            // subscribe event
            theFS.ParameterChanged += TheFSParameterChanged;

        }

        private void TheFSParameterChanged(object sender, EventArgs e)
        {
            if (ShowSeries) UpdateSeriesDataPoints();
            // fire event
            FireParameterChanged();
        }

        public override double GetMembershipDegree(double x)
        {
            double a = theFS.GetMembershipDegree(x);
            return theOperator.Evaluate(a);
        }
    }
}
