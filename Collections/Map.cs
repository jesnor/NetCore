using System;
using System.Collections.Generic;
using NetCore.Collections.Maps;
using NetCore.Utils;

namespace NetCore.Collections {
  public static class Map {
    public static IMap<K, V> Where<K, V>(this IMap<K, V> map, Func<ITuple<K, V>, bool> pred) => new WhereMap<K, V>(map, pred);
    public static IMap<K, V> ToMap<K, V>(this IDictionary<K, V> dict) => new DictionaryMap<K, V>(dict);
  }
}
