namespace QTech.Forms
{
    partial class frmFoodOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFoodOrder));
            this.exPanel1 = new QTech.Component.Components.ExPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new QTech.Component.ExButtonLoading();
            this.btnSave = new QTech.Component.ExButtonLoading();
            this.flpo = new System.Windows.Forms.Integration.ElementHost();
            this.flp = new WpfCustomControlLibrary.WPFFlowLayout();
            this.panelBorderLine1 = new SaleInventory.Components.PanelBorderLine();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtSearch = new QTech.Component.ExTextbox();
            this.lblTableName_ = new System.Windows.Forms.Label();
            this.btnShowImage = new System.Windows.Forms.PictureBox();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabChoose_ = new System.Windows.Forms.TabPage();
            this.tabOrdered_ = new System.Windows.Forms.TabPage();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.flpOrdered = new WpfCustomControlLibrary.WPFFlowLayout();
            this.container.SuspendLayout();
            this.exPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panelBorderLine1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowImage)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabChoose_.SuspendLayout();
            this.tabOrdered_.SuspendLayout();
            this.SuspendLayout();
            // 
            // digheader
            // 
            this.digheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.digheader.Size = new System.Drawing.Size(968, 20);
            // 
            // container
            // 
            this.container.Controls.Add(this.tabMain);
            this.container.Controls.Add(this.panelBorderLine1);
            this.container.Controls.Add(this.exPanel1);
            this.container.Size = new System.Drawing.Size(968, 618);
            // 
            // exPanel1
            // 
            this.exPanel1.BackColor = System.Drawing.Color.Transparent;
            this.exPanel1.Controls.Add(this.flowLayoutPanel2);
            this.exPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanel1.Location = new System.Drawing.Point(1, 581);
            this.exPanel1.Name = "exPanel1";
            this.exPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.exPanel1.Size = new System.Drawing.Size(966, 36);
            this.exPanel1.TabIndex = 17;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(962, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Ivory;
            this.btnClose.DefaultImage = null;
            this.btnClose.Executing = false;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(873, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnClose.ShortcutText = "Q";
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
            this.btnSave.Font = new System.Drawing.Font("Khmer OS Battambang", 8F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(782, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutAligment = QTech.Component.ExButtonLoading.Aligment.Horizontal;
            this.btnSave.ShortcutText = "S";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // flpo
            // 
            this.flpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpo.Location = new System.Drawing.Point(3, 3);
            this.flpo.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.flpo.Name = "flpo";
            this.flpo.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpo.Size = new System.Drawing.Size(952, 503);
            this.flpo.TabIndex = 20;
            this.flpo.Text = "elementHost1";
            this.flpo.Child = this.flp;
            // 
            // panelBorderLine1
            // 
            this.panelBorderLine1.Controls.Add(this.cboCategory);
            this.panelBorderLine1.Controls.Add(this.txtSearch);
            this.panelBorderLine1.Controls.Add(this.lblTableName_);
            this.panelBorderLine1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBorderLine1.Location = new System.Drawing.Point(1, 1);
            this.panelBorderLine1.Name = "panelBorderLine1";
            this.panelBorderLine1.Padding = new System.Windows.Forms.Padding(5);
            this.panelBorderLine1.PenColor = System.Drawing.Color.CornflowerBlue;
            this.panelBorderLine1.PenThickness = 1;
            this.panelBorderLine1.Size = new System.Drawing.Size(966, 39);
            this.panelBorderLine1.TabIndex = 19;
            // 
            // cboCategory
            // 
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(555, 7);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 27);
            this.cboCategory.TabIndex = 22;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F);
            this.txtSearch.Location = new System.Drawing.Point(758, 7);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5, 4, 3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(2, 3, 1, 4);
            this.txtSearch.PlaceHolderText = "";
            this.txtSearch.SearchMode = QTech.Component.ExTextbox.SearchModes.OnKeyReturn;
            this.txtSearch.Size = new System.Drawing.Size(200, 26);
            this.txtSearch.TabIndex = 21;
            this.txtSearch.QuickSearch += new System.EventHandler(this.txtSearch_QuickSearch);
            // 
            // lblTableName_
            // 
            this.lblTableName_.BackColor = System.Drawing.Color.Transparent;
            this.lblTableName_.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTableName_.Font = new System.Drawing.Font("Khmer Muol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName_.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTableName_.Location = new System.Drawing.Point(5, 5);
            this.lblTableName_.Name = "lblTableName_";
            this.lblTableName_.Size = new System.Drawing.Size(516, 29);
            this.lblTableName_.TabIndex = 20;
            this.lblTableName_.Text = ".";
            this.lblTableName_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnShowImage
            // 
            this.btnShowImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowImage.Image = global::QTech.Properties.Resources.maxi_img;
            this.btnShowImage.Location = new System.Drawing.Point(909, 6);
            this.btnShowImage.Name = "btnShowImage";
            this.btnShowImage.Size = new System.Drawing.Size(25, 25);
            this.btnShowImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnShowImage.TabIndex = 23;
            this.btnShowImage.TabStop = false;
            this.btnShowImage.Click += new System.EventHandler(this.btnShowImage_Click);
            this.btnShowImage.MouseLeave += new System.EventHandler(this.btnShowImage_MouseLeave);
            this.btnShowImage.MouseHover += new System.EventHandler(this.btnShowImage_MouseHover);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colUserId
            // 
            this.colUserId.DataPropertyName = "UserId";
            this.colUserId.HeaderText = "UserId";
            this.colUserId.Name = "colUserId";
            this.colUserId.ReadOnly = true;
            this.colUserId.Visible = false;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "FullName";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCreatedBy.DataPropertyName = "CreatedBy";
            this.colCreatedBy.HeaderText = "CreateBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "UserId";
            this.dataGridViewTextBoxColumn2.HeaderText = "UserId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "FullName";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CreatedBy";
            this.dataGridViewTextBoxColumn4.HeaderText = "CreateBy";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabChoose_);
            this.tabMain.Controls.Add(this.tabOrdered_);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(1, 40);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(966, 541);
            this.tabMain.TabIndex = 21;
            // 
            // tabChoose_
            // 
            this.tabChoose_.Controls.Add(this.btnShowImage);
            this.tabChoose_.Controls.Add(this.flpo);
            this.tabChoose_.Location = new System.Drawing.Point(4, 28);
            this.tabChoose_.Name = "tabChoose_";
            this.tabChoose_.Padding = new System.Windows.Forms.Padding(3);
            this.tabChoose_.Size = new System.Drawing.Size(958, 509);
            this.tabChoose_.TabIndex = 0;
            this.tabChoose_.Text = "ជ្រើសរើសមុខម្ហូប";
            this.tabChoose_.UseVisualStyleBackColor = true;
            // 
            // tabOrdered_
            // 
            this.tabOrdered_.Controls.Add(this.elementHost1);
            this.tabOrdered_.Location = new System.Drawing.Point(4, 28);
            this.tabOrdered_.Name = "tabOrdered_";
            this.tabOrdered_.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrdered_.Size = new System.Drawing.Size(437, 199);
            this.tabOrdered_.TabIndex = 1;
            this.tabOrdered_.Text = "ម្ហូបបានកម្មង់";
            this.tabOrdered_.UseVisualStyleBackColor = true;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(3, 3);
            this.elementHost1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.elementHost1.Size = new System.Drawing.Size(431, 193);
            this.elementHost1.TabIndex = 21;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.flpOrdered;
            // 
            // frmFoodOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 638);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmFoodOrder";
            this.Text = "frmTable";
            this.container.ResumeLayout(false);
            this.exPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panelBorderLine1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnShowImage)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabChoose_.ResumeLayout(false);
            this.tabOrdered_.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Component.Components.ExPanel exPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Component.ExButtonLoading btnClose;
        private Component.ExButtonLoading btnSave;
        private SaleInventory.Components.PanelBorderLine panelBorderLine1;
        private System.Windows.Forms.Label lblTableName_;
        private System.Windows.Forms.Integration.ElementHost flpo;
        private WpfCustomControlLibrary.WPFFlowLayout flp;
        private System.Windows.Forms.PictureBox btnShowImage;
        private System.Windows.Forms.ComboBox cboCategory;
        private Component.ExTextbox txtSearch;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabChoose_;
        private System.Windows.Forms.TabPage tabOrdered_;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WpfCustomControlLibrary.WPFFlowLayout flpOrdered;
    }
}