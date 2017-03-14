using System.Collections.Generic;
using NetCore.Utils;

namespace NetCore.Collections.Maps {
  public class DictionaryMap<K, V> : AbstractMap<K, V> {
    private readonly IDictionary<K, V> dict;

    public DictionaryMap(IDictionary<K, V> dict) {
      this.dict = dict;
    }

    public override long Count => dict.Count;
    public override bool IsEmpty => dict.Count == 0;
    public override bool ContainsKey(K key) => dict.ContainsKey(key);
    public override IEnumerator<ITuple<K, V>> GetEnumerator() => dict.GetEnumerator().Select(Tuple.ToITuple);
    public override IOption<V> this[K key] => dict.OptGet(key);
  }
}
