using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class BellFuzzySet : FuzzySet 
    {
        //define properties
        //attribute
        [Category("Parameters"), Description("The width of bell function.")]
        public double Width
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
        [Category("Parameters"), Description("The slope of bell function.")]
        public double Slope
        {
            get
            {
                return parameters[1];
            }
            set
            {
                if( value >= 0 )
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
        //attribute
        [Category("Parameters"), Description("The center of bell function.")]
        public double Center
        {
            get
            {
                return parameters[2];
            }
            set
            {
                parameters[2] = value;
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
                FireParameterChangedEvent();
            }
        }
        //function
        public BellFuzzySet(Universe v) : base(v)
        {
            parameters = new double[3];
            parameters[0] = 1;
            parameters[1] = 2;
            parameters[2] = theUniverse.LowerBound + Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound - theUniverse.LowerBound); ;
            title = "Bell " + title;
        }
        public override double GetMembershipDegree(double x)
        {
            return 1 / (1 + Math.Pow(Math.Abs(((x - parameters[2]) / parameters[0])), 2 * parameters[1])); 
        }
    }
}
