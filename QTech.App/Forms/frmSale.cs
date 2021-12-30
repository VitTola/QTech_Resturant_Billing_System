﻿
using FastMember;
using QTech.Base;
using QTech.Base.BaseReport;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using QTech.ReportModels;
using QTech.Reports;
using Storm.CC.Report.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseReource = QTech.Base.Properties.Resources;
using EasyServer.Domain.Helpers;
using EDomain = EasyServer.Domain;
using WpfCustomControlLibrary;
using System.Globalization;
using Table = WpfCustomControlLibrary.Table;

namespace QTech.Forms
{
    public partial class frmSale : ExDialog, IDialog
    {
        public Sale Model { get; set; }
        public GeneralProcess Flag { get; set; }
        public frmSale(Sale model, GeneralProcess flag)
        {
            InitializeComponent();
            this.Model = model;
            this.Flag = flag;
            ResourceHelper.Register(QTech.Base.Properties.Resources.ResourceManager);
            this.ApplyResource();
            Read();
            this.SetTheme(this.Controls, null);
            InitEvent();

        }

        public async void Read()
        {
            pnl.ClearChildren();
            var tables = await this.RunAsync(() => TableLogic.Instance.SearchAsync(new TableSearch()));
            if (tables != null)
            {
                foreach (var t in tables.Where(x => x.IsUseable))
                {
                    Table table = new Table()
                    {
                        Id = t.Id,
                        TableName = t.Name,
                        TableStatus = t.TableStus,
                        TableColor = t.TableStus == TableStatus.Free ? Color.FromArgb(158, 242, 156) : Color.FromArgb(238, 98, 98),
                        PrimaryColor = t.TableStus == TableStatus.Free ? Color.FromArgb(158, 242, 156) : Color.FromArgb(238, 98, 98),
                        TextColor = Color.Black,
                        BorderColor = Color.Gray,
                        Detail = "",
                        Width = 400,
                        Height = 300,
                        Object = t
                    };
                    table.TableClick += Table_TableClick;
                    table.DoubleClick += Table_DoubleClick;
                    pnl.AddChildren(table);

                    //Set FreeTable Label
                    if(t.TableStus == TableStatus.Free)
                    txtFreeTables.Text = txtFreeTables.Text + (!string.IsNullOrEmpty(txtFreeTables.Text) &&
                            !string.IsNullOrEmpty(t.Name) ? " , " : "") + t.Name;
                }
            }
            //SetFreeTable();
        }

        private void Table_DoubleClick(object sender, EventArgs e)
        {
            btnOrder__Click(sender, e);
        }

        int currentSelectingId;
        List<Product> products = null;
        private async void Table_TableClick(object sender, EventArgs e)
        {
            var table = sender as Table;
            ReleaseOtherTableClick();
            table.TableColor = System.Drawing.Color.FromArgb(190, 230, 253);
            table.IsClicked = true;
            table.BorderColor = Color.Blue;
            lblTable_.Text = table.TableName;
            if (Model.Id != 0 && table.Id != currentSelectingId)
            {
                var _sale = await dgv.RunAsync(() => {
                    products = ProductLogic.Instance.SearchAsync(new ProductSearch());
                    return SaleLogic.Instance.FindAsync(Model.Id);
                });
                _sale.SaleDetails.ForEach(x => {
                    var row = newRow();
                    row.Cells[colId.Name].Value = x.Id;
                    row.Cells[colName.Name].Value = products?.FirstOrDefault(y => y.Id == x.ProductId)?.Name;
                    row.Cells[colQuantity.Name].Value = x.Quantity;
                });
            }
            currentSelectingId = table.Id;
        }
        private DataGridViewRow newRow(bool isFocus = false)
        {
            var row = dgv.Rows[dgv.Rows.Add()];
            row.Cells[colId.Name].Value = 0;
            if (isFocus)
            {
                dgv.Focus();
            }
            return row;
        }
        private void ReleaseOtherTableClick()
        {
            foreach (var tb in pnl.Children)
            {
                if (tb is Table t)
                {
                    t.IsClicked = false;
                    t.TableColor = t.PrimaryColor;
                    t.BorderColor = Color.Gray;
                }
            }
        }
        public void InitEvent()
        {
            timer.Start();
            lblDate_.Text = KhmerDate.GetKhmerDate(DateTime.Now);

            pnlMainLeft.BackColor = pnlMainRight.BackColor = ShareValue.CurrentTheme.FormBackGround;
            txtFreeTables.BackColor = ShareValue.CurrentTheme.PanelColor;
            txtFreeTables.ForeColor = ShareValue.CurrentTheme.LabelColor;
            txtFreeTables.ReadOnly = true;

        }

        public void Write()
        {
        }

        public void BindAsync()
        {

        }

        public bool InValid()
        {
            return false;
        }

        public void Save()
        {
        }

        public void ViewChangeLog()
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Start();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            new frmCalculate(new Base.Models.Table(), GeneralProcess.Add).ShowDialog();
        }

        private void btnOrder__Click(object sender, EventArgs e)
        {
            var clickedTable = pnl.Children?.Cast<Table>()?.FirstOrDefault(x => x.IsClicked);
            if (clickedTable.TableStatus == TableStatus.Occupy)
            {
                if (clickedTable.Object is QTech.Base.Models.Table table)
                {
                    Model.Id = table.CurrentSaleId;
                }
            }
            if (clickedTable != null)
            {
                Model.TableId = clickedTable.Id;
                Model.SaleDate = DateTime.Now;
                var dig = new frmFoodOrder(Model,Flag,clickedTable.TableName);
                if (dig.ShowDialog() == DialogResult.OK)
                {
                    Model.SaleDetails.ForEach(x => {
                        var row = newRow();
                        row.Cells[colId.Name].Value = x.Id;
                        row.Cells[colName.Name].Value = products?.FirstOrDefault(y => y.Id == x.ProductId)?.Name;
                        row.Cells[colQuantity.Name].Value = x.Quantity;
                    });
                    Read();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.O))
            {
                btnOrder__Click(btnOrder_, EventArgs.Empty);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.T))
            {
                btnCalculate_Click(btnCalculate, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SetFreeTable()
        {
            foreach (var tb in pnl.Children)
            {
                if (tb is WpfCustomControlLibrary.Table t)
                {
                    if (t.TableStatus == TableStatus.Free) 
                    { 
                        txtFreeTables.Text = txtFreeTables.Text + (!string.IsNullOrEmpty(txtFreeTables.Text) &&
                            !string.IsNullOrEmpty(t.TableName)? " , " : "" )+ t.TableName; 
                    }
                }
            }
        }
    }
}
