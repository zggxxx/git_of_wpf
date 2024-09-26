using recharge_system.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace recharge_system.Model
{
    public class PhotoList
    {


        public PhotoList() {
            GoNextPhotoCommand = new CommandBase(GoNextPhoto);
        }

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
            }
        }

        private Uri _secImage;
        public Uri SecImage
        {
            get
            {
                if (_secImage == null)
                {
                    _secImage = new Uri( "../Assets/image/480_272_PIC_002.jpg",UriKind.Relative);
                }
                return _secImage;
            }
            set
            {
                _secImage = value;
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
            }
        }
        public ICommand GoNextPhotoCommand { get; set; }
        protected void GoNextPhoto(object parameter)
        {
            Uri currentImage = _currentImage;
            Uri secImage = _secImage;
            Uri lastImage = _lastImage;
            CurrentImage = secImage;
            LastImage = currentImage;
            SecImage = lastImage;
        }
    }
}
