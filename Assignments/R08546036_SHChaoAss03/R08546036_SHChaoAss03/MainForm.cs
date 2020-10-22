using System;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace R08546036_SHChaoAss03
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // default value of dropdown selected index
            dropdownFuzzy.SelectedIndex = 0;
            // setting of theTree
            theTree.HideSelection = false;
        }

        private void btnCreateUniverse_Click(object sender, EventArgs e)
        {
            Universe uobj;
            uobj = new Universe(mainChart);

            // Add a node inside the Universe
            TreeNode aNode = new TreeNode(uobj.Title);
            aNode.Tag = uobj;
            theTree.Nodes.Add(aNode);
            theTree.SelectedNode = aNode;
            theGrid.SelectedObject = uobj;
        }

        private void btnCreateFuzzySet_Click(object sender, EventArgs e)
        {
            Universe selectedU;
            FuzzySet aFS;
            try
            {
                if (theTree.SelectedNode.Tag is Universe)
                {
                    selectedU = (Universe)theTree.SelectedNode.Tag;

                    // assign relative FuzzySet to the variable
                    switch (dropdownFuzzy.SelectedIndex)
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
            }
            catch (System.NullReferenceException exception)
            {
                MessageBox.Show("Create Universe First!!!");
            }


        }

        private void theTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            theGrid.SelectedObject = theTree.SelectedNode.Tag;
        }

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
            }
        }

        // Function to search node and change value
        public void NodeNameChange(string Name)
        {
            theTree.SelectedNode.Name = Name;
        }

        // show pictures inside picture box
        private void dropdownFuzzy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imageFilePath = "";
            switch (dropdownFuzzy.SelectedIndex)
            {
                case 0:
                    imageFilePath = "../../../pictures/TriangleFunction.PNG";
                    break;
                case 1:
                    imageFilePath = "../../../pictures/BellFunction.PNG";
                    break;
                case 2:
                    imageFilePath = "../../../pictures/GaussianFunction.PNG";
                    break;
                case 3:
                    imageFilePath = "../../../pictures/SigmoidFunction.PNG";
                    break;
                case 4:
                    imageFilePath = "../../../pictures/TrapezoidalFunction.PNG";
                    break;
                case 5:
                    imageFilePath = "../../../pictures/LeftRightFunction.PNG";
                    break;
            }

            picBoxFunc.Image = Image.FromFile(imageFilePath);
            picBoxFunc.SizeMode = PictureBoxSizeMode.Zoom;
        }


        // Function to clear & restart
        private void btnClear_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }


    }
}
