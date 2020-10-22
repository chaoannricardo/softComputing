using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class UnaryOperatedFuzzySet : FuzzySet  //繼承  //與GaussianFuzzySet同位階
    {
        // data
        FuzzySet theOperand;
        UnaryFuzzySetOperator theOperator;
        
        // properties
        [Category("Parameters"),TypeConverter(typeof(ExpandableObjectConverter))]
        public UnaryFuzzySetOperator TheOperator
        {
            get => theOperator;
        }

        // constructor
        public UnaryOperatedFuzzySet(FuzzySet operand, UnaryFuzzySetOperator op) : base(operand.TheUniverse) //universe為多餘：在fuzzy set已定義相同universe(存在operand)
        //operand、op：區域變數(函式執行完變數不存在)
        //need：存在的fuzzy set、一個UnaryOperator
        //public UnaryOperatedFuzzySet(Universe v) : base(v)
        {
            //subscribe ParameterChanged event of the universe(父親Fuzzy Set已完成)
            //keep一份在物件本身(收藏operand、op)
            theOperand = operand;  //基礎的fuzzy set
            //subscribe ParameterChanged event
            theOperand.ParameterChanged += TheOperand_ParameterChanged;  //depend on operand
                
            theOperator = op;
            theOperator.OperatorParameterChanged += TheOperand_ParameterChanged;  //與TheOperand_ParameterChanged執行的內容相同，可直接使用    

            title = op.Title + operand.Title;
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
            double originalValue = theOperand.GetMembershipDegree(x);  //得到fuzzy set的歸屬度
            double finalValue = theOperator.Calculate(originalValue);
            return finalValue;

            //return theOperator.Caluculate(theOperand.GetMembershipDegree(x));
        }
    }
}
