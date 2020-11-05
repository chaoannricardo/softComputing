using R08546036_SHChaoAss06;
using R08546036_SHChaoAss06;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
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
        // Sugeno configurations
        ListBox lbOutputEquation = new ListBox();
        TabPage sugenoTabPage = new TabPage();
        // inference cut or scale
        private bool isCut;
        // inference fuzzy set variable
        private IFuzzyInferencing mySystem;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            splitContainer11.SplitterDistance = (cbResulting.Height) / 2;
            splitContainer11.IsSplitterFixed = true;
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
            lbSaveAndOpen.Text = "Press File to further Load or Save Files";
            lbSaveAndOpen.Font = new Font("Arial", 12, FontStyle.Bold);
            lbSaveAndOpen.ForeColor = Color.DarkBlue;
            lbSaveAndOpen.BackColor = topMenuStrip.BackColor;

            // tebcontrol2
            tabControl2.TabPages[0].Text = "If-Then Rule";
            tabControl2.TabPages[1].Text = "Conditions";

            Label outputEquationInstruction = new Label();
            outputEquationInstruction.Parent = lbOutputEquation;
            outputEquationInstruction.Text = "Right click to add selected equations.";
            outputEquationInstruction.Font = new Font("Arial", 14, FontStyle.Bold);
            outputEquationInstruction.Width = 300;
            outputEquationInstruction.Dock = DockStyle.Bottom;
            outputEquationInstruction.ForeColor = Color.Blue;
            outputEquationInstruction.BackColor = lbOutputEquation.BackColor;

            // sugeno tab page
            sugenoTabPage.Font = new Font("Arial", 12, FontStyle.Bold);
            sugenoTabPage.ContextMenuStrip = outputEquationContextMenuStrip;


            // cbResulting configuration
            cbResulting.DropDownStyle = ComboBoxStyle.DropDownList;

            // Inferencing Method label
            Label lbResultingType = new Label();
            lbResultingType.Parent = splitContainer11.Panel1;
            lbResultingType.Text = "Choose Resulting Input & Output Method";
            lbResultingType.Font = new Font("Arial", 8, FontStyle.Bold);
            lbResultingType.Width = 300;
            lbResultingType.Height = 15;
            lbResultingType.Dock = DockStyle.Bottom;
            lbResultingType.ForeColor = Color.DarkBlue;
            lbResultingType.BackColor = lbInference.BackColor;

            // Inferencing Method label
            Label lbInferenceType = new Label();
            lbInferenceType.Parent = lbInference;
            lbInferenceType.Text = "Choose Inferencing Method";
            lbInferenceType.Font = new Font("Arial", 8, FontStyle.Bold);
            lbInferenceType.Width = 300;
            lbInferenceType.Dock = DockStyle.Bottom;
            lbInferenceType.ForeColor = Color.DarkBlue;
            lbInferenceType.BackColor = lbInference.BackColor;

            // tsmFCut or Scale
            toolStripMCut.Checked = true;
            isCut = true;

            // select mamdani when initiate
            cbResulting.Enabled = true;
            if (tabControl2.TabPages.Count == 3)
            {
                tabControl2.TabPages.Remove(sugenoTabPage);
            }
            mySystem = new MamdaniFuzzySystem();
            cbResulting.SelectedIndex = 0;
            lbInference.SelectedIndex = 0;
            ppGSystem.SelectedObject = mySystem;
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
                if (theTree.SelectedNode.GetNodeCount(false) > 0)
                {
                    MessageBox.Show("You can not all more than one Universe in Output section!!!");
                    return;
                }
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
            // could not create fuzzy set in output when sugeno mode
            if (theTree.SelectedNode.Text == "Output" && lbInference.SelectedIndex == 1)
            {
                MessageBox.Show("You could not add fuzzy set in output when in Sugeno mode!");
                return;
            }

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

                            // can not be created under Tsukamoto mode
                            if (lbInference.SelectedIndex == 2)
                            {
                                MessageBox.Show("The selected output fuzzy set for a Tsukamoto model is not monotonic.");
                                return;
                            }

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
                        newFs = +fs;
                        break;
                    case 4: // Dilation
                        newFs = -fs;
                        break;
                    case 5: // Extremely
                        newFs = ++fs;
                        break;
                    case 6: // Intensification
                        newFs = ~fs;
                        break;
                    case 7: //Diminisher
                        newFs = --fs;
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
                        newFs = binaryOperationFuzzyOne < binaryOperationFuzzyTwo;
                        break;
                    case 5: // T-norm: Bounded Product
                        newFs = binaryOperationFuzzyOne + binaryOperationFuzzyTwo;
                        break;
                    case 6: // T-norm: Drastic Product
                        newFs = binaryOperationFuzzyOne / binaryOperationFuzzyTwo;
                        break;
                    case 7: // S-norm: Maximum
                        op = new SNormMaximumOperator();
                        newFs = new BinaryOperatedFuzzySet(binaryOperationFuzzyOne,
                                binaryOperationFuzzyTwo,
                                op);
                        break;
                    case 8: // S-norm: Algebraic
                        newFs = binaryOperationFuzzyOne > binaryOperationFuzzyTwo;
                        break;
                    case 9: // S-norm: Bouded
                        newFs = binaryOperationFuzzyOne ^ binaryOperationFuzzyTwo;
                        break;
                    case 10: // S-norm: Drastic
                        newFs = binaryOperationFuzzyOne % binaryOperationFuzzyTwo;
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
            lbSaveAndOpen.Visible = false;
        }

        private void dgvRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCell theCell = dgvRules.Rows[e.RowIndex].Cells[e.ColumnIndex];
                theCell.ReadOnly = true;

                // Sugeno part to avoid inputing fuzzy
                if (lbInference.SelectedIndex == 1)
                {
                    if (dgvRules.CurrentCell.OwningColumn.Name == theTree.Nodes[1].Nodes[0].Text)
                    {
                        theCell.Tag = lbOutputEquation.SelectedIndex;
                        theCell.Value = lbOutputEquation.SelectedItem.ToString();
                        return;
                    }

                    try
                    {
                        if (theTree.SelectedNode.Parent.Parent.Text == "Output")
                        {
                            theCell.Tag = lbOutputEquation.SelectedIndex;
                            theCell.Value = lbOutputEquation.SelectedItem.ToString();
                            return;
                        }
                    }
                    catch (System.NullReferenceException Exception)
                    {
                        return;
                    }
                }



                // Aviod 
                if (theTree.SelectedNode.Tag is FuzzySet)
                {
                    theCell.Tag = (FuzzySet)theTree.SelectedNode.Tag;
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
            try
            {
                DataGridViewCell theCell = dgvConditions.Rows[e.RowIndex].Cells[e.ColumnIndex];
                theCell.ReadOnly = true;
                // Aviod 
                if (theTree.SelectedNode.Tag is FuzzySet)
                {
                    theCell.Tag = (FuzzySet)theTree.SelectedNode.Tag;
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
            catch (System.ArgumentOutOfRangeException Exception)
            {
                MessageBox.Show("Do not touch the header!");
            }
        }

        // create new rules of data grid
        private void toolStripMenuItemFuzzy1_Click(object sender, EventArgs e)
        {
            try
            {
                dgvRules.Rows.Add();
                lbIfThenInstruction.Visible = false;
            }
            catch (System.InvalidOperationException Exception)
            {
                MessageBox.Show("Create Universe and Fuzzy Set first!!!");
            }

        }

        private void inference_Click(object sender, EventArgs e)
        {

            // check inference method
            if (lbInference.SelectedIndex == 0)
            {
                // Mamdani method
                mySystem.ConstructSystem(dgvRules);
                mySystem.Inferencing(dgvConditions);
            }
            else if (lbInference.SelectedIndex == 1)
            {
                // Sugeno method
                mySystem.ConstructSystem(dgvRules);
                mySystem.Inferencing(dgvConditions);
            }
            else if (lbInference.SelectedIndex == 2)
            {
                //Tsukamo method
                mySystem.ConstructSystem(dgvRules);
                mySystem.Inferencing(dgvConditions);
            }

        }

        private void lbInference_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (lbInference.SelectedIndex == 0)
            {
                // Mamdani
                cbResulting.Enabled = true;

                if (tabControl2.TabPages.Count == 3)
                {
                    tabControl2.TabPages.Remove(sugenoTabPage);
                }

                // create system
                mySystem = new MamdaniFuzzySystem();
                cbResulting.SelectedIndex = 0;



            }
            else if (lbInference.SelectedIndex == 1)
            {
                // Sugeno
                cbResulting.Enabled = false;
                if (tabControl2.TabPages.Count < 3)
                {
                    // add tab into tabcontrol
                    tabControl2.TabPages.Add(sugenoTabPage);
                    tabControl2.SelectedTab = sugenoTabPage;
                    sugenoTabPage.Text = "Output Equation";
                    lbOutputEquation.Parent = sugenoTabPage;
                    lbOutputEquation.Dock = DockStyle.Fill;


                    // add equations into listbox
                    lbOutputEquation.Items.Clear();
                    lbOutputEquation.Items.Add("0: Y=0.1X+6.4");
                    lbOutputEquation.Items.Add("1: Y=0.5X+4");
                    lbOutputEquation.Items.Add("2: Y=X-2");
                    lbOutputEquation.Items.Add("3: Z=-X+Y+1");
                    lbOutputEquation.Items.Add("4: Z=-Y+3");
                    lbOutputEquation.Items.Add("5: Z=-X+3");
                    lbOutputEquation.Items.Add("6: Z=-X+Y+2");
                }

                // create system
                mySystem = new SugenoFuzzySystem();

            }
            else // selected index = 3
            {
                // Tsukamoto
                cbResulting.Enabled = false;

                if (tabControl2.TabPages.Count == 3)
                {
                    tabControl2.TabPages.Remove(sugenoTabPage);
                }

                // create system
                mySystem = new TsukamotoFuzzySystem();
            }

            ppGSystem.SelectedObject = mySystem;

        }

        private void tSMAddSelectedOutputEquation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void CutScaleClick(object sender, EventArgs e)
        {
            int selectedIndex = (sender as ToolStripMenuItemFuzzy).SelectedIndex;
            try
            {
                switch (selectedIndex)
                {
                    case 0:
                        mySystem.IsCut = true;
                        toolStripMCut.Checked = true;
                        toolStripMScale.Checked = false;
                        break;
                    case 1:
                        mySystem.IsCut = false;
                        toolStripMCut.Checked = false;
                        toolStripMScale.Checked = true;
                        break;
                }

                ppGSystem.SelectedObject = mySystem;
            }
            catch (System.NullReferenceException Exception)
            {
                MessageBox.Show("Choose Inference Method first!");
            }
        }

        private void CrispInference_Click(object sender, EventArgs e)
        {
            Universe u1 = ((FuzzySet)(dgvRules.Rows[0].Cells[0].Tag)).TheUniverse;
            Universe u2 = ((FuzzySet)(dgvRules.Rows[0].Cells[1].Tag)).TheUniverse;

            int res = 100;
            double dx = (u1.Maximum - u1.Minimum) / res;
            double dz = (u2.Maximum - u2.Minimum) / res;

            double[] conditions = new double[2];

            //// idiotic function to calculate nums
            //int numXValues = 0;
            //int numZValues = 0;
            //for (double x = u1.Maximum; x < u1.Maximum; x += dx)
            //{
            //    numXValues += 1;
            //}
            //for (double z = u2.Maximum; z < u2.Maximum; z += dz)
            //{
            //    numZValues += 1;
            //}

            //// clear surface and initiate surface1
            //surface1.NumXValues = numXValues;
            //surface1.NumZValues = numZValues;
            surface1.IrregularGrid = true;
            surface1.Clear();

            MessageBox.Show("Start Inferencing..");
            for (double x = u1.Minimum; x < u1.Maximum; x += dx)
            {
                for (double z = u2.Minimum; z < u2.Maximum; z += dz)
                {
                    conditions[0] = x;
                    conditions[1] = z;

                    mySystem.ConstructSystem(dgvRules);
                   
                    double y = mySystem.CrispInCrispOutInferencing(conditions);

                    surface1.Add(x, y, z);
                }
            }
            MessageBox.Show("Inferencing Done");

            try
            {

            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("You still have to construct if then rules!");
            }
        }

        private void cbResulting_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear datagrid view
            dgvRules.Rows.Clear();
            dgvRules.Refresh();
            dgvConditions.Rows.Clear();
            dgvConditions.Refresh();

            // switch inference method index
            switch (cbResulting.SelectedIndex)
            {
                case 0:
                    mySystem.Defuzzification = DefuzzificationType.COA;
                    break;
                case 1:
                    mySystem.Defuzzification = DefuzzificationType.BOA;
                    break;
                case 2:
                    mySystem.Defuzzification = DefuzzificationType.MOM;
                    break;
                case 3:
                    mySystem.Defuzzification = DefuzzificationType.SOM;
                    break;
                case 4:
                    mySystem.Defuzzification = DefuzzificationType.LOM;
                    break;
                default:
                    mySystem.Defuzzification = DefuzzificationType.COA;
                    break;
            }
        }

        // open and save function
        private void OpenOrSave(object sender, EventArgs e)
        {
            TreeNode univNode;
            TreeNode aNode;
            Universe uobj;
            Chart mainChart = new Chart();

            switch ((sender as ToolStripMenuItemFuzzy).SelectedIndex)
            {
                case 0: // open function
                    if (dlgOpen.ShowDialog() != DialogResult.OK) return;
                    string str;
                    string[] items;
                    StreamReader sr = new StreamReader(dlgOpen.FileName);
                    items = sr.ReadLine().Split(':');
                    switch (items[1])
                    {
                        case "Mamdani":
                            lbInference.SelectedIndex = 0;
                            break;
                        case "Sugeno":
                            lbInference.SelectedIndex = 1;
                            break;
                        case "Tsukamoto":
                            lbInference.SelectedIndex = 2;
                            break;
                    }

                    // clear up tab control and tree view
                    if (tabControl1.TabPages.Count > 0)
                    {
                        for (int i = 0; i < tabControl1.TabPages.Count; i++)
                        {
                            tabControl1.TabPages.RemoveAt(i);
                        }
                    }
                    theTree.Nodes[0].Nodes.Clear();
                    theTree.Nodes[1].Nodes.Clear();

                    // set up tree view
                    // input
                    ////////////////////////////////////////////////
                    ////////////////////////////////////////////////
                    items = sr.ReadLine().Split(':');
                    int numInputUniverse = Convert.ToInt32(items[1]);
                    int numFS;
                    TreeNode fsNode;
                    FuzzySet fs;
                    Dictionary<int, FuzzySet> codeVsFS = new Dictionary<int, FuzzySet>();

                    for (int i = 0; i < numInputUniverse; i++)
                    {
                        univNode = new TreeNode();
                        // create new tab if new Universe is created
                        TabPage newTabPage = new TabPage();
                        // add tab into tabcontrol
                        tabControl1.TabPages.Add(newTabPage);
                        tabControl1.SelectedTab = newTabPage;
                        mainChart.Parent = newTabPage;
                        uobj = new Universe(mainChart);

                        // read file with universe
                        uobj.ReadFile(sr);

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
                        TreeNode aNodeI = new TreeNode(uobj.Title);
                        aNodeI.Tag = uobj;
                        theTree.Nodes[0].Nodes.Add(aNodeI);
                        theTree.SelectedNode = aNodeI;
                        theGrid.SelectedObject = uobj;
                        theTree.Focus();

                        // add columns to two data grid views
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

                        // add fuzzy set
                        /////////////////////////////////////////////////
                        items = sr.ReadLine().Split(':');
                        numFS = Convert.ToInt32(items[1]);
                        for (int j = 0; j < numFS; j++)
                        {
                            fsNode = new TreeNode();
                            items = sr.ReadLine().Split(':');
                            switch (items[1])
                            {
                                case "GaussianFuzzySet":
                                    fs = new GaussianFuzzySet(uobj);
                                    break;
                                case "TriangularFuzzySet":
                                    fs = new TriangularFuzzySet(uobj);
                                    break;
                                default:
                                    fs = new GaussianFuzzySet(uobj);
                                    break;

                            }
                            items = sr.ReadLine().Split(':');
                            int hash = Convert.ToInt32(items[1]);
                            codeVsFS.Add(hash, fs);
                            // let fs read its fuzzy set
                            fs.ReadFile(sr);
                            fsNode.Tag = fs;
                            fsNode.Text = fs.Title;
                            univNode.Nodes.Add(fsNode);
                            fs.ShowSeries = true;
                        }

                    }

                    // output
                    /////////////////////////////////////////////
                    ////////////////////////////////////////////////
                    items = sr.ReadLine().Split(':');
                    univNode = new TreeNode();
                    // check if selecting input/output node
                    int nodeIndex = 0;
                    // create new tab if new Universe is created
                    TabPage newTabPageII = new TabPage();
                    // add tab into tabcontrol
                    tabControl1.TabPages.Add(newTabPageII);
                    tabControl1.SelectedTab = newTabPageII;
                    mainChart.Parent = newTabPageII;
                    uobj = new Universe(mainChart);

                    // read file with universe
                    uobj.ReadFile(sr);


                    newTabPageII.Text = uobj.Title;
                    newTabPageII.ToolTipText = $"Chart of {uobj.Title}.";
                    // adjust chart size to fit tab
                    mainChart.Dock = DockStyle.Fill;

                    // tag tab to universe
                    uobj.BindedTab = tabControl1.TabPages[graphTabCount];
                    graphTabCount += 1;
                    // tag chart to universe
                    uobj.BindedChart = mainChart;
                    // Add a node inside the Universe, either for input or output
                    TreeNode bNode = new TreeNode(uobj.Title);
                    bNode.Tag = uobj;
                    theTree.Nodes[1].Nodes.Add(bNode);
                    theTree.SelectedNode = bNode;
                    theGrid.SelectedObject = uobj;
                    theTree.Focus();

                    // add columns to two data grid views
                    dgvRules.Columns.Add(uobj.Title, uobj.Title);
                    // column style properties
                    dgvRules.Columns[uobj.Title].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvRules.Columns[uobj.Title].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvRules.Columns[uobj.Title].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvRules.Columns[uobj.Title].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                    dgvRules.Columns[uobj.Title].DefaultCellStyle.ForeColor = Color.DarkBlue;

                    sr.Close();
                    break;
                case 1: // save function
                    DialogResult ans = dlgSave.ShowDialog();
                    if (ans != DialogResult.OK) return;
                    StreamWriter sw = new StreamWriter(dlgSave.FileName);
                    // write model name
                    switch (lbInference.SelectedIndex)
                    {
                        case 0: // mamdani
                            sw.WriteLine($"Model:Mamdani");
                            break;
                        case 1: // sugeno
                            sw.WriteLine($"Model:Sugeno");
                            break;
                        case 2: // tsukamoto
                            sw.WriteLine($"Model:Tsukamoto");
                            break;
                    }
                    // write tree view
                    int numUniverse = theTree.Nodes[0].Nodes.Count; // input
                    sw.WriteLine($"NumberOfInputUniverse:{numUniverse}");

                    for (int i = 0; i < numUniverse; i++)
                    {
                        univNode = theTree.Nodes[0].Nodes[i];
                        uobj = (Universe)univNode.Tag;
                        uobj.SaveFile(sw);

                        // report included fuzzy set
                        numFS = univNode.Nodes.Count;
                        sw.WriteLine($"NumberOfInputFuzzySet:{numFS}");

                        for (int j = 0; j < numFS; j++)
                        {
                            fsNode = univNode.Nodes[j];
                            fs = (FuzzySet)fsNode.Tag;
                            fs.SaveFile(sw);

                        }
                    }

                    sw.WriteLine($"NumberOfOutputUniverse:1");// output
                    univNode = theTree.Nodes[1].Nodes[0];
                    uobj = (Universe)univNode.Tag;
                    uobj.SaveFile(sw);
                    // report included fuzzy set
                    numFS = univNode.Nodes.Count;
                    sw.WriteLine($"NumberOfInputFuzzySet:{numFS}");

                    for (int j = 0; j < numFS; j++)
                    {
                        fsNode = univNode.Nodes[j];
                        fs = (FuzzySet)fsNode.Tag;
                        fs.SaveFile(sw);

                    }


                    // datagridview

                    sw.Close();
                    break;
            }
        }

        // sample tee chart function
        private void teeChartDemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int numXValues = 100;
            int numZValues = 80;

            surface1.NumXValues = numXValues;
            surface1.NumZValues = numZValues;
            surface1.IrregularGrid = true;
            surface1.Clear();

            for (double x = 0; x < numXValues; x++)
            {
                for (double zz = 0; zz < numZValues; zz++)
                {
                    double y;
                    y = Math.Sin(x / 10.0) * Math.Cos(zz / 4.0);
                    surface1.Add(x, y, zz);
                }
            }
        }
    }
}
