using R08546036_SHChaoAss05;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace R08546036_SHChaoAss04
{
    public partial class MainForm : Form
    {
        #region variable
        // variable to store binary operation fuzzyset
        FuzzySet binaryOperationFuzzyOne;
        FuzzySet binaryOperationFuzzyTwo;
        // counter 
        private static int graphTabCount = 0;
        // other variables
        private Random randomizer = new Random();
        #endregion

        public MainForm()
        {
            InitializeComponent();
            // let application to go full screen
            WindowState = FormWindowState.Maximized;
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
            lbIfThenInstruction.BackColor = dgvRules.BackgroundColor;
            lbSetTip.Text = "";

            // theTree Property


        }

        // create universe function
        private void universeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Universe uobj;
            Chart mainChart = new Chart();

            // check if selecting input/output node
            int nodeIndex;
            if (theTree.SelectedNode.Text == "Input")
            {
                nodeIndex = 0;
            }
            else if (theTree.SelectedNode.Text == "Output")
            {
                nodeIndex = 1;
            }
            else
            {
                MessageBox.Show("You should either select Input or Output to add an Universe!");
                return;
            }
            // ensure instruction label is set invisible
            lbInstruction.Visible = false;

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

            // Add a node inside the Universe, either for input or output
            TreeNode aNode = new TreeNode(uobj.Title);
            aNode.Tag = uobj;
            theTree.Nodes[nodeIndex].Nodes.Add(aNode);
            theTree.SelectedNode = aNode;
            theGrid.SelectedObject = uobj;
            theTree.Focus();

            // add columns to two data grid views
            //dgvRules.Columns[2]
            //dgvRules.Columns[uobj.Title]
            //dgvRules.Columns.RemoveAt()
            dgvRules.Columns.Add(uobj.Title, uobj.Title);
            // column style properties
            dgvRules.Columns[uobj.Title].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRules.Columns[uobj.Title].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRules.Columns[uobj.Title].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRules.Columns[uobj.Title].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dgvRules.Columns[uobj.Title].DefaultCellStyle.ForeColor = Color.DarkBlue;

            // only add input in condition grid
            if (theTree.SelectedNode.Parent.Text == "Input")
            {
                // add row to dgvCondition
                dgvConditions.Columns.Add(uobj.Title, uobj.Title);
                if (dgvConditions.Rows.Count < 1) dgvConditions.Rows.Add();
                // column style properties
                dgvConditions.Columns[uobj.Title].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvConditions.Columns[uobj.Title].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvConditions.Columns[uobj.Title].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvConditions.Columns[uobj.Title].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                dgvConditions.Columns[uobj.Title].DefaultCellStyle.ForeColor = Color.DarkRed;
            }
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
            if (theTree.SelectedNode.Text != "Input" && theTree.SelectedNode.Text != "Output")
            {
                lbSetTip.Width = splitContainer6.Panel2.Width;
                lbSetTip.Height = splitContainer6.Panel2.Height;
                lbSetTip.Text = theTree.SelectedNode.Tag.ToString();
                lbSetTip.TextAlign = ContentAlignment.MiddleCenter;
            }
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
            try
            {
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
                        newFs = fs - randomizer.NextDouble();
                        break;
                    case 2: // value scale
                        newFs = fs * randomizer.NextDouble();
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
            try
            {
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
            try
            {
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
                        newFs = binaryOperationFuzzyOne & binaryOperationFuzzyTwo;
                        break;
                    case 1: // Union Function
                        newFs = binaryOperationFuzzyOne | binaryOperationFuzzyTwo;
                        break;
                    case 2: // substraction
                        newFs = binaryOperationFuzzyOne - binaryOperationFuzzyTwo;
                        break;
                    case 3: // T-norm: Minimum
                        op = new TNormMinimumOperator();
                        newFs = new BinaryOperatedFuzzySet(binaryOperationFuzzyOne,
                                binaryOperationFuzzyTwo,
                                op);
                        break;
                    case 4:  // T-norm: Algebraic
                        op = new TNormAlgebraicOperator();
                        newFs = new BinaryOperatedFuzzySet(binaryOperationFuzzyOne,
                                binaryOperationFuzzyTwo,
                                op);
                        break;
                    case 5: // T-norm: Bounded Product
                        op = new TNormBoundedOperator();
                        newFs = new BinaryOperatedFuzzySet(binaryOperationFuzzyOne,
                                binaryOperationFuzzyTwo,
                                op);
                        break;
                    case 6: // T-norm: Drastic Product
                        op = new TNormDrasticOperator();
                        newFs = new BinaryOperatedFuzzySet(binaryOperationFuzzyOne,
                                binaryOperationFuzzyTwo,
                                op);
                        break;
                    case 7: // S-norm: Maximum
                        op = new SNormMaximumOperator();
                        newFs = new BinaryOperatedFuzzySet(binaryOperationFuzzyOne,
                                binaryOperationFuzzyTwo,
                                op);
                        break;
                    case 8: // S-norm: Algebraic
                        op = new SNormAlgebraicOperator();
                        newFs = new BinaryOperatedFuzzySet(binaryOperationFuzzyOne,
                                binaryOperationFuzzyTwo,
                                op);
                        break;
                    case 9: // S-norm: Bouded
                        op = new SNormBoundedOperator();
                        newFs = new BinaryOperatedFuzzySet(binaryOperationFuzzyOne,
                                binaryOperationFuzzyTwo,
                                op);
                        break;
                    case 10: // S-norm: Drastic
                        op = new SNormDrasticOperator();
                        newFs = new BinaryOperatedFuzzySet(binaryOperationFuzzyOne,
                                binaryOperationFuzzyTwo,
                                op);
                        break;

                }



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
            catch (System.NullReferenceException Exception)
            {
                MessageBox.Show("Create Universe/Fuzzy Set First!");
            }
        }

        // mouse hover instruction close function
        private void CloseInstruction(object sender, EventArgs e)
        {
            lbInstruction.Visible = false;
        }

        private void dgvRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCell theCell = dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex];
                theCell.ReadOnly = true;
                // Aviod 
                if (theTree.SelectedNode.Tag is FuzzySet)
                {
                    theCell.Tag = theTree.SelectedNode.Tag;
                    string columnName = dgvRules.CurrentCell.OwningColumn.Name;
                    // check if the Universe is correct
                    if (((FuzzySet)theTree.SelectedNode.Tag).TheUniverse.Title != columnName)
                    {
                        // selected node is in different Universe
                        MessageBox.Show("Selected Node is in different Universe");
                        return;
                    }
                    // Text Property
                    theCell.Value = theTree.SelectedNode.Text;

                }
                else
                {
                    MessageBox.Show("Selected Node is not Fuzzy Set.");
                }
            }
            catch (System.ArgumentOutOfRangeException Exception)
            {
                MessageBox.Show("Do not touch the header!");
            }
        }

        private void dgvConditions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell theCell = dgvConditions.Rows[e.RowIndex].Cells[e.ColumnIndex];
            theCell.ReadOnly = true;
            // Aviod 
            if (theTree.SelectedNode.Tag is FuzzySet)
            {
                theCell.Tag = theTree.SelectedNode.Tag;
                string columnName = dgvConditions.CurrentCell.OwningColumn.Name;
                // check if the Universe is correct
                if (((FuzzySet)theTree.SelectedNode.Tag).TheUniverse.Title != columnName)
                {
                    // selected node is in different Universe
                    MessageBox.Show("Selected Node is in different Universe");
                    return;
                }
                // Text Property
                theCell.Value = theTree.SelectedNode.Text;
            }
            else
            {
                MessageBox.Show("Selected Node is not Fuzzy Set.");
            }
        }

        // create new rules of data grid
        private void toolStripMenuItemFuzzy1_Click(object sender, EventArgs e)
        {
            try
            {
                dgvRules.Rows.Add();
            }
            catch (System.InvalidOperationException Exception)
            {
                MessageBox.Show("Create Universe and Fuzzy Set first!!!");
            }

        }

        // drag event of theTree
        private void theTreeDrag(object sender, ItemDragEventArgs e)
        {
            // only drag node when using mouse left button
            if (e.Button == MouseButtons.Left)
            {
                // change selceted node to dragging node
                theTree.SelectedNode = (TreeNode)e.Item;
                // do drag drop
                ((TreeView)sender).DoDragDrop(e.Item, DragDropEffects.Move);



            }

        }

        private void theTree_DragEnter(object sender, DragEventArgs e)
        {
            TreeNode selectedNode = (sender as TreeView).SelectedNode;
        }

        private void inference_Click(object sender, EventArgs e)
        {
            // create if-then row
            IfThenFuzzyRule[] allRules = new IfThenFuzzyRule[dgvRules.Rows.Count];
            FuzzySet[] inputs = new FuzzySet[dgvRules.Columns.Count - 1];
            FuzzySet output;

            for (int r = 0; r <= dgvRules.Rows.Count; r++)
            {
                for (int c = 0; c < (dgvRules.Columns.Count - 1); c++)
                {
                    inputs[c] = (FuzzySet)dgvRules.Rows[r].Cells[c].Value;
                }
                output = (FuzzySet)dgvRules.Rows[r].Cells[dgvRules.Columns.Count].Value;
                allRules[r] = new IfThenFuzzyRule(inputs, output);
            }

            // conditions
            FuzzySet[] conditions = new FuzzySet[dgvConditions.Columns.Count];

            // set contents of conditions
            FuzzySet resultingFS = null;

            foreach (IfThenFuzzyRule rule in allRules)
            {
                if (resultingFS == null)
                {
                    resultingFS = rule.FuzzyInFuzzyOutInferencing(conditions);
                }
                else
                {
                    resultingFS = resultingFS | rule.FuzzyInFuzzyOutInferencing(conditions);
                }
            }
            // show the final fs
            resultingFS.ShowSeries = true;
        }


    }
}
