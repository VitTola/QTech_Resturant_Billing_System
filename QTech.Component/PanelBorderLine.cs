using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleInventory.Components
{
    public partial class PanelBorderLine : Panel
    {
        public PanelBorderLine()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color PenColor { get; set; } = Color.Gray;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int PenThickness { get; set; } = 5;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen redPen = new Pen(PenColor, PenThickness);
            redPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            Rectangle rectangle = new Rectangle(0,0, Width, Height);
            e.Graphics.DrawRectangle(redPen, rectangle);
        }
    }
}
