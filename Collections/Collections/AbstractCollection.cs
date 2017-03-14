using System;
using System.Linq;
using NetCore.Collections.Enumerables;

namespace NetCore.Collections.Collections {
  public abstract class AbstractCollection<T> : AbstractEnumerable<T>, ICollection<T> {
    public abstract bool IsEmpty { get; }
    public virtual long Count => this.LongCount();
    public virtual bool Contains(object value) => GetEnumerator().Contains(value);

    public virtual ICollection<T> Strict() {
      if (Count > int.MaxValue)
        throw new IndexOutOfRangeException();

      var a = new T[Count];
      var i = 0;

      foreach (var v in this) {
        a[i++] = v;
      }

      return a.ToSeq();
    }
  }
}
