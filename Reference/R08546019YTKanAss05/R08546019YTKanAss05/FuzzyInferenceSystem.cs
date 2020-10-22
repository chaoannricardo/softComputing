using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546019YTKanAss05
{
    class FuzzyInferenceSystem
    {
        protected IfThenRule[] rules;

        public FuzzyInferenceSystem(IfThenRule[] r)
        {
            rules = r;
        }

        public virtual FuzzySet FuzzyInFuzzyOutInference(FuzzySet[] conditions,  bool isCutting)
        {
            throw new NotImplementedException();
        }
        public virtual FuzzySet CrispInFuzzyOutInference(double[] conditions, bool isCutting)
        {
            throw new NotImplementedException();
        }

        public virtual double FuzzyInCrispOutInference(FuzzySet[] conditions, DefuzzificationType dif, bool isCutting)
        {
            throw new NotImplementedException();
        }
        public virtual double FuzzyInCrispOutInference(FuzzySet[] conditions )
        {
            throw new NotImplementedException();
        }


        public virtual double CrispInCrispOutInference(double[] conditions, DefuzzificationType dif, bool isCutting)
        {
            throw new NotImplementedException();
        }
        public virtual double CrispInCrispOutInference(double[] conditions)
        {
            throw new NotImplementedException();
        }
    }

    class MamdaniInferenceSystem : FuzzyInferenceSystem
    {
  
        public MamdaniInferenceSystem( IfThenRule[] rules ) : base (rules)
        {
        }

        public override FuzzySet CrispInFuzzyOutInference(double[] conditions, bool isCutting)
        {
            FuzzySet result = null;
            // inference each rules
            for (int i = 0; i < rules.Length; i++)
            {
                FuzzySet ruleOut = rules[i].Inferencing(conditions, isCutting);//結果為fuzzy set
                if (result == null) result = ruleOut;  //i=0，result=null
                else
                    //result = result | ruleOut;  //原本rule1的ruleOut聯集rule2的ruleOut
                    result |= ruleOut;
            }
            return result;
        }
        public override FuzzySet FuzzyInFuzzyOutInference(FuzzySet[] conditions, bool isCutting)
        {
            FuzzySet result = null;
            // inference each rules
            for (int i = 0; i < rules.Length; i++)
            {
                FuzzySet ruleOut = rules[i].Inferencing(conditions,isCutting); //結果為fuzzy set
                if (result == null) result = ruleOut;  //i=0，result=null
                else
                    //result = result | ruleOut;  //原本rule1的ruleOut聯集rule2的ruleOut
                    result |= ruleOut;
            }
            return result;
        }

    }

    class SugenoInferenceSystem : FuzzyInferenceSystem
    {
        public SugenoInferenceSystem(IfThenRule[] rules) : base(rules)
        {

        }
    }
}
