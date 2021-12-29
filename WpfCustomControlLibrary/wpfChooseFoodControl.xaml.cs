﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCustomControlLibrary
{
    /// <summary>
    /// Interaction logic for wpfChooseFoodControl.xaml
    /// </summary>
    public partial class wpfChooseFoodControl : UserControl
    {
        public wpfChooseFoodControl()
        {
            InitializeComponent();
        }

        private void InitEvent()
        {
            
        }
        public System.Drawing.Color TextColor
        {
            set
            {
                var bg = new SolidColorBrush(System.Windows.Media.Color.FromArgb(value.A, value.R, value.G, value.B));
                txtAmount.Foreground = txtName.Foreground = bg;
            }
        }
        public bool HidePicture
        {
            get { return _isHideImage; }
            set
            {
                if (value)
                {
                    pic.Visibility = System.Windows.Visibility.Hidden;
                    this.Height = 100;
                }
                else
                {
                    pic.Visibility = System.Windows.Visibility.Visible;
                    this.Height = 315;
                }
                _isHideImage = value;
            }
        }
        private int _quantity;
        private string _foodName;
        private bool _isHideImage;
        public bool HideImage
        {
            get { return _isHideImage; }
            set
            {

                if (value)
                {
                    pic.Visibility = System.Windows.Visibility.Hidden;
                    this.Height = 140;
                }
                else
                {
                    pic.Visibility = System.Windows.Visibility.Visible;
                    this.Height = 300;
                }
                _isHideImage = value;
            }
        }
        public string ImagePath
        {
            set
            {
                pic.ImagePath = value;
            }
        }
        public byte[] ImageSource
        {
            set
            {
                if (value!=null)
                {
                    pic.ImageSource = value;
                }
            }
        }

       [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string FoodName
        {
            get { return _foodName; }
            set
            {
                _foodName = value;
                txtName.Text = value?.ToString();
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int OrderQuantity
        {
            get
            {
                if (int.TryParse(txtAmount.Text, out _quantity))
                {
                    return int.Parse(txtAmount.Text);
                }
                return 0;
            }
            set
            {
                _quantity = value;
                txtAmount.Text = value.ToString();
            }
        }

        private void btnPlus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (int.TryParse(txtAmount.Text, out _quantity))
            {
                var _quantity = int.Parse(txtAmount.Text);
                txtAmount.Text = (_quantity + 1).ToString();
                OrderQuantity = _quantity + 1;
            }
        }

        private void btnMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (int.TryParse(txtAmount.Text, out _quantity))
            {
                var _quantity = int.Parse(txtAmount.Text);
                txtAmount.Text = _quantity > 0 ? (_quantity - 1).ToString() : 0.ToString(); ;
                OrderQuantity = int.Parse(txtAmount.Text);
            }
        }

        private void txtAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
