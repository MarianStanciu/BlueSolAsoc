using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc.butoane_si_controale
{
    class ClassGridView : DataGridView
    {

        public ClassGridView()
            {
           
            EnableHeadersVisualStyles = false;
            ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
            ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            ColumnHeadersDefaultCellStyle.Font = new Font("Mongolian Baiti", 16);
            AllowUserToAddRows = false;
            
            }

        public DGVPrinter.ColumnWidthSetting ColumnWidth { get; internal set; }
        public object HeaderStyle { get; internal set; }
    }
}
