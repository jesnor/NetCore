using System;
using System.Collections.Generic;
using NetCore.Collections.Mutables;
using NetCore.Collections.Observables;
using NetCore.Collections.Observables.Collections;
using NetCore.Collections.Sets;
using NetCore.Observables;

namespace NetCore.Collections.ObservableMutables.Sets {
  public class ObservableMutableSet<T> : AbstractSet<T>, IObservableMutableSet<T> {
    private readonly Signal<ICollectionChange<T>> signal = new Signal<ICollectionChange<T>>();
    private readonly IMutableSet<T> set;

    public ObservableMutableSet(IMutableSet<T> set) {
      this.set = set;
    }

    public override bool IsEmpty => false;

    public bool Add(T item) {
      if (set.Add(item)) {
        signal.Fire(new CollectionChange<T>(item.ToOption(), Seq.Empty<T>()));
        return true;
      }
      else
        return false;
    }

    public bool Remove(T item) {
      if (set.Remove(item)) {
        signal.Fire(new CollectionChange<T>(Seq.Empty<T>(), item.ToOption()));
        return true;
      }
      else
        return false;
    }

    public override bool Contains(object value) => value is T t && set.Contains(t);
    public override IEnumerator<T> GetEnumerator() => set.GetEnumerator();
    public override ISet<T> StrictSet() => set.StrictSet();
    public IDisposable Subscribe(IObserver<ICollectionChange<T>> observer) => signal.Subscribe(observer);
  }
}
