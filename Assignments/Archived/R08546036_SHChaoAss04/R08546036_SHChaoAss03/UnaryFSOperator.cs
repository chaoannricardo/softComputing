using System;
using System.Collections.Generic;
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
        public override string Title { get => "Not"; set => base.Title = value; }
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
        public override string Title { get => "Cut"; set => base.Title = value; }
        public ValueCutOperator()
        {
            parameters = new double[1];
            parameters[0] = rnd.NextDouble();
        }

        public double CutValue
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

        public override double Evaluate(double a)
        {
            return a >= parameters[0] ? parameters[0] : a;
        }
    }
}
