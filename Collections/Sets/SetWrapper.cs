using System;
using System.Collections.Generic;

namespace NetCore.Collections.Sets {
  public class SetWrapper<T> : AbstractSet<T> {
    protected readonly System.Collections.Generic.ISet<T> set;

    public SetWrapper(System.Collections.Generic.ISet<T> set) {
      this.set = set;
    }

    public override bool IsEmpty => set.Count == 0;
    public override long Count => set.Count;
    public override bool Contains(object value) => value is T t && set.Contains(t);
    public override IEnumerator<T> GetEnumerator() => set.GetEnumerator();
  }
}
