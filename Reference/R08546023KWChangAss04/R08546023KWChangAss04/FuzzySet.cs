using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546023KWChangAss05
{
    class FuzzySet //Fezzy Set family
    {

        // Define overloaded operators
        // Intersection
        public static FuzzySet operator&( FuzzySet left, FuzzySet right )
        {
            Binary_Operator.BinaryFSOperator op = new Binary_Operator.IntersectOperator();
            Binary_Operator.BinaryOperatedFS fs = new Binary_Operator.BinaryOperatedFS(left, right, op);
            return fs;
        }

        public static FuzzySet operator|(FuzzySet left, FuzzySet right)
        {
            Binary_Operator.BinaryFSOperator op = new Binary_Operator.UnionOperator();
            Binary_Operator.BinaryOperatedFS fs = new Binary_Operator.BinaryOperatedFS(left, right, op);
            return fs;
        }

        public static FuzzySet operator- (double alpha, FuzzySet operand )
        {
            AlphaCutOperator op = new AlphaCutOperator();
            op.Alpha = alpha;
            return  new UnaryOperatedFS(operand, op);
        }

        public static FuzzySet operator* (double scale, FuzzySet operand )
        {
            ValueScaleOperator op = new ValueScaleOperator();
            op.Scale = scale;
            return new UnaryOperatedFS(operand, op);
        }

        public virtual double MaxDegree
        {
            get
            {
                double max = double.MinValue;
                // loop through all values of the universe get the maximal degree
                if (theSeries != null)
                {
                    for (int i = 0; i < theSeries.Points.Count; i++)
                    {
                        if (theSeries.Points[i].YValues[0] > max)
                        {
                            max = theSeries.Points[i].YValues[0];
                        }
                    }
                }
                else
                {
                    for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x = x + theUniverse.Increment)
                    {
                        double y = GetMembershipDegree(x);
                        if (y > max) max = y;
                    }
                }
                return max;
            }
        }

        //static data
        static int counter = 1;

        //data
        protected Random random = new Random();
        protected double[] parameters;
        protected Universe theUniverse;
        protected string title;
        protected Series theSeries;
        protected bool showSeries = false;

        //event //use default event handling delegate
        //EventHandler is an gelegate has been defined originally
        public event EventHandler ParameterChanged;
        protected void FireParameterChangedEvent()
        {
           if(ParameterChanged!=null)
            {
                ParameterChanged(this, null);
            }
           
        }


        //define properties
        [Browsable(false)] //not show
        
        //attribute
        [Category("Class"), Description("The title of fuzzy set.")]
        public string Title
        {
            get => title;
            set
            {
                title = value;
                //update series's title
                if (theSeries != null)
                {
                    theSeries.Name = value;
                }
            }
        }

        [Browsable(false)]//不顯示
        public Universe TheUniverse { get => theUniverse; } //唯讀

        [Browsable(false)]//不顯示
        public Series TheSeries { get => theSeries; } //唯讀


        [Category("Series"), Description("Whether to show the line on the chart.")]
        public bool ShowSeries
        {
            get => showSeries;
            set
            {
                showSeries = value;
                //prepare series if showSeries is true
                if(showSeries == true)
                {
                    //new a Series when there is no Series
                    if (theSeries == null) 
                    {
                        theSeries = new Series();
                        theSeries.ChartType = SeriesChartType.Line;
                        theSeries.Name = title;
                        theSeries.BorderWidth = 2;
                        theSeries.ChartArea = theUniverse.TheChartArea.Name;
                        //pick out ChartArea in Chart (Series is managed by Chart)
                        //need to know ChartArea(theArea) in Universe (read publicly)
                        ((Chart)theUniverse.TheChartArea.Tag).Series.Add(theSeries);
                    }
                    UpdateSeriesPoints();
                }
            }
        }
        //graphing
        protected void UpdateSeriesPoints()
        {
            if (theSeries == null) return;
            //prevent waste of memory space
            theSeries.Points.Clear();
            for( double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x = x + theUniverse.Increment )
            {
                double y = GetMembershipDegree(x);
                theSeries.Points.AddXY(x, y);
            }
        }

        //constructor
        public FuzzySet( Universe u )
        {
            theUniverse = u;

            title = $"FS {counter++}";
            //subscribe ParameterChanged event
            //+= : 定用事件 
            theUniverse.ParameterChanged += TheUniverse_ParameterChanged;
        }

        protected void TheUniverse_ParameterChanged(object sender, string s)  //sender : from which class 
        {
            //call UpdateSeriesPoints
            UpdateSeriesPoints();
        }

        


        //o-o Polymorphism virtual-override 動態連結
        public virtual double GetMembershipDegree( double x )
        {
            return 0.4;
        }
    }
}
