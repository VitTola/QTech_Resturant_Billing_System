
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    [DefaultEvent("UrlChanged")]
    public partial class ExRoundPictureBox : UserControl
    {
        public bool StretchImage { get; set; } = false;
        public string PictureName { get; set; }
        public Guid PictureGuid { get; set; }
        public string PicturePath { get; set; } = string.Empty;

        [Category("Data")]
        [Browsable(true)]
        public Image Placeholder
        {
            get
            {
                return this.profilePicture.InitialImage;
            }
            set
            {
                this.profilePicture.InitialImage = value;
                profilePicture.Image = Placeholder ?? Properties.Resources.FoodPlacehoder;

            }
        }

        private bool _canRemove = true;
        public bool CanRemove
        {
            get
            {
                return _canRemove;
            }
            set
            {
                _canRemove = value;
               // picRemove.Enabled = _canRemove;
            }
        }
        private bool _canUpload = true;
        public bool CanUpload
        {
            get
            {
                return _canUpload;
            }
            set
            {
                _canUpload = value;
               // picEdit.Enabled = profilePicture.Enabled = _canUpload;
            }
        }
        private bool _canDownload = true;
        public bool CanDownload
        {
            get
            {
                return _canDownload;
            }
            set
            {
                _canDownload = value;
            }
        }

        public ExRoundPictureBox()
        {
            InitializeComponent();
            profilePicture.Click += profilePicture_Click;
           // picRemove.Click += picRemove_Click;
            //picEdit.Click += profilePicture_Click;
        }
        private void profilePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image|*.jpg;*.jpeg;*.png;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PicturePath = dialog.FileName;
            }

            if (!string.IsNullOrEmpty(PicturePath))
            {
                profilePicture.ImageLocation = PicturePath;

                if (StretchImage)
                {
                    profilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    profilePicture.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
        }

        private void picRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PicturePath)) return;
            profilePicture.Image = Placeholder ?? Properties.Resources.FoodPlacehoder;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, this.Width - 3, this.Height - 3);
            Pen pen = new Pen(Color.Gray, 3);
            e.Graphics.DrawPath(pen, gp);
            Region rg = new Region(gp);
            profilePicture.Region = rg;
            base.OnPaint(e);
        }
       
    }
}
