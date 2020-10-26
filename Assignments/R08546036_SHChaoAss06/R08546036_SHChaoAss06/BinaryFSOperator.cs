using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546036_SHChaoAss04
{
    abstract class BinaryFSOperator
    {
        // variables
        #region variables
        protected Random rnd = new Random();
        #endregion

        // Properties
        public virtual string Title
        {
            get { 
                return "";
            }
            set {
                Title = value;
            }
        }

        // Data
        private double[] parameters;

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
        public abstract double Evaluate(double a, double b);
    }

    // Union
    class UnionOperator : BinaryFSOperator 
    {
        public override string Title { get => "Union: "; set => base.Title = value; }
        public UnionOperator()
        {

        }
        public override double Evaluate(double a, double b)
        {
            return Math.Max(a, b);
        }

    }

    // Intersection (Minimum T-norm)
    class IntersectionOperator : BinaryFSOperator
    {
        public override string Title { get => "Intersection: "; set => base.Title = value; }
        public IntersectionOperator()
        {

        }
        public override double Evaluate(double a, double b)
        {
            return Math.Min(a, b);
        }

    }

    // Substraction
    class SubstractionOperator : BinaryFSOperator
    {
        public override string Title { get => "Substraction: "; set => base.Title = value; }
        public SubstractionOperator()
        {

        }
        public override double Evaluate(double a, double b)
        {
            return (a-b) >= 0 ? (a-b) : 0;
        }

    }

    // T-norm: Minimum 
    class TNormMinimumOperator : BinaryFSOperator
    {
        public override string Title { get => "T-norm, Minimum: "; set => base.Title = value; }
        public TNormMinimumOperator()
        {

        }
        public override double Evaluate(double a, double b)
        {
            return Math.Min(a, b);
        }

    }

    // T-norm: Algebraic
    class TNormAlgebraicOperator : BinaryFSOperator
    {
        public override string Title { get => "T-norm, Algebraic Product: "; set => base.Title = value; }
        public TNormAlgebraicOperator()
        {

        }
        public override double Evaluate(double a, double b)
        {
            return (a * b);
        }

    }

    // T-norm: Bounded
    class TNormBoundedOperator : BinaryFSOperator
    {
        public override string Title { get => "T-norm, Bounded Product: "; set => base.Title = value; }
        public TNormBoundedOperator()
        {

        }
        public override double Evaluate(double a, double b)
        {
            return Math.Max(0, (a+b-1));
        }
    }

    // T-norm: Drastic
    class TNormDrasticOperator : BinaryFSOperator
    {
        public override string Title { get => "T-norm, Drastic Product: "; set => base.Title = value; }
        public TNormDrasticOperator()
        {

        }
        public override double Evaluate(double a, double b)
        {
            if (b == 1)
            {
                return a;
            }
            else if (a == 1)
            {
                return b;
            }
            else {
                return 0;
            }
        }
    }

    // S-norm: Maximum
    class SNormMaximumOperator : BinaryFSOperator
    {
        public override string Title { get => "S-norm, Maximum: "; set => base.Title = value; }
        public SNormMaximumOperator()
        {

        }
        public override double Evaluate(double a, double b)
        {
            return Math.Max(a, b);   
        }
    }

    // S-norm: Algebraic
    class SNormAlgebraicOperator : BinaryFSOperator
    {
        public override string Title { get => "S-norm, Algebraic: "; set => base.Title = value; }
        public SNormAlgebraicOperator()
        {

        }
        public override double Evaluate(double a, double b)
        {
            return (a + b - a * b);
        }
    }

    // S-norm: Bounded
    class SNormBoundedOperator : BinaryFSOperator
    {
        public override string Title { get => "S-norm, Bounded: "; set => base.Title = value; }
        public SNormBoundedOperator()
        {

        }
        public override double Evaluate(double a, double b)
        {
            return Math.Min(1, (a+b));
        }
    }

    // S-norm: Drastic
    class SNormDrasticOperator : BinaryFSOperator
    {
        public override string Title { get => "S-norm, Drastic: "; set => base.Title = value; }
        public SNormDrasticOperator()
        {

        }
        public override double Evaluate(double a, double b)
        {
            if (b == 0)
            {
                return a;
            }
            else if (a == 0)
            {
                return b;
            }
            else {
                return 1;
            }
        }
    }

}
