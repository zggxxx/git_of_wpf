using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace recharge_system.Common
{
    class MyTabControl : TabControl
    {

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            Frame frame = ((e.AddedItems[0] as TabItem).Content as Frame);
            frame.NavigationService.Navigate(frame.Source);
            SelectedItem = (e.AddedItems[0] as TabItem);
        }
    }
}
