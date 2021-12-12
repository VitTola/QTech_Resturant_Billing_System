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
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.lineDownPanel1 = new SaleInventory.Components.LineDownPanel();
            this.panelLineRight1 = new SaleInventory.Components.PanelLineRight();
            this.lineDownPanel2 = new SaleInventory.Components.LineDownPanel();
            this.pnlLeft = new SaleInventory.Components.PanelBorderLine();
            this.pnlMainLeft = new SaleInventory.Components.PanelBorderLine();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.pnl = new WpfCustomControlLibrary.WPFFlowLayout();
            this.pnlTop = new SaleInventory.Components.PanelBorderLine();
            this.txtSearch = new QTech.Component.ExTextboxIconPattern();
            this.pnlMainRight = new SaleInventory.Components.PanelBorderLine();
            this.lblDate_ = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.container.SuspendLayout();
            this.pnlMainLeft.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMainRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.pnlMainLeft);
            this.container.Controls.Add(this.pnlMainRight);
            this.container.Padding = new System.Windows.Forms.Padding(5);
            this.container.Size = new System.Drawing.Size(983, 646);
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
            this.lineDownPanel1.Size = new System.Drawing.Size(200, 100);
            this.lineDownPanel1.TabIndex = 0;
            // 
            // panelLineRight1
            // 
            this.panelLineRight1.Location = new System.Drawing.Point(0, 0);
            this.panelLineRight1.Name = "panelLineRight1";
            this.panelLineRight1.PenColor = System.Drawing.Color.Gray;
            this.panelLineRight1.Size = new System.Drawing.Size(200, 100);
            this.panelLineRight1.TabIndex = 0;
            // 
            // lineDownPanel2
            // 
            this.lineDownPanel2.Location = new System.Drawing.Point(0, 0);
            this.lineDownPanel2.Name = "lineDownPanel2";
            this.lineDownPanel2.PenColor = System.Drawing.Color.Gray;
            this.lineDownPanel2.Size = new System.Drawing.Size(200, 100);
            this.lineDownPanel2.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.PenColor = System.Drawing.Color.Gray;
            this.pnlLeft.Size = new System.Drawing.Size(200, 100);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlMainLeft
            // 
            this.pnlMainLeft.Controls.Add(this.elementHost2);
            this.pnlMainLeft.Controls.Add(this.pnlTop);
            this.pnlMainLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainLeft.Location = new System.Drawing.Point(5, 5);
            this.pnlMainLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMainLeft.Name = "pnlMainLeft";
            this.pnlMainLeft.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMainLeft.PenColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pnlMainLeft.Size = new System.Drawing.Size(773, 636);
            this.pnlMainLeft.TabIndex = 0;
            // 
            // elementHost2
            // 
            this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost2.Location = new System.Drawing.Point(5, 50);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(763, 581);
            this.elementHost2.TabIndex = 3;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.pnl;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(5, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.PenColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pnlTop.Size = new System.Drawing.Size(763, 45);
            this.pnlTop.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(10, 9);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 2, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ReadOnly = false;
            this.txtSearch.SearchMode = QTech.Component.ExTextboxIconPattern.SearchModes.OnKeyReturn;
            this.txtSearch.SelectedMenuPattern = null;
            this.txtSearch.Size = new System.Drawing.Size(200, 26);
            this.txtSearch.SizeIcon = new System.Drawing.Size(16, 16);
            this.txtSearch.TabIndex = 1;
            // 
            // pnlMainRight
            // 
            this.pnlMainRight.Controls.Add(this.lblDate_);
            this.pnlMainRight.Controls.Add(this.lblTime);
            this.pnlMainRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMainRight.Location = new System.Drawing.Point(778, 5);
            this.pnlMainRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMainRight.Name = "pnlMainRight";
            this.pnlMainRight.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlMainRight.PenColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pnlMainRight.Size = new System.Drawing.Size(200, 636);
            this.pnlMainRight.TabIndex = 1;
            // 
            // lblDate_
            // 
            this.lblDate_.BackColor = System.Drawing.Color.Transparent;
            this.lblDate_.Font = new System.Drawing.Font("Khmer OS Battambang", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate_.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblDate_.Location = new System.Drawing.Point(3, 81);
            this.lblDate_.Name = "lblDate_";
            this.lblDate_.Size = new System.Drawing.Size(194, 61);
            this.lblDate_.TabIndex = 2;
            this.lblDate_.Text = ".";
            this.lblDate_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTime.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTime.Location = new System.Drawing.Point(0, 10);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(200, 55);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = ".";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
            this.pnlMainLeft.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMainRight.ResumeLayout(false);
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
        private SaleInventory.Components.PanelBorderLine pnlMainRight;
        private SaleInventory.Components.PanelBorderLine pnlTop;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private WpfCustomControlLibrary.WPFFlowLayout pnl;
        private Component.ExTextboxIconPattern txtSearch;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblDate_;
    }
}