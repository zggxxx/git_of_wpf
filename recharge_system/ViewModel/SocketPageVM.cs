using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace recharge_system.ViewModel
{
    public class SocketPageVM:NotifyBase
    {
        private Common.SocketService _socketService;
        private Common.SocketUDPService _socketUDPService;
        private Common.CPackageHelper _cpackageHelper;
        public ICommand ConnectServer {  get; set; }
        public ICommand SendMsg { get; set; }

        public ICommand ConnectUDP { get; set; }

        private string _msgBox;

        public string MsgBox
        {
            get { return _msgBox; }
            set { _msgBox = value; OnPropertyChanged(); }
        }

        private string _inputMsg;
        public string InputMsg
        {
            get { return _inputMsg; }
            set { _inputMsg = value; OnPropertyChanged(); }
        }

        public SocketPageVM() 
        {
            _socketService = new Common.SocketService(9000,"192.168.169.130");
            _socketUDPService = new Common.SocketUDPService();
            _cpackageHelper = new Common.CPackageHelper();
            _socketService.SocketMsgReceivedHandler += _socketService_SocketMsgReceivedHandler;
            _socketUDPService.SocketMsgReceivedHandler += _socketService_SocketMsgReceivedHandler;
            ConnectServer = new Common.CommandBase(OnConnectServer);
            SendMsg = new Common.CommandBase(OnSendMsg);
            ConnectUDP = new Common.CommandBase(OnConnectUDP);
        }

        private void _socketService_SocketMsgReceivedHandler(byte[] obj)
        {
            MsgBox += string.Format("{0}\r\n",Encoding.UTF8.GetString(obj));
        }

        protected void OnConnectServer(object parameter)
        {
            _socketService.Connection();
        }

        protected void OnSendMsg(object parameter)
        {
            Model.BatteryModel.SBatteryCCDCInfo sBatteryCCDCInfo = new Model.BatteryModel.SBatteryCCDCInfo();
            sBatteryCCDCInfo.step = 1;
            sBatteryCCDCInfo.capacity = 50.0;
            sBatteryCCDCInfo.voltage = 4.2;
            sBatteryCCDCInfo.resistance = 10.0;
            sBatteryCCDCInfo.current = 60.0;
            byte[] msg = _cpackageHelper.PackData(_cpackageHelper.UnPackage(sBatteryCCDCInfo));
            MsgBox += "send msg:\r\n";
            for (int i = 0; i < msg.Length; i++)
            {
                MsgBox += string.Format("{0} ", msg[i]); 
            }
            _socketService.SendMsg(msg);
            _socketService.SendMsg(msg);
        }

        protected void OnConnectUDP(object parameter) 
        {
            Task.Factory.StartNew(() =>
            {
                _socketUDPService.ReceiveFrom();
            });
        }
    }
}
