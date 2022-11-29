using System;
using UnityEngine;

/**
* 저수준의 transport api 
* 클라이언트와 서버의 연결과 통신을 담당
*/
namespace Mirror
{
  public abstract class Transport : MonoBehaviour {
    public static Transport active;
    public Action<ArraySegment<byte>, int> OnClientDataReceived;
    public Action<ArraySegment<byte>, int> OnClientDataSent;
    public Action<int, ArraySegment<byte>, int> OnServerDataReceived;
    // ...

    public abstract bool ClientConnected();

    /// <summary>Connects the client to the server at the address.</summary>
    public abstract void ClientConnect(string address);

    /// <summary>Connects the client to the server at the Uri.</summary>
    public virtual void ClientConnect(Uri uri) {}
    public abstract void ClientSend(ArraySegment<byte> segment, int channelId = Channels.Reliable);

    public abstract bool ServerActive();

    /// <summary>Start listening for connections.</summary>
    public abstract void ServerStart();
    public abstract void ServerSend(int connectionId, ArraySegment<byte> segment, int channelId = Channels.Reliable);
    // ...
  }
}