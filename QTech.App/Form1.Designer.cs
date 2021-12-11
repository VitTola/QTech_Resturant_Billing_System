
namespace QTech
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cachedReportExpense1 = new QTech.Reports.CachedReportExpense();
            this.btnRemovePic = new System.Windows.Forms.PictureBox();
            this.btnAddPic_ = new System.Windows.Forms.PictureBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.picBox = new WpfCustomControlLibrary.RoundImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemovePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPic_)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemovePic
            // 
            this.btnRemovePic.Image = global::QTech.Properties.Resources.trashbin;
            this.btnRemovePic.Location = new System.Drawing.Point(484, 209);
            this.btnRemovePic.Name = "btnRemovePic";
            this.btnRemovePic.Size = new System.Drawing.Size(30, 30);
            this.btnRemovePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRemovePic.TabIndex = 2;
            this.btnRemovePic.TabStop = false;
            this.btnRemovePic.Click += new System.EventHandler(this.btnRemovePic_Click);
            // 
            // btnAddPic_
            // 
            this.btnAddPic_.Image = global::QTech.Properties.Resources.addfile;
            this.btnAddPic_.Location = new System.Drawing.Point(448, 211);
            this.btnAddPic_.Name = "btnAddPic_";
            this.btnAddPic_.Size = new System.Drawing.Size(30, 30);
            this.btnAddPic_.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAddPic_.TabIndex = 1;
            this.btnAddPic_.TabStop = false;
            this.btnAddPic_.Click += new System.EventHandler(this.btnAddPic__Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(382, 12);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(203, 193);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost1_ChildChanged);
            this.elementHost1.Child = this.picBox;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(985, 702);
            this.Controls.Add(this.btnRemovePic);
            this.Controls.Add(this.btnAddPic_);
            this.Controls.Add(this.elementHost1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnRemovePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPic_)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Reports.CachedReportExpense cachedReportExpense1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WpfCustomControlLibrary.RoundImageBox picBox;
        private System.Windows.Forms.PictureBox btnAddPic_;
        private System.Windows.Forms.PictureBox btnRemovePic;
    }
}