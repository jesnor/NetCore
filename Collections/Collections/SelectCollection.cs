using System;
using System.Collections.Generic;

namespace NetCore.Collections.Collections {
  public class SelectCollection<T, U> : AbstractCollection<U> {
    private readonly ICollection<T> coll;
    private readonly Func<T, U> fn;

    public SelectCollection(ICollection<T> coll, Func<T, U> fn) {
      this.coll = coll;
      this.fn = fn;
    }

    public override bool IsEmpty => coll.IsEmpty;
    public override long Count => coll.Count;
    public override IEnumerator<U> GetEnumerator() => coll.GetEnumerator().Select(fn);
  }
}
