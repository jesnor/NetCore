using System;

namespace NetCore.Collections.Observables {
  public interface IObservableSet<out T> : IObservableCollection<T>, ISet<T> {
  }
}
