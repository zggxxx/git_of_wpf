using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using recharge_system.Common;

namespace recharge_system.ViewModel
{
    public class PageBaseVM:NotifyBase
    {
        public ICommand PageDragMove { get; set; }

        public ICommand PageMaximized { get; set; }

        public ICommand PageMinimized { get; set; }

        public ICommand PageClose { get; set; }

        public PageBaseVM() 
        {
            PageDragMove = new CommandBase(this.OnPageDragMove);
            PageMaximized = new CommandBase(this.OnPageMaximized);
            PageMinimized = new CommandBase(this.OnPageMinimized);
            PageClose = new CommandBase(this.OnPageClose);
        }

        protected void OnPageDragMove(object parameter) 
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                (parameter as Window).DragMove();
            }
        }

        protected void OnPageMaximized(object parameter)
        {
            if ((parameter as Window).WindowState == WindowState.Maximized)
            {
                (parameter as Window).WindowState = WindowState.Normal;
            }
            else
            {
                (parameter as Window).WindowState = WindowState.Maximized;
            }
        }

        protected void OnPageMinimized(object parameter)
        {
            (parameter as Window).WindowState = WindowState.Minimized;
        }

        protected void OnPageClose(object parameter)
        {
            (parameter as Window).Close();
        }

    }
}
