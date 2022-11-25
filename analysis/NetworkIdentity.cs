using UnityEngine;


namespace Mirror
{
  // 게임 오브젝트의 고유한 ID 관리
  // asset과 scene 오브젝트로 나뉨
  public sealed class NetworkIdentity : MonoBehaviour
  {
    public bool isClient { get; internal set; }
    public bool isServer { get; internal set; }
    [SerializeField] uint _assetId;

    // sceneId, assetId 관리

  }
}