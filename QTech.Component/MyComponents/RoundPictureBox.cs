using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component.MyComponents
{
    public partial class RoundPictureBox : PictureBox
    {
        public RoundPictureBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, this.Width - 3, this.Height - 3);
            Region rg = new Region(gp);
            this.Region = rg;
            base.OnPaint(pe);
        }
    }
}
