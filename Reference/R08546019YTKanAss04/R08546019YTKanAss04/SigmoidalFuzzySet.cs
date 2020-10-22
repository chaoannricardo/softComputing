﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss04
{
    class SigmoidalFuzzySet : FuzzySet  //繼承
    {
        // define properties
        [Category("Parameters")]
        public double Slope
        {
            get
            {
                return parameterValues[0];
            }
            set
            {
                //guarding
                parameterValues[0] = value;
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
            }
        }
        [Category("Parameters")]
        public double Center
        {
            get
            {
                return parameterValues[1];
            }
            set
            {
                //guarding
                if (value >= theUniverse.LowerBound && value <= theUniverse.UpperBound) parameterValues[1] = value;
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
            }
        }

        // constructor
        public SigmoidalFuzzySet(Universe v) : base(v)  //base：父親類別  //base()：呼叫父親的建構函式  //v：區域變數
        {
            parameterValues = new double[2];
            //初始化
            parameterValues[0] = 2;
            parameterValues[1] = 5;
        }

        // function
        public override double GetMembershipDegree(double x)
        {
            return 1 / (1 + Math.Exp(-parameterValues[0] * (x - parameterValues[1])));
        }
    }
}
