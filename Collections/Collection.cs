using System;
using System.Collections.Generic;
using NetCore.Collections.Collections;
using NetCore.Collections.Sets;

namespace NetCore.Collections {
  public static class Collection {
    public static ICollection<T> Where<T>(this ICollection<T> s, Func<T, bool> pred) => new WhereSet<T>(s, pred);
    public static ICollection<U> Select<T, U>(this ICollection<T> s, Func<T, U> fn) => new SelectCollection<T, U>(s, fn);
    public static ICollection<U> SelectMany<T, U>(this ICollection<T> s, Func<T, IEnumerable<U>> fn) => new SelectManyCollection<T, U>(s, fn);

    public static ICollection<T> OrderBy<T, U>(this ICollection<T> s, Func<T, U> fn) =>
      new CollectionWrapper<T>(s, seq => System.Linq.Enumerable.OrderBy(seq, fn).GetEnumerator());

  }
}
