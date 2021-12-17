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
        }
        public QTech.Base.Enums.Theme Theme { get; set; } = Base.Enums.Theme.Template1;
        public ExTabItemComponent CurrentThemeComponent
        {
            get
            {
                var temp = new ExTabItemComponent();
                if (Theme == Base.Enums.Theme.Template1)
                {
                    temp.SPanelLeft = global::QTech.Component.Properties.Resources.WLeft;
                    temp.SPanelRight = global::QTech.Component.Properties.Resources.WRight;
                    temp.SPanelCenter = global::QTech.Component.Properties.Resources.WCenter;
                    temp.SLabelColor = Color.WhiteSmoke;

                    temp.PanelLeft = global::QTech.Component.Properties.Resources.GLeft;
                    temp.PanelRight = global::QTech.Component.Properties.Resources.GRight;
                    temp.PanelCenter = global::QTech.Component.Properties.Resources.GCenter;
                    temp.LabelColor = Color.WhiteSmoke;
                }
                else if (Theme == Base.Enums.Theme.Template2)
                {
                    temp.SPanelLeft = global::QTech.Component.Properties.Resources.S2Left;
                    temp.SPanelRight = global::QTech.Component.Properties.Resources.S2Right;
                    temp.SPanelCenter = global::QTech.Component.Properties.Resources.S2Center;
                    temp.SLabelColor = Color.Black;

                    temp.PanelLeft = global::QTech.Component.Properties.Resources._2Left;
                    temp.PanelRight = global::QTech.Component.Properties.Resources._2Right;
                    temp.PanelCenter = global::QTech.Component.Properties.Resources._2Center;
                    temp.LabelColor = Color.Black;

                }
                else if (Theme == Base.Enums.Theme.Template3)
                {
                    temp.SPanelLeft = global::QTech.Component.Properties.Resources.S3Left;
                    temp.SPanelRight = global::QTech.Component.Properties.Resources.S3Right;
                    temp.SPanelCenter = global::QTech.Component.Properties.Resources.S3Center;
                    temp.SLabelColor = Color.Black;

                    temp.PanelLeft = global::QTech.Component.Properties.Resources._3Left;
                    temp.PanelRight = global::QTech.Component.Properties.Resources._3Right;
                    temp.PanelCenter = global::QTech.Component.Properties.Resources._3Center;
                    temp.LabelColor = Color.Black;
                }

                return temp;
            }
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
                    panelLeft.BackgroundImage = CurrentThemeComponent.SPanelLeft;
                    panelMiddle.BackgroundImage = CurrentThemeComponent.SPanelCenter;
                    panelRight.BackgroundImage = CurrentThemeComponent.SPanelRight;
                    lblCaption.ForeColor = CurrentThemeComponent.SLabelColor;

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
                    panelLeft.BackgroundImage = CurrentThemeComponent.PanelLeft;
                    panelMiddle.BackgroundImage = CurrentThemeComponent.PanelCenter;
                    panelRight.BackgroundImage = CurrentThemeComponent.PanelRight;
                    lblCaption.ForeColor = CurrentThemeComponent.LabelColor;
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
                lblCaption.ForeColor = Color.Red;
            }
        }

      

        private void lblCaption_MouseLeave(object sender, EventArgs e)
        {
            if (!selected && !isTitle)
            {
                lblCaption.ForeColor = CurrentThemeComponent.LabelColor;
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
    public class ExTabItemComponent
    {
        public  Bitmap PanelLeft { get; set; }
        public  Bitmap PanelRight { get; set; }
        public  Bitmap PanelCenter { get; set; }
        public  Color LabelColor { get; set; }

        public Bitmap SPanelLeft { get; set; }
        public Bitmap SPanelRight { get; set; }
        public Bitmap SPanelCenter { get; set; }
        public Color SLabelColor { get; set; }
    }
}
