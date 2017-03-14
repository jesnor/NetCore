using System;
using NetCore.Collections.Mutables;
using NetCore.Collections.Observables.Sets;

namespace NetCore.Collections.ObservableMutables.Sets {
  public class WhereObservableMutableSet<T> : WhereObservableSet<T>, IObservableMutableSet<T> {
    public WhereObservableMutableSet(IMutableSet<T> set, Func<T, bool> pred) : base(set, pred) {
    }

    protected IMutableSet<T> Set => coll as IMutableSet<T>;
    public bool Add(T item) => pred(item) && Set.Add(item);
    public bool Remove(T item) => pred(item) && Set.Remove(item);
  }
}
