using System;
using Mirror;

namespace kcp2k
{
  /**
  * Transport를 상속받는 구현 클래스
  * Kcp 오픈 소스를 사용해서 미러의 전송방식을 구현
  */
  public class MyKcpTransport : Transport
  {
    public const string Scheme = "kcp";
    public ushort Port = 7777;
    public uint Interval = 10;
    public int Timeout = 10000;

    // ...

    KcpServer server;
    KcpClient client;

    // where-allocation server version을 사용시 IL2CPP 사용할 수 있음
    // IL2CPP이란 c# -> IL 코드 -> IL2CPP -> c++
    // 즉, c#을 c++로 바꿔주는 컴파일러. 성능상의 이점과 보안상의 이점이 있음

    void Awake()
    {
      client = new KcpClient(
        () => OnClientConnected.Invoke(),
        (message, channel) => OnClientDataReceived.Invoke(message, FromKcpChannel(channel)),
        () => OnClientDisconnected.Invoke(),
        (error, reason) => OnClientError.Invoke(ToTransportError(error), reason));

      server = new KcpServer(
                      (connectionId) => OnServerConnected.Invoke(connectionId),
                      (connectionId, message, channel) => OnServerDataReceived.Invoke(connectionId, message, FromKcpChannel(channel)),
                      (connectionId) => OnServerDisconnected.Invoke(connectionId),
                      (connectionId, error, reason) => OnServerError.Invoke(connectionId, ToTransportError(error), reason),
                      DualMode,
                      NoDelay,
                      Interval,
                      FastResend,
                      CongestionWindow,
                      SendWindowSize,
                      ReceiveWindowSize,
                      Timeout,
                      MaxRetransmit,
                      MaximizeSendReceiveBuffersToOSLimit);
    }

    // 클라이언트, 서버 연결 및 통신을 Mirror의 Transport 클래스에 맞춰서 작성 ...
    public override void ClientConnect(Uri uri){}
    public override void ClientSend(ArraySegment<byte> segment, int channelId){}
    public override bool ServerActive()
    {
        throw new NotImplementedException();
    }

    public override void ClientDisconnect() {}

    public override bool ClientConnected()
    {
        throw new NotImplementedException();
    }

    public override void ClientConnect(string address)
    {
        throw new NotImplementedException();
    }

    public override void ClientSend(ArraySegment<byte> segment, int channelId = Channels.Reliable)
    {
        throw new NotImplementedException();
    }

    public override void ServerStart(){}
    public override void ServerSend(int connectionId, ArraySegment<byte> segment, int channelId = Channels.Reliable)
    {
        throw new NotImplementedException();
    }

    public override void ServerSend(int connectionId, ArraySegment<byte> segment, int channelId) {}
  }

  // ...
}
