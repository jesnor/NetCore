using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore.Collections.Sets {
  public class WhereSet<T> : AbstractSet<T> {
    protected readonly ICollection<T> coll;
    protected readonly Func<T, bool> pred;

    public WhereSet(ICollection<T> coll, Func<T, bool> pred) {
      this.coll = coll;
      this.pred = pred;
    }

    public override bool IsEmpty => GetEnumerator().IsEmpty();
    public override long Count => coll.LongCount(pred);
    public override IEnumerator<T> GetEnumerator() => coll.GetEnumerator().Where(pred);
  }
}
