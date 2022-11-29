using System;
using UnityEngine;

namespace Mirror
{
  /*
  * NetworkManager는 scene단위로 하나만 존재 (싱글톤)
  *  -> 개인생각 : scene 단위는 백엔드의 모듈 단위정도 ... 
  * 최대 접속 500-1000명이 하나의 scene에서 원활하게 접속해야함 !!
  */
  [HelpURL("https://mirror-networking.gitbook.io/docs/components/network-manager")]
  public class NetworkManager : MonoBehaviour
  {
    // TODO : doc 보고 Manager가 하는 역할 분류
    // 메서드별로 어떤 분류에 들어가는지 정리
    // roomManager, LobbyManager 관계 정리.

    // 오픈소스에는 100으로 설정되어 있음
    public int maxConnections = 100;


    // 1. Transports
    // 네트워크 초기화
    public Transport transport;

    bool InitializeSingleton(){} // ... 

    // 2. Game state management
    //  server와 client 둘 중에 하나만 실행됨 !
    public void StartServer()
    {
      InitializeSingleton();
      ConfigureHeadlessFrameRate();
      NetworkServer.Listen(maxConnections);
      // ???
      RegisterServerMessages();
    }

    public void StartClient(Uri uri)
    {
      InitializeSingleton();
      if (authenticator != null)
      {
        authenticator.OnStartClient();
        authenticator.OnClientAuthenticated.AddListener(OnClientAuthenticated);
      }

      NetworkClient.Connect(networkAddress);
    } 

    // 3. Scene management
    public virtual void ServerChangeScene(string newSceneName){}
    

    // 4. Spawn management, start position
  }
}