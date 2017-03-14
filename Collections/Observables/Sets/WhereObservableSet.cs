using System;
using NetCore.Collections.Observables.Collections;
using NetCore.Collections.Sets;
using NetCore.Observables;

namespace NetCore.Collections.Observables.Sets {
  public class WhereObservableSet<T> : WhereSet<T>, IObservableSet<T>, IObserver<ICollectionChange<T>> {
    private readonly Signal<ICollectionChange<T>> signal = new Signal<ICollectionChange<T>>();

    public WhereObservableSet(ICollection<T> coll, Func<T, bool> pred) : base(coll, pred) {
    }

    public void OnCompleted() { }
    public void OnError(Exception error) { }

    public void OnNext(ICollectionChange<T> value) {
      var added = value.Added.Where(pred);
      var removed = value.Removed.Where(pred);

      if (!added.IsEmpty || !removed.IsEmpty)
        signal.Fire(new CollectionChange<T>(added, removed));
    }

    public IDisposable Subscribe(IObserver<ICollectionChange<T>> observer) => signal.Subscribe(observer);
  }
}
