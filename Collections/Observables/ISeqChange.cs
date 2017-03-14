using NetCore.Utils;

namespace NetCore.Collections.Observables {
  public interface ISeqChange<out T> : ICollectionChange<T> {
    long TotalAddedCount { get; }
    long TotalRemovedCount { get; }

    /// <summary>
    /// Returns a sequence of added sequences with ordered indexes before any modifications took place
    /// </summary>
    ICollection<ITuple<long, ISeq<T>>> AddedWithIndex { get; }

    /// <summary>
    /// Returns a sequence of removed sequences with ordered indexes before any modifications took place
    /// </summary>
    ICollection<ITuple<long, ISeq<T>>> RemovedWithIndex { get; }
  }
}
