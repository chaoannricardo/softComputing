using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546036_SHChaoAss04
{
    class FuzzySet
    {
        #region variable
        protected double[] parameters;
        protected string title;
        protected static Random randomizer = new Random();
        protected Universe theUniverse;
        protected Series theSeries;
        #endregion

        // operator overloaded
        public static FuzzySet operator ! (FuzzySet fs)
        {
            UnaryFSOperator op = new NegateOperator();
            return new UnaryOperatedFuzzySet(fs, op);
        } 
 
        public static FuzzySet operator - (FuzzySet fs)
        {
            UnaryFSOperator op = new ValueCutOperator();
            return new UnaryOperatedFuzzySet(fs, op);
        }

        // operator for intersection binary operation
        public static FuzzySet operator * (FuzzySet leftFS, FuzzySet rightFS)
        {
            return null;
        }

        // Events
        public event EventHandler ParameterChanged;

        protected void FireParameterChanged()
        {
            if (ParameterChanged != null)
            {
                ParameterChanged(this, null);
            }

        }

        public Universe TheUniverse
        {
            get { return theUniverse; }
            set { }

        }



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

        protected void UpdateSeriesDataPoints()
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

        // * parameter changed event within the class
        private void Universe_ParameterChanged(object sender, EventArgs e)
        {
            if (ShowSeries) UpdateSeriesDataPoints();
        }
    }
}
