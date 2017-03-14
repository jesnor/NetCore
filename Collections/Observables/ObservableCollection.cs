using System;
using NetCore.Collections.Observables.Collections;
using NetCore.Collections.Observables.Sets;

namespace NetCore.Collections.Observables {
  public static class ObservableCollection {
    public static IObservableCollection<T> Where<T>(this IObservableCollection<T> coll, Func<T, bool> pred) => 
      new WhereObservableSet<T>(coll, pred);

    public static IObservableCollection<U> Select<T, U>(this IObservableCollection<T> coll, Func<T, U> fn) =>
      new SelectObservableCollection<T, U>(coll, fn);
  }
}
