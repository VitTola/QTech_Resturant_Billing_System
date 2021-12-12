﻿using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Component;
using QTech.Component.Helpers;
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

namespace QTech.Forms
{
    public partial class frmTable : ExDialog, IDialog
    {
        public Table Model { get; set; }

        public frmTable(Table model, GeneralProcess flag)
        {
            InitializeComponent();

            this.Model = model;
            this.Flag = flag;

            Bind();
            InitEvent();
            this.QTechResturantDefaultStyle(this.Controls);
        }
        public GeneralProcess Flag { get; set; }

        public void Bind()
        {
            colName.Visible = true;
            colName.Width = 100;

            Read();
        }
        public void InitEvent()
        {
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            this.MaximizeBox = false;
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.Table);
            txtNote.RegisterPrimaryInput();

        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.RegisterEnglishInput();
            
        }
        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text) 
              )
            {
                return true;
            }
            return false;
        }
        public void Read()
        {
            txtName.Text = Model.Name;
            txtNote.Text = Model.Note;
            chkUseable_.Checked = Model.IsUseable;
        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() => TableLogic.Instance.IsExistsAsync(Model));
            if (isExist == null) { return; }
            if (isExist == true)
            {
                txtName.IsExists(lblName.Text);
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return TableLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return TableLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return TableLogic.Instance.RemoveAsync(Model);
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
            new AuditTrailDialog().ShowDialog();
        }
        public void Write()
        {
            Model.Name = txtName.Text;
            Model.Note = txtNote.Text;
            Model.IsUseable = chkUseable_.Checked;
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeLog_Click(object sender, EventArgs e)
        {
            ViewChangeLog();
        }
    }
}
