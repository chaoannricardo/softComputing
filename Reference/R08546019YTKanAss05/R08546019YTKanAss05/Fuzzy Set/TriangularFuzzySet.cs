using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class TriangularFuzzySet : FuzzySet  //繼承
    {
        // define properties
        public override double MaxDegree => 1.0;
        [Category("Parameters"), Description("Must be less than Peak.")]
        public double Left
        {
            get
            {
                return parameterValues[0];
            }
            set
            {
                //guarding
                if (value >= theUniverse.LowerBound && value <= parameterValues[1])
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
        [Category("Parameters"), Description("Must be greater than Left \nand less than Right.")]
        public double Peak
        {
            get
            {
                return parameterValues[1];
            }
            set
            {
                //guarding
                if (value >= parameterValues[0] && value <= parameterValues[2])
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
        [Category("Parameters"), Description("Must be greater than Peak.")]
        public double Right
        {
            get
            {
                return parameterValues[2];
            }
            set
            {
                //guarding
                if (value >= parameterValues[1] && value <= theUniverse.UpperBound)
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
        public TriangularFuzzySet(Universe v) : base(v)  //base：父親類別  //base()：呼叫父親的建構函式  //v：區域變數
        {
            parameterValues = new double[3];
            //初始化
            parameterValues[0] = 2;
            parameterValues[1] = 3;
            parameterValues[2] = 4;
            title = "Triangular" + title;  //title：父親類別
        }

        // function
        public override double GetMembershipDegree(double x)
        {
            double y;  //degree
            if (x <= parameterValues[0])
            {
                y = 0;
            }
            else
            {
                if (x >= parameterValues[0] && x <= parameterValues[1])
                {
                    y = (x - parameterValues[0]) / (parameterValues[1] - parameterValues[0]);
                }
                else
                {
                    if (x >= parameterValues[1] && x <= parameterValues[2])
                    {
                        y = (parameterValues[2] - x) / (parameterValues[2] - parameterValues[1]);
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
