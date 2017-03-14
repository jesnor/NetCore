using NetCore.Collections.Seqs;
using NetCore.Utils;

namespace NetCore.Collections.Maps {
  public abstract class AbstractMap<K, V> : AbstractSeq<ITuple<K, V>>, IMap<K, V> {
    public virtual bool ContainsKey(K key) => !this[key].IsEmpty;
    public override bool Contains(object value) => value is ITuple<K, V> t && ContainsKey(t.Item1);

    public virtual IOption<V> this[K key] {
      get {
        foreach (var v in this) {
          if (v.Item1.SafeEquals(key))
            return v.Item2.ToOption();
        }

        return Option.Empty<V>();
      }
    }

    public override string ToString() => "Map(" + this.ElementToString() + ")";
  }
}
