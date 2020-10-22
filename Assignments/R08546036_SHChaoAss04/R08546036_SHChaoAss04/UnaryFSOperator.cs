using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546036_SHChaoAss04
{
    abstract class UnaryFSOperator
    {
        // Variables
        protected Random rnd = new Random();

        // Properties
        public virtual string Title
        {
            get
            {
                return "";
            }
            set
            {
                Title = value;
            }

        }
        public virtual double CutValue
        {
            get
            {
                return 0;
            }
            set
            {
                return;
            }
        }
        public virtual double ScaleValue
        {
            get
            {
                return 0;
            }
            set
            {
                return;
            }
        }

        // Data
        protected double[] parameters;

        // Events
        public event EventHandler ParameterChanged;

        protected void FireParameterChangedEvent()
        {
            if (ParameterChanged != null)
            {
                ParameterChanged(this, null);
            }
        }

        // Interfaces
        public abstract double Evaluate(double a);
    }

    class NegateOperator : UnaryFSOperator
    {
        // property
        public override string Title { get => "Not"; set => base.Title = value; }

        [Category("Not Used Parameters")]
        public override double CutValue { get => base.CutValue; }
        public override double ScaleValue { get => base.ScaleValue; }

        public NegateOperator()
        {

        }

        public override double Evaluate(double a)
        {
            return 1.0 - a;
        }
    }

    class ValueCutOperator : UnaryFSOperator
    {
        // construct function
        public ValueCutOperator()
        {
            parameters = new double[1];
            parameters[0] = rnd.NextDouble();
        }

        // properties
        public override string Title { get => "Cut"; set => base.Title = value; }

        public override double CutValue
        {
            get
            {
                return parameters[0];
            }
            set
            {
                if (value >= 0 && value <= 1.0)
                {
                    parameters[0] = value;
                    // Fire parameterChanged event
                    FireParameterChangedEvent();
                }
            }
        }

        [Category("Not Used Parameters")]
        public override double ScaleValue { get => base.ScaleValue; }

        // Evaluation Function
        public override double Evaluate(double a)
        {
            return a >= parameters[0] ? parameters[0] : a;
        }
    }

    class ValueScaleOperator : UnaryFSOperator
    {
        // construct function
        public ValueScaleOperator()
        {
            parameters = new double[1];
            parameters[0] = rnd.NextDouble();
        }

        // properties
        public override string Title { get => "Scale"; set => base.Title = value; }

        public override double ScaleValue { 
            get {
                return parameters[0];
            }
            set {
                if (value is double && value >= 0 && value <= 1) {
                    parameters[0] = value;
                    // Fire parameterChanged event
                    FireParameterChangedEvent();
                }
            }
        }

        [Category("Not Used Parameters")]

        public override double CutValue { get => 0; }

        // Evaluation Function
        public override double Evaluate(double a)
        {
            return a * parameters[0];
        }
    }

    class VeryOperator : UnaryFSOperator
    {
        // construct function
        public VeryOperator()
        {
        }

        // properties
        public override string Title { get => "Very"; set => base.Title = value; }

        [Category("Not Used Parameters")]
        public override double CutValue { get => base.CutValue; }
        public override double ScaleValue { get => base.ScaleValue; }

        // Evaluation Function
        public override double Evaluate(double a)
        {
            return Math.Pow(a, 2);
        }
    }

    class DilationOperator : UnaryFSOperator
    {
        // construct function
        public DilationOperator()
        {
        }

        // properties
        public override string Title { get => "Dilation"; set => base.Title = value; }

        [Category("Not Used Parameters")]
        public override double CutValue { get => base.CutValue; }
        public override double ScaleValue { get => base.ScaleValue; }

        // Evaluation Function
        public override double Evaluate(double a)
        {
            return Math.Pow(a, 0.5);
        }
    }

    class ExtremelyOperator : UnaryFSOperator
    {
        // construct function
        public ExtremelyOperator()
        {
        }

        // properties
        public override string Title { get => "Extremely"; set => base.Title = value; }

        [Category("Not Used Parameters")]
        public override double CutValue { get => base.CutValue; }
        public override double ScaleValue { get => base.ScaleValue; }

        // Evaluation Function
        public override double Evaluate(double a)
        {
            return Math.Pow(a, 8);
        }
    }

    class IntensificationOperator : UnaryFSOperator
    {
        // construct function
        public IntensificationOperator()
        {
        }

        // properties
        public override string Title { get => "Intensification"; set => base.Title = value; }

        [Category("Not Used Parameters")]
        public override double CutValue { get => base.CutValue; }
        public override double ScaleValue { get => base.ScaleValue; }

        // Evaluation Function
        public override double Evaluate(double a)
        {
            if (0.5 >= a && a >= 0)
            {
                return 2 * Math.Pow(a, 2);
            }
            else
            {
                return (1 - 2 * Math.Pow((1 - a), 2));
            }
        }
    }

    class DiminisherOperator : UnaryFSOperator
    {
        // construct function
        public DiminisherOperator()
        {
        }

        // properties
        public override string Title { get => "Diminisher"; set => base.Title = value; }

        [Category("Not Used Parameters")]
        public override double CutValue { get => base.CutValue; }
        public override double ScaleValue { get => base.ScaleValue; }

        // Evaluation Function
        public override double Evaluate(double a)
        {
            for (double yValue = 0; yValue <= 0.5; yValue += 0.00001)
            {
                if ((a - 0.0001) <= 2 * Math.Pow(yValue, 2) && (a + 0.0001) >= 2 * Math.Pow(yValue, 2))
                {
                    return yValue;
                }
            }
            for (double yValue = 0.5; yValue <= 1; yValue += 0.00001)
            {
                if ((a - 0.0001) <= (1 - 2 * Math.Pow((1 - yValue), 2)) && (a + 0.0001) >= (1 - 2 * Math.Pow((1 - yValue), 2)))
                {
                    return yValue;
                }
            }
            // not likely to return value 0
            return 0;
        }
    }
}
