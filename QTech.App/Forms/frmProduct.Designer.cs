namespace QTech.Forms
{
    partial class frmProduct
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblName = new QTech.Component.ExLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChangeLog = new QTech.Component.ExButtonLoading();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.lblCategory = new QTech.Component.ExLabel();
            this.cboCategory = new QTech.Component.ExSearchCombo();
            this.btnRemovePic = new System.Windows.Forms.PictureBox();
            this.btnAddPic_ = new System.Windows.Forms.PictureBox();
            this.picDish = new System.Windows.Forms.Integration.ElementHost();
            this.picFood = new WpfCustomControlLibrary.RoundImageBox();
            this.dgv = new QTech.Component.ExDataGridView();
            this.exLabel1 = new QTech.Component.ExLabel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new QTech.Component.ExLabel();
            this.flowLayOutLabelRemoveAdd = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRemove = new System.Windows.Forms.LinkLabel();
            this.lblAdd = new System.Windows.Forms.LinkLabel();
            this.pnlbackground = new System.Windows.Forms.Panel();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScale = new QTech.Component.ExSearchComboColumn();
            this.colSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.container.SuspendLayout();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemovePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPic_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.flowLayOutLabelRemoveAdd.SuspendLayout();
            this.pnlbackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // digheader
            // 
            this.digheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.digheader.Size = new System.Drawing.Size(685, 20);
            // 
            // container
            // 
            this.container.Controls.Add(this.pnlbackground);
            this.container.Controls.Add(this.flowLayOutLabelRemoveAdd);
            this.container.Controls.Add(this.exLabel1);
            this.container.Controls.Add(this.btnRemovePic);
            this.container.Controls.Add(this.btnAddPic_);
            this.container.Controls.Add(this.picDish);
            this.container.Controls.Add(this.cboCategory);
            this.container.Controls.Add(this.lblCategory);
            this.container.Controls.Add(this.exPanel1);
            this.container.Controls.Add(this.lblNote);
            this.container.Controls.Add(this.txtNote);
            this.container.Controls.Add(this.lblName);
            this.container.Controls.Add(this.txtName);
            this.container.Size = new System.Drawing.Size(685, 389);
            this.container.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(28, 24);
            this.lblName.Name = "lblName";
            this.lblName.Required = true;
            this.lblName.Size = new System.Drawing.Size(40, 19);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "ឈ្មោះ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 21);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 28);
            this.txtName.TabIndex = 0;
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.flowLayoutPanel3);
            this.exPanel1.Controls.Add(this.flowLayoutPanel2);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel1.Location = new System.Drawing.Point(1, 352);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(683, 36);
            this.exPanel1.TabIndex = 25;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnChangeLog);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(200, 32);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // btnChangeLog
            // 
            this.btnChangeLog.BackColor = System.Drawing.Color.Ivory;
            this.btnChangeLog.DefaultImage = null;
            this.btnChangeLog.Executing = false;
            this.btnChangeLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeLog.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.btnChangeLog.ForeColor = System.Drawing.Color.Black;
            this.btnChangeLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeLog.Location = new System.Drawing.Point(2, 3);
            this.btnChangeLog.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnChangeLog.Name = "btnChangeLog";
            this.btnChangeLog.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnChangeLog.ShortcutText = "E";
            this.btnChangeLog.Size = new System.Drawing.Size(75, 27);
            this.btnChangeLog.TabIndex = 8;
            this.btnChangeLog.Text = "ប្រវត្តកែប្រែ";
            this.btnChangeLog.UseVisualStyleBackColor = true;
            this.btnChangeLog.Click += new System.EventHandler(this.btnChangeLog_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(679, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Ivory;
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(590, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = null;
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "បិទ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Ivory;
            this.btnSave.DefaultImage = null;
            this.btnSave.Executing = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(499, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSave.ShortcutText = null;
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(28, 57);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Required = true;
            this.lblCategory.Size = new System.Drawing.Size(43, 19);
            this.lblCategory.TabIndex = 27;
            this.lblCategory.Text = "ប្រភេទ";
            // 
            // cboCategory
            // 
            this.cboCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.cboCategory.Choose = "";
            this.cboCategory.CustomSearchForm = null;
            this.cboCategory.DataSourceFn = null;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.IsGirdViewColumn = false;
            this.cboCategory.LoadAll = true;
            this.cboCategory.Location = new System.Drawing.Point(120, 54);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.SearchParamFn = null;
            this.cboCategory.SelectedItems = null;
            this.cboCategory.SelectedObject = null;
            this.cboCategory.ShowAll = false;
            this.cboCategory.Size = new System.Drawing.Size(200, 27);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.TextAll = "";
            // 
            // btnRemovePic
            // 
            this.btnRemovePic.Image = global::QTech.Properties.Resources.delete;
            this.btnRemovePic.Location = new System.Drawing.Point(235, 325);
            this.btnRemovePic.Name = "btnRemovePic";
            this.btnRemovePic.Size = new System.Drawing.Size(15, 15);
            this.btnRemovePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRemovePic.TabIndex = 34;
            this.btnRemovePic.TabStop = false;
            this.btnRemovePic.Click += new System.EventHandler(this.btnRemovePic_Click);
            // 
            // btnAddPic_
            // 
            this.btnAddPic_.Image = global::QTech.Properties.Resources.folder;
            this.btnAddPic_.Location = new System.Drawing.Point(201, 326);
            this.btnAddPic_.Name = "btnAddPic_";
            this.btnAddPic_.Size = new System.Drawing.Size(15, 15);
            this.btnAddPic_.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAddPic_.TabIndex = 33;
            this.btnAddPic_.TabStop = false;
            this.btnAddPic_.Click += new System.EventHandler(this.btnAddPic__Click);
            // 
            // picDish
            // 
            this.picDish.Location = new System.Drawing.Point(120, 119);
            this.picDish.Name = "picDish";
            this.picDish.Size = new System.Drawing.Size(200, 200);
            this.picDish.TabIndex = 3;
            this.picDish.Text = "elementHost1";
            this.picDish.Child = this.picFood;
            // 
            // dgv
            // 
            this.dgv.AllowEnterToNextCell = false;
            this.dgv.AllowRowNotFound = true;
            this.dgv.AllowRowNumber = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colScale,
            this.colSalePrice});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.Location = new System.Drawing.Point(1, 1);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(286, 273);
            this.dgv.TabIndex = 35;
            // 
            // exLabel1
            // 
            this.exLabel1.AutoSize = true;
            this.exLabel1.Location = new System.Drawing.Point(353, 21);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Required = false;
            this.exLabel1.Size = new System.Drawing.Size(87, 19);
            this.exLabel1.TabIndex = 36;
            this.exLabel1.Text = "តម្លៃលក់តាមខ្នាត";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(120, 86);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(200, 28);
            this.txtNote.TabIndex = 2;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(28, 88);
            this.lblNote.Name = "lblNote";
            this.lblNote.Required = false;
            this.lblNote.Size = new System.Drawing.Size(39, 19);
            this.lblNote.TabIndex = 24;
            this.lblNote.Text = "ចំណាំ";
            // 
            // flowLayOutLabelRemoveAdd
            // 
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblRemove);
            this.flowLayOutLabelRemoveAdd.Controls.Add(this.lblAdd);
            this.flowLayOutLabelRemoveAdd.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayOutLabelRemoveAdd.Location = new System.Drawing.Point(546, 21);
            this.flowLayOutLabelRemoveAdd.Name = "flowLayOutLabelRemoveAdd";
            this.flowLayOutLabelRemoveAdd.Size = new System.Drawing.Size(99, 19);
            this.flowLayOutLabelRemoveAdd.TabIndex = 37;
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblRemove.Location = new System.Drawing.Point(68, 0);
            this.lblRemove.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(28, 19);
            this.lblRemove.TabIndex = 1;
            this.lblRemove.TabStop = true;
            this.lblRemove.Text = "លុប";
            this.lblRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemove_LinkClicked);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblAdd.Location = new System.Drawing.Point(31, 0);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(37, 19);
            this.lblAdd.TabIndex = 0;
            this.lblAdd.TabStop = true;
            this.lblAdd.Text = "បន្ថែម";
            this.lblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAdd_LinkClicked);
            // 
            // pnlbackground
            // 
            this.pnlbackground.Controls.Add(this.dgv);
            this.pnlbackground.Location = new System.Drawing.Point(357, 44);
            this.pnlbackground.Name = "pnlbackground";
            this.pnlbackground.Padding = new System.Windows.Forms.Padding(1);
            this.pnlbackground.Size = new System.Drawing.Size(288, 275);
            this.pnlbackground.TabIndex = 38;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colScale
            // 
            this.colScale.Choose = null;
            this.colScale.CustomSearchForm = null;
            this.colScale.DataSourceFn = null;
            this.colScale.FillWeight = 120F;
            this.colScale.HeaderText = "ខ្នាត";
            this.colScale.Name = "colScale";
            this.colScale.ReadOnly = true;
            this.colScale.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colScale.SearchParamFn = null;
            this.colScale.ShowAll = false;
            this.colScale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colScale.TextAll = null;
            this.colScale.Width = 150;
            // 
            // colSalePrice
            // 
            this.colSalePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colSalePrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSalePrice.HeaderText = "តម្លៃ";
            this.colSalePrice.Name = "colSalePrice";
            this.colSalePrice.ReadOnly = true;
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 409);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmProduct";
            this.Text = "frmEmployee";
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRemovePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPic_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.flowLayOutLabelRemoveAdd.ResumeLayout(false);
            this.flowLayOutLabelRemoveAdd.PerformLayout();
            this.pnlbackground.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Component.ExLabel lblName;
        private System.Windows.Forms.TextBox txtName;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private Component.ExLabel lblCategory;
        private Component.ExSearchCombo cboCategory;
        private System.Windows.Forms.Integration.ElementHost picDish;
        private System.Windows.Forms.PictureBox btnRemovePic;
        private System.Windows.Forms.PictureBox btnAddPic_;
        private WpfCustomControlLibrary.RoundImageBox picFood;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExButtonLoading btnChangeLog;
        private Component.ExLabel exLabel1;
        private Component.ExDataGridView dgv;
        private Component.ExLabel lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.FlowLayoutPanel flowLayOutLabelRemoveAdd;
        private System.Windows.Forms.LinkLabel lblRemove;
        private System.Windows.Forms.LinkLabel lblAdd;
        private System.Windows.Forms.Panel pnlbackground;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private Component.ExSearchComboColumn colScale;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalePrice;
    }
}