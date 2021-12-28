
namespace QTech.Component.MyComponents
{
    public partial class ChooseFoodPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnMinus = new System.Windows.Forms.PictureBox();
            this.btnPlus = new System.Windows.Forms.PictureBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.pic = new WpfCustomControlLibrary.RoundImageBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.btnMinus);
            this.panel1.Controls.Add(this.btnPlus);
            this.panel1.Controls.Add(this.elementHost1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 145);
            this.panel1.TabIndex = 1;
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAmount.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(28, 122);
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(41, 20);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMinus
            // 
            this.btnMinus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMinus.Image = global::QTech.Component.Properties.Resources.btn_minus;
            this.btnMinus.Location = new System.Drawing.Point(3, 119);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(24, 26);
            this.btnMinus.TabIndex = 2;
            this.btnMinus.TabStop = false;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPlus.Image = global::QTech.Component.Properties.Resources.btn_plus;
            this.btnPlus.Location = new System.Drawing.Point(70, 119);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(24, 26);
            this.btnPlus.TabIndex = 3;
            this.btnPlus.TabStop = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(0, 1);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(97, 96);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.pic;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Khmer OS Siemreap", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(-1, 97);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(97, 21);
            this.txtName.TabIndex = 0;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChooseFoodPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Name = "ChooseFoodPanel";
            this.Size = new System.Drawing.Size(97, 145);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox btnPlus;
        private System.Windows.Forms.PictureBox btnMinus;
        private WpfCustomControlLibrary.RoundImageBox pic;
    }
}
