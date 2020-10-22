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
        #region variables
        static int count = 0;
        UnaryFSOperator theOperator;
        FuzzySet theFS;
        #endregion

        // properties
        public double ScaleValue
        {
            get { return theOperator.ScaleValue; }
            set
            {
                if (value is double && 1.0 >= value && value >= 0.0) {
                    theOperator.ScaleValue = value;
                }
            }
        }
        public double CutValue
        {
            get { return theOperator.CutValue; }
            set
            {
                if (value is double && 1.0 >= value && value >= 0.0)
                {
                    theOperator.CutValue = value;
                }
            }
        }

        public UnaryOperatedFuzzySet(FuzzySet fs, UnaryFSOperator op) : base(fs.TheUniverse)
        {
            theFS = fs;
            theOperator = op;

            title = op.Title + "-" + fs.Title + $"{++count}";

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
