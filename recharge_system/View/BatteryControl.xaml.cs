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

namespace recharge_system.View
{
    /// <summary>
    /// BatteryControl.xaml 的交互逻辑
    /// </summary>
    public partial class BatteryControl : UserControl
    {
        public static readonly DependencyProperty BatteryBackgroundProperty = DependencyProperty.Register("BatteryBackground", typeof(SolidColorBrush), typeof(BatteryControl), new PropertyMetadata(new SolidColorBrush(Colors.Gray), new PropertyChangedCallback(OnBatteryBackgroundChanged)));
        public BatteryControl()
        {
            InitializeComponent();
        }


        public SolidColorBrush BatteryBackground
        {
            get { return (SolidColorBrush)GetValue(BatteryBackgroundProperty);}
            set { SetValue(BatteryBackgroundProperty, value);}
        }

        protected static void OnBatteryBackgroundChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);
            Frame frame = parent.FindName("frame") as Frame;
            frame.NavigationService.Navigate(new Uri("../View/DataPage.xaml",UriKind.Relative));
        }
    }
}
