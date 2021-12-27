using System;
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
    public partial class ChooseFoodBox : UserControl
    {
        public EventHandler Click;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ImagePath { get; set; }

        private byte[] ImageSourceInByte;
        public byte[] ImageSource
        {
            get
            {
                return ImageSourceInByte;
            }
            set
            {
                if (value != null)
                {
                    ImageSourceInByte = value;
                    using (MemoryStream stream = new MemoryStream(value, 0, value.Length))
                    {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = stream;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        bitmap.Freeze();
                        ImageBrush imageBrush = new ImageBrush();
                        imageBrush.ImageSource = bitmap;
                        //el.Fill = imageBrush;
                    }
                    isPlaceHoder = false;
                }

            }

        }
        private byte[] BitmapSourceToByteArray(BitmapSource bmpSrc)
        {
            var encoder = new JpegBitmapEncoder();
            encoder.QualityLevel = 100;
            encoder.Frames.Add(BitmapFrame.Create(bmpSrc));

            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
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
                //ImageBrush imageBrush = new ImageBrush();
                //imageBrush.ImageSource = new BitmapImage(new Uri(ImagePath));
                //el.Fill = imageBrush;
                //if (!string.IsNullOrEmpty(ImagePath))
                //{
                //    ImageBrush imageBrush = new ImageBrush();
                //    imageBrush.ImageSource = new BitmapImage(new Uri(ImagePath));
                //    el.Fill = imageBrush;a
                //}
                //else
                //{
                //    el.Fill = new SolidColorBrush(Colors.Transparent);
                //    SetPlaceHolder();
                //}
            }

        }

        private void El_MouseEnter(object sender, MouseEventArgs e)
        {
            //el.Fill = new SolidColorBrush(Colors.LightCyan);
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

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
