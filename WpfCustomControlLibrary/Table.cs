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
        public Table()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            lblDetail.MouseEnter += LblDetail_MouseEnter;
            lblDetail.MouseLeftButtonDown += LblDetail_MouseLeftButtonDown;

            btn.MouseEnter += Btn_MouseEnter;
            btn.Click += Btn_Click;
            //btn.MouseLeave += Btn_MouseLeave;
        }

        //private void Btn_MouseLeave(object sender, MouseEventArgs e) =>
        //    btn.Background = ;


        private void LblDetail_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Btn_Click(sender, e);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button has clicked....");
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            btn.Background = new SolidColorBrush();
        }

        private void LblDetail_MouseEnter(object sender, MouseEventArgs e)
        {
            Btn_MouseEnter(sender, e);
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
       
       
    }
}
