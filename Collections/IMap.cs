using NetCore.Utils;

namespace NetCore.Collections {
  public interface IMap : ISeq {
  }

  public interface IMap<K, out V> : IMap, ISeq<ITuple<K, V>> {
    bool ContainsKey(K key);
    IOption<V> this[K key] { get; }
  }
}
