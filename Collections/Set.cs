using System;
using System.Collections.Generic;
using NetCore.Collections.Sets;

namespace NetCore.Collections {
  public static class Set {
    public static ISet<T> Where<T>(this ISet<T> s, Func<T, bool> pred) => new WhereSet<T>(s, pred);
    public static ISet<T> Of<T>(params T[] values) => new HashSet<T>(values).ToISet();
    public static ISet<T> ToISet<T>(this System.Collections.Generic.ISet<T> s) => new SetWrapper<T>(s);
  }
}
