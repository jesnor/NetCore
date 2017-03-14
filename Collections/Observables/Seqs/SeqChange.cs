using System;
using NetCore.Utils;

namespace NetCore.Collections.Observables.Seqs {
  public class SeqChange<T> : ISeqChange<T> {
    private readonly long totalAddedCount;
    private readonly long totalRemovedCount;
    private readonly ICollection<ITuple<long, ISeq<T>>> addedWithIndex;
    private readonly ICollection<ITuple<long, ISeq<T>>> removedWithIndex;

    public SeqChange(long totalAddedCount, long totalRemovedCount, ICollection<ITuple<long, ISeq<T>>> addedWithIndex,
      ICollection<ITuple<long, ISeq<T>>> removedWithIndex) {
      this.totalAddedCount = totalAddedCount;
      this.totalRemovedCount = totalRemovedCount;
      this.addedWithIndex = addedWithIndex;
      this.removedWithIndex = removedWithIndex;
    }

    public long TotalAddedCount => totalAddedCount;
    public long TotalRemovedCount => totalRemovedCount;
    public ICollection<ITuple<long, ISeq<T>>> AddedWithIndex => addedWithIndex;
    public ICollection<ITuple<long, ISeq<T>>> RemovedWithIndex => removedWithIndex;
    public ICollection<T> Added => addedWithIndex.SelectMany(t => t.Item2);
    public ICollection<T> Removed => removedWithIndex.SelectMany(t => t.Item2);
  }
}
