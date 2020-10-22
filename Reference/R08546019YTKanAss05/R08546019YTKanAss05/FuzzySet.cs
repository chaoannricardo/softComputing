using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546019YTKanAss05
{
    class FuzzySet  //家族
    {
        // define overloaded operators(作用在Fuzzy Set上)

        // Binary Operators
        //Minimum T-norm (Intersection)
        public static FuzzySet operator & (FuzzySet left,FuzzySet right)  //運算結果為Fuzzy Set
        {
            BinaryFuzzySetOperator op = new MinimumTnorm();
            BinaryOperatedFuzzySet fs = new BinaryOperatedFuzzySet(left, right, op);
            return fs;
        }
        //Maximum S-norm (Union)
        public static FuzzySet operator | (FuzzySet left, FuzzySet right)  //運算結果為Fuzzy Set
        {
            BinaryFuzzySetOperator op = new MaximumSnorm();
            BinaryOperatedFuzzySet fs = new BinaryOperatedFuzzySet(left, right, op);
            return fs;
        }
        //Algebraic Product
        public static FuzzySet operator < (FuzzySet left, FuzzySet right)  
        {
            BinaryFuzzySetOperator op = new AlgebraicProduct();
            BinaryOperatedFuzzySet fs = new BinaryOperatedFuzzySet(left, right, op);
            return fs;
        }
        //Bounded Product
        public static FuzzySet operator + (FuzzySet left, FuzzySet right)
        {
            BinaryFuzzySetOperator op = new BoundedProduct();
            BinaryOperatedFuzzySet fs = new BinaryOperatedFuzzySet(left, right, op);
            return fs;
        }
        //Drastic Product
        public static FuzzySet operator / (FuzzySet left, FuzzySet right)
        {
            BinaryFuzzySetOperator op = new DrasticProduct();
            BinaryOperatedFuzzySet fs = new BinaryOperatedFuzzySet(left, right, op);
            return fs;
        }
        //Algebraic Sum
        public static FuzzySet operator > (FuzzySet left, FuzzySet right)
        {
            BinaryFuzzySetOperator op = new AlgebraicSum();
            BinaryOperatedFuzzySet fs = new BinaryOperatedFuzzySet(left, right, op);
            return fs;
        }
        //Bounded Sum
        public static FuzzySet operator ^ (FuzzySet left, FuzzySet right)
        {
            BinaryFuzzySetOperator op = new BoundedSum();
            BinaryOperatedFuzzySet fs = new BinaryOperatedFuzzySet(left, right, op);
            return fs;
        }
        //Drastic Sum
        public static FuzzySet operator % (FuzzySet left, FuzzySet right)
        {
            BinaryFuzzySetOperator op = new DrasticSum();
            BinaryOperatedFuzzySet fs = new BinaryOperatedFuzzySet(left, right, op);
            return fs;
        }
        // Unary Operators        
        //Cut
        public static FuzzySet operator - (double alpha, FuzzySet operand)  //二元運算：數值減掉Fuzzy Set->Fuzzy Set
        {
            UnaryFuzzySetOperator op = new AlphaCut(alpha);
            return new UnaryOperatedFuzzySet(operand, op);  //簡化
        }
        //Scale
        public static FuzzySet operator * (double alpha, FuzzySet operand)  //二元運算：數值減掉Fuzzy Set->Fuzzy Set
        {
            UnaryFuzzySetOperator op = new AlphaScale(alpha);
            return new UnaryOperatedFuzzySet(operand, op);
        }
        //Not
        public static FuzzySet operator ! (FuzzySet operand) 
        {
            UnaryFuzzySetOperator op = new Negate();
            return new UnaryOperatedFuzzySet(operand, op); 
        }
        //Concentration
        public static FuzzySet operator + (FuzzySet operand)
        {
            UnaryFuzzySetOperator op = new Concentration();
            return new UnaryOperatedFuzzySet(operand, op);
        }
        //Dilation
        public static FuzzySet operator - (FuzzySet operand)
        {
            UnaryFuzzySetOperator op = new Dilation();
            return new UnaryOperatedFuzzySet(operand, op);
        }
        //Extremely
        public static FuzzySet operator ++ (FuzzySet operand)
        {
            UnaryFuzzySetOperator op = new Extremely();
            return new UnaryOperatedFuzzySet(operand, op);
        }
        //Intensification
        public static FuzzySet operator ~ (FuzzySet operand)
        {
            UnaryFuzzySetOperator op = new Intensification();
            return new UnaryOperatedFuzzySet(operand, op);
        }
        //Diminisher
        public static FuzzySet operator -- (FuzzySet operand)
        {
            UnaryFuzzySetOperator op = new Diminisher();
            return new UnaryOperatedFuzzySet(operand, op);
        }


        public virtual double GetMemberValueFromMembershipDegree(double degree)
        {
            double member = 0;



            return member;
        }

        public virtual double COA
        {
            get
            {
                double  xTimeArea = 0, Area=0;
                double inc = theUniverse.Increment;
                if (theSeries != null)  //theSeries存在
                {
                    for (int i = 0; i < theSeries.Points.Count; i++)  //已經有的series一點一點出來
                    {
                        double delta = inc * theSeries.Points[i].YValues[0];
                        Area += delta;
                        xTimeArea += theSeries.Points[i].XValue * delta;
                    }
                }
                else  //theSeries不存在
                {
                    for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x = x + theUniverse.Increment)
                    {
                        double delta = inc * GetMembershipDegree(x);
                        Area += delta;
                        xTimeArea += x * delta;

                    }
                }
                return Area == 0 ?  (theUniverse.UpperBound + theUniverse.LowerBound )/ 2 :  xTimeArea / Area;
            }
        }
        //Maximum Degree (property)
        [Browsable(false)]
        public virtual double MaxDegree  //Normal Fuzzy Set max=1
        {
            get
            {
                double max = double.MinValue;  
                //loop through all values of universe get the maimal degree
                if(theSeries != null)  //theSeries存在
                {
                    for (int i = 0; i < theSeries.Points.Count; i++)  //已經有的series一點一點出來
                    {
                        if (theSeries.Points[i].YValues[0] > max)     //chart裡y可能有兩個值
                        {
                            max = theSeries.Points[i].YValues[0];     //大於取代
                        }
                    }
                }
                else  //theSeries不存在
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

        // static data(class-scope data)
        static int counter = 1;

        // data       
        protected Random random = new Random();  //random
        protected double[] parameterValues;  //private：子類別沒有權限直接存取、繼承之父親的私密data
        protected string title;              //protected：無對外公開、子孫皆可使用
        protected Universe theUniverse;      //fuzzy set定義在universe上
        protected Series theSeries;          //new出來較浪費記憶體(Fuzzy Set有些只做運算、不顯示出來)-optional
        protected bool showSeries = false;

        // events //不用像Universe一樣設delegate(利用.Net Framework)
        public event EventHandler ParameterChanged;  //use default event handling delegate(最典型)
        protected void FireParameterChangedEvent()
        {
            if(ParameterChanged != null)       //最後一層UnaryOperated/BinaryOperated Fuzzy Set沒有人定用
                ParameterChanged(this, null);  //(Object, EventArg)(EventHandler樣式)
        }

        // properties
        [Browsable(false)]
        public Universe TheUniverse
        {
            get => theUniverse;
        }
        [Browsable(false)]  
        public Series TheSeries
        {
            get => theSeries;   //唯獨(給Fuzzy Set用)  //間接可以知道lowerBound、upperBound...
        }
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
                        theSeries.BorderWidth = 2;
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
        [Browsable(false)]
        public SeriesChartType TheChartType
        {
            get => theSeries.ChartType;
            set
            {
                theSeries.ChartType = value;  //讓最後result可以更改為shade
            }
        }
        [Category("Display"), Description("Fuzzy Set name")]
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
            //guarding
            if (theSeries == null) return;  //隱藏
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
            //subscribe LowerBoundChanged event
            theUniverse.LowerBoundChanged += TheUniverse_LowerBoundChanged;
            //subscribe UpperBoundChanged event
            theUniverse.UpperBoundChanged += TheUniverse_UpperBoundChanged;
            //subscribe LowerBoundChanged event
            theUniverse.ResolutionChanged += TheUniverse_ResolutionChanged;
        }
        protected void TheUniverse_ResolutionChanged(object sender, string s)
        {
            UpdateSeriesPoints();
        }
        protected void TheUniverse_UpperBoundChanged(object sender, string s)
        {
            UpdateSeriesPoints();
        }
        protected void TheUniverse_LowerBoundChanged(object sender, string s)  //知道哪個universe送進來，提示的字串為何
        {
            UpdateSeriesPoints();
        }

        //Object-Oriented(O-O) Polymorphism virtual-override 動態連結
        // function
        public virtual double GetMembershipDegree(double x) 
        //名稱相同：子類別可以更迭、有不同做法；不想改變也可以呼叫virtual function
        {
            return 0;
        }

    }
}
