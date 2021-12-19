using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db;
using QTech.Db.Logics;
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
    public partial class frmCustomer : ExDialog, IDialog
    {
        public Customer Model = new Customer();

        public frmCustomer(Customer model, GeneralProcess flage)
        {
            InitializeComponent();
            this.Model = model;
            this.Flag = flage;

            Bind();
            InitEvent();
            this.SetTheme(this.Controls, null);

        }
        public GeneralProcess Flag { get; set; }
        public void Bind()
        {
            Read();
        }
        public void InitEvent()
        {
            this.MaximizeBox = false;
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.Customer);
            txtPhone.RegisterEnglishInput();
            txtNote.RegisterPrimaryInput();

            tabMain.SelectedIndexChanged += TabMain_SelectedIndexChanged;
            dgvGoods.EditingControlShowing += DgvGoods_EditingControlShowing;
            dgvGoods.RegisterEnglishInputColumns(colSalePrice);
            dgvGoods.ReadOnly = false;
            dgvGoods.AllowRowNotFound = false;
            colGoodName.ReadOnly = true;
            colCategory_.ReadOnly = true;
            dgvGoods.EditMode = DataGridViewEditMode.EditOnEnter;
            if (Flag == GeneralProcess.Add)
            {
                tabMain.Controls.Remove(tabSetPrice);
            }
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            dgvGoods.EditColumnIcon(colGoodName,colSalePrice);


        }
        private void DgvGoods_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvGoods.CurrentCell.ColumnIndex == colSalePrice.Index)
            {
                if (e.Control is TextBox txt)
                {
                    txt.KeyPress += (o, ee) => { txt.validCurrency(sender, ee); };
                }
            }
        }
        private async void TabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private DataGridViewRow _newRow(bool isFocus = false)
        {
            var row = dgvGoods.Rows[dgvGoods.Rows.Add()];
            row.Cells[colProductId.Name].Value = 0;
            if (isFocus)
            {
                dgvGoods.Focus();
            }
            return row;
        }
        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text) | !txtPhone.IsValidRequired(lblPhone.Text)
                | !txtPhone.IsValidPhone())
            {
                return false;
            }
            return true;
        }
      
        public async void Read()
        {
            txtName.Text = Model.Name;
            txtPhone.Text = Model.Phone;
            txtNote.Text = Model.Note;
           
        }
        public void ViewChangeLog()
        {
            AuditTrailDialog.ShowChangeLog(Model);
        }
        public void Write()
        {
            if (!InValid())
            {
                return;
            }
            
            Model.Active = true;
            Model.Name = txtName.Text;
            Model.Phone = txtPhone.Text;
            Model.Note = txtNote.Text;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (!InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() => CustomerLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
                txtName.IsExists(lblName.Text);
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return CustomerLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return CustomerLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return CustomerLogic.Instance.RemoveAsync(Model);
                }

                return null;
            });
            if (result != null)
            {
                Model = result;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
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
    }
}
