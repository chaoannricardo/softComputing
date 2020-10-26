using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [TypeConverter(typeof(ExpandableObjectConverter))] // Access property of UnaryFSOperator
        public UnaryFSOperator TheOperator { get => theOperator;}

        [TypeConverter(typeof(ExpandableObjectConverter))] // Access property of FuzzySet
        public FuzzySet TheBaseFS { get => theFS; }

        public UnaryOperatedFuzzySet(FuzzySet fs, UnaryFSOperator op) : base(fs.TheUniverse)
        {
            theFS = fs;
            theOperator = op;

            title = op.Title + "-" + fs.Title + $"{++count}";

            // subscribe event
            theFS.ParameterChanged += TheFSParameterChanged;
            theOperator.ParameterChanged += TheFSParameterChanged;

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

        public override string ToString()
        {
            return Title;
        }
    }
}
