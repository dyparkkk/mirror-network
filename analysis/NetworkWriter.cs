using System;
using UnityEngine;

namespace Mirror
{
  public class NetworkWriter
  {
    public const int MaxStringLength = 1024 * 32;
    public const int DefaultCapacity = 1500;

    // 사이즈는 변할 수 있음 
    // 평균적으로 1500 바이트보다 작은 패킷이기 때문에 디폴트는 1500바이트
    internal byte[] buffer = new byte[DefaultCapacity];


    // 버퍼 사이즈 확장
    // 추가 비용이 없음 ... 1. 어차피 남는 자리 검사해야함
    // 2. 결국 확장할 필요 없을 만큼 커짐 ...? ( 이게 맞나 ..?)
    internal void EnsureCapacity(int value)
    {
      if (buffer.Length < value)
      {
        int capacity = Math.Max(value, buffer.Length * 2);
        Array.Resize(ref buffer, capacity);
      }
    }

    // Blittable ... 
    // 작성중 ... https://learn.microsoft.com/ko-kr/dotnet/framework/interop/blittable-and-non-blittable-types 참고
    internal unsafe void WriteBlittable<T>(T value)
      where T : unmanaged
    {

    }
  }
}