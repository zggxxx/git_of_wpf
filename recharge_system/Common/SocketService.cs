using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace recharge_system.Common
{
    public class SocketService
    {
        private Socket _client;
        
        private ushort _port;

        private string _host;

        public event Action<byte[]> SocketMsgReceivedHandler;
        public SocketService (ushort port, string host)
        {
            _client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            _port = port;
            _host = host;
        }

        public void Connection()
        {
            _client.Connect(_host,_port);
            Task.Factory.StartNew(ReceiveMsg);
        }

        public void SendMsg(byte[] msg)
        {
            if (_client.Connected) 
            {
                _client.Send(msg);
            }
        }

        private void ReceiveMsg() 
        {
            while (_client.Connected) {
                byte[] buffer = new byte[1024];
                int len = _client.Receive(buffer);
                if (len > 0) {
                    byte[] msg = new byte[len];
                    Array.Copy(buffer, msg, len);
                    if(SocketMsgReceivedHandler != null)
                    {
                        SocketMsgReceivedHandler.Invoke(msg);
                    }
                }
            }
        }

    }
}
