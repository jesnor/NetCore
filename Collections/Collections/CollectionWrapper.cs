using System;
using System.Collections.Generic;

namespace NetCore.Collections.Collections {
  public class CollectionWrapper<T> : AbstractCollection<T> {
    private readonly ICollection<T> coll;
    private readonly Func<ICollection<T>, IEnumerator<T>> fn;

    public CollectionWrapper(ICollection<T> coll, Func<ICollection<T>, IEnumerator<T>> fn) {
      this.coll = coll;
      this.fn = fn;
    }

    public override bool IsEmpty => false;
    public override long Count => coll.Count;
    public override IEnumerator<T> GetEnumerator() => fn(coll);
  }
}
