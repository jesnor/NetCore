using System;

namespace NetCore.Collections.Observables {
  public interface IObservableCollection<out T> : ICollection<T>, IObservable<ICollectionChange<T>> {
  }
}
