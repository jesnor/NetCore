using System;
using System.Collections.Generic;

namespace NetCore.Utils {
  public static class Tuple {
    public static ITuple<T1, T2> ToTuple<T1, T2>(this T1 item1, T2 item2) => new Tuples.Tuple<T1, T2>(item1, item2);
    public static ITuple<T1, T2, T3> ToTuple<T1, T2, T3>(this T1 item1, T2 item2, T3 item3) => new Tuples.Tuple<T1, T2, T3>(item1, item2, item3);
    public static ITuple<K, V> ToITuple<K, V>(KeyValuePair<K, V> p) => p.Key.ToTuple(p.Value);
  }
}
