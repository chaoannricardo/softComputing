using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    public enum DefuzzificationType
    { COA, BOA, MOM, SOM, LOM};

    class IfThenRule
    {
        // Mamdani
        protected FuzzySet[] antecedents;  //前項：input fuzzy set(array)
        public IfThenRule(FuzzySet[] inputs)
        {
            antecedents = inputs;
        }

        // Fuzzy in fuzzy out Mamdani
        public virtual FuzzySet Inferencing( FuzzySet[] conditions, bool isCutting )
        {
            throw new Exception("No implementation!");
        }

        // Crisp in fuzzy out Mamdani
        public virtual FuzzySet Inferencing(double[] conditions, bool isCutting)
        {
            throw new Exception("No implementation!");
        }


        // Fuzzy in crisp out Tsukamoto, Sugeo
        public virtual double CrispOutferencing(FuzzySet[] conditions )
        {
            throw new Exception("No implementation!");
        }

        // Fuzzy in crisp out Mamdani
        public virtual double CrispOutInferencing(FuzzySet[] conditions, DefuzzificationType dif, bool isCutting )
        {
            throw new Exception("No implementation!");
        }

        // Crisp in crisp out Tsukamoto, Sugeo
        public virtual double CrispOutferencing(double[] conditions)
        {
            throw new Exception("No implementation!");
        }

        // Crisp in crisp out Mamdani
        public virtual double CrispOutInferencing(double[] conditions, DefuzzificationType dif, bool isCutting)
        {
            throw new Exception("No implementation!");
        }


    }
    class SugenoIfThenRule : IfThenRule
    {
        int outputEquationID;
        public SugenoIfThenRule(FuzzySet[] inputs, int outputIndex) : base(inputs)
        {
            outputEquationID = outputIndex;
        }


        double GetOutputValue(double[] inputs, int equationID)
        {
            switch (outputEquationID)
            {
                case 0: // Y=0.1X+6.4
                    return 0.1 * inputs[0] + 6.4;
                    break;
                case 1: // Y=0.5X+4
                    return 0.5 * inputs[0] + 4;
                    break;
            }
            return 0;
        }
    }

    // Mamdani, Tuskamoto
    class MamdaniIfThenRule : IfThenRule
    {
        FuzzySet output;         //後項：output只有一個

        // constructor
        public MamdaniIfThenRule(FuzzySet[] inputs, FuzzySet output) : base( inputs)
        {
            this.output = output;  //區域變數與成員變數相同
        }

        // function

        // {
        ///    return base.Inferencing(conditions, isCutting);
       /// }
        //Member Function名稱相同、參數內容不同(function overloaded函式多展)
        //Inference呼叫法有兩種(fuzzy Set or crisp value)
        //public FuzzySet Inference(FuzzySet[] conditions, bool cutting = true)  //cut & scale兩種：不設計enumeration  //不提供參數cut為true
       public override FuzzySet Inferencing(FuzzySet[] conditions, bool isCutting = true)
        {
            double fireStrength = double.MaxValue;  //antecedents與condion的MaxDegree取min
            for (int i = 0; i < antecedents.Length; i++)  
            {
                double d = (conditions[i] & antecedents[i]).MaxDegree;  //fuzzy set 交集 fuzzy set 取max
                if (d < fireStrength) fireStrength = d;  //前項：x,y,z...最小的
            }

            if (isCutting) return fireStrength - output;   //double - fuzzy set
            else return fireStrength * output;  //scale  //double * fuzzy set
        }

       // public FuzzySet Inference(double[] crispConditions, bool cutting = true)  //cut & scale兩種：不設計enumeration  //不提供參數cut為true
        public override FuzzySet Inferencing(double[] crispConditions, bool isCutting = true)
        {
            double fireStrength = double.MaxValue;  //antecedents的MembershipDegree(crisp)取min
            for (int i = 0; i < antecedents.Length; i++)
            {
                double d = antecedents[i].GetMembershipDegree(crispConditions[i]);  //crisp值切MembershipFunction
                if (d < fireStrength) fireStrength = d;  
            }

            if (isCutting) return fireStrength - output;   
            else return fireStrength * output;  
        }


        public override double CrispOutInferencing(FuzzySet[] conditions, DefuzzificationType dif, bool isCutting)
        {
            FuzzySet result = Inferencing(conditions, isCutting);
            switch( dif )
            {
                case DefuzzificationType.BOA:
                    return result.COA;
                case DefuzzificationType.COA:
                    return result.COA;
                default:
                    return result.COA;
            }
        }

        public override double CrispOutInferencing(double[] conditions, DefuzzificationType dif, bool isCutting)
        {
            FuzzySet result = Inferencing(conditions, isCutting);
            switch (dif)
            {
                case DefuzzificationType.BOA:
                    return result.COA;
                case DefuzzificationType.COA:
                    return result.COA;
                default:
                    return result.COA;
            }

        }
 
        //public override double CrispOutferencing(double[] conditions)
        //{
        //    return base.CrispOutferencing(conditions);
        //}

        //public override double CrispOutferencing(FuzzySet[] conditions)
        //{
        //    return base.CrispOutferencing(conditions);
        //}
    }
}
