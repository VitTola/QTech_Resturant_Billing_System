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

namespace QTech.Forms
{
    public partial class CustomerPage : ExPage, IPage
    {

        public CustomerPage()
        {
            InitializeComponent();
            Bind();
            InitEvent();

        }
        private bool isNodeCollapsed { get; set; } = false;
        private Customer selectedModel { get; set; } = null;
        public Customer Model { get; set; }

        private void Bind()
        {
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(14, 14);
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            imageList1.Images.Add(nameof(Properties.Resources.Customer_img), Properties.Resources.Customer_img);
            imageList1.Images.Add(nameof(Properties.Resources.Site_img), Properties.Resources.Site_img);
        }
        private void InitEvent()
        {
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(173, 205, 239);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgv.RowTemplate.Height = 25;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 25;
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

            btnAdd.Visible = ShareValue.IsAuthorized(AuthKey.Customer_Customer_Add);
            btnRemove.Visible = ShareValue.IsAuthorized(AuthKey.Customer_Customer_Remove);
            btnUpdate.Visible = ShareValue.IsAuthorized(AuthKey.Customer_Customer_Update);
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
                var search = new SiteSearch() { CustomerId = parent.Id };
                var sites = await dgv.RunAsync(() => SiteLogic.Instance.SearchAsync(search));

                if (sites.Any())
                {
                    var dummy = e.Node.Nodes.Add();
                    dummy.Visible = false;
                    AddChildNode(e.Node, sites, parent);
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

        private void RefreshAfterOperation(Customer model)
        {
            var parentNode = dgv.Rows.Cast<TreeGridNode>().FirstOrDefault(x => x.Tag is Customer cus && cus.Id == model.Id);
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
            var customer = new Customer();
            var dig = new frmCustomer(customer, GeneralProcess.Add);
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

            Model = await btnUpdate.RunAsync(() => CustomerLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmCustomer(Model, GeneralProcess.Update);

            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                selectedModel = dig.Model;
                RefreshAfterOperation(selectedModel);
            }
        }

        public async void Reload()
        {
            dgv.ColumnHeadersHeight = 28;

            await Search();
        }

        public async void Remove()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.CurrentRow.Cells[colParentId.Name].Value;
            var canRemove = await btnRemove.RunAsync(() => CustomerLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Employees));
                return;
            }

            Model = await btnRemove.RunAsync(() => CustomerLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmCustomer(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }

        public async Task Search()
        {
            dgv.Columns[colName.Name].DisplayIndex = 1;
            var search = new CustomerSearch()
            {
                Search = txtSearch.Text,
            };

            var result = await dgv.RunAsync(() => CustomerLogic.Instance.SearchAsync(search));
            if (result != null)
            {
                TreeGridFillData(result);
            }
        }

        int row = 1;
        private void TreeGridFillData(List<Customer> customers)
        {
            row = 1;
            if (customers == null)
            {
                return;
            }

            dgv.Nodes.Clear();
            foreach (var parent in customers.OrderByDescending(x => x.RowDate))
            {
                var _treeGridNode = AddParentNode(dgv, parent);

                if (parent.Sites != null && parent.Sites.Any())
                {
                    AddChildNode(_treeGridNode, parent.Sites, parent);
                    dgv.NodeExpanded -= Dgv_NodeExpanded;
                    dgv.NodeExpanded += Dgv_NodeExpanded;
                }

                var dummy = _treeGridNode.Nodes.Add();
                dummy.Visible = false;
            }
        }
        private void AddChildNode(TreeGridNode TreeGridNode, IEnumerable<Site> children, Customer parent)
        {
            foreach (var child in children)
            {
                var node = TreeGridNode.Nodes.Add();
                var font = dgv.DefaultCellStyle.Font;
                node.Height = dgv.RowTemplate.Height;
                node.Tag = child;
                node.Height = dgv.RowTemplate.Height;
                node.Image = imageList1.Images[nameof(Properties.Resources.Site_img)];
                node.Cells[dgv.Columns[colName.Name].Index].Value = child.Name;
                node.Cells[dgv.Columns[colPhone.Name].Index].Value = child.Phone;
                node.Cells[dgv.Columns[colNote.Name].Index].Value = child.Note;
                node.Cells[dgv.Columns[colId.Name].Index].Value = child.Id;
                node.Cells[dgv.Columns[colParentId.Name].Index].Value = child.CustomerId;
            }
        }

        private TreeGridNode AddParentNode(dynamic parentNode, Customer customer)
        {
            //dgv.Columns[colName.Name].DisplayIndex = 0;
            var node = parentNode.Nodes.Add();
            //dgv.Columns[colName.Name].DisplayIndex = 1;
            node.Height = dgv.RowTemplate.Height;
            node.Tag = customer;

            node.Image = imageList1.Images[nameof(Properties.Resources.Customer_img)];
            node.Cells[dgv.Columns[colName.Name].Index].Value = customer?.Name;
            node.Cells[dgv.Columns[colPhone.Name].Index].Value = customer?.Phone;
            node.Cells[dgv.Columns[colNote.Name].Index].Value = customer.Note;
            node.Cells[dgv.Columns[colId.Name].Index].Value = customer.Id;
            node.Cells[dgv.Columns[colParentId.Name].Index].Value = customer.Id;
            node.Cells[dgv.Columns[colRow.Name].Index].Value = row++;
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
            Model = await btnUpdate.RunAsync(() => CustomerLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmCustomer(Model, GeneralProcess.View);
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
