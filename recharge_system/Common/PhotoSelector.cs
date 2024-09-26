using recharge_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recharge_system.Common
{
    public class PhotoSelector
    {
        public static void GoNextPhoto(ref PhotoList photoList)
        {
            Uri currentUri = photoList.CurrentImage;
            Uri secUri = photoList.SecImage;
            Uri lastUri = photoList.LastImage;
            photoList.CurrentImage = secUri;
            photoList.LastImage = currentUri;
            photoList.SecImage = lastUri;
        }
    }
}
