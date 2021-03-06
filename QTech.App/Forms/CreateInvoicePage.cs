using QTech.Base;
using QTech.Component;
using QTech.Db.Logics;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;
using QTech.Base.Helpers;
using QTech.Base.SearchModels;
using System.Collections.Generic;
using System.Drawing;
using QTech.Base.Enums;
using QTech.Base.BaseModels;
using System.ComponentModel;

namespace QTech.Forms
{
    public partial class CreateInvoicePage : ExPage, IPage
    {
        public CreateInvoicePage()
        {
            InitializeComponent();
            Bind();
            InitEvent();
            registerSearchMenu();
        }
        private bool isNodeCollapsed { get; set; } = false;
        private Invoice selectedModel { get; set; } = null;
        public Invoice Model { get; set; }
        public List<Customer> Customers { get; set; }
        private void Bind()
        {
            cboCustomer.DataSourceFn = p => CustomerLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            cboCustomer.SearchParamFn = () => new CustomerSearch();
            cboCustomer.TextAll = BaseResource.Customer;
            cboStatus.SetDataSource<InvoiceStatus>();

            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(14, 14);
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            imageList1.Images.Add(nameof(QTech.Base.Properties.Resources.InvoiceNo_img), QTech.Base.Properties.Resources.InvoiceNo_img);
            imageList1.Images.Add(nameof(QTech.Base.Properties.Resources.Sale_img), QTech.Base.Properties.Resources.Sale_img);
        }
        private void InitEvent()
        {
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(173, 205, 239);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgv.RowTemplate.Height = 25;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.ShowLines = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.SetColumnHeaderDefaultStyle();

            dgv.KeyDown += dgv_KeyDown;
            dgv.NodeExpanded += Dgv_NodeExpanded;
            dgv.NodeCollapsed += Dgv_NodeCollapsed;
            txtSearch.RegisterEnglishInput();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += txtSearch_QuickSearch;
            cboStatus.SelectedIndexChanged += CboStatus_SelectedIndexChanged;
            cboCustomer.SelectedIndexChanged += CboCustomer_SelectedIndexChanged;

            btnAdd.Visible = ShareValue.IsAuthorized(AuthKey.Sale_CreateInvoice_Add);
            btnRemove.Visible = ShareValue.IsAuthorized(AuthKey.Sale_CreateInvoice_Remove);
            btnUpdate.Visible = ShareValue.IsAuthorized(AuthKey.Sale_CreateInvoice_Update);
        }

        private async void CboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Search();
        }
        private async void CboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Search();
        }
        private void registerSearchMenu()
        {
            txtSearch.AddMenuPattern(
             SaleSearchKey.InvoiceNo.ToString(),
             SaleSearchKey.InvoiceNo,
             BaseResource.InvoiceNo_img,
             BaseResource.InvoiceNo,
             Constants.KeyShortcut[SaleSearchKey.InvoiceNo],
             (s, e) =>
             {
                 InputLanguage.CurrentInputLanguage = UI.English;
                 txtSearch.ReadOnly = false;
             });
            InputLanguage.CurrentInputLanguage = UI.English;
            txtSearch.ShowMenuPattern(SaleSearchKey.PurchaseOrderNo);
            // changeDataVisible();
        }
        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }
        private void Dgv_NodeCollapsed(object sender, CollapsedEventArgs e)
        {
            if (sender is TreeGridNode treeGrid)
            {

            }
            isNodeCollapsed = true;
        }
        private async void Dgv_NodeExpanded(object sender, ExpandedEventArgs e)
        {
            if (e.Node.Tag is Customer parent)
            {
                //In case top level node is expanded manually
                if (parent.Id == int.Parse(BaseResource.TopLevelNodeId))
                {
                    return;
                }

                e.Node.Nodes.Clear();
                var search = new SiteSearch() {
                    Paging = pagination.Paging,
                    CustomerId = parent.Id
                };
                var sites = await dgv.RunAsync(() => SiteLogic.Instance.SearchAsync(search));

                if (sites.Any())
                {
                    var dummy = e.Node.Nodes.Add();
                    dummy.Visible = false;
                    //AddChildNode(e.Node, sites, parent);
                    return;
                }
            }
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                dgv.CurrentNode?.Expand();
            }
            else if (e.KeyCode == Keys.Left)
            {
                dgv.CurrentNode?.Collapse();
            }
        }
        private void RefreshAfterOperation(Invoice model)
        {
            var parentNode = dgv.Rows.Cast<TreeGridNode>().FirstOrDefault(x => x.Tag is Invoice inv && inv.Id == model.Id);
            if (parentNode != null)
            {
                parentNode.Selected = true;
                if (parentNode.IsExpanded)
                {
                    parentNode.Collapse();
                }
                parentNode.Expand();
            }
        }
        public async void AddNew()
        {
            var customer = new Invoice();
            var dig = new frmCreateInvoice(customer, GeneralProcess.Add);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                selectedModel = dig.Model;
                RefreshAfterOperation(selectedModel);
            }
        }
        public async void EditAsync()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colParentId.Name].Value;
            Model = await btnRemove.RunAsync(() => InvoiceLogic.Instance.FindAsync(id));
            if (Model.InvoiceStatus == InvoiceStatus.Paid)
            {
                MsgBox.ShowWarning(BaseResource.MsgInvoiceAlreadyPaidCannotEdit,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Invoice));
                return;
            }
            Model = await btnUpdate.RunAsync(() => InvoiceLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmCreateInvoice(Model, GeneralProcess.Update);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                selectedModel = dig.Model;
                RefreshAfterOperation(selectedModel);
            }
        }
        public async void Reload()
        {
            await Search();
        }
        public async void Remove()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colParentId.Name].Value;
            Model = await btnRemove.RunAsync(() => InvoiceLogic.Instance.FindAsync(id));
            var canRemove = await btnRemove.RunAsync(() => InvoiceLogic.Instance.CanRemoveAsync(Model));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(BaseResource.MsgInvoiceAlreadyPaid,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Invoice));
                return;
            }

            Model = await btnRemove.RunAsync(() => InvoiceLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmCreateInvoice(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }
        public async Task Search()
        {
            dgv.Columns[colInvoiceNo.Name].DisplayIndex = 1;
            var _selectdCus = cboCustomer?.SelectedObject?.ItemObject as Customer;
            var search = new InvoiceSearch();
            if (_selectdCus != null)
            {
                search.CustomerId = _selectdCus.Id;
            }
            if (cboStatus.SelectedValue != null)
            {
                search.InvoiceStatus = (InvoiceStatus)cboStatus.SelectedValue;
            }
            search.Search = txtSearch.Text;
            search.Paging = pagination.Paging;
        
            pagination.ListModel = await dgv.RunAsync(() =>
            {
               var allInvoices =  InvoiceLogic.Instance.SearchAsync(search);
                if (allInvoices.Any())
                {
                    var customerIds = allInvoices.Select(x => x.CustomerId).ToList();
                    Customers = CustomerLogic.Instance.GetCustomersById(customerIds);
                }

                return allInvoices;
            });

            if (pagination.ListModel != null)
            {
                List<Invoice> invoices = pagination.ListModel;
                TreeGridFillData(invoices);
            }
            

            if (dgv.RowCount > 0) dgv.Rows[0].Selected = true;

        }

        int row = 1;
        private void TreeGridFillData(List<Invoice> invoices)
        {
            row = 1;
            if (invoices == null)
            {
                return;
            }

            dgv.Nodes.Clear();
            foreach (var parent in invoices.OrderByDescending(x=>x.RowDate))
            {
                var _treeGridNode = AddParentNode(dgv, parent);

                if (parent.InvoiceDetails.Any())
                {
                    AddChildNode(_treeGridNode, parent.InvoiceDetails, parent);
                    dgv.NodeExpanded -= Dgv_NodeExpanded;
                    dgv.NodeExpanded += Dgv_NodeExpanded;
                }

                var dummy = _treeGridNode.Nodes.Add();
                dummy.Visible = false;
            }
        }
        private async void AddChildNode(TreeGridNode TreeGridNode, IEnumerable<InvoiceDetail> children, Invoice parent)
        {
            var saleIds = children.Select(x=>x.SaleId).ToList();
            var sales = await dgv.RunAsync(()=> {
                var result = SaleLogic.Instance.GetSaleByIds(saleIds);
                return result;
            });
            foreach (var sale in sales)
            {
                var node = TreeGridNode.Nodes.Add();
                var font = dgv.DefaultCellStyle.Font;
                node.Height = dgv.RowTemplate.Height;
                node.Tag = sale;

                node.Height = dgv.RowTemplate.Height;
                node.Image = imageList1.Images[nameof(QTech.Base.Properties.Resources.Sale_img)];
                node.Cells[dgv.Columns[colId.Name].Index].Value = sale.Id;
                node.Cells[dgv.Columns[colParentId.Name].Index].Value = parent.Id;
                node.Cells[dgv.Columns[colInvoiceNo.Name].Index].Value = sale.InvoiceNo;
                node.Cells[dgv.Columns[colInvoicingDate.Name].Index].Value = sale.SaleDate.ToString("dd-MMM-yyyy hh:mm");
                var customerName = parent.SaleType == SaleType.General ? parent.CustomerName : Customers.FirstOrDefault(x => x.Id == parent.CustomerId)?.Name;
                node.Cells[dgv.Columns[colCustomer.Name].Index].Value = customerName;
                node.Cells[dgv.Columns[colTotalAmount.Name].Index].Value = sale.Total;
            }
            TreeGridNode.Collapse();
        }

        private TreeGridNode AddParentNode(dynamic parentNode, Invoice invoice)
        {
            //dgv.Columns[colInvoiceNo.Name].DisplayIndex = 0;
            var node = parentNode.Nodes.Add();
            //dgv.Columns[colInvoiceNo.Name].DisplayIndex = 1;
            node.Height = dgv.RowTemplate.Height;
            node.Tag = invoice;

            node.Image = imageList1.Images[nameof(QTech.Base.Properties.Resources.InvoiceNo_img)];
            node.Cells[dgv.Columns[colId.Name].Index].Value = invoice.Id;
            node.Cells[dgv.Columns[colRow_.Name].Index].Value = row++;
            node.Cells[dgv.Columns[colParentId.Name].Index].Value = invoice.Id;
            node.Cells[dgv.Columns[colInvoiceNo.Name].Index].Value = invoice.InvoiceNo;
            node.Cells[dgv.Columns[colInvoicingDate.Name].Index].Value = invoice.InvoicingDate.ToString("dd-MMM-yyyy hh:mm");
            var customerName = invoice.SaleType == SaleType.General ? invoice.CustomerName : Customers.FirstOrDefault(x => x.Id == invoice.CustomerId)?.Name;
            node.Cells[dgv.Columns[colCustomer.Name].Index].Value =customerName;
            node.Cells[dgv.Columns[colTotalAmount.Name].Index].Value = invoice.TotalAmount;
            node.Cells[dgv.Columns[colPaidAmount.Name].Index].Value = invoice.PaidAmount;
            node.Cells[dgv.Columns[colLeftAmount.Name].Index].Value = invoice.LeftAmount;
            node.Cells[dgv.Columns[colRowDate.Name].Index].Value = invoice.RowDate;

            if (invoice.InvoiceStatus == InvoiceStatus.Paid)
            {
                node.Cells[dgv.Columns[colStatus.Name].Index].Value = BaseResource.InvoiceStatus_Paid;
                node.Cells[dgv.Columns[colStatus.Name].Index].Style.ForeColor = Color.Red;
            }
            else if (invoice.InvoiceStatus == InvoiceStatus.PaySome)
            {
                node.Cells[dgv.Columns[colStatus.Name].Index].Value = BaseResource.InvoiceStatus_PaySome;
                node.Cells[dgv.Columns[colStatus.Name].Index].Style.ForeColor = Color.Violet;
            }
            else if (invoice.InvoiceStatus == InvoiceStatus.WaitPayment)
            {
                node.Cells[dgv.Columns[colStatus.Name].Index].Value = BaseResource.InvoiceStatus_WaitPayment;
                node.Cells[dgv.Columns[colStatus.Name].Index].Style.ForeColor = Color.Orange;
            }

            var dummy = node.Nodes.Add();
            dummy.Visible = false;
            return node;
        }
        public async void View()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colParentId.Name].Value;
            Model = await btnUpdate.RunAsync(() => InvoiceLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmCreateInvoice(Model, GeneralProcess.View);
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
       
    }
}
