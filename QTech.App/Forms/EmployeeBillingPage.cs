using QTech.Base;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Db.Logics;
using QTech.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;

namespace QTech.Forms
{
    public partial class EmployeeBillingPage : ExPage, IPage
    {
        public EmployeeBill Model { get; set; }
        public EmployeeBillingPage()
        {
            InitializeComponent();
            Bind();
            InitEvent();
        }
        private void Bind()
        {
        }            
        private void InitEvent()
        {
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(173, 205, 239);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgv.RowTemplate.Height = 28;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.SetColumnHeaderDefaultStyle();
            cboPayStatus.SetDataSource<InvoiceStatus>();
            cboPayStatus.SelectedValue = InvoiceStatus.WaitPayment;
            txtSearch.RegisterEnglishInput();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += txtSearch_QuickSearch;
            cboPayStatus.SelectedIndexChanged += CboPayStatus_SelectedIndexChanged;

            btnAdd.Visible = ShareValue.IsAuthorized(AuthKey.Employee_EmployeeBill_Add);
            btnRemove.Visible = ShareValue.IsAuthorized(AuthKey.Employee_EmployeeBill_Remove);
            btnUpdate.Visible = ShareValue.IsAuthorized(AuthKey.Employee_EmployeeBill_Update);
        }
        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }
        public async void AddNew()
        {
            Model = new EmployeeBill();
            var dig = new frmEmployeeBilling(Model, GeneralProcess.Add);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }
        public async void EditAsync()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.CurrentRow.Cells[colId.Name].Value;
            var bill = await btnRemove.RunAsync(() => EmployeeLogic.Instance.FindAsync(id));
           
            Model = await btnUpdate.RunAsync(() => EmployeeBillLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }
            else if (Model.InvoiceStatus == InvoiceStatus.Paid)
            {
                MsgBox.ShowWarning(BaseResource.MsgBillCannotEdit,
                   GeneralProcess.Update.GetTextDialog(BaseResource.Categorys));
                return;
            }

            var dig = new frmEmployeeBilling(Model, GeneralProcess.Update);

            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                dgv.RowSelected(colId.Name, dig.Model.Id);
            }
        }
        public async void Reload()
        {
            dgv.AllowRowNotFound = true;
            dgv.ColumnHeadersHeight = 28;

            await Search();
        }
        public async void Remove()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.CurrentRow.Cells[colId.Name].Value;
            var canRemove = await btnRemove.RunAsync(() => EmployeeBillLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Categorys));
                return;
            }

            Model = await btnRemove.RunAsync(() => EmployeeBillLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmEmployeeBilling(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }
        public async Task Search()
        {
            var invStatus = (InvoiceStatus)cboPayStatus.SelectedValue;
            var search = new EmployeeBillSearch()
            {
                Search = txtSearch.Text,
                Paging = pagination.Paging,
                PayStatus = invStatus
            };

            List<Customer> customers = null;
            List<Site> sites = null;
            List<Employee> employees = null;
            dgv.Rows.Clear();
            pagination.ListModel = await dgv.RunAsync(() =>
            {
                var employeeBills = EmployeeBillLogic.Instance.SearchAsync(search);
                var empIds = employeeBills.Select(x => x.EmployeeId)?.ToList();
                employees = EmployeeLogic.Instance.GetEmployeesByIds(empIds);
                var customerIds = employeeBills?.Select(x => x.CustomerId).ToList();
                var siteIds = employeeBills?.Select(x => x.SiteId).ToList();
                customers = CustomerLogic.Instance.GetCustomersById(customerIds);
                sites = SiteLogic.Instance.GetSiteByIds(customerIds);
                return employeeBills;
            });

            if (pagination.ListModel == null)
            {
                return;
            }

            List<EmployeeBill> sales = pagination.ListModel;
            sales.ForEach(x =>
            {
                var row = newRow(false);
                row.Cells[colId.Name].Value = x.Id;
                row.Cells[colBillNo_.Name].Value = x.BillNo;
                row.Cells[colDriver.Name].Value = employees?.FirstOrDefault(e => e.Id == x.EmployeeId);
                row.Cells[colDoDate_.Name].Value = x.DoDate.ToString("dd-MMM-yyyy hh:mm");
                var customer = customers?.FirstOrDefault(cus => cus.Id == x.CustomerId);
                row.Cells[colCustomer_.Name].Value = customer?.Id == null ? BaseResource.AllCustomer : customer?.Name;
                var site = sites?.FirstOrDefault(s => s.Id == x.SiteId);
                row.Cells[colSite.Name].Value = site?.Id == null ? BaseResource.All_ + BaseResource.Site : site?.Name;
                row.Cells[colTotal.Name].Value = x.Total;
                row.Cells[colPaidAmount.Name].Value = x.PaidAmount;
                row.Cells[colLeftAmount.Name].Value = x.LeftAmount;

                var cell = row.Cells[colStatus.Name];
                if (x.InvoiceStatus == InvoiceStatus.Paid)
                {
                    row.Cells[colStatus.Name].Value = BaseResource.IsPaid;
                    cell.Style.ForeColor = Color.Red;
                }
                else if (x.InvoiceStatus == InvoiceStatus.WaitPayment)
                {
                    row.Cells[colStatus.Name].Value = BaseResource.PayStatus_WaitPayment;
                    cell.Style.ForeColor = Color.Orange;
                }
                else
                {
                    row.Cells[colStatus.Name].Value = BaseResource.InvoiceStatus_PaySome;
                    cell.Style.ForeColor = Color.Green;
                }
            });
            dgv.Sort(dgv.Columns[colDoDate_.Name], ListSortDirection.Descending);

        }
        private async void CboPayStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Search();
        }
        private DataGridViewRow newRow(bool isFocus = false)
        {
            var row = dgv.Rows[dgv.Rows.Add()];
            row.Cells[colId.Name].Value = 0;
            row.Cells[colId.Name].Value = 0;
            if (isFocus)
            {
                dgv.Focus();
            }
            return row;
        }
        public async void View()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;
            Model = await btnUpdate.RunAsync(() => EmployeeBillLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmEmployeeBilling(Model, GeneralProcess.View);
            dig.ShowDialog();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditAsync();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            View();
        }
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells[colRow.Name].Value = (e.RowIndex + 1).ToString();
        }
    }
}
