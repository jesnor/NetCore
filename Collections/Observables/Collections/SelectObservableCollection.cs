using System;
using NetCore.Collections.Collections;
using NetCore.Observables;

namespace NetCore.Collections.Observables.Collections {
  public class SelectObservableCollection<T, U> : SelectCollection<T, U>, IObservableCollection<U> {
    private readonly Signal<ICollectionChange<U>> signal = new Signal<ICollectionChange<U>>();

    public SelectObservableCollection(ICollection<T> coll, Func<T, U> fn) : base(coll, fn) {
    }

    public IDisposable Subscribe(IObserver<ICollectionChange<U>> observer) => signal.Subscribe(observer);
  }
}
