using System;
using System.Collections.Generic;

namespace NetCore.Collections {
  public static class Dictionary {
    public static IOption<V> OptGet<K, V>(this IDictionary<K, V> dict, K key) => dict.TryGetValue(key, out var v) ? v.ToOption() : Option.Empty<V>();
  }
}
