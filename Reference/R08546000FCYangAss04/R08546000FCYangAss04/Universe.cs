using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546000FCYangAss04
{
    class Universe
    {
        // class-scope data
        static int counter = 1;
        // data
        string title;
        double lowrBound;
        double upperBound;
        int resolution;
        ChartArea theArea;

        // properties
        public double LowerBound
        {
            get
            {
                return lowrBound;
            }
            set
            {
                // guarding
                if (value < upperBound) lowrBound = value;
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
            }
        }

        public double GetLowerBound()
        {
            return lowrBound;
        }
        public void SetLowerBound( double newLow )
        {
            if( newLow < upperBound )  lowrBound = newLow;
        }

        // function, method
        public Universe( string t, double min, double max, int res)
        {
            title = t;
            lowrBound = min;
        }

        public Universe( Chart mainChart )
        {
            title = $"Universe{counter++}";
            lowrBound = 0;
            upperBound = 10;
            resolution = 100;
            theArea = new ChartArea(title);
            theArea.BackColor = Color.Pink;
            mainChart.ChartAreas.Add(theArea);
        }

    }
}
