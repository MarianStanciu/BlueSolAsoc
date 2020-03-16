using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc.butoane_si_controale
{
    class ClassButonSelectieAsoc : Button
    {
        
       public ClassButonSelectieAsoc() : base()
        {
            base.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Blue;
            this.Font = new Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            base.BackColor = Color.DeepSkyBlue;

        }
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            base.BackColor = Color.Blue;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ClassButonSelectieAsoc
            // 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResumeLayout(false);

        }
    }
}

    


