﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546036_SHChaoAss04
{
    class Universe
    {
        static int count = 0;

        // data
        int resolution = 100;
        ChartArea theArea;
        Chart theChart;


        // event 
        public event EventHandler ParameterChanged;

        // properties
        public string Title
        {
            set
            {
                theArea.AxisX.Title = value;
            }
            get
            {
                return theArea.AxisX.Title;
            }
        }

        public double Minimum
        {
            get
            {
                return theArea.AxisX.Minimum;

            }
            set
            {
                if (value < theArea.AxisX.Maximum)
                {
                    theArea.AxisX.Minimum = value;

                    // Fire the event of parameter change
                    if (ParameterChanged != null)
                    {
                        ParameterChanged(this, null);
                    }
                }
            }
        }

        public double Maximum
        {
            get
            {
                return theArea.AxisX.Maximum;
            }
            set
            {
                if (value > theArea.AxisX.Minimum)
                {
                    theArea.AxisX.Maximum = value;
                }
            }
        }

        [Description("Resolution must be greater than 50")]
        public int Resolution
        {
            get => resolution;

            set
            {
                if (value >= 50)
                {
                    resolution = value;
                }
            }
        }

        public void AddASeriesOfAFuzzySet(Series aSeries)
        {
            // register the series to the chart area
            aSeries.ChartArea = this.theArea.Name;

            // add the series to Chart.Series
            theChart.Series.Add(aSeries);

        }


        // constructor
        public Universe(Chart theMainChart)
        {
            string title = $"Universe {++count}";
            theArea = new ChartArea(title);
            theArea.AxisX.Title = title;
            theArea.AxisY.Title = "Membership Degree";
            theArea.AxisX.Enabled = theArea.AxisY.Enabled = AxisEnabled.True;
            theChart = theMainChart;
            theMainChart.ChartAreas.Add(theArea);

            // define initiate value of the AxisX
            theArea.AxisX.Minimum = Minimum = 0;
            theArea.AxisX.Maximum = Maximum = 30;
        }




    }
}
