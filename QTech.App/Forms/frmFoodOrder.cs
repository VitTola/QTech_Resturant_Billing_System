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
        public List<Product> Products { get; set; }
        public List<ProductPrice> productPrices { get; set; }
        public List<Scale> scales { get; set; }
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

        public async void BindAsync()
        {
            lblTableName_.Text = TableName;

            Products = await this.RunAsync(() =>
            {
                var products = ProductLogic.Instance.SearchAsync(new ProductSearch());
                productPrices = ProductPriceLogic.Instance.SearchAsync(new ProductPriceSearch());
                scales = ScaleLogic.Instance.SearchAsync(new ScaleSearch());

                return products;
            });
            if (Model.SaleDetails == null)
            {
                Model.SaleDetails = new List<SaleDetail>();
            }
        }
        public void InitEvent()
        {
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            this.MaximizeBox = false;
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.FoodOrder);

            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            this.MaximizeBox = true;
            WindowState = FormWindowState.Maximized;
            btnSave.Click += BtnSave_Click;
            cboCategory.SelectedIndexChanged += CboCategory_SelectedIndexChanged;
            this.Load += FrmFoodOrder_Load;
            tabMain.SelectedIndexChanged += TabMain_SelectedIndexChanged;
        }

        private void TabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab.Equals(tabOrdered_))
            {
                var _products = new List<wpfChooseFoodControl>();

                Model.SaleDetails.ForEach(x =>
                {
                    var p = new wpfChooseFoodControl
                    {
                        Id = x.ProductId,
                        Width = 300,
                        Height = 340,
                        FoodName = Products?.FirstOrDefault(y => y.Id == x.ProductId)?.Name ?? "",
                        ImageSource = Products?.FirstOrDefault(y => y.Id == x.ProductId)?.Photo,
                        OrderQuantity = x.Quantity,
                        UnitPrice = x.UnitPrice,
                        Scale = scales.FirstOrDefault(y => y.Id == x.ScaleId),
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
                Search();
            }
        }

        private void P_QuantityChange(object sender, EventArgs e)
        {
            var currentProduct = sender as wpfChooseFoodControl;
            var saleDetail = Model.SaleDetails.FirstOrDefault(x => x.ProductId == currentProduct?.Id);
            if (saleDetail != null)
            {
                Model.SaleDetails[Model.SaleDetails.IndexOf(saleDetail)].Quantity = currentProduct.OrderQuantity;
                Model.SaleDetails[Model.SaleDetails.IndexOf(saleDetail)].Total = currentProduct.OrderQuantity * currentProduct.UnitPrice;
            }
            else
            {   
                var _saleDetail = new SaleDetail()
                {
                    SaleId = Model.Id,
                    ProductId = currentProduct.Id,
                    Quantity = currentProduct.OrderQuantity,
                    UnitPrice = currentProduct.UnitPrice,
                    ScaleId = currentProduct.Scale?.Id ?? 0,
                    Total = currentProduct.OrderQuantity * currentProduct.UnitPrice,
                };
                Model.Total = Model.Total + _saleDetail.Total;
                Model.SaleDetails.Add(_saleDetail);
            }
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
            //await Search();
        }

        private  void CboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
             Search();
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
        private void Search()
        {
            flp.ClearChildren();
            int catId = Parse.ToInt(cboCategory?.SelectedValue?.ToString() ?? "0");

            var filteredProducts = Products.Where(x =>
            (catId == 0 ? true : x.CategoryId == catId) &&
            (string.IsNullOrEmpty(txtSearch.Text) ? true : x.Name.ToLower().Contains(txtSearch.Text.ToLower()))
            ).ToList();
            var _productPrices = productPrices?.Where(x => filteredProducts.Any(y => y.Id == x.ProductId))?.ToList() ?? new List<ProductPrice>();
            var _products = new List<wpfChooseFoodControl>();
            _productPrices?.ForEach(x =>
                {
                    int Qty = Model?.SaleDetails?.FirstOrDefault(y => y.ProductId == x.ProductId && y.ScaleId == x.ScaleId)?.Quantity ?? 0;
                 
                    var p = new wpfChooseFoodControl
                    {
                        SaleDetailId = Model?.SaleDetails.FirstOrDefault(y => y.ProductId == x.Id)?.Id ?? 0,
                        Id = x.ProductId,
                        Width = 300,
                        Height = 340,
                        FoodName = Products.FirstOrDefault(z=>z.Id == x.ProductId)?.Name ?? "",
                        ImageSource = Products.FirstOrDefault(z => z.Id == x.ProductId)?.Photo,
                        TextColor = ShareValue.CurrentTheme.LabelColor,
                        Scale = scales.FirstOrDefault(y=>y.Id == x.ScaleId),
                        OrderQuantity = Qty,
                        UnitPrice = x.SalePrice
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
            Model.SaleDetails.ForEach(x => {
                if (x.Quantity == 0)
                {
                    if (x.Id == 0)
                    {
                        Model.SaleDetails.Remove(x);
                    }
                    else
                    {
                        Model.SaleDetails[Model.SaleDetails.IndexOf(x)].Active = false;
                    }
                }
            
            });

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
                MsgBox.ShowWarning("សូមធ្វើការកម្មង់ម្ហូប មុននឹងធ្វើការរក្សារទុក!", "មិនទាន់កម្មង់");
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
        private  void txtSearch_QuickSearch(object sender, EventArgs e)
        {
             Search();
        }

    }
}
