using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EX = Microsoft.Office.Interop.Excel;

namespace DataBaseApp
{
    public partial class Form4 : Form
    {
        EX.Application theExcel;
        EX.Workbook theBook;
        EX.Worksheet theSheet;

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK) {

                theExcel = new EX.Application();
                theBook = theExcel.Workbooks.Open(dlg.FileName);
                theSheet = theBook.Worksheets[1];

                object o = theSheet.Cells[1, 1].Value;
                richTextBox1.AppendText(o.ToString() + "\t");
                o = theSheet.Cells[1, 2].Value;
                richTextBox1.AppendText(o.ToString() + "\n");
                o = theSheet.Cells[2, 1].Value;
                richTextBox1.AppendText(o.ToString() + "\t");
                o = theSheet.Cells[2, 2].Value;
                richTextBox1.AppendText(o.ToString() + "\t");

                Marshal.ReleaseComObject(theBook);
                Marshal.ReleaseComObject(theExcel);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                theExcel = new EX.Application();
                theBook = theExcel.Workbooks.Add();
                theSheet = theBook.Worksheets[1];
                theSheet.Cells[1, 1].Value = "NNNNNNN";
                theSheet.Cells[1, 2].Value = "NNNNNNN";
                theSheet.Cells[2, 1].Value = DateTime.Now;
                theSheet.Cells[3, 1].Value = 44.5f;

                theBook.SaveAs(dlg.FileName);

                Marshal.ReleaseComObject(theBook);
                Marshal.ReleaseComObject(theExcel);

            }
        }
    }
}
