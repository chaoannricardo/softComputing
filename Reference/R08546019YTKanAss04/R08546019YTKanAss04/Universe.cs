using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace R08546019YTKanAss04
{
    delegate void ParameterChangeEventFunction(object sender, string s); 

    class Universe
    {

        // class-scope data (流水號)
        static int counter = 1;  //初始化  //內定為dynamic：物件中途run出來
                                          //static靜態：程式執行前已準備好

        // data (物件資料)

        //string title;          //內定為private(不使用public：讓外面的人有accessibility修改資料)
        //double lowerBound;
        //double upperBound;
        int resolution;          //曲線解析度：解析度大、刻劃精細、曲線較smooth
        ChartArea theArea;       //資料重複-x軸=title；y軸=MembershipDegree;最小值=lowerBound;最大值=upperBound

        // events
        public event ParameterChangeEventFunction ParameterChanged;

        // properties (非data、與data有關、本身為方法)

        // attributes (在properties上面添加attributes)
        [Browsable(false)]  //不顯示
        public ChartArea TheChartArea 
        {
            get => theArea;  //唯獨(給Fuzzy Set用)  //間接可以知道lowerBound、upperBound...
        }
        [Category("Display")]
        public string Title
        {
            get => theArea.AxisX.Title;  //=>：Lambda operator
            set
            {
                theArea.AxisX.Title = value;
            }
        }
        [Category("Parameters"), Description("Must be less than UpperBound.")]
        public double LowerBound  //LowerBound：property
        {
            get
            {
                //return lowerBound;  //lowerBound：data
                return theArea.AxisX.Minimum; 
            }
            set
            {
                //guarding
                if (value < theArea.AxisX.Maximum)
                {
                    theArea.AxisX.Minimum = value; //value：保留值
                    // fire ParameterChanged event
                    //if (ParameterChanged != null)
                    ParameterChanged(this, "Lower Bound Changed");
                }
            }
        }
        [Category("Parameters"), Description("Must be greater than LowerBound.")]
        public double UpperBound  //UpperBound：property
        {
            get
            {
                return theArea.AxisX.Maximum;
            }
            set
            {
                //guarding
                if (value > theArea.AxisX.Minimum) theArea.AxisX.Maximum = value;
            }
        }
        [Category("Parameters"),Description("Number of points in a Fuzzy Set curve ;\nmust be greater than 9.")]
        public int Resolution  //Resolution：property
        {
            get
            {
                return resolution;  //resolution：data
            }
            set
            {
                //guarding
                if (value < 10) return;
                resolution = value;
            }
        }
        [Browsable(false)]
        public double Increment
        {
            get => (UpperBound - LowerBound) / (resolution - 1);  //-1為interval
        }

        //物件導向(data encapsulation)：自己掌管(data修改需要符合物件的integrated)
        //以前作法：
        //public double GetLowerBound()  //取用
        //{
        //    return lowerBound;
        //}

        //public void SetLowerBound(double newLow)  //設定(no return)
        //{
        //    把關(合乎規定才執行)
        //    if (newLow < upperBound) lowerBound = newLow;
        //}
        

        // function (Microsoft：method)

        //以前作法：先蒐集到Universe()裡的值，導致人機介面複雜(過多label、textbox)
        //public Universe(string t, double min, double max, int res)  //建構函式：不能return
        //{
        //    title = t;
        //    lowerBound = min;
        //    upperBound = max;
        //    resolution = res;
        //}

        //overload constuctor
        //關鍵字(暗碼)：ctor(constructor)、按Tab鍵兩下
        public Universe( Chart mainChart )
        {
            //初始化(因資料重複，放入ChartArea)
            //title = $"Universe{counter++}";   //不需要獨立title
            //lowerBound = 0;
            //upperBound = 10;

            string s = $"Universe{counter++}";  //sweet string  //s：區域變數
            resolution = 100;

            theArea = new ChartArea(s);
            //外觀設計
            theArea.BackColor = Color.SeaShell;
            theArea.AxisX.LineColor = Color.Gray;
            theArea.AxisY.LineColor = Color.Gray;
            theArea.AxisX.LineWidth = 2;
            theArea.AxisY.LineWidth = 2;
            theArea.AxisX.MajorGrid.LineColor = Color.Silver;
            theArea.AxisY.MajorGrid.LineColor = Color.Silver;
            theArea.AxisX.TitleFont = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            theArea.AxisY.TitleFont = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            theArea.AxisX.LabelStyle.Font = new Font("微軟正黑體", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            theArea.AxisY.LabelStyle.Font = new Font("微軟正黑體", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            
            theArea.AxisX.Title = s;
            theArea.AxisX.Minimum = 0;
            theArea.AxisX.Maximum = 10;
            theArea.AxisX.Enabled = AxisEnabled.True;  //enumeration列舉//Auto：沒有series不會顯現出來
            theArea.AxisY.Title = "Membership Degree";
            theArea.AxisY.Enabled = AxisEnabled.True;
            theArea.Tag = mainChart;  //讓Fuzzy Set知道mainChart

            mainChart.ChartAreas.Add(theArea);
        }
    }
}
