using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class IfThenRule
    {
        FuzzySet[] antecedents;
        FuzzySet output;

        public IfThenRule( FuzzySet[] inputs, FuzzySet output )
        {
            antecedents = inputs;
            this.output = output; 
        }

        public FuzzySet Inference( FuzzySet[] conditions, bool cutting = true )
        {
            double fireStrength = double.MaxValue;
            for( int i = 0; i < antecedents.Length; i++)
            {
                double d = (conditions[i] & antecedents[i]).MaxDegree;
                if (d < fireStrength) fireStrength = d;
            }
            if (cutting) return fireStrength - output;
            else return fireStrength * output;
        }

        public FuzzySet Inference(double[] crispConditions, bool cutting = true)
        {
            double fireStrength = double.MaxValue;
            for (int i = 0; i < antecedents.Length; i++)
            {
                double d = antecedents[i].GetMembershipDegree(crispConditions[i]);
                if (d < fireStrength) fireStrength = d;
            }
            if (cutting) return fireStrength - output;
            else return fireStrength * output;
        }

    }
}
