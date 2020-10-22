using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546023KWChangAss05
{
    //define delegate event function
    //void : not return
   public delegate void ParameterChangeEventFunction(object sender, string s);
    
    //origally is internal(can not be used outside)
    //public can be used outside
    class Universe
    {
        //class-scope data (流水號)
        //dynamic(setting) : object run in the middle of process
        //static : prepared before runnug the program
        static int counter = 1; //initialize


        //data
        int resolution; //the greater the resolutionis, the smoother the line would be
        ChartArea theArea; //double data; x-axis is title, y-axis is MemberShipDegree
        

        //events : purple case sign
        //usualiy public
        public event ParameterChangeEventFunction ParameterChanged;


        //properties : is a method, not a data, beut related to data
        //attribute
        [Browsable(false)] //not show
        public ChartArea TheChartArea { get => theArea; }
        
        //attribute
        [Browsable(false)]
        public double Increment
        {
            get => ((UpperBound - LowerBound) / (resolution - 1));
        }
        //attribute
        [Category("Class"), Description("The title of universe.")]
        public string Title
        {
            get => theArea.AxisX.Title;
            set
            {
                theArea.AxisX.Title = value;
            }
        }
        //attribute
        [Category("Parameters"), Description("Must be less the Upper Bound.")]
        public double LowerBound
        {
            get
            {
                //return LowerBound
                return theArea.AxisX.Minimum;
            }
            set
            {
                //guarding
                if (value < theArea.AxisX.Maximum)
                {
                    theArea.AxisX.Minimum = value;
                    //fire ParameterChanged event
                    //if(ParameterChanged != null)
                    ParameterChanged(this, "Lower Bound Changed");
                }
            }
        }
        //attribute
        [Category("Parameters"), Description("Must be greater than Lower Bound.")]
        public double UpperBound
        {
            get
            {
                return theArea.AxisX.Maximum;
            }
            set
            {
                //guarding
                if (value > theArea.AxisX.Minimum)
                {
                    theArea.AxisX.Maximum = value;
                    //fire ParameterChanged event
                    //if(ParameterChanged != null) //redundant
                    ParameterChanged(this, "Upper Bound Changed"); //this : Universe object (tell the user the information through the parameter)
                }
            }
        }
        //attribute
        [Category("Parameters"),Description("Number of points of a fuzzy set; must be greater than 9.")]
        public int Resolution
        {
            get => resolution;
            set
            {
                //guarding
                if (value < 10) return;
                resolution = value;
                //fire ParameterChanged event
                //if(ParameterChanged != null) //redundant
                ParameterChanged(this, "Resolution Changed");
            }
        }
        

        //function, method
        public Universe( Chart mainChart )
        {
            string s = $"Universe{counter++}";
            resolution = 100;
            theArea = new ChartArea(s);
            theArea.BackColor = Color.Cornsilk;
            theArea.AxisX.Title = s;
            theArea.AxisX.Minimum = 0;
            theArea.AxisX.Maximum = 10;
            theArea.AxisX.Enabled = AxisEnabled.True;
            theArea.AxisX.TitleFont = new Font("Calibri", 11F, style: FontStyle.Bold, unit: GraphicsUnit.Point, gdiCharSet: 0);
            theArea.AxisX2.TitleFont = new Font("Calibri", 9.75F, style: FontStyle.Regular, unit: GraphicsUnit.Point, gdiCharSet: 0); 
            theArea.AxisY.Title = "Membership Degree";
            theArea.AxisY.Enabled = AxisEnabled.True;
            theArea.AxisY.TitleFont = new Font("Calibri", 11F, style: FontStyle.Bold, unit: GraphicsUnit.Point, gdiCharSet: 0);
            theArea.AxisY2.TitleFont = new Font("Calibri", 9.75F, style: FontStyle.Regular, unit: GraphicsUnit.Point, gdiCharSet: 0);
            theArea.Tag = mainChart;
            mainChart.ChartAreas.Add(theArea);
        }
    }
}
