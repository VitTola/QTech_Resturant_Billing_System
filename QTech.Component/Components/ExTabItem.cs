using System;                        
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QTech.Component
{
    [DefaultEvent("Click")]
    public partial class ExTabItem : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        public ExTabItem()
        {
            InitializeComponent();
           // this.BorderColor = Color.FromArgb(238, 127, 0);

        }

        bool selected = false;

        bool isTitle = false;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return lblCaption.Text;
            }
            set
            {
                lblCaption.Text = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //lblCaption.ForeColor = Color.Blue;
            this.Font = new Font("Khmer OS Siemreap", 9);

        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ContentAlignment TextAlignment
        {
            get
            {
                return lblCaption.TextAlign;
            }
            set
            {
                lblCaption.TextAlign = value;
            }
        }


        [Browsable(true)]
        public Image Image
        {
            get
            {
                return picBox.Image;
            }
            set
            {
                picBox.Image = value;
            }
        }

        [Browsable(true)]
        public bool Selected
        {
            set
            {
                selected = value;

                if (selected)
                {
                    panelLeft.BackgroundImage = global::QTech.Component.Properties.Resources.WRight;
                    panelMiddle.BackgroundImage = global::QTech.Component.Properties.Resources.centerW;
                    panelRight.BackgroundImage = global::QTech.Component.Properties.Resources.WLeft;
                    lblCaption.ForeColor = Color.Black;

                    if (Parent!=null)
                    {
                        foreach (Control c in Parent.Controls)
                        {
                            if (c is ExTabItem)
                            {
                                if (c != this)
                                {
                                    ((ExTabItem)c).Selected = false;
                                }
                            }
                        }
                    } 
                }
                else
                {

                    panelLeft.BackgroundImage = global::QTech.Component.Properties.Resources.Left;
                    panelMiddle.BackgroundImage = global::QTech.Component.Properties.Resources.center5;
                    panelRight.BackgroundImage = global::QTech.Component.Properties.Resources.Right;
                    lblCaption.ForeColor = Color.White;

                }
            }
            get
            {
                return selected;
            }
        }

        [Browsable(true)]
        public bool IsTitle
        {
            get
            {
                return isTitle;
            }
            set
            {
                isTitle = value;
                Selected = false;
            }
        }

        private void lblCaption_MouseEnter(object sender, EventArgs e)
        {
            if (!selected && !isTitle)
            {
                lblCaption.ForeColor = Color.Yellow;
            }
        }

      

        private void lblCaption_MouseLeave(object sender, EventArgs e)
        {
            if (!selected && !isTitle)
            {
                lblCaption.ForeColor = Color.White;
            }
        } 
        
        private void lblCaption_Click(object sender, EventArgs e)
        {
            if (!isTitle)
            {
                Selected = true;
            }
            base.OnClick(e);
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            if (!isTitle)
            {
                Selected = true;
            }
            base.OnClick(e);
        }

        private void lblCaption_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        private void lblCaption_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }
    }
}
