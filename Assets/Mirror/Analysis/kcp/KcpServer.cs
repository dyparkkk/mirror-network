using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace kcp2k
{
    public class KcpServer
    {
      // events
      public Action<int> OnConnected;
      public Action<int, ArraySegment<byte>, KcpChannel> OnData;
      public Action<int> OnDisconnected;

       // state
        protected Socket socket;
        EndPoint newClientEP;
        readonly byte[] rawReceiveBuffer = new byte[Kcp.MTU_DEF];


        // connections <connectionId, connection>
        public Dictionary<int, KcpServerConnection> connections = new Dictionary<int, KcpServerConnection>();
        public void Start(ushort port){}

        // ...
    }
}