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
            this.SetTheme(this.Controls, null);

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
            dgv.AllowUserToResizeColumns = false;

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
            //var customer = new Customer();
            //var dig = new frmCustomer(customer, GeneralProcess.Add);
            //if (dig.ShowDialog() == DialogResult.OK)
            //{
            //    await Search();
            //    selectedModel = dig.Model;
            //    RefreshAfterOperation(selectedModel);
            //}
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

            //var dig = new frmCustomer(Model, GeneralProcess.Update);

            //if (dig.ShowDialog() == DialogResult.OK)
            //{
            //    await Search();
            //    selectedModel = dig.Model;
            //    RefreshAfterOperation(selectedModel);
            //}
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
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Employee));
                return;
            }

            Model = await btnRemove.RunAsync(() => CustomerLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            //var dig = new frmCustomer(Model, GeneralProcess.Remove);
            //if (dig.ShowDialog() == DialogResult.OK)
            //{
            //    await Search();
            //}
        }

        public async Task Search()
        {
            //dgv.Columns[colName.Name].DisplayIndex = 1;
            //var search = new CustomerSearch()
            //{
            //    Search = txtSearch.Text,
            //};

            //var result = await dgv.RunAsync(() => CustomerLogic.Instance.SearchAsync(search));
            //if (result != null)
            //{
            //}
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

            //var dig = new frmCustomer(Model, GeneralProcess.View);
            //dig.ShowDialog();
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
