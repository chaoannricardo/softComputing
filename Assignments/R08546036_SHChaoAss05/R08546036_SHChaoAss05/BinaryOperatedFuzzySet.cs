using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546036_SHChaoAss04
{
    class BinaryOperatedFuzzySet : FuzzySet
    {
        // configuration
        #region variables
        static int count = 0;
        BinaryFSOperator theOperator;
        FuzzySet theFS1;
        FuzzySet theFS2;
        #endregion

        public BinaryOperatedFuzzySet(FuzzySet fs1, FuzzySet fs2, BinaryFSOperator op): base(fs1.TheUniverse)
        {
            theFS1 = fs1;
            theFS2 = fs2;
            theOperator = op;
            title = op.Title + fs1.Title + "-" + fs2.Title;

            // Subscribe event
            theFS1.ParameterChanged += TheFSParameterChanged;
            theFS2.ParameterChanged += TheFSParameterChanged;

        }

        // Parameter Change Event
        private void TheFSParameterChanged(object sender, EventArgs e)
        {
            if (ShowSeries) UpdateSeriesDataPoints();
            // fire event
            FireParameterChanged();
        }

        public override double GetMembershipDegree(double x)
        {
            double a = theFS1.GetMembershipDegree(x);
            double b = theFS2.GetMembershipDegree(x);;
            return theOperator.Evaluate(a, b);
        }
    }
}
