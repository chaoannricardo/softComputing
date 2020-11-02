using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546036_SHChaoAss07
{
    public partial class Mainform : Form
    {
        JobAssignmentProblem theProblem;
        
        public Mainform()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;

        }
    }
}
