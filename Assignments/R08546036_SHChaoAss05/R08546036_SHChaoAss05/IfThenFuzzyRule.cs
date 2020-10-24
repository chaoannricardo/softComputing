using R08546036_SHChaoAss04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            try
            {
                double fireValue = double.MaxValue;
                // fault-proof
                if (antecedents.Length != conditions.Length)
                {
                    MessageBox.Show("Not enough rule or condition is given.");
                    return null; ;
                }

                // loop thorough each antecedent fuzzy set
                for (int i = 0; i < antecedents.Length; i++)
                {
                    // cariables
                    double maxDegree;

                    // check if the universe is the same
                    if (antecedents[i].TheUniverse != conditions[i].TheUniverse)
                    {
                        MessageBox.Show("Conditions and Antecedents are not in same Universe");
                        return null;
                    }

                    maxDegree = (antecedents[i] & conditions[i]).MaxDegree;
                    if (maxDegree < fireValue) fireValue = maxDegree;

                }

                if (isCut)
                {
                    return conclusion - fireValue;
                }
                else
                {
                    return conclusion * fireValue;
                }
            }
            catch (System.NullReferenceException Exception)
            {
                MessageBox.Show("Not enough rule or condition is given.");
                return null;
            }
        }
    }
}
