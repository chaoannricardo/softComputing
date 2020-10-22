using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class UnaryOperatedFS : FuzzySet //繼承
    {
        //要提供fuzzy set和運算式參照
        //Fuzzy set就有Universe
        //子類別要有儲存data(fuzzy set) 否則進來稍縱即逝
        FuzzySet theOperand;
        UnaryFSOperator theOperator;

        //properties
        [Category(""),TypeConverter(typeof(ExpandableObjectConverter))]
        public UnaryFSOperator TheOperator
        {
            get => theOperator;
        }

        public UnaryOperatedFS( FuzzySet operand, UnaryFSOperator op ) : base( operand.TheUniverse )
        {
            //FuzzySet has subscribe ParameterChanged event
            //在子類別儲存一份data
            theOperand = operand;
            //FuzzySet的參數改變 Unary也要跟著改變
            theOperand.ParameterChanged += TheOperand_ParameterChanged;
            theOperator = op;
            theOperator.OperatorParameterChanged += TheOperand_ParameterChanged;

            title = op.Title + operand.Title + Title;
        }

        private void TheOperand_ParameterChanged(object sender, EventArgs e)
        {
            //update series points if it is shown
            UpdateSeriesPoints();
            //fire parameter changed events
            FireParameterChangedEvent();
        }

        //override return data of GetMembershipDegree function in FuzzySet
        //contructor進來,把operand送給父親去update Universe
        //把x送到FuzzySet算出MembershipDegree,再請Operator去算出真正的值
        public override double GetMembershipDegree(double x)
        {
            //FuzzySet運算出的值
            double originalValue = theOperand.GetMembershipDegree(x);
            //Unary算出的值
            double finalValue = theOperator.Calculate(originalValue);
            return finalValue;
        }
    }
}
