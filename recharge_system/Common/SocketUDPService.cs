using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace recharge_system.Common
{
    public class SocketUDPService
    {
        private Socket _csocket;
        private EndPoint _serverAddr;
        private EndPoint _cAddr;
        private ushort _port = 9001;
        private byte[] _data = new byte[1024];

        public event Action<byte[]> SocketMsgReceivedHandler;

        public SocketUDPService()
        {
            _csocket = new Socket(SocketType.Dgram,ProtocolType.Udp);
            _serverAddr = new IPEndPoint(IPAddress.Parse("192.168.169.130"),_port);
            _cAddr = new IPEndPoint(IPAddress.Parse("127.0.0.1"),0);
        }


        public void ReceiveFrom()
        {
            while (true)
            {
                int result = _csocket.SendTo(Encoding.UTF8.GetBytes("HEEEEEEEEEEE"),_serverAddr);


                int recvLen = 0;

                System.Threading.Thread.Sleep(1000);

                recvLen = _csocket.ReceiveFrom(_data, SocketFlags.None, ref _cAddr);
                if (recvLen > 0) 
                {
                    byte[] msg = new byte[recvLen];
                    Array.Copy(_data, msg, recvLen);
                    if (SocketMsgReceivedHandler != null)
                    {
                        SocketMsgReceivedHandler.Invoke(msg);
                    }
                }
            }
        }
    }
}
