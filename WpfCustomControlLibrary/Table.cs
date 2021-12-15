using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
using System.Drawing;


namespace WpfCustomControlLibrary
{
    /// <summary>
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class Table : UserControl
    {
        public event EventHandler TableClick;
        public event EventHandler MouseHover;
        public event EventHandler MouseLeave;

        private System.Drawing.Color PrimaryColor;

        public Table()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            lblDetail.MouseEnter += LblDetail_MouseEnter;
            lblDetail.MouseLeftButtonDown += LblDetail_MouseLeftButtonDown;
            lblDetail.MouseLeave += LblDetail_MouseLeave;

            btn.MouseEnter += Btn_MouseEnter;
            btn.Click += Btn_Click;
            btn.MouseLeave += Btn_MouseLeave;
        }

        private void Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            TableColor = PrimaryColor;
            if (MouseLeave != null) MouseLeave(this, e);
        }

        private void LblDetail_MouseLeave(object sender, MouseEventArgs e)
        {
            TableColor = PrimaryColor;
            if (MouseLeave != null) MouseLeave(this, e);
        }

        private void LblDetail_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TableClick != null) TableClick(this, e);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (TableClick != null) TableClick(this,e);
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            PrimaryColor = TableColor;
            TableColor = System.Drawing.Color.FromArgb(190, 230, 253);
            if (MouseHover != null) MouseHover(this, e);
        }

        private void LblDetail_MouseEnter(object sender, MouseEventArgs e)
        {
            PrimaryColor = TableColor;
            TableColor = System.Drawing.Color.FromArgb(190, 230, 253);
            if(MouseHover != null) MouseHover(this, e);
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TableName
        {
            get
            {
                return btn.Content.ToString();
            }
            set
            {
                btn.Content = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Detail
        {
            get
            {
                return lblDetail.Content.ToString();
            }
            set
            {
                lblDetail.Content = value;
            }
        }


        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color TableColor
        {
            get
            {
                var brush = ((SolidColorBrush)btn.Background).Color;
                return System.Drawing.Color.FromArgb(brush.A,brush.R,brush.G,brush.B);
            }
            set
            {
                var bg = new SolidColorBrush(System.Windows.Media.Color.FromArgb(value.A,value.R,value.G,value.B));
                btn.Background = bg;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Radius { 
            set {
                 var obj = btn.Resources.FindName("btn");
                obj = value;
                 } 
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color TextColor
        {
            get
            {
                var brush = ((SolidColorBrush)btn.Foreground).Color;
                return System.Drawing.Color.FromArgb(brush.A, brush.R, brush.G, brush.B);
            }
            set 
            {
                var bg = new SolidColorBrush(System.Windows.Media.Color.FromArgb(value.A, value.R, value.G, value.B));
                btn.Foreground = bg;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color BorderColor
        {
            get
            {
                var brush = ((SolidColorBrush)btn.BorderBrush).Color;
                return System.Drawing.Color.FromArgb(brush.A, brush.R, brush.G, brush.B);
            }
            set
            {
                var bg = new SolidColorBrush(System.Windows.Media.Color.FromArgb(value.A, value.R, value.G, value.B));
                btn.BorderBrush = bg;
            }
        }
    }
}
