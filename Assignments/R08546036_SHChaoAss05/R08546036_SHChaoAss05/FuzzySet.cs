using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
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
        private Series bindedSeries;
        #endregion

        // operator overloaded
        // Unary operators ####################################################
        // negate
        public static FuzzySet operator !(FuzzySet fs)
        {
            UnaryFSOperator op = new NegateOperator();
            return new UnaryOperatedFuzzySet(fs, op);
        }

        // for value scale operator
        public static FuzzySet operator *(FuzzySet fs, double scaleValue)
        {
            ValueScaleOperator op = new ValueScaleOperator();
            op.ScaleValue = scaleValue;
            return new UnaryOperatedFuzzySet(fs, op);
        }

        // binary operators ####################################################
        // cut: binary operation for Fuzzy Set


        // for union binary operation
        public static FuzzySet operator |(FuzzySet leftFS, FuzzySet rightFS)
        {
            UnionOperator op = new UnionOperator();
            return new BinaryOperatedFuzzySet(leftFS, rightFS, op);
        }

        // for intersection binary operation
        public static FuzzySet operator &(FuzzySet leftFS, FuzzySet rightFS)
        {
            IntersectionOperator op = new IntersectionOperator();
            return new BinaryOperatedFuzzySet(leftFS, rightFS, op);
        }

        // binary and unary oprations ####################################################
        public static FuzzySet operator -(FuzzySet fs, object secondInput)
        {
            // determine wheter unary or binary operation
            if (secondInput is double)
            {
                // unary operation: cut
                ValueCutOperator op = new ValueCutOperator();
                op.CutValue = (double)secondInput;
                return new UnaryOperatedFuzzySet(fs, op);
            }
            else if (secondInput is FuzzySet)
            {
                // binary operation: substract
                SubstractionOperator op = new SubstractionOperator();
                return new BinaryOperatedFuzzySet(fs,
                                (FuzzySet)secondInput,
                                op);
            }
            else {
                return null;
            }
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

        [Category("Property"), Browsable(false)]
        public virtual double MaxDegree
        {
            get
            {
                // initiate maxDegree Variable
                double maxDegree = 0.0;
                if (theSeries == null)
                {
                    // traverse the range of universe to get the maximum degree
                }
                else
                {
                    // traverse each DataPoint of the series
                    for (int i = 0; i < theSeries.Points.Count; i++)
                    {
                        if (theSeries.Points[i].YValues[0] > maxDegree)
                        {
                            maxDegree = theSeries.Points[i].YValues[0];
                        }
                    }
                }
                return 0.0;
            }
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
                    // Fire parameterChanged event
                    FireParameterChanged();
                }
                catch (System.ArgumentException Exception)
                {
                    MessageBox.Show("Title name already exists!!!");
                }
            }
        }

        //[TypeConverter(typeof(ExpandableObjectConverter)), Category("Universe Property")]
        [Category("Property"), Browsable(false)]
        public Universe TheUniverse
        {
            get { return theUniverse; }
            set { }

        }

        [Browsable(false)]
        public Series BindedSeries
        {
            get
            {
                return bindedSeries;
            }
            set
            {
                if (value is Series)
                {
                    bindedSeries = value;
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

        public override string ToString()
        {
            return title;
        }

        public void UpdateSeriesDataPoints()
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
                theSeries.ToolTip = $"Chart of {Title} Series";
            }
            // series count index
            this.BindedSeries = theSeries;
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

    class BellFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Attributes
        [Category("MemberFunctionParameters"), Description(""),
            DisplayName("Information")]

        // Parameters
        public double A_Value
        {
            set
            {
                if (value is double)
                {
                    parameters[0] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[0];
            }

        }
        public double B_Value
        {
            set
            {
                if (value is double)
                {
                    parameters[1] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[1];
            }

        }
        public double C_Value
        {
            set
            {
                if (value is double)
                {
                    parameters[2] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[2];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            return 1 / (1 + Math.Pow(Math.Abs((x - parameters[2]) / parameters[0]), (2 * parameters[1])));
        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public override string Core => $"{theUniverse.Title}={parameters[0]}";


        public BellFuzzySet(Universe u) : base(u)
        {
            parameters = new double[3];
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum);
            parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
            parameters[2] = (u.Maximum - u.Minimum) * randomizer.NextDouble();

            title = $"Bell Fuzzy Set {++count}";
        }
    }

    class TriangularFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Parameters: Left, Peak, Right
        [Category("MembershipParameters")]
        public double Left
        {
            set
            {
                if (value is double)
                {
                    parameters[0] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();

                }
            }
            get
            {
                return parameters[0];
            }

        }
        [Category("MembershipParameters")]
        public double Peak
        {
            set
            {
                if (value is double)
                {
                    parameters[1] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[1];
            }

        }
        [Category("MembershipParameters")]
        public double Right
        {
            set
            {
                if (value is double)
                {
                    parameters[2] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[2];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            double yValue;
            if (x <= parameters[0])
            {
                yValue = 0;
            }
            else if (x <= parameters[1])
            {
                yValue = (x - parameters[0]) / (parameters[1] - parameters[0]);
            }
            else if (x <= parameters[2])
            {
                yValue = (parameters[2] - x) / (parameters[2] - parameters[1]);
            }
            else
            {
                yValue = 0;
            }
            return yValue;
        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public override string Core => $"{theUniverse.Title}={parameters[0]}";

        public TriangularFuzzySet(Universe u) : base(u)
        {
            parameters = new double[3];
            while (true)
            {
                parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum);
                parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
                parameters[2] = (u.Maximum - u.Minimum) * randomizer.NextDouble();

                if (parameters[2] > parameters[1] && parameters[1] > parameters[0])
                {
                    break;
                }

            }

            title = $"Triangular Fuzzy Set {++count}";
        }

    }

    class GaussianFuzzySet : FuzzySet
    {
        static int count = 0;
        public override double MaxDegree => 1.0;

        // properties
        // Attributes
        [Category("MembershipParameters"), Description("The location of the symmetric point"),
            DisplayName("Information")]

        public double Center
        {
            set
            {
                if (value is double)
                {
                    parameters[0] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[0];
                FireParameterChanged();
            }

        }
        [Category("MembershipParameters")]

        public double Std
        {
            set
            {
                if (value is double)
                {
                    parameters[1] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[1];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            return Math.Exp(-0.5 * (x - parameters[0]) * (x - parameters[0]) / parameters[1] / parameters[1]);
        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public override string Core => $"x={parameters[0]}";
        public override string Support => $"(x={theUniverse.Minimum})~(x={theUniverse.Maximum})";


        public GaussianFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum);

            while (true)
            {
                parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble() / 10.0;

                if (Math.Abs(parameters[1]) > 1)
                {
                    break;
                }

            }

            title = $"Gaussian Fuzzy Set {++count}";
        }

    }

    class SigmoidFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Attributes
        [Category("MemberFunctionParameters"), Description(""),
            DisplayName("Information")]

        // Parameters
        public double A_Value
        {
            set
            {
                if (value is double)
                {
                    parameters[0] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();

                }
            }
            get
            {
                return parameters[0];
            }

        }
        public double B_Value
        {
            set
            {
                if (value is double)
                {
                    parameters[1] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[1];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            return 1 / (1 + Math.Exp((-parameters[0]) * (x - parameters[1])));
        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public override string Core => $"{theUniverse.Title}={parameters[0]}";


        public SigmoidFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = u.Minimum + randomizer.NextDouble() * (u.Maximum - u.Minimum);
            parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble();

            title = $"Sigmoidal Fuzzy Set {++count}";
        }
    }

    class TrapezoidalFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Parameters: Left, Peak, Right
        [Category("MembershipParameters")]
        public double Left
        {
            set
            {
                if (value is double)
                {
                    parameters[0] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[0];
            }

        }
        [Category("MembershipParameters")]
        public double Peak_A
        {
            set
            {
                if (value is double)
                {
                    parameters[1] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[1];
            }

        }
        [Category("MembershipParameters")]
        public double Peak_B
        {
            set
            {
                if (value is double)
                {
                    parameters[2] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[2];
            }

        }
        [Category("MembershipParameters")]
        public double Right
        {
            set
            {
                if (value is double)
                {
                    parameters[3] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[3];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            if (x < parameters[0])
            {
                return 0;
            }
            else if (x < parameters[1])
            {
                return (x - parameters[0]) / (parameters[1] - parameters[0]);
            }
            else if (x < parameters[2])
            {
                return 1;
            }
            else if (x < parameters[3])
            {
                return (parameters[3] - x) / (parameters[3] - parameters[2]);
            }
            else
            {
                return 0;
            }

        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public override string Core => $"{theUniverse.Title}={parameters[0]}";

        public TrapezoidalFuzzySet(Universe u) : base(u)
        {
            parameters = new double[4];
            ;

            while (true)
            {
                parameters[0] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
                parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
                parameters[2] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
                parameters[3] = (u.Maximum - u.Minimum) * randomizer.NextDouble();

                if (parameters[3] > parameters[2] &&
                parameters[2] > (parameters[1] + 2) && parameters[1] > parameters[0])
                {
                    break;
                }

            }

            title = $"TrapezoidalFuzzySet {++count}";
        }
    }

    class LeftRightFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Parameters: Left, Peak, Right
        [Category("MembershipParameters")]
        public double ParameterA
        {
            set
            {
                if (value is double)
                {
                    parameters[0] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[0];
            }

        }
        [Category("MembershipParameters")]
        public double ParameterB
        {
            set
            {
                if (value is double)
                {
                    parameters[1] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[1];
            }

        }
        [Category("MembershipParameters")]
        public double ParameterC
        {
            set
            {
                if (value is double)
                {
                    parameters[2] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[2];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            if (x < parameters[2])
            {
                if (0 < (1 - Math.Pow(((parameters[2] - x) / parameters[0]), 2)))
                {
                    return (1 - Math.Pow(((parameters[2] - x) / parameters[0]), 2));
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return Math.Exp(-Math.Pow(Math.Abs((x - parameters[2]) / parameters[1]), 3));
            }
        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public override string Core => $"{theUniverse.Title}={parameters[0]}";

        public LeftRightFuzzySet(Universe u) : base(u)
        {
            parameters = new double[3];
            parameters[0] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
            parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble() + (0.5);
            parameters[2] = parameters[1] + 3;

            title = $"LeftRightFuzzySet {++count}";
        }

    }

    class SMFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Parameters: Left, Right
        [Category("MembershipParameters")]
        public double Left
        {
            set
            {
                if (value is double && value <= this.Right)
                {
                    parameters[0] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[0];
            }

        }
        [Category("MembershipParameters")]
        public double Right
        {
            set
            {
                if (value is double && value >= this.Left)
                {
                    parameters[1] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[1];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            if (x <= parameters[0])
            {
                return 0;
            }
            else if (x <= ((1 + parameters[0]) / 2))
            {
                return 2 * Math.Pow(((x - parameters[0]) / (parameters[1] - parameters[0])), 2);
            }
            else if (x <= parameters[1])
            {
                return 1 - (2 * Math.Pow(((x - parameters[0]) / (parameters[1] - parameters[0])), 2));
            }
            else
            {
                return 1;
            }
        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public SMFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
            parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble() + (2);

            title = $"SMFuzzySet {++count}";
        }

    }

    class ZMFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Parameters: Left, Right
        [Category("MembershipParameters")]
        public double Left
        {
            set
            {
                if (value is double && value <= this.Right)
                {
                    parameters[0] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[0];
            }

        }
        [Category("MembershipParameters")]
        public double Right
        {
            set
            {
                if (value is double && value >= this.Left)
                {
                    parameters[1] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[1];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            if (x <= parameters[0])
            {
                return 1;
            }
            else if (x <= ((1 + parameters[0]) / 2))
            {
                return 1 - (2 * Math.Pow(((x - parameters[0]) / (parameters[1] - parameters[0])), 2));
            }
            else if (x <= parameters[1])
            {
                return (2 * Math.Pow(((x - parameters[0]) / (parameters[1] - parameters[0])), 2));
            }
            else
            {
                return 0;
            }
        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public ZMFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
            parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble() + (2);

            title = $"ZMFuzzySet {++count}";
        }

    }

    class PiFuzzySet : FuzzySet
    {
        static int count = 0;

        // properties
        // Parameters: Left, Right
        [Category("MembershipParameters")]
        public double ParameterA
        {
            set
            {
                if (value is double)
                {
                    parameters[0] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[0];
            }

        }
        [Category("MembershipParameters")]
        public double ParameterC
        {
            set
            {
                if (value is double)
                {
                    parameters[1] = value;

                    // Fire parameterChanged event
                    FireParameterChanged();
                }
            }
            get
            {
                return parameters[1];
            }

        }

        public override double GetMembershipDegree(double x)
        {
            if (x <= this.ParameterC)
            {
                return SMFFunction(x, (ParameterC - ParameterA), ParameterC);
            }
            else
            {
                return (1 - SMFFunction(x, (ParameterC - ParameterA), ParameterC));
            }
        }

        // Fuzzy Set Properties
        // override virtual property of parent class 
        public PiFuzzySet(Universe u) : base(u)
        {
            parameters = new double[2];
            parameters[0] = (u.Maximum - u.Minimum) * randomizer.NextDouble();
            parameters[1] = (u.Maximum - u.Minimum) * randomizer.NextDouble() + (2);

            title = $"PiFuzzySe {++count}";
        }

        private double SMFFunction(double x, double left, double right)
        {
            if (x <= left)
            {
                return 0;
            }
            else if (x <= ((1 + left) / 2))
            {
                return 2 * Math.Pow(((x - left) / (right - left)), 2);
            }
            else if (x <= parameters[1])
            {
                return 1 - (2 * Math.Pow(((x - left) / (right - left)), 2));
            }
            else
            {
                return 1;
            }

        }
    }

}
