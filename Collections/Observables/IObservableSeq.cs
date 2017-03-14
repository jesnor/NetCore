using System;

namespace NetCore.Collections.Observables {
  public interface IObservableSeq<out T> : IObservableCollection<T>, IObservable<ISeqChange<T>> {
  }
}
