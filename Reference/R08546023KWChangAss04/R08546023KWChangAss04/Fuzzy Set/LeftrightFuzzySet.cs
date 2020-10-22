using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class LeftrightFuzzySet : FuzzySet
    {
        //define properties
        //attribute
        [Category("Parameters"), Description("The left slope of left-right function.")]
        public double LeftSlope
        {
            get
            {
                return parameters[0];
            }
            set
            {
                if( value >= 0 )
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
        [Category("Parameters"), Description("The right slope of left-right function.")]
        public double RightSlope
        {
            get
            {
                return parameters[1];
            }
            set
            {
                if ( value >= 0 )
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
        [Category("Parameters"), Description("The center of left-right function.")]
        public double Center
        {
            get
            {
                return parameters[2];
            }
            set
            {
                if ( value >= theUniverse.LowerBound && value <= theUniverse.UpperBound )
                {
                    parameters[2] = value;
                }
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
                FireParameterChangedEvent();
            }
        }
        //function
        public LeftrightFuzzySet(Universe v) : base(v)
        {
            parameters = new double[3];
            parameters[0] = 2;
            parameters[1] = 3;
            parameters[2] = theUniverse.LowerBound + Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound - theUniverse.LowerBound); ;
            title = "Left-right " + title;
        }
        public override double GetMembershipDegree(double x)
        {
            double y = 0;
            if(x <= parameters[2])
            {
                y = Math.Sqrt(Math.Max(0, 1 - Math.Pow(((parameters[2] - x) / parameters[0]), 2)));
            }
            else
            {
                if(x >= parameters[2])
                {
                    y = Math.Exp(-Math.Pow(Math.Abs((x - parameters[2]) / parameters[1]), 3));
                }
            }
            return y; 
        }
    }
}
