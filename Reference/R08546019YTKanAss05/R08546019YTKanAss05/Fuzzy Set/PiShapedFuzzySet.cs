using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class PiShapedFuzzySet : FuzzySet  //繼承
    {
        // define properties
        public override double MaxDegree => 1.0;
        [Category("Parameters"), Description("Must be less than LeftPeak.")]
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
        [Category("Parameters"), Description("Must be greater than Left \nand less than RightPeak.")]
        public double LeftPeak
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
        [Category("Parameters"), Description("Must be greater than LeftPeak \nand less than Right.")]
        public double RightPeak
        {
            get
            {
                return parameterValues[2];
            }
            set
            {
                //guarding
                if (value >= parameterValues[1] && value <= parameterValues[3])
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
        [Category("Parameters"), Description("Must be greater than RightPeak.")]
        public double Right
        {
            get
            {
                return parameterValues[3];
            }
            set
            {
                //guarding
                if (value >= parameterValues[2] && value <= theUniverse.UpperBound)
                {
                    parameterValues[3] = value;
                    if (showSeries)
                    {
                        UpdateSeriesPoints();
                    }
                    FireParameterChangedEvent();
                }
            }
        }

        // constructor
        public PiShapedFuzzySet(Universe v) : base(v)  //base：父親類別；base()：呼叫父親的建構函式；v：區域變數
        {
            parameterValues = new double[4];
            //初始化
            parameterValues[0] = 1;
            parameterValues[1] = 4;
            parameterValues[2] = 5;
            parameterValues[3] = 8;
            title = "Pi-Shaped" + title;  //title：父親類別
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
                if (x >= parameterValues[0] && x <= (parameterValues[0] + parameterValues[1]) / 2)
                {
                    y = 2 * Math.Pow(((x - parameterValues[0]) / (parameterValues[1] - parameterValues[0])), 2);
                }
                else
                {
                    if (x >= (parameterValues[0] + parameterValues[1]) / 2 && x <= parameterValues[1])
                    {
                        y = 1 - 2 * Math.Pow(((x - parameterValues[1]) / (parameterValues[1] - parameterValues[0])), 2);
                    }
                    else
                    {
                        if (x >= parameterValues[1] && x <= parameterValues[2])
                        {
                            y = 1;
                        }
                        else
                        {
                            if (x >= parameterValues[2] && x <= (parameterValues[2] + parameterValues[3]) / 2)
                            {
                                y = 1 - 2 * Math.Pow(((x - parameterValues[2]) / (parameterValues[3] - parameterValues[2])), 2);
                            }
                            else
                            {
                                if (x >= (parameterValues[2] + parameterValues[3]) / 2 && x <= parameterValues[3])
                                {
                                    y = 2 * Math.Pow(((x - parameterValues[3]) / (parameterValues[3] - parameterValues[2])), 2);
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
