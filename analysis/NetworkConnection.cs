namespace Mirror
{
  /// 기본 네트워크 연결 클래스 
  public abstract class NetworkConnection
  {
    // 트랜스포트 계층에서 사용되는 연결 당 유니크한 아이디
    public readonly int connectionId;

    protected static bool ValidatePacketSize(ArraySegment<byte> segment, int channelId){}
    protected Batcher GetBatchForChannelId(int channelId){}

    // 특정 채널에 메시지를 보냄
    // 밑에 Send() 메서드로 이어짐 
    public void Send<T>(T message, int channelId = Channels.Reliable) {}
    
    // 1. 네트워크 메시지는 ArraySegment<byte>를 통해서 직렬화한다.
    // 2. 메시지는 항상 배치해서 전송함 
    // 밑에 Update() 메서드로 이어짐
    internal virtual void Send(ArraySegment<byte> segment, int channelId = Channels.Reliable)
    {
      GetBatchForChannelId(channelId).AddMessage(segment, NetworkTime.localTime);
    }

    // 3. 배치된 메시지들을 실제로 전송하고 버퍼를 비움
    // max 메시지 사이즈를 넘기면 안됨 !
    internal virtual void Update() {}

    // test
  }
}