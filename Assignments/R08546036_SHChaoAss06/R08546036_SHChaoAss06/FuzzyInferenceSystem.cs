using R08546036_SHChaoAss04;
using R08546036_SHChaoAss06;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;

namespace R08546036_SHChaoAss06
{
    public enum DefuzzificationType
    {
        COA, BOA, MOM, SOM, LOM
    }

    public interface IFuzzyInferencing
    {

        // properties
        DefuzzificationType Defuzzification { get; set; }
        bool IsCut { get; set; }

        void ConstructSystem(DataGridView dgvRules);
        void Inferencing(DataGridView dgvConditions);
        double CrispInCrispOutInferencing(double[] dgvConditions);
    }


    public class MamdaniFuzzySystem : IFuzzyInferencing
    {
        IfThenFuzzyRule[] allRules;
        private bool isCut = true;
        DataGridView rulesDG;
        // initiate defuzzification with a value
        private DefuzzificationType defuzzification = DefuzzificationType.COA;

        // properties
        public DefuzzificationType Defuzzification
        {
            get
            {
                return defuzzification;
            }
            set
            {
                if (value is DefuzzificationType)
                {
                    defuzzification = value;
                }
            }
        }

        public bool IsCut
        {
            get
            {
                return isCut;
            }
            set
            {
                if (value is bool)
                {
                    isCut = value;
                }
            }
        }

        public MamdaniFuzzySystem()
        {
            
        }

        // functions
        public void ConstructSystem(DataGridView dgvRules)
        {
            rulesDG = dgvRules;

            // create if-then rules
            allRules = new IfThenFuzzyRule[dgvRules.Rows.Count];

            for (int r = 0; r < (dgvRules.Rows.Count); r++)
            {
                FuzzySet[] inputs = new FuzzySet[dgvRules.ColumnCount - 1];
                // input fuzzy list
                for (int c = 0; c < (inputs.Length); c++)
                {
                    inputs[c] = (FuzzySet)dgvRules.Rows[r].Cells[c].Tag;
                }
                // output fuzzy list
                FuzzySet output = (FuzzySet)dgvRules.Rows[r].Cells[dgvRules.Columns.Count - 1].Tag;

                allRules[r] = new IfThenFuzzyRule(inputs, output);
            }
        }

        public void Inferencing(DataGridView dgvConditions)
        {
            // conditions
            FuzzySet[] conditions = new FuzzySet[dgvConditions.Columns.Count];
            for (int i = 0; i < dgvConditions.Columns.Count; i++)
            {
                conditions[i] = (FuzzySet)dgvConditions.Rows[0].Cells[i].Tag;
            }

            // set contents of conditions
            FuzzySet resultingFS = null;

            foreach (IfThenFuzzyRule rule in allRules)
            {
                if (resultingFS == null)
                {
                    resultingFS = rule.FuzzyInFuzzyOutInferencing(conditions, isCut);
                }
                else
                {
                    resultingFS = resultingFS | rule.FuzzyInFuzzyOutInferencing(conditions, isCut);
                }
            }

            try
            {
                // show the final fs
                resultingFS.ShowInferenceSeries = true;
            }
            catch (System.NullReferenceException Exception)
            {
                return;
            }

        }

        public double CrispInCrispOutInferencing(double[] dgvConditions)
        {
            double crispValue;
            FuzzySet resultFS = null;

            // inferencing function
            foreach (IfThenFuzzyRule ifr in allRules)
            {
                if (resultFS == null)
                {
                    resultFS = ifr.CrispInFuzzyOutInferencing(dgvConditions);
                }
                else
                {
                    resultFS = resultFS | ifr.CrispInFuzzyOutInferencing(dgvConditions);
                }
            }

            resultFS.AssignDefuzzificationValueEach(defuzzification);

            // defuzzification
            switch (defuzzification)
            {
                case DefuzzificationType.BOA:
                    crispValue = resultFS.BOACrispValue;
                    break;
                case DefuzzificationType.COA:
                    crispValue = resultFS.COACrispValue;
                    break;
                case DefuzzificationType.MOM:
                    crispValue = resultFS.MOMCrispValue;
                    break;
                case DefuzzificationType.SOM:
                    crispValue = resultFS.SOMCrispValue;
                    break;
                case DefuzzificationType.LOM:
                    crispValue = resultFS.LOMCrispValue;
                    break;
                default:
                    crispValue = resultFS.COACrispValue;
                    break;
            }

            return crispValue;

        }
    }

    public class TsukamotoFuzzySystem : IFuzzyInferencing
    {
        IfThenFuzzyRule[] allRules;
        private bool isCut = true;
        private bool isWeighted = false;

        // property
        public bool IsWeighted
        {
            get
            {
                return isWeighted;
            }
            set
            {
                if (value is bool)
                {
                    isWeighted = value;
                }
            }
        }
        
        [Browsable(false)]
        public DefuzzificationType Defuzzification { get; set; }

        public bool IsCut
        {
            get
            {
                return isCut;
            }
            set
            {
                if (value is bool)
                {
                    isCut = value;
                }
            }
        }

        // functions
        public void ConstructSystem(DataGridView dgvRules)
        {
            // create if-then rules
            allRules = new IfThenFuzzyRule[dgvRules.Rows.Count];

            for (int r = 0; r < (dgvRules.Rows.Count); r++)
            {
                FuzzySet[] inputs = new FuzzySet[dgvRules.ColumnCount - 1];
                // input fuzzy list
                for (int c = 0; c < (inputs.Length); c++)
                {
                    inputs[c] = (FuzzySet)dgvRules.Rows[r].Cells[c].Tag;
                }
                // output fuzzy list
                FuzzySet output = (FuzzySet)dgvRules.Rows[r].Cells[dgvRules.Columns.Count - 1].Tag;

                allRules[r] = new IfThenFuzzyRule(inputs, output);
            }
        }

        public void Inferencing(DataGridView dgvConditions)
        {
            // conditions
            FuzzySet[] conditions = new FuzzySet[dgvConditions.Columns.Count];
            for (int i = 0; i < dgvConditions.Columns.Count; i++)
            {
                conditions[i] = (FuzzySet)dgvConditions.Rows[0].Cells[i].Tag;
            }

            // set contents of conditions
            FuzzySet resultingFS = null;

            foreach (IfThenFuzzyRule rule in allRules)
            {
                if (resultingFS == null)
                {
                    resultingFS = rule.FuzzyInFuzzyOutInferencing(conditions, isCut);
                }
                else
                {
                    resultingFS = resultingFS | rule.FuzzyInFuzzyOutInferencing(conditions, isCut);
                }
            }

            try
            {
                // show the final fs
                resultingFS.ShowInferenceSeries = true;
            }
            catch (System.NullReferenceException Exception)
            {
                return;
            }


        }

        public double CrispInCrispOutInferencing(double[] conditions)
        {
            throw new NotImplementedException();
            if (isWeighted)
            {
                //when true

            }
            else
            {
                // when false
            }
        }
    }

    public class SugenoFuzzySystem : IFuzzyInferencing
    {
        SugenoIfThenRule[] allRules;
        private bool isCut = true;

        // do not need this
        [Browsable(false)]
        public DefuzzificationType Defuzzification { get; set;}
        
        public bool IsCut
        {
            get
            {
                return isCut;
            }
            set
            {
                if (value is bool)
                {
                    isCut = value;
                }
            }
        }

        public void ConstructSystem(DataGridView dgvRules)
        {
            // create if-then rules
            allRules = new SugenoIfThenRule[dgvRules.Rows.Count];

            for (int r = 0; r < (dgvRules.Rows.Count); r++)
            {
                FuzzySet[] inputs = new FuzzySet[dgvRules.ColumnCount - 1];
                // input fuzzy list
                for (int c = 0; c < (inputs.Length); c++)
                {
                    inputs[c] = (FuzzySet)dgvRules.Rows[r].Cells[c].Tag;
                }
                // output fuzzy list
                int output = (int)dgvRules.Rows[r].Cells[dgvRules.Columns.Count - 1].Tag;

                allRules[r] = new SugenoIfThenRule(inputs, output);
            }
        }

        public void Inferencing(DataGridView dgvConditions)
        {
            // conditions
            FuzzySet[] conditions = new FuzzySet[dgvConditions.Columns.Count];
            for (int i = 0; i < dgvConditions.Columns.Count; i++)
            {
                conditions[i] = (FuzzySet)dgvConditions.Rows[0].Cells[i].Tag;
            }

            // set contents of conditions
            double resultingFS = 0;

            foreach (SugenoIfThenRule rule in allRules)
            {
                if (resultingFS == null)
                {
                    resultingFS = rule.FuzzyInCrispOutInferencing (conditions);
                }
                else
                {
                    //resultingFS = resultingFS | rule.FuzzyInCrispOutInferencing(conditions);
                }
            }

            MessageBox.Show($"Inference value is {resultingFS}");

        }

        public double CrispInCrispOutInferencing(double[] conditions)
        {
            return 0;
        }
    }
}
