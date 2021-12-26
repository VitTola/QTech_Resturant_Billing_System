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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.lineDownPanel1 = new SaleInventory.Components.LineDownPanel();
            this.panelLineRight1 = new SaleInventory.Components.PanelLineRight();
            this.lineDownPanel2 = new SaleInventory.Components.LineDownPanel();
            this.pnlLeft = new SaleInventory.Components.PanelBorderLine();
            this.pnlMainLeft = new SaleInventory.Components.PanelBorderLine();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.pnl = new WpfCustomControlLibrary.WPFFlowLayout();
            this.topLinedown = new SaleInventory.Components.LineDownPanel();
            this.txtFreeTables = new System.Windows.Forms.TextBox();
            this.btnOrder_ = new QTech.Component.ExButtonLoading();
            this.txtSearch = new QTech.Component.ExTextboxIconPattern();
            this._lblOccupy = new System.Windows.Forms.Label();
            this._lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFreeTable_ = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lineDownPanel3 = new SaleInventory.Components.LineDownPanel();
            this.lblDate_ = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.pnlMainRight = new SaleInventory.Components.PanelBorderLine();
            this.exPanel = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCalculate = new QTech.Component.ExButtonLoading();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTable_ = new System.Windows.Forms.Label();
            this.dgv = new QTech.Component.ExDataGridView();
            this.col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQauntity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.container.SuspendLayout();
            this.pnlMainLeft.SuspendLayout();
            this.topLinedown.SuspendLayout();
            this.lineDownPanel3.SuspendLayout();
            this.pnlMainRight.SuspendLayout();
            this.exPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // digheader
            // 
            this.digheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.digheader.Size = new System.Drawing.Size(1295, 20);
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(247)))));
            this.container.Controls.Add(this.pnlMainLeft);
            this.container.Controls.Add(this.pnlMainRight);
            this.container.Padding = new System.Windows.Forms.Padding(5);
            this.container.Size = new System.Drawing.Size(1295, 751);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(200, 100);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Child = null;
            // 
            // lineDownPanel1
            // 
            this.lineDownPanel1.Location = new System.Drawing.Point(0, 0);
            this.lineDownPanel1.Name = "lineDownPanel1";
            this.lineDownPanel1.PenColor = System.Drawing.Color.Gray;
            this.lineDownPanel1.PenThickness = 5;
            this.lineDownPanel1.Size = new System.Drawing.Size(200, 100);
            this.lineDownPanel1.TabIndex = 0;
            // 
            // panelLineRight1
            // 
            this.panelLineRight1.Location = new System.Drawing.Point(0, 0);
            this.panelLineRight1.Name = "panelLineRight1";
            this.panelLineRight1.PenColor = System.Drawing.Color.Gray;
            this.panelLineRight1.PenThickness = 5;
            this.panelLineRight1.Size = new System.Drawing.Size(200, 100);
            this.panelLineRight1.TabIndex = 0;
            // 
            // lineDownPanel2
            // 
            this.lineDownPanel2.Location = new System.Drawing.Point(0, 0);
            this.lineDownPanel2.Name = "lineDownPanel2";
            this.lineDownPanel2.PenColor = System.Drawing.Color.Gray;
            this.lineDownPanel2.PenThickness = 5;
            this.lineDownPanel2.Size = new System.Drawing.Size(200, 100);
            this.lineDownPanel2.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.PenColor = System.Drawing.Color.Gray;
            this.pnlLeft.PenThickness = 5;
            this.pnlLeft.Size = new System.Drawing.Size(200, 100);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlMainLeft
            // 
            this.pnlMainLeft.Controls.Add(this.elementHost2);
            this.pnlMainLeft.Controls.Add(this.topLinedown);
            this.pnlMainLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainLeft.Location = new System.Drawing.Point(5, 5);
            this.pnlMainLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMainLeft.Name = "pnlMainLeft";
            this.pnlMainLeft.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMainLeft.PenColor = System.Drawing.Color.CornflowerBlue;
            this.pnlMainLeft.PenThickness = 3;
            this.pnlMainLeft.Size = new System.Drawing.Size(1059, 741);
            this.pnlMainLeft.TabIndex = 0;
            // 
            // elementHost2
            // 
            this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost2.Location = new System.Drawing.Point(5, 44);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(1049, 692);
            this.elementHost2.TabIndex = 3;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.pnl;
            // 
            // topLinedown
            // 
            this.topLinedown.Controls.Add(this.txtFreeTables);
            this.topLinedown.Controls.Add(this.btnOrder_);
            this.topLinedown.Controls.Add(this.txtSearch);
            this.topLinedown.Controls.Add(this._lblOccupy);
            this.topLinedown.Controls.Add(this._lbl);
            this.topLinedown.Controls.Add(this.label1);
            this.topLinedown.Controls.Add(this.lblFreeTable_);
            this.topLinedown.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLinedown.Location = new System.Drawing.Point(5, 5);
            this.topLinedown.Name = "topLinedown";
            this.topLinedown.PenColor = System.Drawing.Color.CornflowerBlue;
            this.topLinedown.PenThickness = 2;
            this.topLinedown.Size = new System.Drawing.Size(1049, 39);
            this.topLinedown.TabIndex = 6;
            // 
            // txtFreeTables
            // 
            this.txtFreeTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFreeTables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFreeTables.Font = new System.Drawing.Font("Khmer OS Siemreap", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFreeTables.Location = new System.Drawing.Point(430, 5);
            this.txtFreeTables.Multiline = true;
            this.txtFreeTables.Name = "txtFreeTables";
            this.txtFreeTables.Size = new System.Drawing.Size(533, 27);
            this.txtFreeTables.TabIndex = 12;
            // 
            // btnOrder_
            // 
            this.btnOrder_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrder_.BackColor = System.Drawing.Color.Ivory;
            this.btnOrder_.DefaultImage = null;
            this.btnOrder_.Executing = false;
            this.btnOrder_.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder_.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.btnOrder_.ForeColor = System.Drawing.Color.Black;
            this.btnOrder_.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder_.Location = new System.Drawing.Point(968, 4);
            this.btnOrder_.Margin = new System.Windows.Forms.Padding(2, 6, 2, 2);
            this.btnOrder_.Name = "btnOrder_";
            this.btnOrder_.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnOrder_.ShortcutText = "O";
            this.btnOrder_.Size = new System.Drawing.Size(75, 27);
            this.btnOrder_.TabIndex = 11;
            this.btnOrder_.Text = "កម្មង់ម្ហូប";
            this.btnOrder_.UseVisualStyleBackColor = true;
            this.btnOrder_.Click += new System.EventHandler(this.btnOrder__Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(3, 2);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 2, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ReadOnly = false;
            this.txtSearch.SearchMode = QTech.Component.ExTextboxIconPattern.SearchModes.OnKeyReturn;
            this.txtSearch.SelectedMenuPattern = null;
            this.txtSearch.Size = new System.Drawing.Size(200, 30);
            this.txtSearch.SizeIcon = new System.Drawing.Size(16, 16);
            this.txtSearch.TabIndex = 1;
            // 
            // _lblOccupy
            // 
            this._lblOccupy.AutoSize = true;
            this._lblOccupy.Font = new System.Drawing.Font("Khmer OS Siemreap", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOccupy.ForeColor = System.Drawing.Color.Blue;
            this._lblOccupy.Location = new System.Drawing.Point(255, 5);
            this._lblOccupy.Name = "_lblOccupy";
            this._lblOccupy.Size = new System.Drawing.Size(79, 24);
            this._lblOccupy.TabIndex = 5;
            this._lblOccupy.Text = "តុទំមានភ្ញៀវ";
            // 
            // _lbl
            // 
            this._lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(191)))), ((int)(((byte)(85)))));
            this._lbl.Location = new System.Drawing.Point(352, 7);
            this._lbl.Name = "_lbl";
            this._lbl.Size = new System.Drawing.Size(20, 20);
            this._lbl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(235, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 3;
            // 
            // lblFreeTable_
            // 
            this.lblFreeTable_.AutoSize = true;
            this.lblFreeTable_.Font = new System.Drawing.Font("Khmer OS Siemreap", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreeTable_.ForeColor = System.Drawing.Color.Blue;
            this.lblFreeTable_.Location = new System.Drawing.Point(374, 6);
            this.lblFreeTable_.Name = "lblFreeTable_";
            this.lblFreeTable_.Size = new System.Drawing.Size(63, 24);
            this.lblFreeTable_.TabIndex = 4;
            this.lblFreeTable_.Text = "តុទំនេរ ៖​";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lineDownPanel3
            // 
            this.lineDownPanel3.Controls.Add(this.lblDate_);
            this.lineDownPanel3.Controls.Add(this.lblTime);
            this.lineDownPanel3.Location = new System.Drawing.Point(3, 3);
            this.lineDownPanel3.Name = "lineDownPanel3";
            this.lineDownPanel3.PenColor = System.Drawing.Color.CornflowerBlue;
            this.lineDownPanel3.PenThickness = 3;
            this.lineDownPanel3.Size = new System.Drawing.Size(220, 126);
            this.lineDownPanel3.TabIndex = 4;
            // 
            // lblDate_
            // 
            this.lblDate_.BackColor = System.Drawing.Color.Transparent;
            this.lblDate_.Font = new System.Drawing.Font("Khmer OS Battambang", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate_.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblDate_.Location = new System.Drawing.Point(3, 65);
            this.lblDate_.Name = "lblDate_";
            this.lblDate_.Size = new System.Drawing.Size(214, 41);
            this.lblDate_.TabIndex = 2;
            this.lblDate_.Text = ".";
            this.lblDate_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTime.Location = new System.Drawing.Point(3, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(217, 55);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = ".";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMainRight
            // 
            this.pnlMainRight.Controls.Add(this.exPanel);
            this.pnlMainRight.Controls.Add(this.label2);
            this.pnlMainRight.Controls.Add(this.label4);
            this.pnlMainRight.Controls.Add(this.lblTable_);
            this.pnlMainRight.Controls.Add(this.dgv);
            this.pnlMainRight.Controls.Add(this.lineDownPanel3);
            this.pnlMainRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMainRight.Location = new System.Drawing.Point(1064, 5);
            this.pnlMainRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMainRight.Name = "pnlMainRight";
            this.pnlMainRight.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlMainRight.PenColor = System.Drawing.Color.CornflowerBlue;
            this.pnlMainRight.PenThickness = 3;
            this.pnlMainRight.Size = new System.Drawing.Size(226, 741);
            this.pnlMainRight.TabIndex = 1;
            // 
            // exPanel
            // 
            this.exPanel.BackColor = System.Drawing.Color.Transparent;
            this.exPanel.Controls.Add(this.flowLayoutPanel3);
            this.exPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel.Location = new System.Drawing.Point(0, 697);
            this.exPanel.Name = "exPanel";
            this.exPanel.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel.Size = new System.Drawing.Size(226, 44);
            this.exPanel.TabIndex = 23;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnCalculate);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(222, 40);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.BackColor = System.Drawing.Color.Ivory;
            this.btnCalculate.DefaultImage = null;
            this.btnCalculate.Executing = false;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.btnCalculate.ForeColor = System.Drawing.Color.Black;
            this.btnCalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalculate.Location = new System.Drawing.Point(145, 6);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(2, 6, 2, 2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnCalculate.ShortcutText = "T";
            this.btnCalculate.Size = new System.Drawing.Size(75, 27);
            this.btnCalculate.TabIndex = 10;
            this.btnCalculate.Text = "គិតលុយ";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Khmer OS Battambang", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(7, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 33);
            this.label2.TabIndex = 9;
            this.label2.Text = "បានកម្មង់";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Khmer OS Battambang", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(8, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 41);
            this.label4.TabIndex = 8;
            this.label4.Text = "តុ ៖";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTable_
            // 
            this.lblTable_.BackColor = System.Drawing.Color.Transparent;
            this.lblTable_.Font = new System.Drawing.Font("Khmer OS Battambang", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable_.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTable_.Location = new System.Drawing.Point(46, 136);
            this.lblTable_.Name = "lblTable_";
            this.lblTable_.Size = new System.Drawing.Size(173, 41);
            this.lblTable_.TabIndex = 7;
            this.lblTable_.Text = ".";
            this.lblTable_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col,
            this.colProduct,
            this.colQauntity});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(205)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Executing = false;
            this.dgv.Location = new System.Drawing.Point(12, 222);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.Paging = null;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(208, 459);
            this.dgv.TabIndex = 6;
            // 
            // col
            // 
            this.col.HeaderText = "Id";
            this.col.Name = "col";
            this.col.ReadOnly = true;
            this.col.Visible = false;
            // 
            // colProduct
            // 
            this.colProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProduct.HeaderText = "មុខទំនិញ";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            // 
            // colQauntity
            // 
            this.colQauntity.HeaderText = "ចំនួន";
            this.colQauntity.Name = "colQauntity";
            this.colQauntity.ReadOnly = true;
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 771);
            this.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSale";
            this.Text = "frmEmployeePay";
            this.container.ResumeLayout(false);
            this.pnlMainLeft.ResumeLayout(false);
            this.topLinedown.ResumeLayout(false);
            this.topLinedown.PerformLayout();
            this.lineDownPanel3.ResumeLayout(false);
            this.pnlMainRight.ResumeLayout(false);
            this.exPanel.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WpfCustomControlLibrary.WPFFlowLayout flp;
        private SaleInventory.Components.PanelLineRight panelLineRight1;
        private SaleInventory.Components.LineDownPanel lineDownPanel1;
        private SaleInventory.Components.LineDownPanel lineDownPanel2;
        private SaleInventory.Components.PanelBorderLine pnlLeft;
        private SaleInventory.Components.PanelBorderLine pnlMainLeft;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private WpfCustomControlLibrary.WPFFlowLayout pnl;
        private System.Windows.Forms.Timer timer;
        private SaleInventory.Components.LineDownPanel topLinedown;
        private Component.ExTextboxIconPattern txtSearch;
        private System.Windows.Forms.Label _lblOccupy;
        private System.Windows.Forms.Label _lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFreeTable_;
        private SaleInventory.Components.PanelBorderLine pnlMainRight;
        private SaleInventory.Components.LineDownPanel lineDownPanel3;
        private System.Windows.Forms.Label lblDate_;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTable_;
        private Component.ExDataGridView dgv;
        private Component.ExButtonLoading btnCalculate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQauntity;
        private Component.Components.ExPanel exPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Component.ExButtonLoading btnOrder_;
        private System.Windows.Forms.TextBox txtFreeTables;
    }
}