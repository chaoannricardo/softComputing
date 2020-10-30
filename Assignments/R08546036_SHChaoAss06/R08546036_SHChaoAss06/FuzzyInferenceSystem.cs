using R08546036_SHChaoAss04;
using R08546036_SHChaoAss05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546036_SHChaoAss06
{
    public enum DefuzzificationType
    {
        COA, BOA, MOM, SOM, LOM
    }

    public interface IFuzzyInferencing
    {
        void ConstructSystem(DataGridView dgv);
        double CrispInCrispOutInferencing(double[] conditions);
    }

    class MamdaniFuzzySystem : IFuzzyInferencing
    {
        IfThenFuzzyRule[] rules;
        DefuzzificationType defuzzification = DefuzzificationType.COA;

        // property
        public DefuzzificationType Defuzzification { get => defuzzification; set => defuzzification = value; }

        public bool IsCut
        {
            get;
            set;
        } = true;




        // functions
        public void ConstructSystem(DataGridView dgv)
        {
            IfThenFuzzyRule[] allRules = new IfThenFuzzyRule[dgv.Rows.Count];
            for (int r = 0; r < (dgv.Rows.Count); r++)
            {
                FuzzySet[] inputs = new FuzzySet[dgv.ColumnCount - 1];

                // input fuzzy list
                for (int c = 0; c < (inputs.Length); c++)
                {
                    inputs[c] = (FuzzySet)dgv.Rows[r].Cells[c].Tag;
                }

                // output fuzzy list
                FuzzySet output = (FuzzySet)dgv.Rows[r].Cells[dgv.Columns.Count - 1].Tag;

                allRules[r] = new IfThenFuzzyRule(inputs, output);
            }
        }

        public double CrispInCrispOutInferencing(double[] conditions)
        {
            double result = 0;
            FuzzySet resultFS = null;

            //foreach (IfThenFuzzyRule ifr in rules)
            //{
            //    if (resultFS == null)
            //    {
            //        resultFS = ifr.CrispInFuzzyOutInferencing(conditions);
            //    }
            //    else {
            //        resultFS = resultFS | ifr.CrispInFuzzyOutInferencing(conditions);
            //    }
            //}

            //switch (defuzzification) {
            //    case DefuzzificationType.BOA:
            //        return resultFS.BOACrispValue;
            //        break;
            //    case DefuzzificationType.COA:
            //        return resultFS.COACrispValue;
            //        break;
            //        // and continue on 

            //}

            return result;

        }
    }

    class TsukamotoFuzzySystem : IFuzzyInferencing
    {
        IfThenFuzzyRule[] rules;

        public void ConstructSystem(DataGridView dgv)
        {
            throw new NotImplementedException();
        }

        public double CrispInCrispOutInferencing(double[] conditions)
        {
            throw new NotImplementedException();
        }
    }

    class SugenoFuzzySystem : IFuzzyInferencing
    {
        SugenoIfThenRule[] rules;

        public void ConstructSystem(DataGridView dgv)
        {
            IfThenFuzzyRule[] allRules = new IfThenFuzzyRule[dgv.Rows.Count];
            for (int r = 0; r < (dgv.Rows.Count); r++)
            {
                FuzzySet[] inputs = new FuzzySet[dgv.ColumnCount - 1];

                // input fuzzy list
                for (int c = 0; c < (inputs.Length); c++)
                {
                    inputs[c] = (FuzzySet)dgv.Rows[r].Cells[c].Tag;
                }

                // output fuzzy list
                //int output = (FuzzySet)dgv.Rows[r].Cells[dgv.Columns.Count - 1].Tag;

                //allRules[r] = new IfThenFuzzyRule(inputs, output);
            }
        }

        public double CrispInCrispOutInferencing(double[] conditions)
        {
            throw new NotImplementedException();
        }
    }
}
