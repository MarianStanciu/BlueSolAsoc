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

    class ClassButonModifica:Button
    {
        protected override void OnResize(EventArgs e)
        {
            /*using (var path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(1, 1, this.Width - 3, this.Height - 3));
                this.Region = new Region(path);
            }
            base.OnResize(e);*/
        }

        public ClassButonModifica() : base()
        {
            base.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Blue;
        }
    protected override void OnBackColorChanged(EventArgs e)
    {
        base.OnBackColorChanged(e);
        base.BackColor = Color.Yellow;

    }
    protected override void OnMouseHover(EventArgs e)
    {
        base.OnMouseHover(e);
        base.BackColor = Color.Blue;
    }
}
}
