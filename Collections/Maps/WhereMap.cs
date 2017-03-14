using System;
using System.Collections.Generic;
using System.Linq;
using NetCore.Utils;

namespace NetCore.Collections.Maps {
  public class WhereMap<K, V> : AbstractMap<K, V> {
    private readonly IMap<K, V> map;
    private readonly Func<ITuple<K, V>, bool> pred;

    public WhereMap(IMap<K, V> map, Func<ITuple<K, V>, bool> pred) {
      this.map = map;
      this.pred = pred;
    }

    public override long Count => map.LongCount(pred);
    public override bool IsEmpty => GetEnumerator().IsEmpty();
    public override IEnumerator<ITuple<K, V>> GetEnumerator() => map.GetEnumerator().Where(pred);
    public override bool Contains(object value) => value is ITuple<K, V> t && map.Contains(t) && pred(t);
    public override bool ContainsKey(K key) => !this[key].IsEmpty;
    public override IOption<V> this[K key] => map[key].Where(v => pred(key.ToTuple(v)));
  }
}
