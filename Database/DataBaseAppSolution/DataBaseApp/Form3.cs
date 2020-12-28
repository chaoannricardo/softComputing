using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void publisherBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.publisherBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.iIEBooksDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iIEBooksDataSet.Publisher' table. You can move, or remove it, as needed.
            this.publisherTableAdapter.Fill(this.iIEBooksDataSet.Publisher);

        }
    }
}
