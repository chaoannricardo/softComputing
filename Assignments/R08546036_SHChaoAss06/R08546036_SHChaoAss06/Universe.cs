using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546036_SHChaoAss04
{
    class Universe
    {
        static int count = 0;

        // data
        private TabPage bindedTab;
        private Chart bindedChart;
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

        public override string ToString()
        {
            return Title;
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

                    // Fire the event of parameter change
                    if (ParameterChanged != null)
                    {
                        ParameterChanged(this, null);
                    }
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
                    // Fire the event of parameter change
                    if (ParameterChanged != null)
                    {
                        ParameterChanged(this, null);
                    }
                }
            }
        }

        [Browsable(false)]
        public TabPage BindedTab
        {
            get
            {
                return bindedTab;
            }
            set
            {
                if (value is TabPage)
                {
                    bindedTab = value;
                }
            }

        }

        [Browsable(false)]
        public Chart BindedChart
        {
            get
            {
                return bindedChart;
            }
            set
            {
                if (value is Chart)
                {
                    bindedChart = value;
                }
            }

        }

        // functions
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

        public void SaveFile(StreamWriter sw)
        {
            sw.WriteLine($"Title:{Title}");
            sw.WriteLine($"Minimum:{Minimum}");
            sw.WriteLine($"Maximum:{Maximum}");
            sw.WriteLine($"Resolution:{Resolution}");
        }

        public void ReadFile(StreamReader sr)
        {
            string[] items;

            items = sr.ReadLine().Split(':');
            Title = items[1];
            items = sr.ReadLine().Split(':');
            Minimum = Convert.ToDouble(items[1]);
            items = sr.ReadLine().Split(':');
            Maximum = Convert.ToDouble(items[1]);
            items = sr.ReadLine().Split(':');
            Resolution = Convert.ToInt32(items[1]);
        }
    }
}
