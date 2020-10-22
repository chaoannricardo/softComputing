using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546036_SHChaoAss04
{
    public class ToolStripMenuItemFuzzy : ToolStripMenuItem
    {
        private int selectedIndex;
        

        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }

            set
            {
                if (value is int)
                {
                    selectedIndex = value;
                }

            }

        }
    }
}
