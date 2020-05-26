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

        public ClassGridView(): base()
            {
           
            EnableHeadersVisualStyles = false;
            ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
            ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
         
            AllowUserToAddRows = false;

            }
        

    }
}
