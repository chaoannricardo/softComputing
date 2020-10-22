using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class PiShapedFuzzySet : FuzzySet
    {
        //define properties
        //attribute
        [Category("Parameters"), Description("The shoulder of Z-shaped function.")]
        public double LeftFoot
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
        public double LeftShoulder
        {
            get
            {
                return parameters[1];
            }
            set
            {
                //guarding
                if (value >= parameters[0] && value <= parameters[1])
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
        //attribute
        [Category("Parameters"), Description("The foot of Z-shaped function.")]
        public double RightShoulder
        {
            get
            {
                return parameters[2];
            }
            set
            {
                //guarding
                if (value >= parameters[1] && value <= parameters[2])
                {
                    parameters[2] = value;
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
        public double RightFoot
        {
            get
            {
                return parameters[3];
            }
            set
            {
                //guarding
                if (value >= parameters[2] && value <= TheUniverse.UpperBound)
                {
                    parameters[3] = value;
                    if (showSeries)
                    {
                        UpdateSeriesPoints();
                    }
                    FireParameterChangedEvent();
                }

            }
        }
        //function
        public PiShapedFuzzySet(Universe v) : base(v)
        {
            parameters = new double[4];
            parameters[0] = theUniverse.LowerBound + Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound - theUniverse.LowerBound) / 4;
            parameters[1] = (theUniverse.UpperBound + theUniverse.LowerBound) / 2 - Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound - theUniverse.LowerBound) / 4;
            parameters[2] = (theUniverse.UpperBound + theUniverse.LowerBound) / 2 + Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound - theUniverse.LowerBound) / 4;
            parameters[3] = theUniverse.UpperBound - Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound - theUniverse.LowerBound) / 4;
            title = "Pi-shaped " + title;
        }

        public override double GetMembershipDegree(double x)
        {
            double y = 0;
            if (x <= parameters[0])
            {
                y = 0;
            }
            else
            {
                if (x >= parameters[0] && x <= ((parameters[0] + parameters[1]) / 2))
                {
                    y = 2 * Math.Pow((x - parameters[0]) / (parameters[1] - parameters[0]), 2);
                }
                else
                {
                    if (x >= ((parameters[0] + parameters[1])) / 2 && x <= parameters[1])
                    {
                        y = 1 - 2 * Math.Pow((x - parameters[1]) / (parameters[1] - parameters[0]), 2);
                    }
                    else
                    {
                        if( x>=parameters[1] && x<= parameters[2] )
                        {
                            y = 1;
                        }
                        else
                        {
                            if (x >= parameters[2] && x <= ((parameters[2] + parameters[3]) / 2))
                            {
                                y = 1 - 2 * Math.Pow((x - parameters[2]) / (parameters[3] - parameters[2]), 2);
                            }
                            else
                            {
                                if(x >= ((parameters[2] + parameters[3]) / 2) && x <= parameters[3])
                                {
                                    y = 2 * Math.Pow((x - parameters[3]) / (parameters[3] - parameters[2]), 2);
                                }
                                else
                                {
                                    y = 0;
                                }
                            }
                        }
                    }
                }
            }
            return y;
        }
    }
}
