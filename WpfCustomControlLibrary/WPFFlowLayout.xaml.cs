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
        }
        public void ClearChildren()
        {
            wrp.Children.Clear();
        }
        public UIElementCollection Children { 
            get { return wrp.Children; }
        }

        private void WPFFlowLayout_Loaded(object sender, RoutedEventArgs e)
        {
        }
        public void AddChildren(List<Table> tables)
        {
            foreach (Table table in tables)
            {
                wrp.Children.Add(table);
            }
        }
        public void AddChildren(Table table)
        {
            wrp.Children.Add(table);

        }

        public void AddFoodPanel(List<wpfChooseFoodControl> controls)
        {
            foreach (var c in controls)
            {
                wrp.Children.Add(c);
            }
        }
    }
}
