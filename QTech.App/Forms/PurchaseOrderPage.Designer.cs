namespace QTech.Forms
{
    partial class PurchaseOrderPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            QTech.Base.BaseModels.Paging paging2 = new QTech.Base.BaseModels.Paging();
            this.graPanel1 = new QTech.Component.GRAPanel();
            this.colorWithAlpha1 = new QTech.Component.ColorWithAlpha();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new QTech.Component.ExTextbox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemove = new QTech.Component.ExButtonLoading();
            this.btnUpdate = new QTech.Component.ExButtonLoading();
            this.btnAdd = new QTech.Component.ExButtonLoading();
            this.colorWithAlpha2 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha3 = new QTech.Component.ColorWithAlpha();
            this.colName = new QTech.Component.TreeGridColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv = new QTech.Component.ExDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRowDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.pagination = new QTech.Component.ExPaging();
            this.cboCustomer = new QTech.Component.ExSearchCombo();
            this.graPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // graPanel1
            // 
            this.graPanel1.BackColor = System.Drawing.Color.Transparent;
            this.graPanel1.Border = false;
            this.graPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.graPanel1.Colors.Add(this.colorWithAlpha1);
            this.graPanel1.ContentPadding = new System.Windows.Forms.Padding(0);
            this.graPanel1.Controls.Add(this.flowLayoutPanel2);
            this.graPanel1.Controls.Add(this.flowLayoutPanel1);
            this.graPanel1.CornerRadius = 3;
            this.graPanel1.Corners = ((QTech.Component.Corners)((((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight) 
            | QTech.Component.Corners.BottomLeft) 
            | QTech.Component.Corners.BottomRight)));
            this.graPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.graPanel1.Gradient = false;
            this.graPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.graPanel1.GradientOffset = 1F;
            this.graPanel1.GradientSize = new System.Drawing.Size(0, 0);
            this.graPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.graPanel1.Grayscale = false;
            this.graPanel1.Image = null;
            this.graPanel1.ImageAlpha = 75;
            this.graPanel1.ImagePadding = new System.Windows.Forms.Padding(0);
            this.graPanel1.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.graPanel1.ImageSize = new System.Drawing.Size(48, 48);
            this.graPanel1.Location = new System.Drawing.Point(0, 0);
            this.graPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.graPanel1.Name = "graPanel1";
            this.graPanel1.Rounded = true;
            this.graPanel1.Size = new System.Drawing.Size(945, 35);
            this.graPanel1.TabIndex = 0;
            // 
            // colorWithAlpha1
            // 
            this.colorWithAlpha1.Alpha = 255;
            this.colorWithAlpha1.Color = System.Drawing.SystemColors.Control;
            this.colorWithAlpha1.Parent = this.graPanel1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.txtSearch);
            this.flowLayoutPanel2.Controls.Add(this.cboCustomer);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(664, 35);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(4, 4);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(2, 3, 1, 4);
            this.txtSearch.PlaceHolderText = "";
            this.txtSearch.SearchMode = QTech.Component.ExTextbox.SearchModes.OnKeyReturn;
            this.txtSearch.Size = new System.Drawing.Size(200, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnRemove);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdate);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(658, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(287, 35);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Ivory;
            this.btnRemove.DefaultImage = null;
            this.btnRemove.Executing = false;
            this.btnRemove.Location = new System.Drawing.Point(193, 4);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(0, 4, 4, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnRemove.ShortcutText = null;
            this.btnRemove.Size = new System.Drawing.Size(90, 27);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "លុប";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Ivory;
            this.btnUpdate.DefaultImage = null;
            this.btnUpdate.Executing = false;
            this.btnUpdate.Location = new System.Drawing.Point(101, 4);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0, 4, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnUpdate.ShortcutText = null;
            this.btnUpdate.Size = new System.Drawing.Size(90, 27);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "កែប្រែ";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Ivory;
            this.btnAdd.DefaultImage = null;
            this.btnAdd.Executing = false;
            this.btnAdd.Location = new System.Drawing.Point(9, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0, 4, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnAdd.ShortcutText = null;
            this.btnAdd.Size = new System.Drawing.Size(90, 27);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "បន្ថែម";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // colorWithAlpha2
            // 
            this.colorWithAlpha2.Alpha = 255;
            this.colorWithAlpha2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.colorWithAlpha2.Parent = null;
            // 
            // colorWithAlpha3
            // 
            this.colorWithAlpha3.Alpha = 255;
            this.colorWithAlpha3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.colorWithAlpha3.Parent = null;
            // 
            // colName
            // 
            this.colName.DefaultNodeImage = null;
            this.colName.Name = "colName";
            // 
            // colNote
            // 
            this.colNote.Name = "colNote";
            // 
            // dgv
            // 
            this.dgv.AllowEnterToNextCell = false;
            this.dgv.AllowRowNotFound = true;
            this.dgv.AllowRowNumber = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Khmer OS System", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.ColumnHeadersHeight = 28;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colRowDate,
            this.colRow,
            this.colName_,
            this.colCustomer,
            this.colNote_});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Khmer OS System", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.Font = new System.Drawing.Font("Khmer OS System", 8F);
            this.dgv.Location = new System.Drawing.Point(0, 35);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(945, 440);
            this.dgv.TabIndex = 2;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colRowDate
            // 
            this.colRowDate.HeaderText = "RowDate";
            this.colRowDate.Name = "colRowDate";
            this.colRowDate.ReadOnly = true;
            this.colRowDate.Visible = false;
            // 
            // colRow
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRow.DefaultCellStyle = dataGridViewCellStyle7;
            this.colRow.HeaderText = "ល.រ";
            this.colRow.Name = "colRow";
            this.colRow.ReadOnly = true;
            this.colRow.Width = 30;
            // 
            // colName_
            // 
            this.colName_.DataPropertyName = "Name";
            this.colName_.FillWeight = 40F;
            this.colName_.HeaderText = "ឈ្មោះ";
            this.colName_.MinimumWidth = 300;
            this.colName_.Name = "colName_";
            this.colName_.ReadOnly = true;
            this.colName_.Width = 300;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "អតិថិជន";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 200;
            // 
            // colNote_
            // 
            this.colNote_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNote_.DataPropertyName = "Note";
            this.colNote_.FillWeight = 60F;
            this.colNote_.HeaderText = "កំណត់ចំណាំ";
            this.colNote_.Name = "colNote_";
            this.colNote_.ReadOnly = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.pagination);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 475);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(945, 33);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // pagination
            // 
            this.pagination.Action = null;
            this.pagination.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pagination.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagination.IsPaging = false;
            this.pagination.ListModel = null;
            this.pagination.Location = new System.Drawing.Point(3, 4);
            this.pagination.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagination.MinimumSize = new System.Drawing.Size(380, 33);
            this.pagination.Name = "pagination";
            paging2.CurrentPage = 1;
            paging2.IsPaging = true;
            paging2.PageSize = 25;
            this.pagination.Paging = paging2;
            this.pagination.ShowAllOption = false;
            this.pagination.Size = new System.Drawing.Size(504, 33);
            this.pagination.TabIndex = 0;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Choose = "";
            this.cboCustomer.CustomSearchForm = null;
            this.cboCustomer.DataSourceFn = null;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.IsGirdViewColumn = false;
            this.cboCustomer.LoadAll = true;
            this.cboCustomer.Location = new System.Drawing.Point(210, 3);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.SearchParamFn = null;
            this.cboCustomer.SelectedItems = null;
            this.cboCustomer.SelectedObject = null;
            this.cboCustomer.ShowAll = false;
            this.cboCustomer.Size = new System.Drawing.Size(200, 27);
            this.cboCustomer.TabIndex = 27;
            this.cboCustomer.TextAll = "";
            // 
            // PurchaseOrderPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 508);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.graPanel1);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PurchaseOrderPage";
            this.Text = "PurchaseOrder";
            this.graPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Component.GRAPanel graPanel1;
        private Component.ColorWithAlpha colorWithAlpha1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Component.ExButtonLoading btnAdd;
        private Component.ExButtonLoading btnRemove;
        private Component.ExButtonLoading btnUpdate;
        private Component.ColorWithAlpha colorWithAlpha2;
        private Component.ColorWithAlpha colorWithAlpha3;
        private Component.ExTextbox txtSearch;
        private Component.TreeGridColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
        private Component.ExDataGridView dgv;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExPaging pagination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote_;
        private Component.ExSearchCombo cboCustomer;
    }
}