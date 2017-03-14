using System;
using NetCore.Collections.Observables.Sets;

namespace NetCore.Collections.Observables {
  public static class ObservableSet {
    public static IObservableSet<T> Where<T>(this IObservableSet<T> coll, Func<T, bool> pred) =>
      new WhereObservableSet<T>(coll, pred);
  }
}
