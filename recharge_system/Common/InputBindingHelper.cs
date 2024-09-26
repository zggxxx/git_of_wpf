using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace recharge_system.Common
{
    public class InputBindingHelper
    {
        public static readonly DependencyProperty TestDepProperty = DependencyProperty.RegisterAttached("TestDep", typeof(string), typeof(InputBindingHelper), new PropertyMetadata(null, new PropertyChangedCallback(OnTestDepPropertyChanged)));


        public static string GetTestDep(DependencyObject obj)
        {
            return (string)obj.GetValue(TestDepProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(TestDepProperty, value);
        }

        public static ICommand LeftClickCommand { get; set; } = new CommandBase(DoLeftClick);

        private static void DoLeftClick(object parameter)
        {

        }

        protected static void OnTestDepPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {

        }



    }
}
