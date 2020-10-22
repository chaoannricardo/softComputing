using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class ZShapedFuzzySet : FuzzySet
    {
        //define properties
        //attribute
        [Category("Parameters"), Description("The shoulder of Z-shaped function.")]
        public double Shoulder
        {
            get
            {
                return parameters[0];
            }
            set
            {
                //guarding
                if (value >= theUniverse.LowerBound && value <= parameters[1])
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
        [Category("Parameters"), Description("The foot of Z-shaped function.")]
        public double Foot
        {
            get
            {
                return parameters[1];
            }
            set
            {
                //guarding
                if (value >= parameters[0] && value <= TheUniverse.UpperBound)
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
        public ZShapedFuzzySet(Universe v) : base(v)
        {
            parameters = new double[2];
            parameters[0] = (theUniverse.UpperBound + theUniverse.LowerBound) / 2 - Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound + theUniverse.LowerBound) / 2; ;
            parameters[1] = (theUniverse.UpperBound + theUniverse.LowerBound) / 2 + Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound + theUniverse.LowerBound) / 2; ;
            title = "Z-shaped " + title;
        }

        public override double GetMembershipDegree(double x)
        {
            double y = 0;
            if( x <= parameters[0] )
            {
                y = 1;
            }
            else
            {
                if( x >= parameters[0] && x <= ((parameters[0]+parameters[1])/2) )
                {
                    y = 1 - 2 * Math.Pow((x - parameters[0]) / (parameters[1] - parameters[0]), 2);
                }
                else
                {
                    if (x >= ((parameters[0] + parameters[1]) / 2) && x <= parameters[1] )
                    {
                        y = 2 * Math.Pow((x - parameters[1]) / (parameters[1] - parameters[0]), 2);
                    }
                    else
                    {
                        y = 0;
                    }
                }
            }
            return y;
        }
    }
}
