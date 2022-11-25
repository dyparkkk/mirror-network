using UnityEngine;

namespace Mirror
{
  public abstract class NetworkBehaviour : MonoBehaviour 
  {
    public NetworkIdentity netIdentity { get; internal set; }

    public bool isServer => netIdentity.isServer;

    // <summary>True if this object is on the client and has been spawned by the server.</summary>
    public bool isClient => netIdentity.isClient;

    // Command 명령어
    protected void SendCommandInternal(string functionFullName, NetworkWriter writer, int channelId, bool requiresAuthority = true){
      // NetworkClient.active, NetworkClient.ready, Authority 확인

      // 메시지 생성
      CommandMessage message = new CommandMessage
      {
        netId = netId,
        ComponentIndex = ComponentIndex,
        funcionHash = (ushort)functionFullName.GetStableHashCode(),
        payload = writer.ToArraySegment()
      };

      NetworkClient.connection.Send(message, channelId);
    }

    // 
    protected void SendRPCInternal(string functionFullName, NetworkWriter writer, int channelId, bool includeOwner)
    {
      // NetworkServer.active, isServer 확인

      // 메시지 생성
      RpcMessage message = new RpcMessage
      {
        // ...
      };

      using (NetworkWriterPooled serialized = NetworkWriterPool.Get())
      {
        serialized.Write(message);

        
      }
    }
  }
}