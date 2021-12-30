using EasyServer.Domain.Helpers;
using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Component.MyComponents;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfCustomControlLibrary;

namespace QTech.Forms
{
    public partial class frmFoodOrder : ExDialog, IDialog
    {
        public Sale Model { get; set; }
        public string TableName { get; set; }
        public frmFoodOrder(Sale model, GeneralProcess flag, string tableName)
        {
            InitializeComponent();
            this.TableName = tableName;
            this.Model = model;
            this.Flag = flag;

            Read();
            BindAsync();
            InitEvent();
            this.SetTheme(this.Controls, null);

        }
        public GeneralProcess Flag { get; set; }

        public void BindAsync()
        {
            lblTableName_.Text = TableName;
        }
        public void InitEvent()
        {
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            this.MaximizeBox = false;
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.FoodOrder);

            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            this.MaximizeBox = true;
            btnSave.Click += BtnSave_Click;
            cboCategory.SelectedIndexChanged += CboCategory_SelectedIndexChanged;
            this.Load += FrmFoodOrder_Load;
            tabMain.SelectedIndexChanged += TabMain_SelectedIndexChanged;
        }

        private async void TabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab.Equals(tabOrdered_))
            {
                Sale sale = null;
                var products = new List<Product>();
                var _products = new List<wpfChooseFoodControl>();
                var ordered = await this.RunAsync(()=>{
                    sale = SaleLogic.Instance.FindAsync(Model.Id);
                    products = ProductLogic.Instance.SearchAsync(new ProductSearch());
                    return sale;
                });
                if (sale != null)
                {
                    sale.SaleDetails.GroupBy(x => x.Id).Select(y => y.First()).ToList().ForEach(x =>
                    {
                        var p = new wpfChooseFoodControl
                        {
                            Id = x.ProductId,
                            Width = 300,
                            Height = 315,
                            FoodName = products?.FirstOrDefault(y=>y.Id == x.ProductId)?.Name ?? "",
                            ImageSource = products?.FirstOrDefault(y => y.Id == x.ProductId)?.Photo,
                            OrderQuantity = x.Quantity,
                            TextColor = ShareValue.CurrentTheme.LabelColor,
                        };
                        p.QuantityChange += P_QuantityChange;
                        _products.Add(p);
                    });
                    if (_products.Any())
                    {
                        flpOrdered.ClearChildren();
                        flpOrdered.AddFoodPanel(_products);
                    }
                }
                else
                {
                    await Search();
                }
            }
        }

        private void P_QuantityChange(object sender, EventArgs e)
        {
            
        }

        private async void FrmFoodOrder_Load(object sender, EventArgs e)
        {
            colName.Visible = true;
            colName.Width = 100;

            List<Category> categories = null;
            await this.RunAsync(() => categories = CategoryLogic.Instance.SearchAsync(new CategorySearch()));
            if (categories?.Any() ?? false)
            {
                var objects = categories.Select(x => new
                {
                    Name = x.Name,
                    Id = x.Id,
                    Object = x
                }).ToList();

                var _allCategory = $"{QTech.Base.Properties.Resources.Category}{QTech.Base.Properties.Resources.All_}";
                objects.Add(
                    new
                    {
                        Name = _allCategory,
                        Id = 0,
                        Object = new Category()
                    }
                    );
                cboCategory.ValueMember = "Id";
                cboCategory.DisplayMember = "Name";
                cboCategory.DataSource = objects;
                cboCategory.SelectedIndex = cboCategory.FindStringExact(_allCategory);
            }
            await Search();
        }

        private async void CboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Search();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.RegisterEnglishInput();

        }
        public void Read()
        {
            //await Search();
        }
        private async Task Search()
        {
            flp.ClearChildren();
            int catId = Parse.ToInt(cboCategory?.SelectedValue?.ToString() ?? "0");
            var search = new ProductSearch
            {
                Search = txtSearch.Text,
                categoryId = catId
            };
            var result = await this.RunAsync(() =>
            {
                var products = ProductLogic.Instance.SearchAsync(search);

                return products;
            });


            var _products = new List<wpfChooseFoodControl>();
            result.GroupBy(x=>x.Id).Select(y=>y.First()).ToList().ForEach(x =>
            {
                var p = new wpfChooseFoodControl
                {
                    Id = x.Id,
                    Width = 300,
                    Height = 315,
                    FoodName = x.Name,
                    ImageSource = x.Photo,
                    TextColor = ShareValue.CurrentTheme.LabelColor,
                };
                p.QuantityChange += P_QuantityChange;
                _products.Add(p);
            });
            if (_products.Any())
            {
                flp.AddFoodPanel(_products);
            }
        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            Write();
            if (InValid()) { return; }

            var isExist = await btnSave.RunAsync(() => SaleLogic.Instance.IsExistsAsync(Model));
            if (isExist)
            {
                Flag = GeneralProcess.Update;
            }
            else
            {
                Flag = GeneralProcess.Add;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return SaleLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return SaleLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return SaleLogic.Instance.RemoveAsync(Model);
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
            foreach (var b in flp.Children)
            {
                if (b is wpfChooseFoodControl wp)
                {
                    var _saleDetail = new SaleDetail() { 
                       SaleId = Model.Id,
                       ProductId = wp.Id,
                       Quantity = wp.OrderQuantity,
                       UnitPrice = wp.UnitPrice,
                       Total = wp.OrderQuantity * wp.UnitPrice, 
                    };
                    Model.Total = Model.Total + _saleDetail.Total;
                    Model.SaleDetails.Add(_saleDetail);
                }
            }
            Model.PayStatus = Base.Enums.PayStatus.NotYetPaid;
            Model.EmployeeId = ShareValue.User.Id;
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
            if (!Model.SaleDetails.Any())
            {
                MsgBox.ShowWarning("សូមធ្វើការកម្មង់ម្ហូប មុននឹងធ្វើការរក្សារទុក!","មិនទាន់កម្មង់");
                return true;
            }
            return false;
        }
        private void btnShowImage_Click(object sender, EventArgs e)
        {
            foreach (var b in flp.Children)
            {
                if (b is wpfChooseFoodControl wp)
                {
                    wp.HidePicture = !wp.HidePicture;
                }
            }
        }
        private void btnShowImage_MouseHover(object sender, EventArgs e)
        {
            btnShowImage.BackColor = Color.LightBlue;

        }
        private void btnShowImage_MouseLeave(object sender, EventArgs e)
        {
            btnShowImage.BackColor = ShareValue.CurrentTheme.PanelColor;
        }
        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }

    }
}
