using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace R08546036_SHChaoAss05
{
    public partial class MainForm : Form
    {
        #region variable
        // variable to store binary operation fuzzyset
        FuzzySet binaryOperationFuzzyOne;
        FuzzySet binaryOperationFuzzyTwo;
        // counter 
        private static int graphTabCount = 0;
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        protected void MainForm_Load(object sender, EventArgs e)
        {

            // Tooltips
            ToolTip theTreeToolTip = new ToolTip();
            theTreeToolTip.ShowAlways = true;
            theTreeToolTip.SetToolTip(theTree, "Right Click to: \n  1. Create Universe and Fuzzy Set.\n  2. Apply Unary or Binary Operation");

            ToolTip theChartToolTip = new ToolTip();
            theChartToolTip.ShowAlways = true;
            theChartToolTip.SetToolTip(tabControl1, "Chart of Universe Shows Here.");

            // Label
            lbInstruction.BackColor = theTree.BackColor;

        }

        // create universe function
        private void universeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Universe uobj;
            Chart mainChart = new Chart();

            // create new tab if new Universe is created
            TabPage newTabPage = new TabPage();
            // add tab into tabcontrol
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectedTab = newTabPage;
            mainChart.Parent = newTabPage;
            uobj = new Universe(mainChart);
            newTabPage.Text = uobj.Title;
            newTabPage.ToolTipText = $"Chart of {uobj.Title}.";
            // adjust chart size to fit tab
            mainChart.Dock = DockStyle.Fill;

            // tag tab to universe
            uobj.BindedTab = tabControl1.TabPages[graphTabCount];
            graphTabCount += 1;
            // tag chart to universe
            uobj.BindedChart = mainChart;
            
            // Add a node inside the Universe
            TreeNode aNode = new TreeNode(uobj.Title);
            aNode.Tag = uobj;
            theTree.Nodes.Add(aNode);
            theTree.SelectedNode = aNode;
            theGrid.SelectedObject = uobj;
        }

        // create fuzzy set function
        private void CreateFuzzySet(object sender, EventArgs e)
        {
            // get property of defined menuitem control
            int selectedIndex = (sender as ToolStripMenuItemFuzzy).SelectedIndex;

            Universe selectedU;
            FuzzySet aFS;
            try
            {
                if (theTree.SelectedNode.Tag is Universe)
                {
                    selectedU = (Universe)theTree.SelectedNode.Tag;

                    // assign relative FuzzySet to the variable
                    switch (selectedIndex)
                    {
                        case 0:
                            // Triangular Function
                            aFS = new TriangularFuzzySet(selectedU);
                            break;
                        case 1:
                            // Bell Function
                            aFS = new BellFuzzySet(selectedU);
                            break;
                        case 2:
                            // Gaussian Function
                            aFS = new GaussianFuzzySet(selectedU);
                            break;
                        case 3:
                            // Sigmoidal Function
                            aFS = new SigmoidFuzzySet(selectedU);
                            break;
                        case 4:
                            // Trapezoidal Function
                            aFS = new TrapezoidalFuzzySet(selectedU);
                            break;
                        case 5:
                            // LeftRight Function
                            aFS = new LeftRightFuzzySet(selectedU);
                            break;
                        case 6:
                            // SMFuzzySet
                            aFS = new SMFuzzySet(selectedU);
                            break;
                        case 7:
                            // ZMF Fuzzy Set
                            aFS = new ZMFuzzySet(selectedU);
                            break;
                        case 8:
                            // Pi Fuzzy Set
                            aFS = new PiFuzzySet(selectedU);
                            break;
                        default:
                            // the following lines are not likely to be executed.
                            aFS = new TriangularFuzzySet(selectedU);
                            break;
                    }
                    // Add a subnode to selected node
                    TreeNode cNode = new TreeNode(aFS.Title);
                    cNode.Tag = aFS;
                    theTree.SelectedNode.Nodes.Add(cNode);
                    cNode.Name = aFS.Title;
                    aFS.ShowSeries = true;
                    theTree.ExpandAll();
                    theTree.Focus();

                }
                else
                {
                    MessageBox.Show("You could only create fuzzy set under a Universe!");
                }
            }
            catch (System.NullReferenceException exception)
            {
                MessageBox.Show("Create Universe First!!!");
            }
        }

        // after select function
        private void theTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            theGrid.SelectedObject = theTree.SelectedNode.Tag;
        }

        // Grid property change function
        private void theGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            GridItem gi = e.ChangedItem;
            object ov = e.OldValue;
            if (theTree.SelectedNode.Tag is Universe)
            {
                theTree.SelectedNode.Text = ((Universe)theTree.SelectedNode.Tag).Title;
            }
            else if (theTree.SelectedNode.Tag is FuzzySet)
            {
                theTree.SelectedNode.Text = ((FuzzySet)theTree.SelectedNode.Tag).Title;
                ((FuzzySet)theTree.SelectedNode.Tag).UpdateSeriesDataPoints();
            }
        }

        // Function to Restart
        private void topFileRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        // Unary Operation
        private void createUnaryFuzzySet(object sender, EventArgs e)
        {
            try {
                // return if not fuzzy set
                if (!(theTree.SelectedNode.Tag is FuzzySet))
                {
                    MessageBox.Show("Selected Node is not Fuzzy Set!");
                    return;
                }

                int selectedIndex = (sender as ToolStripMenuItemFuzzy).SelectedIndex;
                FuzzySet fs = (FuzzySet)theTree.SelectedNode.Tag;
                FuzzySet newFs = null;
                UnaryFSOperator op = null;

                switch (selectedIndex)
                {
                    case 0: // negate
                        newFs = !fs;
                        break;
                    case 1: // value-cut
                        newFs = -fs;
                        break;
                    case 2: // value scale
                        op = new ValueScaleOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 3: // Very
                        op = new VeryOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 4: // Dilation
                        op = new DilationOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 5: // Extremely
                        op = new ExtremelyOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 6: // Intensification
                        op = new IntensificationOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                    case 7: //Diminisher
                        op = new DiminisherOperator();
                        newFs = new UnaryOperatedFuzzySet(fs, op);
                        break;
                }

                //newFs = new UnaryOperatedFuzzySet(fs, op);

                // Add a subnode to selected node
                TreeNode cNode = new TreeNode(newFs.Title);
                cNode.Tag = newFs;
                theTree.SelectedNode.Parent.Nodes.Add(cNode); // add node in parent node.
                cNode.Name = newFs.Title;
                newFs.ShowSeries = true;
                theTree.ExpandAll();
                theTree.Focus();
            }
            catch (System.NullReferenceException Exception)
            {
                MessageBox.Show("Create Universe/Fuzzy Set First!");
            }
        }

        // Binary Operation
        private void selectAsBinaryFuzzy(object sender, EventArgs e)
        {
            try {
                if (theTree.SelectedNode.Tag is FuzzySet)
                {
                    int selectedIndex = (sender as ToolStripMenuItemFuzzy).SelectedIndex;
                    switch (selectedIndex)
                    {
                        case 0:
                            foreach (TreeNode node in theTree.Nodes)
                            {
                                BinaryChangeNodesColor(node, Color.Yellow);
                            }
                            binaryOperationFuzzyOne = (FuzzySet)theTree.SelectedNode.Tag;
                            theTree.SelectedNode.BackColor = Color.Yellow;
                            break;
                        case 1:
                            foreach (TreeNode node in theTree.Nodes)
                            {
                                BinaryChangeNodesColor(node, Color.Pink);
                            }
                            binaryOperationFuzzyTwo = (FuzzySet)theTree.SelectedNode.Tag;
                            theTree.SelectedNode.BackColor = Color.Pink;
                            break;
                    }
                    // operation start after two fuzzy set is selected
                    // check if two selected fuzzy set is the same
                    if (binaryOperationFuzzyOne == binaryOperationFuzzyTwo)
                    {
                        MessageBox.Show("Caution: Two Fuzzy Set Selected are the same!");
                    }

                }
                else
                {
                    MessageBox.Show("Selected Node is not Fuzzy Set");
                }
            }
            catch (System.NullReferenceException Exception)
            {
                MessageBox.Show("Create Universe/Fuzzy Set First!\nSelect Fuzzy Set 1 & 2 First!");
            }
        }

        private void createBinaryFuzzySet(object sender, EventArgs e)
        {
            try {
                // check if universe are same
                if (binaryOperationFuzzyOne.TheUniverse != binaryOperationFuzzyTwo.TheUniverse)
                {
                    MessageBox.Show("Two Fuzzy Set Selected are not in same Universe!");
                    return;
                }

                int selectedIndex = (sender as ToolStripMenuItemFuzzy).SelectedIndex;
                FuzzySet newFs = null;
                BinaryFSOperator op = null;

                switch (selectedIndex)
                {
                    case 0: // Intersection
                        op = new IntersectionOperator();
                        break;
                    case 1: // Union Function
                        op = new UnionOperator();
                        break;
                    case 2: // substraction
                        op = new SubstractionOperator();
                        break;
                    case 3: // T-norm: Minimum
                        op = new TNormMinimumOperator();
                        break;
                    case 4:  // T-norm: Algebraic
                        op = new TNormAlgebraicOperator();
                        break;
                    case 5: // T-norm: Bounded Product
                        op = new TNormBoundedOperator();
                        break;
                    case 6: // T-norm: Drastic Product
                        op = new TNormDrasticOperator();
                        break;
                    case 7: // S-norm: Maximum
                        op = new SNormMaximumOperator();
                        break;
                    case 8: // S-norm: Algebraic
                        op = new SNormAlgebraicOperator();
                        break;
                    case 9: // S-norm: Bouded
                        op = new SNormBoundedOperator();
                        break;
                    case 10: // S-norm: Drastic
                        op = new SNormDrasticOperator();
                        break;

                }

                newFs = new BinaryOperatedFuzzySet(binaryOperationFuzzyOne,
                                binaryOperationFuzzyTwo,
                                op);

                // Add a subnode to selected node
                TreeNode cNode = new TreeNode(newFs.Title);
                cNode.Tag = newFs;
                theTree.SelectedNode.Parent.Nodes.Add(cNode); // add node in parent node.
                cNode.Name = newFs.Title;
                newFs.ShowSeries = true;
                theTree.ExpandAll();
                theTree.Focus();
            }
            catch (System.NullReferenceException Exception)
            {
                MessageBox.Show("Create Universe/Fuzzy Set First!\nSelect Fuzzy Set 1 & 2 First!");
            }


        }

        // recursive function to get all nodes in levels 
        private void BinaryChangeNodesColor(TreeNode node, Color color)
        {
            if (node.BackColor == color)
            {
                node.BackColor = theTree.BackColor;
            }
            // recursive code
            foreach (TreeNode subnode in node.Nodes)
            {
                BinaryChangeNodesColor(subnode, color);
            }
        }

        // remove universe/fuzzyset function
        private void removeUniverseOrFuzzy(object sender, EventArgs e)
        {
            int selectedIndex = (sender as ToolStripMenuItemFuzzy).SelectedIndex;
            try
            {
                switch (selectedIndex)
                {
                    case 0: // remove Universe
                        if (theTree.SelectedNode.Tag is Universe)
                        {
                            tabControl1.TabPages.Remove(((Universe)theTree.SelectedNode.Tag).BindedTab);
                            theTree.Nodes.Remove(theTree.SelectedNode);
                        }
                        else
                        {
                            MessageBox.Show("Selected Node is not Universe!");
                        }
                        break;
                    case 1: // remove fuzzy
                        if (theTree.SelectedNode.Tag is FuzzySet)
                        {
                            ((FuzzySet)theTree.SelectedNode.Tag).TheUniverse.BindedChart.Series.Remove(((FuzzySet)theTree.SelectedNode.Tag).BindedSeries);
                            theTree.Nodes.Remove(theTree.SelectedNode);
                        }
                        else
                        {
                            MessageBox.Show("Selected Node is not Fuzzy Set!");
                        }
                        break;
                }

            }
            catch(System.NullReferenceException Exception) {
                MessageBox.Show("Create Universe/Fuzzy Set First!");
            }
        }

        // mouse hover instruction close function
        private void CloseInstruction(object sender, EventArgs e)
        {
            lbInstruction.Visible = false;
        }
    }
}
