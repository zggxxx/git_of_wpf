using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recharge_system.Model
{
    public class BillInfo:ViewModel.NotifyBase
    {
        private string _userName;
        public string UserName { get { return _userName; } set { _userName = value; OnPropertyChanged(); } }

        public int BillNo { get; set; }

        public string ItemName { get; set; }

        public string ItemType { get; set; }

        public DateTime OrderTime { get; set; }

        public DateTime OrderMdfTime { get; set; }
    }
}
