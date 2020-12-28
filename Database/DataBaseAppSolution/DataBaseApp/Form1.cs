using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DataBaseApp
{


    public partial class Form1 : Form
    {

        string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Windows_Storage\\Storage\\Github\\softComputing\\Database\\IIEBooks.mdb";

        public Form1()
        {
            // windows state
            WindowState = FormWindowState.Maximized;

            InitializeComponent();

            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = conStr;

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Books a, Publisher b WHERE a.publisherID = b.ID;";
            con.Open();

            OleDbDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                for (int c = 0; c < rd.FieldCount; c++)
                {
                    richTextBox1.AppendText(rd[c].ToString() + "\t");
                }
                richTextBox1.AppendText("\n");

            }

            con.Close();

            OleDbDataAdapter adp = new OleDbDataAdapter();
            adp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            DataSet db = new DataSet();
            int num = adp.Fill(db);
            dataGridView1.DataSource = db.Tables[0];
           

        }

        private void publisherBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.publisherBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.iIEBooksDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iIEBooksDataSet.Publisher' table. You can move, or remove it, as needed.
            this.publisherTableAdapter.Fill(this.iIEBooksDataSet.Publisher);

        }
    }
}
