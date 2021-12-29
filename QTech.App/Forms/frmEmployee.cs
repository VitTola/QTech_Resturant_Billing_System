using EasyServer.Domain.Helpers;
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

        public frmEmployee(Employee model, GeneralProcess flag)
        {
            InitializeComponent();

            this.Model = model;
            this.Flag = flag;

            BindAsync();
            InitEvent();
            this.SetTheme(this.Controls, null);
        }

        public GeneralProcess Flag { get; set; }

        public void BindAsync()
        {
            Read();

            cboPosition.DataSourceFn = p => PositionLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            cboPosition.SearchParamFn = () => new PositionSearch();
        }
        public void InitEvent()
        {
            this.MaximizeBox = false;
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.Employee);
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
        }

        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text) 
                | !cboPosition.IsSelected())
            {
                return true;
            }
            return false;
        }
        public async void Read()
        {
            txtName.Text = Model.Name;
            txtPhone.Text = Model.Phone;
            txtNote.Text = Model.Note;
            var position = await this.RunAsync(() => PositionLogic.Instance.FindAsync(Model.PositionId));
            if (position != null)
            {
                cboPosition.SetValue(position);
            }
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
            AuditTrailDialog.ShowChangeLog(Model);
        }
        public void Write()
        {
            Model.Name = txtName.Text;
            Model.Note = txtNote.Text;
            Model.Phone = txtPhone.Text;
            var posId = Parse.ToInt(cboPosition.SelectedValue.ToString());
            Model.PositionId = posId;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.E))
            {
                btnChangeLog.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnChangeLog_Click(object sender, EventArgs e)
        {
            ViewChangeLog();
        }

        private void cboPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
