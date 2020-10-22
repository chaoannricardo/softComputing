using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class TriangularFuzzySet : FuzzySet
    {
        //define properties
        //attribute
        [Category("Parameters"), Description("The left of triangular function.")]
        public double Left
        {
            get
            {
                return parameters[0];
            }
            set
            {
                //guarding
                if( value >= theUniverse.LowerBound && value < Peak )
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
        [Category("Parameters"), Description("The peak of triangular function.")]
        public double Peak
        {
            get
            {
                return parameters[1];
            }
            set
            {
                //guarding
                if (value > Left && value < Right)
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
        [Category("Parameters"), Description("The right of triangular function.")]
        public double Right 
        {
            get
            {
                return parameters[2];
            }
            set
            {
                //guarding
                if ( value > Peak && value <= theUniverse.UpperBound )
                {
                    parameters[2] = value;
                }
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
            }
        }
        //function
        public TriangularFuzzySet(Universe v) : base(v)
        {
            parameters = new double[3];
            parameters[0] = (theUniverse.UpperBound + theUniverse.LowerBound) / 2 - Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound + theUniverse.LowerBound) / 2;
            parameters[1] = (theUniverse.UpperBound + theUniverse.LowerBound) / 2;
            parameters[2] = (theUniverse.UpperBound + theUniverse.LowerBound) / 2 + Math.Round(random.NextDouble(), 2) * (theUniverse.UpperBound + theUniverse.LowerBound) / 2; 
            title = "Triangular " + title;
        }
        public override double GetMembershipDegree(double x)
        {
            double y;
            if (x <= parameters[0])
            {
                y = 0;
            }
            else
            {
                if (x >= parameters[0] && x <= parameters[1])
                {
                    y = (x - parameters[0]) / (parameters[1] - parameters[0]);
                }
                else
                {
                    if (x >= parameters[1] && x <= parameters[2])
                    {
                        y = (parameters[2] - x) / (parameters[2] - parameters[1]);
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
