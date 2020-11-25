using R08546036_SHChaoAss04;
using R08546036_SHChaoAss06;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        private bool lessThanThreeRows = false;

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

            if (dgvRules.Columns.Count < 3) lessThanThreeRows = true;
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
        private bool isWeightedSum = true;

        // property
        public bool IsWeightedSum
        {
            get
            {
                return isWeightedSum;
            }
            set
            {
                if (value is bool)
                {
                    isWeightedSum = value;
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

        public double CrispInCrispOutInferencing(double[] dgvConditions)
        {
            double crispValue;
            FuzzySet resultFS = null;
            List<double> zValueList = new List<double>();
            List<double> weightList = new List<double>();

            // inferencing function
            foreach (IfThenFuzzyRule ifr in allRules)
            {
                resultFS = ifr.CrispInFuzzyOutInferencing(dgvConditions);

                double zValue = 0;
                double resultFSUniverseMin = resultFS.TheUniverse.Minimum;
                double resultFSUniverseMax = resultFS.TheUniverse.Maximum;
                List<double> culmulative = new List<double>();

                for (double i = resultFSUniverseMin; i <= resultFSUniverseMax; i += resultFS.TheUniverse.Delta) {
                    culmulative.Add(resultFS.GetMembershipDegree(i));
                }

                for (double i = resultFSUniverseMin; i <= resultFSUniverseMax; i += resultFS.TheUniverse.Delta)
                {
                    if (resultFS.GetMembershipDegree(i) == culmulative.Max())
                    {
                        zValue = i;
                        break;
                    }
                }

                zValueList.Add(zValue);
                weightList.Add(culmulative.Max());
            }

            double lower = (weightList.Sum());
            List<double> upper = new List<double>();

            for (int i = 0; i < zValueList.Count; i++)
            {
                double value = zValueList[i] * weightList[i];
                upper.Add(value);
            }


            if (isWeightedSum)
            {
                // when true
                return upper.Sum();
            }
            else
            {
                // when false
                return upper.Sum() / lower;
            }

        }
    }

    public class SugenoFuzzySystem : IFuzzyInferencing
    {
        SugenoIfThenRule[] allRules;
        private bool isCut = true;
        private bool isWeightedSum = true;
        private double[] crispOutputs;

        // do not need this
        [Browsable(false)]
        // property
        public bool IsWeightedSum
        {
            get
            {
                return isWeightedSum;
            }
            set
            {
                if (value is bool)
                {
                    isWeightedSum = value;
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

        public DefuzzificationType Defuzzification { get => DefuzzificationType.BOA; set => throw new NotImplementedException(); }

        public void ConstructSystem(DataGridView dgvRules)
        {
            // create if-then rules
            allRules = new SugenoIfThenRule[dgvRules.Rows.Count];
            crispOutputs = new double[dgvRules.Rows.Count];

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
                crispOutputs[r] = output;
            }
        }

        public void Inferencing(DataGridView dgvConditions)
        {
            Random randomizer = new Random();
            double value = randomizer.NextDouble();
            MessageBox.Show(value.ToString());
        }

        public double CrispInCrispOutInferencing(double[] dgvConditions)
        {
            double crispValue;
            double firingStrength = double.NaN;
            double zValue = double.NaN;
            List<double> zValueList = new List<double>();
            List<double> weightList = new List<double>();
            int rowOrder = 0;

            // inferencing function
            foreach (SugenoIfThenRule ifr in allRules)
            {
                firingStrength = ifr.CrispInCrispOutInferencing(dgvConditions);
                weightList.Add(firingStrength);

                switch (crispOutputs[rowOrder])
                {
                    case 0:
                        zValue = dgvConditions[0] * 0.1 + 6.4;
                        break;
                    case 1:
                        zValue = dgvConditions[0] * 0.5 + 4;
                        break;
                    case 2:
                        zValue = dgvConditions[0] - 2;
                        break;
                    case 3:
                        zValue = -dgvConditions[0] + dgvConditions[1] + 1;
                        break;
                    case 4:
                        zValue = -(dgvConditions[1]) + 3;
                        break;
                    case 5:
                        zValue = -(dgvConditions[0]) + 3;
                        break;
                    case 6:
                        zValue = (dgvConditions[0]) + (dgvConditions[1]) + 2;
                        break;
                }


                zValueList.Add(zValue);
                rowOrder += 1;
            }

            //lbOutputEquation.Items.Add("0: Y=0.1X+6.4");
            //lbOutputEquation.Items.Add("1: Y=0.5X+4");
            //lbOutputEquation.Items.Add("2: Y=X-2");
            //lbOutputEquation.Items.Add("3: Z=-X+Y+1");
            //lbOutputEquation.Items.Add("4: Z=-Y+3");
            //lbOutputEquation.Items.Add("5: Z=-X+3");
            //lbOutputEquation.Items.Add("6: Z=-X+Y+2");

            double lower = (weightList.Sum());
            List<double> upper = new List<double>();

            for (int i = 0; i < zValueList.Count; i++)
            {
                double value = zValueList[i] * weightList[i];
                upper.Add(value);
            }

            if (isWeightedSum)
            {
                // when true
                return upper.Sum();
            }
            else
            {
                // when false
                return upper.Sum() / lower;
            }

        }

    }
}
