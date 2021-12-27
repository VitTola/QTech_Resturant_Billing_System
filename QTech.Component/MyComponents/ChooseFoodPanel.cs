using EasyServer.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component.MyComponents
{
    public partial class ChooseFoodPanel : UserControl
    {
        public event EventHandler IncreaseQuantityClick;
        public event EventHandler DecreaseQuantityClick;
        public ChooseFoodPanel()
        {
            InitializeComponent();
        }

        private int _quantity;
        private string _foodName;
        private bool _isHideImage;
        public bool HideImage
        {
            get { return _isHideImage; }
            set {
                if (value)
                {
                    pic.Visibility = System.Windows.Visibility.Hidden;
                    this.Height = 100;
                }
                else
                {
                    pic.Visibility = System.Windows.Visibility.Visible;
                    this.Height = 260;
                }
                _isHideImage = value;
            } }
        public string ImagePath { set {
                pic.ImagePath = value;
            }}

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TextBoxBackColor { set {
                txtName.BackColor = txtAmount.BackColor = this.BackColor = value;
            } }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string FoodName { get { return _foodName; } set {
                    _foodName = value;
                    txtName.Text = value.ToString();
                } }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int OrderQuantity { get { return _quantity; } set {
                _quantity = value;
                txtAmount.Text = value.ToString();
            } }

    }
}
