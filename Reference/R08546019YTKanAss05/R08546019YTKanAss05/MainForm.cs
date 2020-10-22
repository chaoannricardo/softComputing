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

namespace R08546019YTKanAss05
{
    public partial class MainForm : Form
    {
        FuzzyInferenceSystem theFussySystem;

        //FunctionTakeNoArgumentReturnNothing firstFunction;
        //FunctionTakesOneIntAndReturnInt secondFunction;
        //void f1()  //MainForm裡的function  //不需要任何參數
        //{ 
        //    MessageBox.Show("f1() is called");  //MessageBox：類別  //Show：靜態函式
        //}
        //void f2()
        //{
        //    MessageBox.Show("f2() is called");
        //}
        //int g1(int i)  //return int
        //{
        //    MessageBox.Show($"g1( {i} ) is called");
        //    return 0;
        //}
        //int g2(int j)
        //{
        //    MessageBox.Show($"g2( {j} ) is called");
        //    return 1;
        //}

        //Universe u1成員變數
        public MainForm()
        {
            InitializeComponent();
            trvUniverses.Select();
            rbtnMamdani.Checked = true;
            rbtnCut.Checked = true;

            InferenceSystemChanged(null, null);
        }

        private void btnCreateUniverse_Click(object sender, EventArgs e)
        //區域變數this：函式是否屬於此類別MainForm(data u1)
        //區域變數sender：按鈕觸發事件
        //區域變數e：事件相關的data
        //板手符號：properties與data有關，骨子裡為function
        {           
            ImageList trvImage = new ImageList();
            trvUniverses.ImageList = trvImage;
            trvImage.Images.Add( Properties.Resources.input );
            trvImage.Images.Add(Properties.Resources.output);
            trvImage.Images.Add(Properties.Resources.universe);
            trvImage.Images.Add(Properties.Resources.fuzzyset);            
            trvUniverses.Nodes[0].ImageIndex = 0;
            trvUniverses.Nodes[1].ImageIndex = 1;
            trvUniverses.Nodes[0].SelectedImageIndex = trvUniverses.Nodes[0].ImageIndex;
            trvUniverses.Nodes[1].SelectedImageIndex = trvUniverses.Nodes[1].ImageIndex;

            if (trvUniverses.SelectedNode.Level == 0)
            {                
                if (trvUniverses.SelectedNode.Index == 0)  //兄弟位階第1個
                {                    
                    Universe u1 = new Universe(mainChart);       //u1：區域變數  //null：參考型別、開啟記憶體                    
                    TreeNode aNode = new TreeNode();             //aNode：區域變數(函式執行完變數不存在/new恆存在                   
                    aNode.Tag = u1;                              //tag：與某物件息息相關、紀錄及拷貝參照(非資料拷貝)//任何類別都間接繼承至Object
                    aNode.Text = u1.Title;
                    aNode.ImageIndex = 2;
                    aNode.SelectedImageIndex = aNode.ImageIndex;
                    ppgTarget.SelectedObject = u1;
                    trvUniverses.SelectedNode.Nodes.Add(aNode);  //集合(Nodes)一定有Add：屬性加東西
                    //trvUniverses.SelectedNode = aNode;         //直接跳回Input/Output Universe新增
                    trvUniverses.ExpandAll();                    //展開treeview

                    DataGridViewColumn col = new DataGridViewTextBoxColumn();  //刪除universe需同時刪除column(column要記錄起來)
                    //DataGridViewColumn父類別；DataGridViewTextBoxColumn子類別(樣板)
                    col.Tag = u1;                                //藏一份universe作為參照(辨識)
                    col.HeaderText = u1.Title;                   //universe name

                    //input universe in both rules and conditions 
                    if(trvUniverses.Nodes[1].Nodes.Count == 0)   //output子系數目
                    { 
                        dgvRules.Columns.Add(col);              
                    }
                    else if (trvUniverses.Nodes[1].Nodes.Count != 0)  
                    { 
                        dgvRules.Columns.Insert(dgvRules.ColumnCount - 1 , col);    //集合皆有的function：Insert
                    }
                    col = new DataGridViewTextBoxColumn();       //重新new(實體資料只有一份，上下datagridview設定相同一個)
                    col.Tag = u1;
                    col.HeaderText = u1.Title;
                    dgvCondition.Columns.Add(col);
                    if (dgvCondition.Rows.Count == 0)            //需清楚說明colunm的欄位(ex：ButtonCoulumn、TextBoxCoulumn、ComboBoxCoulumn...)
                        dgvCondition.Rows.Add();                 //condition只有一個row
                    trvUniverses_AfterSelect(null, null);
                }
                else if (trvUniverses.SelectedNode.Index == 1)   //兄弟位階第2個
                {
                    if (trvUniverses.Nodes[1].Nodes.Count == 0)  //only has one output universe
                    {
                        Universe u1 = new Universe(mainChart);  
                        TreeNode aNode = new TreeNode();                       
                        aNode.Tag = u1;                         
                        aNode.Text = u1.Title;
                        aNode.ImageIndex = 2;
                        aNode.SelectedImageIndex = aNode.ImageIndex;
                        ppgTarget.SelectedObject = u1;
                        trvUniverses.SelectedNode.Nodes.Add(aNode);          
                        //trvUniverses.SelectedNode = aNode;     //直接跳回Input/Ouyput Universe新增
                        trvUniverses.ExpandAll();

                        DataGridViewColumn col = new DataGridViewTextBoxColumn();  //刪除universe需同時刪除column(column要記錄起來)
                        //DataGridViewColumn父類別；DataGridViewTextBoxColumn子類別(樣板)
                        col.Tag = u1;                            //藏一份universe作為參照(辨識)
                        col.HeaderText = u1.Title;               //universe name

                        //only if output universe in rules        
                        dgvRules.Columns.Add(col);               //add to botton                        
                        trvUniverses_AfterSelect(null, null);    //呼叫function，強制讓delete鍵disable
                    }
                }
            }            
        }

        Series highlightedSeries = null;
        private void trvUniverses_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvUniverses.SelectedNode.Level == 0)
            {
                btnCreateUniverse.Enabled = true;
                btnDelete.Enabled = false;
                gpxPrimaryFuzzySet.Enabled = false;
                gpxUnaryOperatedFS.Enabled = false;
                gpxBinaryOperatedFS.Enabled = false;
                txbTitle.Text = "";
                btnSingleInference.Enabled = false;  //
                btnCrispAllInference.Enabled = false;  //

                if (trvUniverses.SelectedNode.Index == 0)
                {
                    btnCreateUniverse.Text = "New Input Universe";                    
                }
                else if (trvUniverses.SelectedNode.Index == 1)
                {
                    btnCreateUniverse.Text = "New Output Universe";                   
                    if (trvUniverses.SelectedNode.Nodes.Count != 0)
                    {
                        btnCreateUniverse.Enabled = false;  
                    }
                }
            }
            if (trvUniverses.SelectedNode.Level == 1)
            {
                btnCreateUniverse.Enabled = false;
                btnDelete.Enabled = true;
                gpxPrimaryFuzzySet.Enabled = true;               
                gpxUnaryOperatedFS.Enabled = false;
                gpxBinaryOperatedFS.Enabled = false;
                txbTitle.Text = ((Universe)trvUniverses.SelectedNode.Tag).Title;           
            }
            if (trvUniverses.SelectedNode.Level == 2)  //選擇Fuzzy Set level
            {
                btnCreateUniverse.Enabled = false;
                btnDelete.Enabled = true;
                gpxPrimaryFuzzySet.Enabled = false;
                gpxUnaryOperatedFS.Enabled = true;
                gpxBinaryOperatedFS.Enabled = true;
                txbTitle.Text = ((FuzzySet)trvUniverses.SelectedNode.Tag).Title;

                if (((FuzzySet)trvUniverses.SelectedNode.Tag).TheSeries != null)  //Series需要new出來
                {
                    if (highlightedSeries != null)  //舊的線變回原本粗細
                    {
                        highlightedSeries.BorderWidth = 2;
                    }
                    ((FuzzySet)trvUniverses.SelectedNode.Tag).TheSeries.BorderWidth = 5;
                    highlightedSeries = ((FuzzySet)trvUniverses.SelectedNode.Tag).TheSeries;  //儲存變粗的Series
                }
            }
            ppgTarget.SelectedObject = trvUniverses.SelectedNode.Tag;
        }

        private void ppgTarget_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //chekout whether selectedNode is Universe or Fuzzy Set
            //selected is a Universe
            if (trvUniverses.SelectedNode.Level == 1)
            {
                trvUniverses.SelectedNode.Text = ((Universe)trvUniverses.SelectedNode.Tag).Title;
                //rules and condition colomns name changed
                dgvRules.Columns[trvUniverses.SelectedNode.Index].HeaderText = ((Universe)trvUniverses.SelectedNode.Tag).Title;
                dgvCondition.Columns[trvUniverses.SelectedNode.Index].HeaderText = ((Universe)trvUniverses.SelectedNode.Tag).Title;
            }
            //selected is a Fuzzy Set
            else if (trvUniverses.SelectedNode.Level == 2)
            {
                trvUniverses.SelectedNode.Text = ((FuzzySet)trvUniverses.SelectedNode.Tag).Title;
                //rules and condition cells name changed
                for (int r = 0; r < dgvRules.RowCount; r++)
                {
                    for (int c = 0; c < dgvRules.ColumnCount; c++)
                    {
                        if (dgvRules.Rows[r].Cells[c].Tag == (FuzzySet)trvUniverses.SelectedNode.Tag)
                            dgvRules.Rows[r].Cells[c].Value = ((FuzzySet)trvUniverses.SelectedNode.Tag).Title;
                    }
                }
                for (int r = 0; r < dgvCondition.RowCount; r++)
                {
                    for (int c = 0; c < dgvCondition.ColumnCount; c++)
                    {
                        if (dgvCondition.Rows[r].Cells[c].Tag == (FuzzySet)trvUniverses.SelectedNode.Tag)
                            dgvCondition.Rows[r].Cells[c].Value = ((FuzzySet)trvUniverses.SelectedNode.Tag).Title;
                    }
                }
            }
        }
        private void btnCreateFuzzySet_Click(object sender, EventArgs e)
        {
            //checkout whether a universe is selected
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 1) return;  //!=：non equal
            if (cbxFSTypes.SelectedIndex < 0) return;  //index：0,1,2...
            
            Universe su = (Universe)trvUniverses.SelectedNode.Tag;  //su：區域變數
            FuzzySet aFS = null;  //aFS：區域變數  //子類別物件可以看成父類別(物件導向)

            switch (cbxFSTypes.SelectedIndex)
            {
                case 0:  //Gaussiain Fuzzy Set
                    aFS = new GaussianFuzzySet(su);  //骨子裡為Gaussian
                    break;
                case 1:  //Triangular Fuzzy Set
                    aFS = new TriangularFuzzySet(su);
                    break;
                case 2:  //Trapezoidal Fuzzy Set
                    aFS = new TrapezoidalFuzzySet(su);
                    break;
                case 3:  //Bell Fuzzy Set
                    aFS = new BellFuzzySet(su);
                    break;
                case 4:  //Sigmoidal Fuzzy Set
                    aFS = new SigmoidalFuzzySet(su);
                    break;
                case 5:  //Left-Right Fuzzy Set
                    aFS = new LeftRightFuzzySet(su);
                    break;
                case 6:  //S-Shaped Fuzzy Set
                    aFS = new SShapedFuzzySet(su);
                    break;
                case 7:  //Z-Shaped Fuzzy Set
                    aFS = new ZShapedFuzzySet(su);
                    break;
                case 8:  //Pi-Shaped Fuzzy Set
                    aFS = new PiShapedFuzzySet(su);
                    break;

                //case 0: //Gaussiain Fuzzy Set
                //    GaussianFuzzySet g = new GaussianFuzzySet(su); //g；block變數
                //    TreeNode gfsNode = new TreeNode();
                //    gfsNode.Tag = g;
                //    gfsNode.Text = g.Title;
                //    trvUniverses.SelectedNode.Nodes.Add(gfsNode);
                //    ppgTarget.SelectedObject = g;
                //    break;                                         
            }

            TreeNode fsNode = new TreeNode();
            fsNode.Tag = aFS;
            fsNode.Text = aFS.Title;
            fsNode.ImageIndex = 3;
            fsNode.SelectedImageIndex = fsNode.ImageIndex;
            trvUniverses.SelectedNode.Nodes.Add(fsNode);
            //trvUniverses.SelectedNode = fsNode;  //(強制設成Fuzzy Set的Node)//直接跳回Universe新增
            trvUniverses.ExpandAll();

            ppgTarget.SelectedObject = aFS;

            aFS.ShowSeries = true;
            trvUniverses_AfterSelect(null, null);  //呼叫function：SelectedNode的Series變粗
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (trvUniverses.SelectedNode.Level == 1)
            {
                ChartArea c = ((Universe)trvUniverses.SelectedNode.Tag).TheChartArea;
                mainChart.ChartAreas.Remove(c);
                if (trvUniverses.SelectedNode.Parent.Index == 0)  //input universe
                {
                    for (int i = 0; i < dgvRules.ColumnCount; i++)
                    {
                        if (trvUniverses.SelectedNode.Index == dgvRules.Columns[i].Index)
                            dgvRules.Columns.RemoveAt(i);
                    }
                    for (int i = 0; i < dgvCondition.ColumnCount; i++)
                    { 
                        if (trvUniverses.SelectedNode.Index == dgvCondition.Columns[i].Index)
                            dgvCondition.Columns.RemoveAt(i);
                    }
                }
                if (trvUniverses.SelectedNode.Parent.Index == 1)  //output universe
                {
                    dgvRules.Columns.RemoveAt(dgvRules.ColumnCount - 1);
                }               
            }
            if (trvUniverses.SelectedNode.Level == 2)
            {
                Series s = ((FuzzySet)trvUniverses.SelectedNode.Tag).TheSeries;
                mainChart.Series.Remove(s);
            }
                trvUniverses.Nodes.Remove(trvUniverses.SelectedNode);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    firstFunction = f2;  //firstFunction為變數名稱；datatype-delegate  //assign給f1、f2皆可；不能委派給g1、g2(因為在委派裡的形式已設定好)
        //    //記憶體位置：f1函式在記憶體中的起始位置
        //    //不直接呼叫f1，透過委派呼叫
        //    //不單純只是一個函式的delegate
        //    firstFunction += f1;  //firstFunction = firstFunction + f1;f2再f1

        //    //call delegate執行delegate的呼叫
        //    firstFunction();    //像函式呼叫，骨子裡的delegate-f1被呼叫
        //    //firstFunction = f2;
        //    //firstFunction();  //像函式呼叫，骨子裡的delegate-f2被呼叫
        //}

        private void btnCreateUnaryOperatedFS_Click(object sender, EventArgs e)
        {
            //get fuzzy set operand
            //checkout whether a fuzzy set is selected
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 2) return;  //選在fuzzy set 上
            if (cbxUnaryOperators.SelectedIndex < 0) return;   //index：0,1,2...

            FuzzySet operand = (FuzzySet)trvUniverses.SelectedNode.Tag;  //operand：區域變數
            UnaryFuzzySetOperator op = null;  //op：區域變數  //子類別物件可以看成父類別(物件導向)
           
            //create unary operator           
            switch (cbxUnaryOperators.SelectedIndex)
            {
                case 0:  //Negate
                    op = new Negate();
                    break;
                case 1:  //Alpha Cut
                    op = new AlphaCut(0.5);
                    break;
                case 2:  //Alpha Scale
                    op = new AlphaScale(0.8);
                    break;
                case 3:  //Concentration
                    op = new Concentration();
                    break;
                case 4:  //Dilation
                    op = new Dilation();
                    break;
                case 5:  //Extremely
                    op = new Extremely();
                    break;
                case 6:  //Intensification
                    op = new Intensification();
                    break;
                case 7:  //Diminisher
                    op = new Diminisher();
                    break;
                case 8:  //Sugeno Negate
                    op = new Sugeno_Negate(0.9);
                    break;
                case 9:  //Yager Negate
                    op = new Yager_Negate(0.4);
                    break;
            }

            //create unary operated fuzzy set
            FuzzySet aFS = null;  //aFS：區域變數  //子類別物件可以看成父類別(物件導向)
            aFS = new UnaryOperatedFuzzySet(operand, op);

            TreeNode fsNode = new TreeNode();
            fsNode.Tag = aFS;
            fsNode.Text = aFS.Title;
            fsNode.ImageIndex = 3;
            fsNode.SelectedImageIndex = fsNode.ImageIndex;
            trvUniverses.SelectedNode.Parent.Nodes.Add(fsNode);  //parent同位階
            //trvUniverses.SelectedNode = fsNode;  //(強制設成Fuzzy Set的Node)//直接跳回Universe新增
            trvUniverses.ExpandAll();

            ppgTarget.SelectedObject = aFS;

            aFS.ShowSeries = true;
            trvUniverses_AfterSelect(null, null);  //呼叫function：SelectedNode的Series變粗
        }
    
        private void labOperand1_Click_1(object sender, EventArgs e)
        {
            //get fuzzy set operand 1
            //checkout whether a fuzzy set is selected
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 2) return;
            if (cbxFSTypes.SelectedIndex < 0) return;

            labOperand1.Tag = trvUniverses.SelectedNode.Tag;  //fuzzy set藏在SelectedNode裡面
            labOperand1.Text= trvUniverses.SelectedNode.Text;
        }

        private void labOperand2_Click(object sender, EventArgs e)
        {
            //get fuzzy set operand 2
            //checkout whether a fuzzy set is selected
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 2) return;
            if (cbxFSTypes.SelectedIndex < 0) return;            

            labOperand2.Tag = trvUniverses.SelectedNode.Tag;  //fuzzy set藏在SelectedNode裡面
            labOperand2.Text = trvUniverses.SelectedNode.Text;
        }

        private void btnCreateBinaryOperatedFS_Click(object sender, EventArgs e)
        {
            //get fuzzy set operand1、operand2
            //checkout whether a fuzzy set is selected
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 2) return; //選在fuzzy set 上
            if (cbxBinaryOperators.SelectedIndex < 0) return;   //index：0,1,2...
            
            FuzzySet operand1 = (FuzzySet)labOperand1.Tag;  //operand：區域變數
            FuzzySet operand2 = (FuzzySet)labOperand2.Tag;
            BinaryFuzzySetOperator op = null;  //op：區域變數  //子類別物件可以看成父類別(物件導向)

            //create binary operator           
            switch (cbxBinaryOperators.SelectedIndex)
            {
                case 0:  //Minimum T-norm
                    op = new MinimumTnorm();
                    break;
                case 1:  //Algebraic Product
                    op = new AlgebraicProduct();
                    break;
                case 2:  //Bounded Product
                    op = new BoundedProduct();
                    break;
                case 3:  //Drastic Product
                    op = new DrasticProduct();
                    break;
                case 4:  //Maximum S-norm
                    op = new MaximumSnorm();
                    break;
                case 5:  //Algebraic Sum
                    op = new AlgebraicSum();
                    break;
                case 6:  //Bounded Sum
                    op = new BoundedSum();
                    break;
                case 7:  //Drastic Sum
                    op = new DrasticSum();
                    break;
                case 8:  //Sugeno T-norm
                    op = new Sugeno_Tnorm(0.8);
                    break;
                case 9:  //Yager T-norm
                    op = new Yager_Tnorm(0.7);
                    break;
                case 10:  //Hamacher T-norm
                    op = new Hamacher_Tnorm(0.8);
                    break;                
                case 11:  //Schweizer-Sklar T-norm
                    op = new SchweizerSklar_Tnorm(0.5);
                    break;
                case 12:  //Sugeno S-norm
                    op = new Sugeno_Snorm(0.3);
                    break;
                case 13:  //Yager S-norm
                    op = new Yager_Snorm(0.2);
                    break;
                case 14:  //Hamacher S-norm
                    op = new Hamacher_Snorm(0.4);
                    break;
                
            }

            //operand1、operand2 need to depened on same universe
            if (operand1.TheUniverse.TheChartArea != operand2.TheUniverse.TheChartArea)
            {
                MessageBox.Show("Two Fuzzy Set must in the same Universe!!");
                return;
            }

            //create binary operated fuzzy set
            FuzzySet aFS = null;  //aFS：區域變數  //子類別物件可以看成父類別(物件導向)
            aFS = new BinaryOperatedFuzzySet(operand1, operand2, op);

            TreeNode fsNode = new TreeNode();
            fsNode.Tag = aFS;
            fsNode.Text = aFS.Title;
            fsNode.ImageIndex = 3;
            fsNode.SelectedImageIndex = fsNode.ImageIndex;
            trvUniverses.SelectedNode.Parent.Nodes.Add(fsNode);  //parent同位階
            //trvUniverses.SelectedNode = fsNode;    //(強制設成Fuzzy Set的Node)//直接跳回Universe新增
            trvUniverses.ExpandAll();

            ppgTarget.SelectedObject = aFS;

            aFS.ShowSeries = true;
            trvUniverses_AfterSelect(null, null);  //呼叫function：SelectedNode的Series變粗
        }

        private void btnAddRules_Click(object sender, EventArgs e)
        {
            if(dgvRules.ColumnCount > 0)  //
            dgvRules.Rows.Add();
        }

        private void dgvRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                //checkout whether a fuzzy set is selected
                if (trvUniverses.SelectedNode.Level == 2)
                {
                    //guarding：fuzzy set need to put in the specific column (the same universe)
                    if (trvUniverses.SelectedNode.Parent.Tag == dgvRules.Columns[e.ColumnIndex].Tag)
                    {
                        DataGridViewCell cell = dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex];  //Rows：collection->第幾個row(e.RowIndex)
                        FuzzySet fs = (FuzzySet)trvUniverses.SelectedNode.Tag;  //object(cast Fuzzy Set)
                        cell.Tag = fs;
                        cell.Value = fs.Title;  //value放object
                    }
                    else if (trvUniverses.SelectedNode.Parent.Tag != dgvRules.Columns[e.ColumnIndex].Tag)
                    {
                        if (MessageBox.Show($"The selected fuzzy set {((FuzzySet)trvUniverses.SelectedNode.Tag).Title} is defined in {((Universe)trvUniverses.SelectedNode.Parent.Tag).Title}.\nIt's not defined in clicked {dgvRules.Columns[e.ColumnIndex].HeaderText}." , "Failed Selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            return;
                        }
                    }
                }
            }
            foreach (DataGridViewRow ruleRow in dgvRules.Rows)
            {
                foreach (DataGridViewCell ruleCell in ruleRow.Cells)
                {
                    foreach (DataGridViewRow conditionRow in dgvCondition.Rows)
                    {
                        foreach (DataGridViewCell conditionCell in conditionRow.Cells)
                        {
                            //guarding：cells cannot be empty
                            if (ruleCell.Value != null && conditionCell.Value != null)
                            {
                                btnSingleInference.Enabled = true;
                            }
                            else if (ruleCell.Value == null || conditionCell.Value == null)
                            {                                 
                                btnSingleInference.Enabled = false;                                
                            }
                        }
                    }
                }
            }
            foreach (DataGridViewRow ruleRow in dgvRules.Rows)
            {
                foreach (DataGridViewCell ruleCell in ruleRow.Cells)
                {
                    //guarding：cells cannot be empty
                    if (ruleCell.Value != null )
                    {
                        btnCrispAllInference.Enabled = true;
                    }
                    else if (ruleCell.Value == null)
                    {
                        btnCrispAllInference.Enabled = false;
                    }
                }
            }
        }
        private void dgvCondition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                //checkout whether a fuzzy set is selected
                if (trvUniverses.SelectedNode.Level == 2)
                {
                    //guarding：fuzzy set need to put in the specific column (the same universe)
                    if (trvUniverses.SelectedNode.Parent.Tag == dgvCondition.Columns[e.ColumnIndex].Tag)  //藏的Tag皆為universe
                    {
                        DataGridViewCell cell = dgvCondition.Rows[e.RowIndex].Cells[e.ColumnIndex];  //Rows：collection->第幾個row(e.RowIndex)
                        FuzzySet fs = (FuzzySet)trvUniverses.SelectedNode.Tag;  //object(cast Fuzzy Set)
                        cell.Tag = fs;
                        cell.Value = fs.Title;  //value放object
                    }
                    else if (trvUniverses.SelectedNode.Parent.Tag != dgvCondition.Columns[e.ColumnIndex].Tag)
                    {
                        if (MessageBox.Show($"The selected fuzzy set {((FuzzySet)trvUniverses.SelectedNode.Tag).Title} is defined in {((Universe)trvUniverses.SelectedNode.Parent.Tag).Title}.\nIt's not defined in clicked {dgvCondition.Columns[e.ColumnIndex].HeaderText}.", "Failed Selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            return;
                        }
                    }
                }
            }
            foreach (DataGridViewRow ruleRow in dgvRules.Rows)
            {
                foreach (DataGridViewCell ruleCell in ruleRow.Cells)
                {
                    foreach (DataGridViewRow conditionRow in dgvCondition.Rows)
                    {
                        foreach (DataGridViewCell conditionCell in conditionRow.Cells)
                        {
                            //guarding：cells cannot be empty
                            if (ruleCell.Value != null && conditionCell.Value != null)
                            {
                                btnSingleInference.Enabled = true;
                            }
                            else if (ruleCell.Value == null || conditionCell.Value == null)
                            {
                                btnSingleInference.Enabled = false;
                            }
                        }
                    }
                }
            }
            foreach (DataGridViewRow ruleRow in dgvRules.Rows)
            {
                foreach (DataGridViewCell ruleCell in ruleRow.Cells)
                {
                    //guarding：cells cannot be empty
                    if (ruleCell.Value != null)
                    {
                        btnCrispAllInference.Enabled = true;
                    }
                    else if (ruleCell.Value == null)
                    {
                        btnCrispAllInference.Enabled = false;
                    }
                }
            }
        }
                
        private void btnSingleInference_Click(object sender, EventArgs e)
        {
            IfThenRule[] rules = null;
            FuzzySet[] conditions =null;

            if (dgvRules.RowCount == 0)  //
            {
                if (MessageBox.Show("No rules are defined.\nPlease set up a rule first.", "Set up Rules",
                    MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    return;
                }
            }
             
            if (dgvRules.ColumnCount > 0)
            {
                //check Datagridview setup rules
                //List<IfThenRule> rules = new List<IfThenRule>();  //動態一一添加(generic)
                rules = new IfThenRule[dgvRules.RowCount];  //幾條rules
                for (int r = 0; r < dgvRules.RowCount; r++)  //每個row需獨立new出來
                {
                    FuzzySet[] inputs;
                    inputs = new FuzzySet[dgvRules.ColumnCount - 1];  //總column數減1               
                    for (int c = 0; c < inputs.Length; c++)  //length：陣列總數
                    {
                        inputs[c] = (FuzzySet)dgvRules.Rows[r].Cells[c].Tag;  //cell骨子裡為fuzzy set
                    }

                    if (rbtnSugeno.Checked)
                    {
                        int eId;

                    }
                    else
                    {
                        FuzzySet output;
                        output = (FuzzySet)dgvRules.Rows[r].Cells[dgvRules.ColumnCount - 1].Tag;  //最後一個column
                        if (rbtnMamdani.Checked)
                            rules[r] = new MamdaniIfThenRule(inputs, output);
                        //else
                        //    rules[r] = new TuskamotoIfThenRule(inputs, output);
                    }
                }

                //check Datagridview setup condtion
                conditions = new FuzzySet[dgvRules.ColumnCount - 1];  //總column數減1               
                for (int c = 0; c < conditions.Length; c++)
                {
                    conditions[c] = (FuzzySet)dgvCondition.Rows[0].Cells[c].Tag;  //row只有一行
                }
            }

            // Instantiate an object of Fuzzy Inference System
            if (rbtnMamdani.Checked)
                theFussySystem = new MamdaniInferenceSystem(rules);
            else if (rbtnSugeno.Checked)
                theFussySystem = new FuzzyInferenceSystem(rules);
            // else 
            //
            FuzzySet result = null;

            result = theFussySystem.FuzzyInFuzzyOutInference( conditions, rbtnCut.Checked );
            //inference each rules
            //for (int i = 0; i < rules.Length; i++)
            //{
            //    FuzzySet ruleOut = rules[i].Inference(conditions); //結果為fuzzy set
            //    if (result == null) result = ruleOut;  //i=0，result=null
            //    else
            //        //result = result | ruleOut;  //原本rule1的ruleOut聯集rule2的ruleOut
            //        result |= ruleOut;
            //}
            result.ShowSeries = true;
            result.TheChartType = SeriesChartType.Area;
            result.TheSeries.Color = Color.DarkGray;
        }

        private void btnCrispAllInference_Click(object sender, EventArgs e)
        {
            if (dgvRules.RowCount == 0)  //
            {
                if (MessageBox.Show("No rules are defined.\nPlease set up a rule first.", "Set up Rules",
                    MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    return;
                }
            }
            if (dgvRules.ColumnCount > 0)
            {
                //check Datagridview setup rules
                MamdaniIfThenRule[] rules = new MamdaniIfThenRule[dgvRules.RowCount];  //幾條rules
                for (int r = 0; r < dgvRules.RowCount; r++)  //每個row需獨立new出來
                {
                    FuzzySet[] inputs;
                    inputs = new FuzzySet[dgvRules.ColumnCount - 1];  //總column數減1               
                    for (int c = 0; c < inputs.Length; c++)  //length：陣列總數
                    {
                        inputs[c] = (FuzzySet)dgvRules.Rows[r].Cells[c].Tag;  //cell骨子裡為fuzzy set
                    }
                    if (rbtnMamdani.Checked)
                    {
                        FuzzySet output;
                        output = (FuzzySet)dgvRules.Rows[r].Cells[dgvRules.ColumnCount - 1].Tag;  //最後一個column
                        rules[r] = new MamdaniIfThenRule(inputs, output);
                    }
                    // else ...
                }

                //check Crisp condtion
                double[] conditions;
                string[] items = txbCrisp.Text.Split(',');  //碰到逗號隔開，知道有幾個
                conditions = new double[items.Length];
                for (int c = 0; c < conditions.Length; c++)
                {
                    conditions[c] = Convert.ToDouble(items[c]);
                }

                // Instantiate an object of Fuzzy Inference System
                if (rbtnMamdani.Checked)
                    theFussySystem = new MamdaniInferenceSystem(rules);
                else if (rbtnSugeno.Checked)
                    theFussySystem = new FuzzyInferenceSystem(rules);

              FuzzySet result =   theFussySystem.CrispInFuzzyOutInference(conditions, rbtnCut.Checked);
                ////inference each rules
                //null;
                //for (int i = 0; i < rules.Length; i++)
                //{
                //    FuzzySet ruleOut = rules[i].Inference(conditions); //結果為fuzzy set
                //    if (result == null) result = ruleOut;  //i=0，result=null
                //    else
                //        //result = result | ruleOut;  //原本rule1的ruleOut聯集rule2的ruleOut
                //        result |= ruleOut;
                //}
                result.ShowSeries = true;
                result.TheChartType = SeriesChartType.Area;
                result.TheSeries.Color = Color.DarkGray;               
            }
        }

        private void btnDeleteRule_Click(object sender, EventArgs e)
        {
            if (dgvRules.RowCount != 0)  //不存在row時無法刪除
            {
                if (MessageBox.Show("The selected rule will be deleted.\nAre you sure to delete it?", "Confirmation", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DataGridViewRow row = dgvRules.SelectedRows[0];
                    dgvRules.Rows.Remove(row);     
                }                           
            }
        }

        private void InferenceSystemChanged(object sender, EventArgs e)
        {
            if(rbtnSugeno.Checked)
            {
                tbcFS_Rules.TabPages.Add(pagSugeno);
            }
            else
            {
                tbcFS_Rules.TabPages.Remove(pagSugeno);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // for one-d and two-D
            Universe ux =null, uz=null;
            int xnum =30, znum=30;
            surface1.NumXValues = xnum;
            surface1.NumZValues = znum;
            double xinc, zinc;
            xinc = ( ux.UpperBound - ux.LowerBound ) / (xnum - 1);
            zinc = (uz.UpperBound - uz.LowerBound) / (znum - 1);
            double[] inputs = new double[2];
            surface1.Clear();
            for( int x = 0; x < xnum; x++)
            {
                for( int z = 0; z < znum; z++)
                {
                   inputs[0] = ux.LowerBound + x * xinc;
                    inputs[1] = uz.LowerBound + z * zinc;
                    double yy = theFussySystem.CrispInCrispOutInference(inputs);
                    surface1.Add(inputs[0], yy, inputs[1]);
                }
            }
        }
    }
}
