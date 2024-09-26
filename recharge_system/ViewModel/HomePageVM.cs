using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace recharge_system.ViewModel
{
    public class HomePageVM: PageBaseVM
    {
        public ICommand OpenSocketTestPage {  get; set; }

        private int _slideValue = 0;

        public int SlideValue
        {
            get { return _slideValue; }
            set { _slideValue = value; OnPropertyChanged(); }
        }

        private TimeSpan _mediaPosition = new TimeSpan(0,0,0,0);

        public TimeSpan MediaPosition
        {
            get { return _mediaPosition; } 
            set { _mediaPosition = value; OnPropertyChanged(); }
        }

        public HomePageVM() : base()
        {
            OpenSocketTestPage = new Common.CommandBase(OnOpenSocketTestPage);
            Task.Factory.StartNew(() => 
            {
                for (; ;)
                {
                    SlideValue++;
                    System.Threading.Thread.Sleep(1000);
                }
            });
        }

        protected void OnOpenSocketTestPage(object parameter)
        {
            (parameter as Frame).NavigationService.Navigate(new Uri("../View/SocketPage.xaml",UriKind.Relative));
        }
    }
}
