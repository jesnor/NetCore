using System;
using NetCore.Collections.Mutables;
using NetCore.Collections.ObservableMutables.Sets;

namespace NetCore.Collections.ObservableMutables {
  public static class MutableObservableSet {
    public static IObservableMutableSet<T> Where<T>(this IObservableMutableSet<T> set, Func<T, bool> pred) => 
      new WhereObservableMutableSet<T>(set, pred);

    public static IObservableMutableSet<T> ToObservable<T>(this IMutableSet<T> set) => new ObservableMutableSet<T>(set);
  }
}
