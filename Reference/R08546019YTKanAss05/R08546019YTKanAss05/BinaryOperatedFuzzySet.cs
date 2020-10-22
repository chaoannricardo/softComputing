using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class BinaryOperatedFuzzySet : FuzzySet  //繼承  //與GaussianFuzzySet同位階
    {
        // data
        FuzzySet theOperand1;
        FuzzySet theOperand2;
        BinaryFuzzySetOperator theOperator;

        // properties
        [Category("Parameters"), TypeConverter(typeof(ExpandableObjectConverter))]
        public BinaryFuzzySetOperator TheOperator
        {
            get => theOperator;
        }

        // constructor
        public BinaryOperatedFuzzySet(FuzzySet operand1, FuzzySet operand2, BinaryFuzzySetOperator op) : base(operand1.TheUniverse)  //operand1、operand2為相同universe
        //need：存在兩個相同universe的fuzzy set、一個BinaryOperator
        {
            //subscribe ParameterChanged event of the universe(父親Fuzzy Set已完成)
            //keep一份在物件本身(收藏operand、op)
            theOperand1 = operand1;  //基礎的fuzzy set
            theOperand2 = operand2;
            //subscrtheOperand1 = operand1;ibe ParameterChanged event
            theOperand1.ParameterChanged += TheOperand_ParameterChanged;  //depend on operand1、operand2
            theOperand2.ParameterChanged += TheOperand_ParameterChanged;

            theOperator = op;
            theOperator.OperatorParameterChanged += TheOperand_ParameterChanged;

            title = op.Title + operand1.Title + "" +operand2.Title ;
        }

        protected void TheOperand_ParameterChanged(object sender, EventArgs e)
        {
            //update series point if it is shown
            UpdateSeriesPoints();
            //fire ParameterChanged event  //別人depend on你
            FireParameterChangedEvent();
        }

        public override double GetMembershipDegree(double x)  //override GetMembershipDegree
        {
            double originalValue1 = theOperand1.GetMembershipDegree(x);
            double originalValue2 = theOperand2.GetMembershipDegree(x);
            double finalValue = theOperator.Calculate(originalValue1,originalValue2);
            return finalValue;           
        }
    }
}
