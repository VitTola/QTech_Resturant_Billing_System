
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
            this.label1 = new System.Windows.Forms.Label();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.curvePanel = new WpfCustomControlLibrary.CurvePanel();
            this.transparentPanel1 = new QTech.Component.MyComponents.TransparentPanel();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.star1 = new WpfCustomControlLibrary.Star();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.logoPanel1 = new WpfCustomControlLibrary.LogoPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(594, 611);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 73);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // elementHost3
            // 
            this.elementHost3.Location = new System.Drawing.Point(-2, 0);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(116, 82);
            this.elementHost3.TabIndex = 4;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost3_ChildChanged);
            this.elementHost3.Child = this.curvePanel;
            // 
            // transparentPanel1
            // 
            this.transparentPanel1.Location = new System.Drawing.Point(179, 419);
            this.transparentPanel1.Name = "transparentPanel1";
            this.transparentPanel1.Size = new System.Drawing.Size(292, 277);
            this.transparentPanel1.TabIndex = 3;
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(209, 341);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(243, 72);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost2_ChildChanged_1);
            this.elementHost2.Child = this.star1;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(471, 284);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(447, 428);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.logoPanel1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 708);
            this.Controls.Add(this.elementHost3);
            this.Controls.Add(this.transparentPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.elementHost1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WpfCustomControlLibrary.LogoPanel logoPanel1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private WpfCustomControlLibrary.Star star1;
        private System.Windows.Forms.Label label1;
        private Component.MyComponents.TransparentPanel transparentPanel1;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private WpfCustomControlLibrary.CurvePanel curvePanel;
    }
}