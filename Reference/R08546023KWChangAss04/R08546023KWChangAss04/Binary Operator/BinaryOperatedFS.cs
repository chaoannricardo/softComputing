using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class BinaryOperatedFS : FuzzySet
    {
        //要提供fuzzy set和運算式參照
        //Fuzzy set就有Universe
        //子類別要有儲存data(fuzzy set) 否則進來稍縱即逝
        FuzzySet theOperand1;
        FuzzySet theOperand2;
        BinaryFSOperator theOperator;

        //properties
        [Category(""), TypeConverter(typeof(ExpandableObjectConverter))]
        public BinaryFSOperator TheOperator
        {
            get => theOperator;
        }

        public BinaryOperatedFS(FuzzySet operand1, FuzzySet operand2, BinaryFSOperator op) : base(operand1.TheUniverse)
        {
            //FuzzySet has subscribe ParameterChanged event
            //在子類別儲存一份data
            theOperand1 = operand1;
            theOperand2 = operand2;
            //FuzzySet的參數改變 Unary也要跟著改變
            theOperand1.ParameterChanged += TheOperand_ParameterChanged;
            theOperand2.ParameterChanged += TheOperand_ParameterChanged;
            theOperator = op;
            theOperator.OperatorParameterChanged += TheOperand_ParameterChanged;

            title = op.Title + operand1.Title + " & " + operand2.Title + Title;
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
            double originalValue1 = theOperand1.GetMembershipDegree(x);
            double originalValue2 = theOperand2.GetMembershipDegree(x);
            //Bnary算出的值
            double finalValue = theOperator.Calculate(originalValue1, originalValue2);
            return finalValue;
        }
    }
}

