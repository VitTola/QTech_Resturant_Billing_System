
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cachedReportExpense1 = new QTech.Reports.CachedReportExpense();
            this.btnRemovePic = new System.Windows.Forms.PictureBox();
            this.btnAddPic_ = new System.Windows.Forms.PictureBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.picBox = new WpfCustomControlLibrary.RoundImageBox();
            this.exDataGridView1 = new QTech.Component.ExDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemovePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPic_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView1)).BeginInit();
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
            // exDataGridView1
            // 
            this.exDataGridView1.AllowEnterToNextCell = false;
            this.exDataGridView1.AllowRowNotFound = true;
            this.exDataGridView1.AllowRowNumber = false;
            this.exDataGridView1.AllowUserToAddRows = false;
            this.exDataGridView1.AllowUserToDeleteRows = false;
            this.exDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.exDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.exDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.exDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.exDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.exDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.exDataGridView1.EnableHeadersVisualStyles = false;
            this.exDataGridView1.Executing = false;
            this.exDataGridView1.Location = new System.Drawing.Point(173, 353);
            this.exDataGridView1.MultiSelect = false;
            this.exDataGridView1.Name = "exDataGridView1";
            this.exDataGridView1.Paging = null;
            this.exDataGridView1.ReadOnly = true;
            this.exDataGridView1.RowHeadersVisible = false;
            this.exDataGridView1.RowTemplate.Height = 28;
            this.exDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.exDataGridView1.Size = new System.Drawing.Size(584, 150);
            this.exDataGridView1.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(985, 702);
            this.Controls.Add(this.exDataGridView1);
            this.Controls.Add(this.btnRemovePic);
            this.Controls.Add(this.btnAddPic_);
            this.Controls.Add(this.elementHost1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnRemovePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPic_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Reports.CachedReportExpense cachedReportExpense1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WpfCustomControlLibrary.RoundImageBox picBox;
        private System.Windows.Forms.PictureBox btnAddPic_;
        private System.Windows.Forms.PictureBox btnRemovePic;
        private Component.ExDataGridView exDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}