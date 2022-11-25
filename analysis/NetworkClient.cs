namespace Mirror
{
  // partial :클래스, 인터페이스 등을 소스 코드 분할해서 정의할 수 있음.
  //          컴파일할 때 합쳐짐 
  public static partial class NetworkServer
  {

    //  SendToAll, BroadcastToConnection, Broadcast 차이 ?? 
    public static void SendToAll<T>(T message, int channelId = Channels.Reliable, bool sendToReadyOnly = false)
      where T : struct, NetworkMessage
    {
      using (NetworkWriterPooled writer = NetworkWriterPool.Get())
      {
        // pack message only once
        NetworkMessages.Pack(message, writer);
        ArraySegment<byte> segment = writer.ToArraySegment();

        // filter and then send to all internet connections at once
        //    avoid allocations, allow for multicast, etc.
        int count = 0;
        foreach (NetworkConnectionToClient conn in connections.Values)
        {
          if (sendToReadyOnly && !conn.isReady)
            continue;

          count++;
          conn.Send(segment, channelId);
        }

        NetworkDiagnostics.OnSend(message, channelId, segment.Count, count);
      }
    }

    // add/remove/replace player 
    // ...

    // SpawnObserverForConnection() 
    


  }
}