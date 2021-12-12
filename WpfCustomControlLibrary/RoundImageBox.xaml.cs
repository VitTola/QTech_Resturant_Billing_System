﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCustomControlLibrary
{
    /// <summary>
    /// Interaction logic for RoundImageBox.xaml
    /// </summary>
    public partial class RoundImageBox : UserControl
    {
        public EventHandler Click;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ImagePath { get; set; }
        private bool isPlaceHoder;
        public RoundImageBox()
        {
            InitializeComponent();
            el.MouseEnter += El_MouseEnter;
            el.MouseLeave += El_MouseLeave;

        }

        private void El_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isPlaceHoder)
            {
                el.Fill = new SolidColorBrush(Colors.Transparent);
                SetPlaceHolder();
            }
            else
            {
                if (!string.IsNullOrEmpty(ImagePath))
                {
                    ImageBrush imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri(ImagePath));
                    el.Fill = imageBrush;
                }
                else
                {
                    el.Fill = new SolidColorBrush(Colors.Transparent);
                    SetPlaceHolder();
                }
            }
            
        }

        private void El_MouseEnter(object sender, MouseEventArgs e)
        {
            el.Fill = new SolidColorBrush(Colors.LightCyan);
        }

        private void Ellipse_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Click != null) Click(this, e);
            if (!string.IsNullOrEmpty(ImagePath))
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri(ImagePath));
                el.Fill = imageBrush;

                isPlaceHoder = false;
            }
        }
        public void SetPlaceHolder()
        {
            try
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = ToBitmapImage(Properties.Resources.dish__1_);
                el.Fill = imageBrush;

                isPlaceHoder = true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

    }
}