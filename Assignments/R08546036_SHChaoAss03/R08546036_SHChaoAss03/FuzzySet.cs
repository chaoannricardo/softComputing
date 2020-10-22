using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546036_SHChaoAss03
{
    class FuzzySet
    {
        protected double[] parameters;
        protected string title;
        protected static Random randomizer = new Random();
        protected Universe theUniverse;
        protected Series theSeries;

        [Category("Property")]
        public string Title
        {
            get
            {
                if (theSeries == null)
                {
                    return title;
                }
                else
                {
                    return theSeries.Name;
                }
            }
            set
            {
                try
                {
                    theSeries.Name = value;
                }
                catch (System.ArgumentException Exception)
                {
                    MessageBox.Show("Title name already exists!!!");
                }
            }
        }



        public bool ShowSeries
        {
            set
            {
                if (theSeries == null)
                {
                    theSeries = new Series(Title);
                    theSeries.ChartType = SeriesChartType.Line;
                    // Update Series Data Points
                    UpdateSeriesDataPoints();
                    // Add this series to chart via universe
                    theUniverse.AddASeriesOfAFuzzySet(this.theSeries);
                }
            }
            get
            {
                return theSeries == null ? false : true;
            }
        }

        private void UpdateSeriesDataPoints()
        {
            if (theSeries == null) return;

            theSeries.Points.Clear();
            double deltaX = (theUniverse.Maximum - theUniverse.Minimum) / (theUniverse.Resolution - 1);
            for (double x = theUniverse.Minimum; x <= theUniverse.Maximum; x += deltaX)
            {
                double y;
                y = GetMembershipDegree(x);
                theSeries.BorderWidth = 3;
                theSeries.Points.AddXY(x, y);
            }
        }

        public virtual double GetMembershipDegree(double x)
        {
            return 0;
        }

        [Category("Property")]
        public virtual string Core
        {
            get
            {
                return "";
            }

        }
        [Category("Property")]
        public virtual string Support
        {
            get
            {
                return "";
            }

        }

        public FuzzySet(Universe u)
        {
            theUniverse = u;
            // subscribe the event
            u.ParameterChanged += Universe_ParameterChanged;

        }

        // parameter changed event within the class
        private void Universe_ParameterChanged(object sender, EventArgs e)
        {
            if (ShowSeries)
            {
                UpdateSeriesDataPoints();
            }
        }
    }
}
