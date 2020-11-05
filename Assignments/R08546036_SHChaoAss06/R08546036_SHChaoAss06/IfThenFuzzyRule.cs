using R08546036_SHChaoAss04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace R08546036_SHChaoAss06
{
    class IfThenFuzzyRule
    {
        FuzzySet[] antecedents;
        FuzzySet conclusion;

        // for weighted average requirement
        public double FiringSrength { get; set; } = 0.0;

        public IfThenFuzzyRule(FuzzySet[] inputs, FuzzySet output)
        {
            antecedents = inputs;
            conclusion = output;
        }

        // for Mamdani
        public FuzzySet FuzzyInFuzzyOutInferencing(FuzzySet[] conditions, bool isCut = true)
        {
            try
            {
                FiringSrength = 0.0;

                FiringSrength = double.MaxValue;

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
                    if (maxDegree < FiringSrength) FiringSrength = maxDegree;

                }

                if (isCut)
                {
                    return conclusion - FiringSrength;
                }
                else
                {
                    return conclusion * FiringSrength;
                }
            }
            catch (System.NullReferenceException Exception)
            {
                MessageBox.Show("Not enough rule or condition is given.");
                return null;
            }
        }

        public FuzzySet CrispInFuzzyOutInferencing(double[] conditions, bool isCut = true)
        {
            try
            {
                List<double> canditates = new List<double>();
                List<double> xDegree = new List<double>();
                List<double> yDegree = new List<double>();
                double fireValue;

                // loop thorough each antecedent fuzzy set
                for (int i = 0; i < antecedents.Length; i++)
                {
                    // variables
                    double maxDegree;

                    maxDegree = antecedents[i].GetMembershipDegree(conditions[i]);

                    canditates.Add(maxDegree);
                }

                fireValue = canditates.Min();

                //if (fireValue >= 0.5) {
                //    MessageBox.Show("Larger than 0.5");
                //}


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

        // for Tsukamoto
        public double FuzzyInCrispOutInferencing(FuzzySet[] conditions)
        {
            if (!conclusion.IsMonotonic) {
                // conclusion should be monotic
                return double.NaN;
            }

            //// inference process of tsukamoto
            //// Firing Strength
            //conclusion.GetUniverseValueForADegree()
            return 0;

        }


    }

    class SugenoIfThenRule
    {
        FuzzySet[] antecedents;
        int conclusion;

        // for weighted average requirement
        public double FiringSrength { get; set; } = 0.0;

        public SugenoIfThenRule(FuzzySet[] inputs, int output)
        {
            antecedents = inputs;
            conclusion = output;
        }

        // need to be done
        public double FuzzyInCrispOutInferencing(FuzzySet[] conditions)
        {
            return 0;
            FiringSrength = 0.0;
            FuzzySet tempFS;
            FuzzySet yFS;
            FuzzySet zFS;

            //lbOutputEquation.Items.Add("0: Y=0.1X+6.4");
            //lbOutputEquation.Items.Add("1: Y=0.5X+4");
            //lbOutputEquation.Items.Add("2: Y=X-2");
            //lbOutputEquation.Items.Add("3: Z=-X+Y+1");
            //lbOutputEquation.Items.Add("4: Z=-Y+3");
            //lbOutputEquation.Items.Add("5: Z=-X+3");
            //lbOutputEquation.Items.Add("6: Z=-X+Y+2");

            switch (conclusion)
            {
                case 0:
                    yFS =  antecedents[0] * 0.1 + 6.4;
                    break;
                case 1:
                    yFS = antecedents[0] * 0.5 + 4;
                    break;
                case 2:
                    yFS = antecedents[0] - 2;
                    break;
                case 3:
                    zFS = -(antecedents[0]) + (antecedents[1]) + 1;
                    break;
                case 4:
                    zFS = -(antecedents[1]) + 3;
                    break;
                case 5:
                    zFS = -(antecedents[0]) + 3;
                    break;
                case 6:
                    zFS = -(antecedents[0]) + (antecedents[1]) + 2;
                    break;
            }


        }


        public FuzzySet CrispInCrispOutInferencing(double conditions)
        {
            FiringSrength = 0.0;

            return null;

            //switch (equationID)
            //{
            //    case 0:
            //        return 0.1 * inputs[0] + 6.4;
            //        break;
            //    case 1:
            //        return 0.5 * inputs[0] + 4; break;
            //        break;

            //        // fault proof
            //}



        }
    }
}
