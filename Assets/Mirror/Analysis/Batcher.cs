using System;
using System.Collections.Generic;

namespace Mirror
{
  public class Batcher
  {
    readonly int threshold;
    NetworkWriterPooled batch;

    // NetworkWriterPooled == writer
    Queue<NetworkWriterPooled> batches = new Queue<NetworkWriterPooled>();

    public void AddMessage(ArraySegment<byte> message, double timeStamp) {}
    public bool GetBatch(NetworkWriter writer){}
  }
}
