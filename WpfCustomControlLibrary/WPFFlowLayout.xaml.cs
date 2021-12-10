using System;
using System.Collections.Generic;
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

namespace WpfCustomControlLibrary
{
    /// <summary>
    /// Interaction logic for WPFFlowLayout.xaml
    /// </summary>
    public partial class WPFFlowLayout : UserControl
    {
        public WPFFlowLayout()
        {
            InitializeComponent();
            this.Loaded += WPFFlowLayout_Loaded;
        }

        private void WPFFlowLayout_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                wrp.Children.Add(new Table() /*{Width =100, Height=70, Content = "Table "+i}*/);

            }
        }
    }
}
