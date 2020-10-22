﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss04
{
    class BellFuzzySet : FuzzySet  //繼承
    {
        // define properties
        [Category("Parameters"), Description("Must be greater than 0.")]
        public double Width
        {
            get
            {
                return parameterValues[0];
            }
            set
            {
                //guarding
                if (value >= 0) parameterValues[0] = value;
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
            }
        }
        [Category("Parameters")]
        public double Slope
        {
            get
            {
                return parameterValues[1];
            }
            set
            {
                //guarding
                parameterValues[1] = value;
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
                return parameterValues[2];
            }
            set
            {
                //guarding
                if (value >= theUniverse.LowerBound && value <= theUniverse.UpperBound) parameterValues[2] = value;
                if (showSeries)
                {
                    UpdateSeriesPoints();
                }
            }
        }

        // constructor
        public BellFuzzySet(Universe v) : base(v)  //base：父親類別  //base()：呼叫父親的建構函式  //v：區域變數
        {
            parameterValues = new double[3];
            //初始化
            parameterValues[0] = 4;
            parameterValues[1] = 2;
            parameterValues[2] = 5;
        }

        // function
        public override double GetMembershipDegree(double x)
        {
            return 1 / (1 + Math.Pow((Math.Abs((x - parameterValues[2]) /
                parameterValues[0])), 2 * parameterValues[1]));
        }
    }
}
