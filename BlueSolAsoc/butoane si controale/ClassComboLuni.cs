using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc.butoane_si_controale
{
    class ClassComboLuni : ComboBox
    {
        private ComboBox comboBox1;

        public ClassComboLuni()
        {
            string[] lunicombobox = { "ianuarie", "februarie", "martie", "aprilie", "mai", "iunie", "iulie", "august", "septembrie", "octombrie", "noiembrie", "decembrie" };
            int[] numarlunicombo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            DataTable TabelNumarareLuni = new DataTable();
            TabelNumarareLuni.Columns.Add("luna");
            TabelNumarareLuni.Columns.Add("numar_luna");
            for (int i = 0; i < lunicombobox.Length; i++)
            {
                TabelNumarareLuni.Rows.Add(lunicombobox[i], numarlunicombo[i]);
            }
            base.DataSource = TabelNumarareLuni;
            base.ValueMember = "numar_luna";
            base.DisplayMember = "luna";
        }

        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.ResumeLayout(false);

        }
    }
}
