using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class GaussianFuzzySet : FuzzySet //繼承
    {
        public override double MaxDegree => 1.0;

        //define properties
        //attribute
        [Category("Parameters"), Description("The center of Gaussian function.")]
        public double Center
        {
            get
            {
                return parameters[0];
            }
            set
            {
                //guarding
                if (value >= theUniverse.LowerBound && value <= theUniverse.UpperBound)
                {
                    parameters[0] = value;
                    if (showSeries)
                    {
                        UpdateSeriesPoints();
                    }
                    FireParameterChangedEvent();
                }
            }
        }
        //attribute
        [Category("Parameters"), Description("The standard deviation of Gaussian function.")]
        public double STD
        {
            get
            {
                return parameters[1];
            }
            set
            {
                //guarding
                if( value  >= 0 )
                {
                    parameters[1] = value;
                    if (showSeries)
                    {
                        UpdateSeriesPoints();
                    }
                    FireParameterChangedEvent();
                }
                
            }
        }
        //function
        public GaussianFuzzySet(Universe v ) : base( v )
        {
            parameters = new double[2];
            parameters[0] = theUniverse.LowerBound +Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound - theUniverse.LowerBound);
            parameters[1] = 1;
            title = "Gaussian " + title;
        }

        public override double GetMembershipDegree(double x)
        {
            return Math.Exp(-0.5 * (x - parameters[0]) * (x - parameters[0]) / (parameters[1] * parameters[1]));
        }
    }
}
