
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    public class ExButtonLoading:Button,IAsyncTask
    {
        public ExButtonLoading()
        {
            InitializeStyle();
            //this.MouseHover += ExButtonLoading_MouseHover;
            //this.MouseLeave += ExButtonLoading_MouseLeave;
        }

        private void ExButtonLoading_MouseLeave(object sender, EventArgs e)
        {
            ForeColor = Color.White;
        }

        private void ExButtonLoading_MouseHover(object sender, EventArgs e)
        {
            ForeColor = Color.Blue;
        }

        private void InitializeStyle()
        {
            //BackColor = Color.DodgerBlue;
            //FlatStyle = FlatStyle.Flat;
            //FlatAppearance.BorderColor = Color.Gray;
            //FlatAppearance.BorderSize = 1;
            //FlatAppearance.MouseOverBackColor = Color.FromArgb(152, 203, 255);
            //ForeColor = Color.White;
        }
        public enum Aligment
        {
            Vertical,
            Horizontal
        }
        [Browsable(false)]
        public Image DefaultImage { get; set; } = null;
        public Aligment ShortcutAligment { get; set; } = Aligment.Horizontal;
        public string ShortcutText { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (string.IsNullOrEmpty(ShortcutText))
            {
                return;
            }

            // Create font and brush.
            //var drawFont = new Font("Constantia", 6.75F);
            var drawFont = new Font("Arial Black", 7F);
            //var drawFont = new Font("DDD Round Square", 8F);
            var drawBrush = new SolidBrush(ColorTranslator.FromHtml(EDomain.Resources.ColorPrimary));
            // Set format of string.
            var drawFormat = new StringFormat
            {
                FormatFlags = StringFormatFlags.DisplayFormatControl,
                Alignment = StringAlignment.Far,
            };
            var locationF = new PointF(Width - 2, 1);
            var textSize = e.Graphics.MeasureString(ShortcutText, drawFont);
            if (ShortcutAligment == Aligment.Vertical)
            {
                locationF = new PointF(locationF.X - textSize.Height, locationF.Y);
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                drawFormat.Alignment = StringAlignment.Near;
            }
            this.Font = new Font("Khmer OS Battambang", 8);

             e.Graphics.DrawString(ShortcutText, drawFont, drawBrush, locationF, drawFormat);
        }


        public bool Executing { get; set ;}

        public void PostExecute(bool block =false)
        {
            if (block)
            { 
                Enabled = true;
            }
            Image = DefaultImage;
            FlatAppearance.BorderColor = Color.Gray;

        }

        public void PreExecute(bool block = false)
        {
            if (block)
            {
                Enabled = false;
            }
            if (Image != null)
            {
                DefaultImage = (Image)Image.Clone();
            }
            Image = Properties.Resources.spin;
            ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204);
        }

        protected override void OnClick(EventArgs e)
        {
            if (Executing)
            {
                return;
            }
            base.OnClick(e);
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }
}
