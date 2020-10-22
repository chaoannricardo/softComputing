using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss04
{
    class UnaryOperatedFS : FuzzySet
    {
        FuzzySet theOperand;
        UnaryFSOperator theOperator;

        public UnaryOperatedFS( FuzzySet operand, UnaryFSOperator op ) : base( operand.TheUniverse)
        {
            theOperand = operand;
            theOperand.ParameterChanged += TheOperand_ParameterChanged;

            theOperator = op;
            title = op.Title + operand.Title + title;

        }

        private void TheOperand_ParameterChanged(object sender, EventArgs e)
        {
            // update series points if it is shown
            UpdateSeriesPoints();
            // fire parameter changed events 
            FireParameterChangedEvent();
        }

        public override double GetMembershipDegree(double x)
        {
            double originalValue = theOperand.GetMembershipDegree(x);
            double finalValue =  theOperator.Calculate(originalValue);
            return finalValue;
        }
    }
}
