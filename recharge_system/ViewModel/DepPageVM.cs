using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace recharge_system.ViewModel
{
    class DepPageVM:NotifyBase
    {
        private readonly Common.IUserOrderService _userOrderService;


        private ObservableCollection<Model.BillInfo> billInfos;

        public ObservableCollection<Model.BillInfo> BillInfos
        {
            get { return billInfos; }
            set { billInfos = value; }
        }



        public DepPageVM(Common.IUserOrderService userOrderService)
        {
            _userOrderService = userOrderService;
            BillInfos = new ObservableCollection<Model.BillInfo>( _userOrderService.GetBillInfos());

        }


    }
}
