﻿using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;

namespace QTech.Forms
{
    public partial class TablePage : ExPage, IPage
    {
        public TablePage()
        {
            InitializeComponent();
            btnAdd.Visible = ShareValue.IsAuthorized(AuthKey.Product_Product_Add);
            btnRemove.Visible = ShareValue.IsAuthorized(AuthKey.Product_Product_Remove);
            btnUpdate.Visible = ShareValue.IsAuthorized(AuthKey.Product_Product_Update);
            this.SetTheme(this.Controls, null);

        }

        public Table Model { get; set; }

        private void Bind()
        {
        }
        private void InitEvent()
        {
            dgv.RowTemplate.Height = 28;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            btnAdd.Visible = ShareValue.IsAuthorized(AuthKey.Setting_Table_Add);
            btnRemove.Visible = ShareValue.IsAuthorized(AuthKey.Setting_Table_Update);
            btnUpdate.Visible = ShareValue.IsAuthorized(AuthKey.Setting_Table_Remove);

            txtSearch.RegisterEnglishInput();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += txtSearch_QuickSearch;
            dgv.DataSourceChanged += Dgv_DataSourceChanged;
        }

        private void Dgv_DataSourceChanged(object sender, EventArgs e)
        {
            this.SetTheme(this.Controls, null);

        }

        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }


        public async void AddNew()
        {
            Model = new Table();
            var dig = new frmTable(Model, GeneralProcess.Add);
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

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;

            Model = await btnUpdate.RunAsync(() => TableLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmTable(Model, GeneralProcess.Update);

            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                dgv.RowSelected(colId.Name, dig.Model.Id);
            }
        }

        public async void Reload()
        {
            dgv.AllowRowNotFound = true;
            dgv.AllowRowNumber = true;
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
            var canRemove = await btnRemove.RunAsync(() => TableLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Table));
                return;
            }

            Model = await btnRemove.RunAsync(() => TableLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmTable(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }

        public async Task Search()
        {
            var search = new CustomerSearch()
            {
                Search = txtSearch.Text,
            };

            var result = await dgv.RunAsync(() => TableLogic.Instance.SearchAsync(search));
            if (result != null)
            {
                dgv.DataSource = result._ToDataTable();
            }
        }

        public async void View()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;
            Model = await btnUpdate.RunAsync(() => TableLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmTable(Model, GeneralProcess.View);
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
