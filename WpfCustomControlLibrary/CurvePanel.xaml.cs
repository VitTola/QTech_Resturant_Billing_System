using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCustomControlLibrary
{
    /// <summary>
    /// Interaction logic for CurvePanel.xaml
    /// </summary>
    public partial class CurvePanel : UserControl
    {
        public CurvePanel()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            this.Loaded += CurvePanel_Loaded;
        }

        private void CurvePanel_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(BackGroundColor);
            pnlLeft.Background = brush;
            pnlRight.Background = brush;
        }

        public Color BackGroundColor { get; set; } = System.Windows.Media.Color.FromRgb(100, 149, 237);
    }
}
