using System.ComponentModel;
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
            var brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(BackGroundColor.A, BackGroundColor.R, BackGroundColor.G, BackGroundColor.B));
            pnlLeft.Background = brush;
            pnlRight.Background = brush;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color BackGroundColor { get; set; } = System.Drawing.Color.FromArgb(23, 33, 43);
    }
}
