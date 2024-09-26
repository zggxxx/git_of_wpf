using recharge_system.Common;
using recharge_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace recharge_system.ViewModel
{
    public class NewsPageVM:NotifyBase
    {

        private Uri _currentImage;
        public Uri CurrentImage
        {
            get
            {
                if (_currentImage == null)
                {
                    _currentImage = new Uri("../Assets/image/480_272_PIC_001.jpeg", UriKind.Relative);
                }
                return _currentImage;
            }
            set
            {
                _currentImage = value;
                OnPropertyChanged();
            }
        }

        private Uri _secImage;
        public Uri SecImage
        {
            get
            {
                if (_secImage == null)
                {
                    _secImage = new Uri("../Assets/image/480_272_PIC_002.jpg", UriKind.Relative);
                }
                return _secImage;
            }
            set
            {
                _secImage = value;
                OnPropertyChanged();
            }
        }

        private Uri _lastImage;
        public Uri LastImage
        {
            get
            {
                if (_lastImage == null)
                {
                    _lastImage = new Uri("../Assets/image/480_272_PIC_003.jpg", UriKind.Relative);
                }
                return _lastImage;
            }
            set
            {
                _lastImage = value;
                OnPropertyChanged();
            }
        }
        public ICommand GoNextPhotoCommand { get; set; }
        public ICommand GoLastPhotoCommand { get; set; }
        protected void GoNextPhoto(object parameter)
        {
            Task.Run(()=>
                {
                    System.Threading.Thread.Sleep(300);
                    Uri currentImage = _currentImage;
                    Uri secImage = _secImage;
                    Uri lastImage = _lastImage;
                    CurrentImage = secImage;
                    LastImage = currentImage;
                    SecImage = lastImage;
                });

        }
        protected void GoLastPhoto(object parameter)
        {
            Task.Run(() => {
                System.Threading.Thread.Sleep(300);
                Uri currentImage = _currentImage;
                Uri secImage = _secImage;
                Uri lastImage = _lastImage;
                CurrentImage = lastImage;
                LastImage = secImage;
                SecImage = currentImage;
            });
        }
        public NewsPageVM()
        {
            GoNextPhotoCommand = new CommandBase(GoNextPhoto);
            GoLastPhotoCommand = new CommandBase(GoLastPhoto);
        }
    }
}
