using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using QTech.ReportModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;

namespace QTech.Forms
{
    public partial class frmEmployee : ExDialog, IDialog
    {
        public Employee Model { get; set; }
        private int selectedSupplierPaidId;

        public frmEmployee(Employee model, GeneralProcess flag)
        {
            InitializeComponent();

            this.Model = model;
            this.Flag = flag;

            Bind();
            InitEvent();
        }

        public GeneralProcess Flag { get; set; }

        public void Bind()
        {
            cboPosition.SetDataSource<Base.Enums.Position>();
            colName.Visible = true;
            colName.Width = 100;
            Read();
        }
        public void InitEvent()
        {
            this.MaximizeBox = false;
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.Employees);
            txtPhone.RegisterEnglishInputWith(txtPayAmount);
            txtName.RegisterPrimaryInputWith(cboPosition,txtNote,txtName, txtPayNote);
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            dgv.ReadOnly = true;
            dgv.SetColumnHeaderDefaultStyle();

            if (Flag == GeneralProcess.Add)
            {
                tabMain.Controls.Remove(tabGeneralTotal);
            }
            tabMain.SelectedIndexChanged += TabMain_SelectedIndexChanged;
            dgv.Columns[colDoDate.Name].DefaultCellStyle.Format = "dd-MMM-yyyy hh:mm";
            txtPayAmount.KeyPress += (s, e) => { txtPayAmount.validCurrency(s, e); };
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.RowCount > 0)
            {
                var selectedRow = dgv.SelectedRows;
                dtpDoDate.Value =Convert.ToDateTime(selectedRow[0].Cells[colDoDate.Name].Value.ToString());
                txtPayAmount.Text = selectedRow[0].Cells[colAmount.Name].Value.ToString();
                txtPayNote.Text = selectedRow[0].Cells[colNote.Name].Value.ToString();

                selectedSupplierPaidId= int.Parse(selectedRow[0].Cells[colId.Name].Value.ToString());
            }

            
        }

        private async void TabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.RegisterEnglishInput();
            
        }
        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text) 
                | !cboPosition.IsValidRequired(lblPosition.Text))
            {
                return true;
            }
            return false;
        }
        public void Read()
        {
            txtName.Text = Model.Name;
            txtPhone.Text = Model.Phone;
            txtNote.Text = Model.Note;
        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() => EmployeeLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
                txtName.IsExists(lblName.Text);
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return EmployeeLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return  EmployeeLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return EmployeeLogic.Instance.RemoveAsync(Model);
                }

                return null;
            });
            if (result != null)
            {
                Model = result;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        public void ViewChangeLog()
        {
            throw new NotImplementedException();
        }
        public void Write()
        {
            Model.Name = txtName.Text;
            Model.Note = txtNote.Text;
            Model.Phone = txtPhone.Text;
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Flag != GeneralProcess.Add)
            {
                var empyeeId = Model.Id;
                if (empyeeId != 0)
                {
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.P))
            {
                btnPrint.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
