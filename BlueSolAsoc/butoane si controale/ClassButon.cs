using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc.butoane_si_controale
{
    class ClassButon : Button
    {
       public ClassButon() :base()
        {
            base.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Blue;
          
        }
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            base.BackColor = Color.Aquamarine;
       
        }
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            base.BackColor = Color.Blue;
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            base.FontHeight = 25;
        }
    }
}
