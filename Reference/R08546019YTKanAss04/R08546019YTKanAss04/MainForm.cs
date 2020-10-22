using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546019YTKanAss04
{
    public partial class MainForm : Form
    {
        FunctionTakeNoArgumentReturnNothing fistFunction;
        FunctionTakesOneIntAndReturnInt seconFunction;

        void f1()
        {
            MessageBox.Show("f1() is called");
        }
        void f2()
        {
            MessageBox.Show("f2() is called");
        }

        int g1( int i )
        {
            MessageBox.Show($"g1( {i} ) is called");
            return 0;
        }
        int g2( int j )
        {
            MessageBox.Show( $"g2( {j} ) is called");
            return 1;
        }

        //Universe u1成員變數
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCreateUniverse_Click(object sender, EventArgs e)
        //區域變數this：函式是否屬於此類別MainForm(data u1)
        //區域變數sender：按鈕觸發事件
        //區域變數e：事件相關的data
        //板手符號：properties與data有關，骨子裡為function
        {
            Universe u1 = new Universe(labOperand1);  //u1：區域變數  //null：參考型別、開啟記憶體
            TreeNode aNode = new TreeNode();        //aNode：區域變數(函式執行完變數不存在/new恆存在)

            aNode.Tag = u1;                         //tag：與某物件息息相關、紀錄及拷貝參照(非資料拷貝)//任何類別都間接繼承至Object
            aNode.Text = u1.Title;            

            ppgTarget.SelectedObject = u1;

            trvUniverses.Nodes.Add(aNode);          //集合(Nodes)一定有Add：屬性加東西
            trvUniverses.SelectedNode = aNode;
        }

        private void trvUniverses_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ppgTarget.SelectedObject = trvUniverses.SelectedNode.Tag;
        }

        private void ppgTarget_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //chekout whether selectedNode is Universe or Fuzzy Set
            //selected is a Universe
            if (trvUniverses.SelectedNode.Level == 0) 
                trvUniverses.SelectedNode.Text = ((Universe)trvUniverses.SelectedNode.Tag).Title;
            //selected is a Fuzzy Set
            else if (trvUniverses.SelectedNode.Level == 1)
                trvUniverses.SelectedNode.Text = ((FuzzySet)trvUniverses.SelectedNode.Tag).Title;
        }

        private void btnCreateFuzzySet_Click(object sender, EventArgs e)
        {
            //checkout whether a universe is selected
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 0) return;  //!=：non equal

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
                //case 1: //Triangular Fuzzy Set
                //    TriangularFuzzySet t = new TriangularFuzzySet(su); //t；block變數
                //    TreeNode tfsNode = new TreeNode();
                //    tfsNode.Tag = t;
                //    tfsNode.Text = t.Title;
                //    trvUniverses.SelectedNode.Nodes.Add(tfsNode);
                //    ppgTarget.SelectedObject = t;
                //    break;
                //case 2: //Trapezoidal Fuzzy Set
                //    TrapezoidalFuzzySet tz = new TrapezoidalFuzzySet(su); //tz；block變數
                //    TreeNode tzfsNode = new TreeNode();
                //    tzfsNode.Tag = tz;
                //    tzfsNode.Text = tz.Title;
                //    trvUniverses.SelectedNode.Nodes.Add(tzfsNode);
                //    ppgTarget.SelectedObject = tz;
                //    break;
                //case 3: //Bell Fuzzy Set
                //    BellFuzzySet b = new BellFuzzySet(su); //b；block變數
                //    TreeNode bfsNode = new TreeNode();
                //    bfsNode.Tag = b;
                //    bfsNode.Text = b.Title;
                //    trvUniverses.SelectedNode.Nodes.Add(bfsNode);
                //    ppgTarget.SelectedObject = b;
                //    break;
                //case 4: //Sigmoidal Fuzzy Set
                //    SigmoidalFuzzySet s = new SigmoidalFuzzySet(su); //s；block變數
                //    TreeNode sfsNode = new TreeNode();
                //    sfsNode.Tag = s;
                //    sfsNode.Text = s.Title;
                //    trvUniverses.SelectedNode.Nodes.Add(sfsNode);
                //    ppgTarget.SelectedObject = s;
                //    break;
                //case 5: //Left-Right Fuzzy Set
                //    LeftRightFuzzySet lf = new LeftRightFuzzySet(su); //lf；block變數
                //    TreeNode lffsNode = new TreeNode();
                //    lffsNode.Tag = lf;
                //    lffsNode.Text = lf.Title;
                //    trvUniverses.SelectedNode.Nodes.Add(lffsNode);
                //    ppgTarget.SelectedObject = lf;
                //    break;

            }

            TreeNode fsNode = new TreeNode();
            fsNode.Tag = aFS;
            fsNode.Text = aFS.Title;
            trvUniverses.SelectedNode.Nodes.Add(fsNode);
            trvUniverses.SelectedNode = fsNode;  //強制設成Fuzzy Set的Node
            ppgTarget.SelectedObject = aFS;

            aFS.ShowSeries = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            trvUniverses.Nodes.Remove(trvUniverses.SelectedNode);
            //mainChart.ChartAreas.Remove();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fistFunction = f2;
            fistFunction += f1;
            // call delegate
            fistFunction();
        }

        private void btnUnaryOperatedFS_Click(object sender, EventArgs e)
        {
            // get fuzzy set operand
            //checkout whether a universe is selected
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 1) return;  //!=：non equal       
            if (cbxUnaryOperators.SelectedIndex < 0) return;
            FuzzySet operand = (FuzzySet) trvUniverses.SelectedNode.Tag;

            // create unary operator
            UnaryFSOperator op = null;
            switch( cbxUnaryOperators.SelectedIndex )
            {
                case 0: // negate
                    op = new Negate();
                    break;
                case 1: // alpha-cut
                    op = new AlphaCut(0.8);
                    break;
            }
            // create Unary Operated Fuzzy Set
            FuzzySet aFS = null;
            aFS = new UnaryOperatedFS(operand, op);

            TreeNode fsNode = new TreeNode();
            fsNode.Tag = aFS;
            fsNode.Text = aFS.Title;
            trvUniverses.SelectedNode.Parent.Nodes.Add(fsNode);
            trvUniverses.SelectedNode = fsNode;  //強制設成Fuzzy Set的Node
            ppgTarget.SelectedObject = aFS;

            aFS.ShowSeries = true;

        }

        private void labOperand1_Click(object sender, EventArgs e)
        {
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 1) return;
            labOperand1.Tag = trvUniverses.SelectedNode.Tag;
            labOperand1.Text = trvUniverses.SelectedNode.Text;
        }
    }
}
