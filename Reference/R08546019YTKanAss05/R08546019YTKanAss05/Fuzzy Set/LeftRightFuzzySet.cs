using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class LeftRightFuzzySet : FuzzySet  //繼承
    {
        // define properties
        public override double MaxDegree => 1.0;
        [Category("Parameters")]
        public double Center
        {
            get
            {
                return parameterValues[0];
            }
            set
            {
                //guarding
                if (value >= theUniverse.LowerBound && value <= theUniverse.UpperBound)
                {
                    parameterValues[0] = value;
                    if (showSeries)
                    {
                        UpdateSeriesPoints();
                    }
                    FireParameterChangedEvent();
                }

            }
        }
        [Category("Parameters"), Description("Must be greater than 0.")]
        public double LeftParameter
        {
            get
            {
                return parameterValues[1];
            }
            set
            {
                //guarding
                if (value > 0)
                {
                    parameterValues[1] = value;
                    if (showSeries)
                    {
                        UpdateSeriesPoints();
                    }
                    FireParameterChangedEvent();
                }
            }
        }
        [Category("Parameters"), Description("Must be greater than 0.")]
        public double RightParameter
        {
            get
            {
                return parameterValues[2];
            }
            set
            {
                //guarding
                if (value > 0)
                {
                    parameterValues[2] = value;
                    if (showSeries)
                    {
                        UpdateSeriesPoints();
                    }
                    FireParameterChangedEvent();
                }
            }
        }

        // constructor
        public LeftRightFuzzySet(Universe v) : base(v)  //base：父親類別  //base()：呼叫父親的建構函式  //v：區域變數
        {
            parameterValues = new double[3];
            //初始化
            parameterValues[0] = theUniverse.LowerBound + Math.Round((random.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound)), 3);
            parameterValues[1] = 2;
            parameterValues[2] = 2;
            title = "Left-Right" + title;  //title：父親類別
        }

        // function
        public override double GetMembershipDegree(double x)
        {
            double y;  //degree
            if (x <= parameterValues[0])
            {
                y = Math.Sqrt(Math.Max(0, (1 - (parameterValues[0] - x) / parameterValues[1] *
                    (parameterValues[0] - x) / parameterValues[1])));
            }
            else  //(x >= parameterValues[0])
            {
                y = Math.Exp(-Math.Pow((Math.Abs((x - parameterValues[0]) / parameterValues[2])), 3));
            }
            return y;
        }
    }
}
