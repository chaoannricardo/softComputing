using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class TrapezoidalFuzzySet : FuzzySet
    {
        //define properties
        //attribute
        [Category("Parameters"), Description("The left of trapezoidal function.")]
        public double Left
        {
            get
            {
                return parameters[0];
            }
            set
            {
                //guarding
                if( value >= theUniverse.LowerBound )
                {
                    parameters[0] = value;
                }
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
                FireParameterChangedEvent();
            }
        }
        //attribute
        [Category("Parameters"), Description("The left peak of trapezoidal function.")]
        public double LeftPeak
        {
            get
            {
                return parameters[1];
            }
            set
            {
                //guarding
                if( value > Left && value < RightPeak )
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
        [Category("Parameters"), Description("The right peak of trapezoidal function.")]
        public double RightPeak
        {
            get
            {
                return parameters[2];
            }
            set
            {
                //guarding
                if( value > LeftPeak && value < Right )
                {
                    parameters[2] = value;
                }
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
            }
        }
        //attribute
        [Category("Parameters"), Description("The right of trapezoidal function.")]
        public double Right
        {
            get
            {
                return parameters[3];
            }
            set
            {
                //guarding
                if( value > RightPeak && value <=theUniverse.UpperBound )
                {
                    parameters[3] = value;
                }
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
            }
        }
        //function
        public TrapezoidalFuzzySet(Universe v) : base(v)
        {
            parameters = new double[4];
            parameters[0] = theUniverse.LowerBound + Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound - theUniverse.LowerBound) / 4;
            parameters[1] = (theUniverse.UpperBound + theUniverse.LowerBound) / 2 - Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound - theUniverse.LowerBound) / 4;
            parameters[2] = (theUniverse.UpperBound + theUniverse.LowerBound) / 2 + Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound - theUniverse.LowerBound) / 4;
            parameters[3] = theUniverse.UpperBound - Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound - theUniverse.LowerBound) / 4;
            title = "Trapezoidal " + title;
        }
        public override double GetMembershipDegree(double x)
        {
            double y = 0;
            if(x <= parameters[0])
            {
                y = 0;
            }
            else
            {
                if(x >= parameters[0] && x <= parameters[1])
                {
                    y = (x - parameters[0]) / (parameters[1] - parameters[0]);
                }
                else
                {
                    if(x >= parameters[1] && x <= parameters[2])
                    {
                        y = 1;
                    }
                    else
                    {
                        if(x >= parameters[2] && x <= parameters[3])
                        {
                            y = (parameters[3] - x) / (parameters[3] - parameters[2]);
                        }
                        else
                        {
                            y = 0;
                        }
                    }
                }
            }
                
            return y;
        }
    }
}
