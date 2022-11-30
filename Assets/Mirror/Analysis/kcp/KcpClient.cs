/**
* mirror나 닷넷 위한 kcp client logic 정의
*/

using System;

namespace kcp2k
{
    public class KcpClient
    {
      // events
        public Action OnConnected;
        public Action<ArraySegment<byte>, KcpChannel> OnData;
        public Action OnDisconnected;

         // state
        public KcpClientConnection connection;
        public bool connected;

        public void Connect(string address,
                            ushort port,
                            bool noDelay,
                            uint interval,
                            int fastResend = 0,
                            bool congestionWindow = true,
                            uint sendWindowSize = Kcp.WND_SND,
                            uint receiveWindowSize = Kcp.WND_RCV,
                            int timeout = KcpConnection.DEFAULT_TIMEOUT,
                            uint maxRetransmits = Kcp.DEADLINK,
                            bool maximizeSendReceiveBuffersToOSLimit = false) {}

        public void Send(ArraySegment<byte> segment, KcpChannel channel) {}
        public void Disconnect(){}
    }
}
