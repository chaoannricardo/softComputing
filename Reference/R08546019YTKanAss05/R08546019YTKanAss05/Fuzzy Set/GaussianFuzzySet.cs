using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class GaussianFuzzySet : FuzzySet  //繼承
    {


        public override double COA => parameterValues[0];
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
                if (value >= theUniverse.LowerBound && value <=theUniverse.UpperBound)
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
        public double StandardDeviation
        {
            get
            {
                return parameterValues[1];
            }
            set
            {
                //guarding
                if (value >= 0)
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

        // constructor
        public GaussianFuzzySet(Universe v) : base(v)  //base：父親類  //base()：呼叫父親的建構函式  //v：區域變數
        {
            parameterValues = new double[2];
            //初始化
            parameterValues[0] = theUniverse.LowerBound + Math.Round((random.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound)), 3);
            parameterValues[1] = 1;
            title = "Gaussian" + title;  //title：父親類別
        }

        // function
        public override double GetMembershipDegree(double x)
        {
            return Math.Exp(-0.5 * (x - parameterValues[0]) * (x - parameterValues[0]) /
                (parameterValues[1] * parameterValues[1]));  //degree
            //return base.GetMembershipDegree(x);
        }
    }
}
