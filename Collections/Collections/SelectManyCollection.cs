using System;
using System.Collections.Generic;

namespace NetCore.Collections.Collections {
  public class SelectManyCollection<T, U> : AbstractCollection<U> {
    private readonly ICollection<T> coll;
    private readonly Func<T, IEnumerable<U>> fn;

    public SelectManyCollection(ICollection<T> coll, Func<T, IEnumerable<U>> fn) {
      this.coll = coll;
      this.fn = fn;
    }

    public override bool IsEmpty => GetEnumerator().IsEmpty();
    public override IEnumerator<U> GetEnumerator() => coll.GetEnumerator().SelectMany(fn);
  }
}
