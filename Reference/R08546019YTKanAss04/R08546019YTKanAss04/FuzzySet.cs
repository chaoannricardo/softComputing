using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546019YTKanAss04
{
    class FuzzySet  //家族
    {
        // static data(class-scope data)
        static int counter = 1;

        // data
        protected double[] parameterValues;  //private：子類別沒有權限直接存取、繼承之父親的私密data
        protected string title;              //protected：無對外公開、子孫皆可使用
        protected Universe theUniverse;      //fuzzy set定義在universe上
        protected Series theSeries;          //new出來較浪費記憶體(Fuzzy Set有些只做運算、不顯示出來)-optional
        protected bool showSeries = false;

        // event // use default event handling delegate
        public event EventHandler ParameterChanged;

        protected void FireParameterChangedEvent()
        {
            if( ParameterChanged != null) ParameterChanged(this, null);
        }

        // properties
        [Browsable(false)]
        public Universe TheUniverse { get => theUniverse; }

        [Category("Display")]
        public bool ShowSeries  //(DisplaySeries/EnableSeries)
        {
            get => showSeries;
            set
            {
                showSeries = value;
                //prepare series if showSeries is true
                if (showSeries)  //true
                {
                    if(theSeries == null)  //沒有的時候new出來
                    {
                        theSeries = new Series();
                        theSeries.ChartType = SeriesChartType.Line;
                        theSeries.BorderWidth = 3;
                        theSeries.Name = title;                       
                        theSeries.ChartArea = theUniverse.TheChartArea.Name;  //不能相同名稱
                        //選定Chart(Seriese歸Chart管)裡的ChartArea
                        //需知道universe的ChartArea(theArea)：公開讀取
                        ((Chart)theUniverse.TheChartArea.Tag).Series.Add(theSeries);
                    }
                    UpdateSeriesPoints();  //不然Update Series Points就好
                }
            }
        }
        [Category("Display")]
        public string Title
        {
            get => title;
            set
            {
                title = value;
                //update series's title
                if (theSeries != null)  //有new出來才要更新
                {
                    theSeries.Name = value;
                }
            }
        }

        protected void UpdateSeriesPoints()
        {
            if (theSeries == null) return;
            theSeries.Points.Clear();  //點數沒有變化，其實只有改變y值(較浪費記憶體)
            for(double x= theUniverse.LowerBound; x <= theUniverse.UpperBound; x = x + theUniverse.Increment)
            {
                double y = GetMembershipDegree(x);
                theSeries.Points.AddXY(x, y);
            }
        }

        // constructor
        public FuzzySet( Universe u )
        {
            theUniverse = u;
            title = $"FS {counter++}";
            // subscribe ParameterChanged event
            theUniverse.ParameterChanged += TheUniverse_ParameterChanged;
        }

        protected void TheUniverse_ParameterChanged(object sender, string s)
        {
            UpdateSeriesPoints();
        }

        //Object-Oriented(O-O) Polymorphism virtual-override 動態連結
        // function
        public virtual double GetMembershipDegree(double x) 
        //名稱相同：子類別可以更迭、有不同做法；不想改變也可以呼叫virtual function
        {
            return 0.4;
        }

    }
}
