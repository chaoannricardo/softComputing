using R08546023KWChangAss05.Binary_Operator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace R08546023KWChangAss05
{
    public partial class MainForm : Form
    {
        //FunctionTakeNoArgumentReturnNothing firstFunction;
        //FunctionTakesOneIntAndReturnInt secondFunction;

        //void f1()
        //{
        //tell user what's going on
        //    MessageBox.Show("f1() is called.");
        //}

        //void f2()
        //{
        //    MessageBox.Show("f2() is called.");
        //}

        //int g1(int i)
        //{
        //    MessageBox.Show($"g1({i}) is called.");
        //    return 0;
        //}

        //int g2(int j)
        //{
        //    MessageBox.Show($"g2({j}) is called.");
        //    return 0;
        //}


        public double unaryparameter;
        public MainForm()
        {
            InitializeComponent();
        }

        


        private void btnCreateUniverse_Click(object sender, EventArgs e)
            //reginal variable this : whether function belongs to this class(data u1)
            //reginal variable sender : trigger button event
            //reginal variable e : event-related data
            //spanner sign : related to properties and data, which is a function
        {
            Universe u1 = new Universe( mainChart );
            TreeNode aNode = new TreeNode();

            aNode.Tag = u1;
            aNode.Text = u1.Title;

            ppgTarget.SelectedObject = u1;
            trvUniverses.Nodes.Add(aNode);
            trvUniverses.SelectedNode = aNode;
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = u1.Title;
            col.Tag = u1;
            // 
            dgvRules.Columns.Add(col); // add to bottom
            //int pos = 0;
            //dgvRules.Columns.Insert(pos, col);

            // only if input universe
            col = new DataGridViewTextBoxColumn();
            col.HeaderText = u1.Title;
            col.Tag = u1;

            dgvCondition.Columns.Add(col);
            if (dgvCondition.Rows.Count == 0)
                dgvCondition.Rows.Add();

        }

        Series highlightedseries = null;

        private void trvUniverses_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            ppgTarget.SelectedObject = trvUniverses.SelectedNode.Tag;
            
            if (trvUniverses.SelectedNode.Level == 1)
            {
                btnCreateFuzzySet.Enabled = false;
                btnDelete.Enabled = true;
                btnUnaryOperatedFS.Enabled=true;
                //Seires要有東西
                if (((FuzzySet)trvUniverses.SelectedNode.Tag).TheSeries != null)
                {
                    //把之前highlight的series變回來
                    if (highlightedseries != null)
                    {
                        highlightedseries.BorderWidth = 2;
                    }
                    ((FuzzySet)trvUniverses.SelectedNode.Tag).TheSeries.BorderWidth = 5;
                    highlightedseries = ((FuzzySet)trvUniverses.SelectedNode.Tag).TheSeries;
                }
            }
            if(trvUniverses.SelectedNode.Level == 0)
            {
                btnCreateFuzzySet.Enabled = true;
                btnDelete.Enabled = true;
                btnUnaryOperatedFS.Enabled = false;
            }
        }

        private void ppgTarget_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //selected is a universe
            if(trvUniverses.SelectedNode.Level == 0)
                trvUniverses.SelectedNode.Text = ((Universe)trvUniverses.SelectedNode.Tag).Title;
            //selected is a fuzzy set
            else if(trvUniverses.SelectedNode.Level == 1)
                trvUniverses.SelectedNode.Text = ((FuzzySet)trvUniverses.SelectedNode.Tag).Title;
        }

        private void btnCreateFuzzySet_Click(object sender, EventArgs e)
        {

            //Check wheather a universe is selected
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 0) return;
            if (cbxFSTypes.SelectedIndex < 0) return;
            

            Universe su = (Universe)trvUniverses.SelectedNode.Tag; 
            FuzzySet aFS = null;
            switch( cbxFSTypes.SelectedIndex )
            {
                case 0:  //Gaussian
                    aFS = new GaussianFuzzySet(su);
                    break;
                case 1:  //Triangular
                    aFS = new TriangularFuzzySet(su);
                    break;
                case 2:  //Trapezoidal
                    aFS = new TrapezoidalFuzzySet(su);
                    break;
                case 3:  //Bell
                    aFS = new BellFuzzySet(su);
                    break;
                case 4:  //Sigmoidal
                    aFS = new SigmoidalFuzzySet(su);
                    break;
                case 5:  //Left-right
                    aFS = new LeftrightFuzzySet(su);
                    break;
                case 6:  //Pi-shaped
                    aFS = new PiShapedFuzzySet(su);
                    break;
                case 7:  //S-shaped
                    aFS = new SShapedFuzzySet(su);
                    break;
                case 8:  //Z-shaped
                    aFS = new ZShapedFuzzySet(su);
                    break;

            }
            TreeNode fsNode = new TreeNode();
            fsNode.Text = aFS.Title;
            fsNode.Tag = aFS;
            trvUniverses.SelectedNode.Nodes.Add(fsNode);
            trvUniverses.SelectedNode = fsNode;
            ppgTarget.SelectedObject = aFS;
            aFS.ShowSeries = true;
            //強制呼叫 把線變粗
            trvUniverses_AfterSelect(null, null);
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(trvUniverses.SelectedNode.Level == 0)
            {
                ChartArea c = ((Universe)trvUniverses.SelectedNode.Tag).TheChartArea;
                mainChart.ChartAreas.Remove(c);
            }
            if (trvUniverses.SelectedNode.Level == 1)
            {
                Series s = ((FuzzySet)trvUniverses.SelectedNode.Tag).TheSeries;
                mainChart.Series.Remove(s);
            }
            trvUniverses.Nodes.Remove(trvUniverses.SelectedNode);
            if (trvUniverses.SelectedNode == null)
            {
                btnDelete.Enabled = false;
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
            //firstFunction = f2;
            //firstFunction += f1;//累積串接f1 f2->f2+f1
            //執行delegate呼叫
            //firstFunction();
            //firstFunction = f2;
            //firstFunction();
        //}

        private void btnUnaryOperatedFS_Click(object sender, EventArgs e)
        {
            //get fuzzy set operand
            //Check wheather a universe is selected
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 1) return;
            if (cbxUnaryOperator.SelectedIndex <0 ) return;
            FuzzySet operand = (FuzzySet)trvUniverses.SelectedNode.Tag;
            //create unary operator
            //子類別的物件可以看成父類別的參照
            UnaryFSOperator op = null;
            switch( cbxUnaryOperator.SelectedIndex )
            {
                case 0: //negate
                    op = new NegateOperator();
                    break;
                case 1: //alpha-cut
                    op = new AlphaCutOperator();
                    break;
                case 2: //value-scale
                    op = new ValueScaleOperator();
                    break;
                case 3: //concentration
                    op = new ConcentrationOperator();
                    break;
                case 4: //dilation
                    op = new DilationOperator();
                    break;
                case 5: //intensification
                    op = new IntensificationOperator();
                    break;
                case 6: //diminisher
                    op = new DiminisherOperator();
                    break;
                case 7: //extreme
                    op = new ExtremeOperator();
                    break;
                case 8: //Sugeno
                    op = new SugenoComplementOperator();
                    break;
                case 9: //Yager
                    op = new YagerComplementOperator();
                    break;
            }

            //create unary operated Fuzzy Set
            FuzzySet aFS = null;
            aFS = new UnaryOperatedFS(operand, op);
            TreeNode fsNode = new TreeNode();
            fsNode.Tag = aFS;
            fsNode.Text = aFS.Title;
            trvUniverses.SelectedNode.Parent.Nodes.Add(fsNode);
            trvUniverses.SelectedNode = fsNode;
            ppgTarget.SelectedObject = aFS;
            aFS.ShowSeries = true;
            //強制呼叫 把線變粗
            trvUniverses_AfterSelect(null, null);
        }

        private void labOperand1_Click(object sender, EventArgs e)
        {
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 1) return;
            //把FuzzySet藏在Tag
            labOperand1.Tag = trvUniverses.SelectedNode.Tag;
            //選定第一個Fuzzy Set後 改變text給user確認
            labOperand1.Text = trvUniverses.SelectedNode.Text;
        }

        private void labOperand2_Click(object sender, EventArgs e)
        {
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 1) return;
            //把FuzzySet藏在Tag
            labOperand2.Tag = trvUniverses.SelectedNode.Tag;
            //選定第二個Fuzzy Set後 改變text給user確認
            labOperand2.Text = trvUniverses.SelectedNode.Text;
        }

        private void btnBinaryOperatedFS_Click(object sender, EventArgs e)
        {
            //get fuzzy set operand
            //Check wheather a universe is selected
            if (trvUniverses.SelectedNode == null) return;
            if (labOperand1.Tag == null && labOperand2.Tag == null) return;
            if (cbxBinaryOperator.SelectedIndex < 0) return;
            FuzzySet operand1 = (FuzzySet)labOperand1.Tag;
            FuzzySet operand2 = (FuzzySet)labOperand2.Tag;
            //create binary operator
            //子類別的物件可以看成父類別的參照
            BinaryFSOperator op = null;
            switch (cbxBinaryOperator.SelectedIndex)
            {
                case 0: //Minimum T-norm
                    op = new IntersectOperator();
                    break;
                case 1: //Maximum S-norm
                    op = new UnionOperator();
                    break;
                case 2: //Algebriac Product T-norm
                    op = new AlgebriacTOperator();
                    break;
                case 3: //Algebriac Sum S-norm
                    op = new AlgebriacSOperator();
                    break;
                case 4: //Bounded Product T-norm
                    op = new BoundedTOperator();
                    break;
                case 5: //Bounded Sum S-norm
                    op = new BoundedSOperator();
                    break;
                case 6: //Drastic Product T-norm
                    op = new DrasticTOperator();
                    break;
                case 7: //Drastic Sum S-norm
                    op = new DrasticSOperator();
                    break;
                case 8: //Sugeno T -norm
                    op = new SugenoTOperator();
                    break;
                case 9: //Sugeno S-norm
                    op = new SugenoSOperator();
                    break;
                case 10: //Einstein T -norm
                    op = new EinsteinTOperator();
                    break;
                case 11: //Einstein S-norm
                    op = new EinsteinSOperator();
                    break;
                case 12: //Hamacher T -norm
                    op = new HamacherTOperator();
                    break;
                case 13: //Hamacher S-norm
                    op = new HamacherSOperator();
                    break;
                case 14: //Yager T-norm
                    op = new YagerTOperator();
                    break;
                case 15: //Yager S-norm
                    op = new YagerSOperator();
                    break;
            }
            if(operand1.TheUniverse.TheChartArea != operand2.TheUniverse.TheChartArea)
            {
                btnBinaryOperatedFS.Enabled = false;
                return;
            }
            //create binary operated Fuzzy Set
            FuzzySet aFS = null;
            aFS = new BinaryOperatedFS(operand1, operand2, op);
            TreeNode fsNode = new TreeNode();
            fsNode.Tag = aFS;
            fsNode.Text = aFS.Title;
            trvUniverses.SelectedNode.Parent.Nodes.Add(fsNode);
            trvUniverses.SelectedNode = fsNode;
            ppgTarget.SelectedObject = aFS;
            aFS.ShowSeries = true;
            //強制呼叫 把線變粗
            trvUniverses_AfterSelect(null, null);
        }

        private void labOperand1_TextChanged(object sender, EventArgs e)
        {
            if (labOperand1.Tag != null && labOperand2.Tag != null)
            {
                btnBinaryOperatedFS.Enabled = true;
            }
        }

        private void labOperand2_TextChanged(object sender, EventArgs e)
        {
            if (labOperand1.Tag != null && labOperand2.Tag != null)
            {
                btnBinaryOperatedFS.Enabled = true;
            }
        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            dgvRules.Rows.Add();
        }

        private void dgvRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // guarding condition 
            DataGridViewCell cell = dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex];
            FuzzySet fs = (FuzzySet)trvUniverses.SelectedNode.Tag;
            cell.Tag = fs;
            cell.Value = fs.Title;
        }

        private void dgvCondition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dgvCondition.Rows[e.RowIndex].Cells[e.ColumnIndex];
            FuzzySet fs = (FuzzySet)trvUniverses.SelectedNode.Tag;
            cell.Tag = fs;
            cell.Value = fs.Title;
        }

        private void btnSingleInference_Click(object sender, EventArgs e)
        {
            // check dgv setup rules
            //  List<IfThenRule> rules = new List<IfThenRule>();
            IfThenRule[] rules = new IfThenRule[dgvRules.RowCount];
            for( int r = 0; r < dgvRules.RowCount; r++ )
            {
                FuzzySet[] inputs;
                FuzzySet output;
                inputs = new FuzzySet[dgvRules.ColumnCount - 1];
                for( int c = 0; c < inputs.Length;c++)
                {
                    inputs[c] = (FuzzySet)dgvRules.Rows[r].Cells[c].Tag;
                }
                output = (FuzzySet)dgvRules.Rows[r].Cells[dgvRules.ColumnCount-1].Tag;
                rules[r] = new IfThenRule(inputs, output);
            }
            // check dgv setup condition
            FuzzySet[] conditions;
            conditions = new FuzzySet[dgvRules.ColumnCount-1];
            for (int c = 0; c < conditions.Length; c++)
                conditions[c] = (FuzzySet)dgvCondition.Rows[0].Cells[c].Tag;

            // inference each rule
            FuzzySet result = null;
            for( int i = 0; i < rules.Length; i++)
            {
                FuzzySet ruleOut =  rules[i].Inference(conditions);
                if (result == null) result = ruleOut;
                else
                    //result = result | ruleOut;
                    result |= ruleOut;
            }

            result.ShowSeries = true;
        }

        private void btnCrispAllInference_Click(object sender, EventArgs e)
        {


            // check dgv setup rules
            //  List<IfThenRule> rules = new List<IfThenRule>();
            IfThenRule[] rules = new IfThenRule[dgvRules.RowCount];
            for (int r = 0; r < dgvRules.RowCount; r++)
            {
                FuzzySet[] inputs;
                FuzzySet output;
                inputs = new FuzzySet[dgvRules.ColumnCount - 1];
                for (int c = 0; c < inputs.Length; c++)
                {
                    inputs[c] = (FuzzySet)dgvRules.Rows[r].Cells[c].Tag;
                }
                output = (FuzzySet)dgvRules.Rows[r].Cells[dgvRules.ColumnCount - 1].Tag;
                rules[r] = new IfThenRule(inputs, output);
            }
            // check dgv setup condition
            double[] conditions;
            string[] items = txbCrisp.Text.Split(',');
            conditions = new double[items.Length];
            for (int c = 0; c < conditions.Length; c++)
                conditions[c] = Convert.ToDouble(items[c]);

            // inference each rule
            FuzzySet result = null;
            for (int i = 0; i < rules.Length; i++)
            {
                FuzzySet ruleOut = rules[i].Inference(conditions);
                if (result == null) result = ruleOut;
                else
                    //result = result | ruleOut;
                    result |= ruleOut;
            }

            result.ShowSeries = true;

        }
    }
}
