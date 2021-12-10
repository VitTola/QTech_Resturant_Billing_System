namespace QTech.Forms
{
    partial class frmSale
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
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.exPanel2 = new QTech.Component.Components.ExPanel();
            this.exPanel3 = new QTech.Component.Components.ExPanel();
            this.exPanel4 = new QTech.Component.Components.ExPanel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.flp = new WpfCustomControlLibrary.WPFFlowLayout();
            this.container.SuspendLayout();
            this.exPanel1.SuspendLayout();
            this.exPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.elementHost1);
            this.container.Controls.Add(this.exPanel3);
            this.container.Controls.Add(this.exPanel1);
            this.container.Size = new System.Drawing.Size(983, 646);
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.exPanel1.Controls.Add(this.exPanel2);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.exPanel1.Location = new System.Drawing.Point(1, 1);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(981, 36);
            this.exPanel1.TabIndex = 18;
            // 
            // exPanel2
            // 
            this.exPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.exPanel2.Location = new System.Drawing.Point(8, 61);
            this.exPanel2.Name = "exPanel2";
            this.exPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel2.Size = new System.Drawing.Size(806, 36);
            this.exPanel2.TabIndex = 19;
            // 
            // exPanel3
            // 
            this.exPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.exPanel3.Controls.Add(this.exPanel4);
            this.exPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel3.Location = new System.Drawing.Point(1, 609);
            this.exPanel3.Name = "exPanel3";
            this.exPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel3.Size = new System.Drawing.Size(981, 36);
            this.exPanel3.TabIndex = 20;
            // 
            // exPanel4
            // 
            this.exPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.exPanel4.Location = new System.Drawing.Point(8, 61);
            this.exPanel4.Name = "exPanel4";
            this.exPanel4.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel4.Size = new System.Drawing.Size(806, 36);
            this.exPanel4.TabIndex = 19;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(1, 37);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(981, 572);
            this.elementHost1.TabIndex = 21;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.flp;
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 666);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSale";
            this.Text = "frmEmployeePay";
            this.container.ResumeLayout(false);
            this.exPanel1.ResumeLayout(false);
            this.exPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private Component.Components.ExPanel exPanel3;
        private Component.Components.ExPanel exPanel4;
        private Component.Components.ExPanel exPanel1;
        private Component.Components.ExPanel exPanel2;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WpfCustomControlLibrary.WPFFlowLayout flp;
    }
}