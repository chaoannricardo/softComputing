﻿using R08546036_SHChaoAss04;
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
            double maxDegree;
            try
            {
                FiringSrength = double.MaxValue;

                // loop thorough each antecedent fuzzy set
                for (int i = 0; i < antecedents.Length; i++)
                {
                    // variables
                    maxDegree = antecedents[i].GetMembershipDegree(conditions[i]);
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


        public double CrispInCrispOutInferencing(double[] conditions)
        {
            FiringSrength = 0.0;
            FuzzySet tempFS;
            FuzzySet yFS;
            FuzzySet zFS;

            double maxDegree;
            try
            {
                FiringSrength = double.MaxValue;

                // loop thorough each antecedent fuzzy set
                for (int i = 0; i < antecedents.Length; i++)
                {
                    // variables
                    maxDegree = antecedents[i].GetMembershipDegree(conditions[i]);
                    if (maxDegree < FiringSrength) FiringSrength = maxDegree;
                }
            }
            catch (System.NullReferenceException Exception)
            {
                MessageBox.Show("Not enough rule or condition is given.");
                return double.NaN;
            }

            return FiringSrength;


        }

        public double FuzzyInFuzzyOutInferencing(FuzzySet[] conditions, bool isCut = true)
        {
            try
            {
                FiringSrength = 0.0;

                FiringSrength = double.MaxValue;

                // fault-proof
                if (antecedents.Length != conditions.Length)
                {
                    MessageBox.Show("Not enough rule or condition is given.");
                    return double.NaN; ;
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
                        return double.NaN;
                    }

                    maxDegree = (antecedents[i] & conditions[i]).MaxDegree;
                    if (maxDegree < FiringSrength) FiringSrength = maxDegree;

                }

                return FiringSrength;
            }
            catch (System.NullReferenceException Exception)
            {
                MessageBox.Show("Not enough rule or condition is given.");
                return double.NaN;
            }
        }

    }
}
