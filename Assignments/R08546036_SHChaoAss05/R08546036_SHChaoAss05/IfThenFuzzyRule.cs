using R08546036_SHChaoAss04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace R08546036_SHChaoAss05
{
    class IfThenFuzzyRule
    {
        FuzzySet[] antecedents;
        FuzzySet conclusion;
        public IfThenFuzzyRule(FuzzySet[] inputs, FuzzySet output)
        {
            antecedents = inputs;
            conclusion = output;


        }

        public FuzzySet FuzzyInFuzzyOutInferencing(FuzzySet[] conditions, bool isCut = true)
        {
            // fault-proof
            // 
            double fireValue = double.MaxValue;

            // debuged code
            FuzzySet tempFuzzy = null;
            return tempFuzzy;

            //// loop thorough each antecedent fuzzy set
            //for (int i = 0; i < antecedents.Length; i++)
            //{
            //    double maxDegree;
            //    maxDegree = (antecedents[i] & conditions[i]).MaxDegree;
            //    if (antecedents[i].TheUniverse != conditions[i].TheUniverse)
            //    {
            //        return null;
            //    }
                
            //    if (isCut)
            //    {
            //        return fireValue - conclusion;
            //    }
            //    else
            //    {
            //        return fireValue * conclusion;
            //    }
            //}




        }
    }
}
