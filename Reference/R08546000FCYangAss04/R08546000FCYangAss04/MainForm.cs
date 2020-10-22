using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546000FCYangAss04
{
    public partial class MainForm : Form
    {
       
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCreateUniverse_Click(object sender, EventArgs e)
        {
             Universe u1 = new Universe( mainChart ); 

            TreeNode aNode = new TreeNode();

            aNode.Tag = u1;
            aNode.Text = u1.Title;

            ppgTarget.SelectedObject = u1;

            trvUniverses.Nodes.Add(aNode);
            trvUniverses.SelectedNode = aNode;
            
        }

        private void trvUniverses_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ppgTarget.SelectedObject = trvUniverses.SelectedNode.Tag;
        }

        private void ppgTarget_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            trvUniverses.SelectedNode.Text = ((Universe)trvUniverses.SelectedNode.Tag).Title;
        }

        private void btnCreateFuzzySet_Click(object sender, EventArgs e)
        {
            // check whether a universe is selected
            if (trvUniverses.SelectedNode == null) return;
            if (trvUniverses.SelectedNode.Level != 0) return;

            if (cbxFSTypes.SelectedIndex < 0) return;

            Universe su = (Universe)trvUniverses.SelectedNode.Tag;
            switch ( cbxFSTypes.SelectedIndex )
            {
                case 0: // Gaussian
                    GaussianFuzzySet g = new GaussianFuzzySet(su);

                    TreeNode fsNode = new TreeNode();
                    fsNode.Text = "A FUZZY SET";
                    fsNode.Tag = g;

                    trvUniverses.SelectedNode.Nodes.Add(fsNode);
                    ppgTarget.SelectedObject = g;
                    break;
                case 1: // Triangular FS
                    break;
            }
        }
    }
}
