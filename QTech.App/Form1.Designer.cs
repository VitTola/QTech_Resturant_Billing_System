﻿
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
            this.cachedReportProfit1 = new QTech.Reports.CachedReportProfit();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.wpfFlowLayout1 = new WpfCustomControlLibrary.WPFFlowLayout();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.wpfFlowLayout2 = new WpfCustomControlLibrary.WPFFlowLayout();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(922, 579);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.wpfFlowLayout1;
            // 
            // elementHost2
            // 
            this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost2.Location = new System.Drawing.Point(0, 0);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(922, 579);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.wpfFlowLayout2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 579);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.elementHost1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Reports.CachedReportProfit cachedReportProfit1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WpfCustomControlLibrary.WPFFlowLayout wpfFlowLayout1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private WpfCustomControlLibrary.WPFFlowLayout wpfFlowLayout2;
    }
}