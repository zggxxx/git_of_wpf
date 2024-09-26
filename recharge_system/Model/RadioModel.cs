using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recharge_system.Model
{
    public class RadioModel
    {
		private Uri _radioImg;

		public Uri RadioImg
		{
			get { return _radioImg; }
			set { _radioImg = value; }
		}

		private string _radioAddr;

		public string RadioAddr
		{
			get { return _radioAddr; }
			set { _radioAddr = value; }
		}

		private string _radioName;

		public string RadioName 
		{
			get { return _radioName; }
			set { _radioName = value; }
		}


		private bool _available;

		public bool Available
		{
			get { return _available; }
			set { _available = value; }
		}


		public RadioModel() 
		{
			_available = true;
			_radioImg = new Uri("../Assets/image/DefRadio.jpg", UriKind.Relative);
			_radioName = "中国之声";
			_radioAddr = "mms://211.89.225.141/cnr001";
		}




	}
}
