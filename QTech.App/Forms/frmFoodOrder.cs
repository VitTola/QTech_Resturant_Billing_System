using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Component.MyComponents;
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
    public partial class frmFoodOrder : ExDialog, IDialog
    {
        public Table Model { get; set; }

        public frmFoodOrder(Table model, GeneralProcess flag)
        {
            InitializeComponent();

            this.Model = model;
            this.Flag = flag;

            Bind();
            InitEvent();
            this.SetTheme(this.Controls, null);

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

            chooseFoodPanel1.TextBoxBackColor = ShareValue.CurrentTheme.FormBackGround;
            chooseFoodPanel1.OrderQuantity = 2;
            chooseFoodPanel1.FoodName = "ឆាខ្ញីសាច់មាន់លាយសាច់ទា";
            chooseFoodPanel1.Height = 260;
            chooseFoodPanel1.Width = 219;
            chooseFoodPanel1.ImagePath = @"C:\Users\vitto\Downloads\DOG (2).jpg";
            btnSave.Click += BtnSave_Click;



        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            chooseFoodPanel1.HideImage = !chooseFoodPanel1.HideImage;
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.RegisterEnglishInput();
            
        }
   
        public void Read()
        {
            for (int i = 0; i < 20; i++)
            {
                //var p = new List<ChooseFoodPanel>() {
                //    {new ChooseFoodPanel() }
                
                //};
                //flp.AddFoodPanel(p);
            }
            
        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

           

            var isExist = await btnSave.RunAsync(() => TableLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
              
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

        public bool InValid()
        {
            throw new NotImplementedException();
        }
    }
}
