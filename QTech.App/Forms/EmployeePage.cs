using QTech.Base;
using QTech.Component;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTech.Base.Helpers;
using QTech.Base.SearchModels;
using QTech.Db.Logics;
using QTech.Db;
using BaseResource = QTech.Base.Properties.Resources;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
using System.Collections.Generic;

namespace QTech.Forms
{
    public partial class EmployeePage : ExPage, IPage
    {
        public Employee Model { get; set; }
        public EmployeePage()
        {
            InitializeComponent();
            txtSearch.RegisterPrimaryInput();
            
            btnAdd.Visible = ShareValue.IsAuthorized(AuthKey.Employee_Employee_Add);
            btnRemove.Visible = ShareValue.IsAuthorized(AuthKey.Employee_Employee_Remove);
            btnUpdate.Visible = ShareValue.IsAuthorized(AuthKey.Employee_Employee_Update);
            this.SetTheme(this.Controls, null);

        }

        public async void AddNew()
        {
            var employee = new Employee();
            var dig = new frmEmployee(employee, GeneralProcess.Add);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                dgv.RowSelected(colId.Name, dig.Model.Id);
            }
        }

        public async void EditAsync()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;

            Model = await btnUpdate.RunAsync(() => EmployeeLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmEmployee(Model, GeneralProcess.Update);

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

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;
            var canRemove = await btnRemove.RunAsync(() => EmployeeLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Employee));
                return;
            }

            Model = await btnRemove.RunAsync(() => EmployeeLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmEmployee(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }

        public async Task Search()
        {
            var search = new EmployeeSearch()
            {
                Search = txtSearch.Text,
            };

            List<Base.Position> positions = null;
            var result = await dgv.RunAsync(() => 
            {
              var res =  EmployeeLogic.Instance.SearchAsync(search);
                positions = PositionLogic.Instance.SearchAsync(new PositionSearch());

                return res;
            });
            if (result?.Any() ?? false)
            {
                dgv.Rows.Clear();
                foreach (var e in result.OrderByDescending(x => x.RowDate))
                {
                    var row = _newRow(false);
                    row.Cells[colId.Name].Value = e.Id;
                    row.Cells[colName.Name].Value = e.Name;
                    row.Cells[colPosition.Name].Value = positions.FirstOrDefault(x=>x.Id == e.PositionId)?.Name ?? string.Empty;
                    row.Cells[colPhone.Name].Value = e.Phone;
                    row.Cells[colNote.Name].Value = e.Note;
                }
            }
        }
        private DataGridViewRow _newRow(bool isFocus = false)
        {
            var row = dgv.Rows[dgv.Rows.Add()];
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

            Model = await btnUpdate.RunAsync(() => EmployeeLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmEmployee(Model, GeneralProcess.View);
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

        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells[colRow_.Name].Value = (e.RowIndex + 1).ToString();

        }
    }
}
