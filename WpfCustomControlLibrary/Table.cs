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
using QTech.Base.Enums;

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
        public event EventHandler DoubleClick;
        public TableStatus TableStatus { get; set; } = TableStatus.Free;
        public Object Object { get; set; }

        private bool _isClick;
        public bool IsClicked
        {
            get { return _isClick; }
            set
            {
                _isClick = value;
            }
        }

        public int Id { get; set; }
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
            if (!IsClicked)
            {
                TableColor = PrimaryColor;
            }
            if (MouseLeave != null) MouseLeave(this, e);
        }

        private void LblDetail_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!IsClicked)
            {
                TableColor = PrimaryColor;
            }
            if (MouseLeave != null) MouseLeave(this, e);
        }

        private void LblDetail_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TableClick != null) TableClick(this, e);
            TableColor = System.Drawing.Color.Gray;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (TableClick != null) TableClick(this, e);
            TableColor = System.Drawing.Color.Gray;
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!IsClicked)
            {
                PrimaryColor = TableColor;
            }
            TableColor = System.Drawing.Color.Gray;
            if (MouseHover != null) MouseHover(this, e);
        }

        private void LblDetail_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!IsClicked)
            {
                PrimaryColor = TableColor;
            }
            TableColor = System.Drawing.Color.Gray;
            if (MouseHover != null) MouseHover(this, e);
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
                return System.Drawing.Color.FromArgb(brush.A, brush.R, brush.G, brush.B);
            }
            set
            {
                var bg = new SolidColorBrush(System.Windows.Media.Color.FromArgb(value.A, value.R, value.G, value.B));
                btn.Background = bg;
            }
        }

        public System.Drawing.Color PrimaryColor;
        public System.Drawing.Color PrimaryBorderColor;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Radius
        {
            set
            {
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

        private void btn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DoubleClick != null) DoubleClick(sender, e);
        }

        private void lblDetail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DoubleClick != null) DoubleClick(sender, e);
        }
    }
}
