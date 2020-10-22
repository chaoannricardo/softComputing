using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class SigmoidalFuzzySet : FuzzySet
    {
        //define properties
        //attribute
        [Category("Parameters"), Description("The slope of Sigmoidal function.")]
        public double Slope
        {
            get
            {
                return parameters[0];
            }
            set
            {
                parameters[0] = value;
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
                FireParameterChangedEvent();
            }
        }
        //attribute
        [Category("Parameters"), Description("The center of Sigmoidal function.")]
        public double Center
        {
            get
            {
                return parameters[1];
            }
            set
            {
                if( value >= theUniverse.LowerBound && value <= theUniverse.UpperBound )
                {
                    parameters[1] = value;
                }
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
                FireParameterChangedEvent();
            }
        }
        //function
        public SigmoidalFuzzySet(Universe v) : base(v)
        {
            parameters = new double[2];
            parameters[0] = 5;
            parameters[1] = 1;
            title = "Sigmoidal " + title;
        }
        public override double GetMembershipDegree(double x)
        {
            return 1 / (1 + Math.Exp(-parameters[0] * (x - parameters[1])));
        }
    }
}
