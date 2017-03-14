using System;
using System.Collections.Generic;

namespace NetCore.Collections.Enumerators {
  public class SelectEnumerator<T, U> : AbstractEnumerator<U> {
    private readonly IEnumerator<T> en;
    private readonly Func<T, U> fn;

    public SelectEnumerator(IEnumerator<T> en, Func<T, U> fn) {
      this.en = en;
      this.fn = fn;
    }

    public override U Current => fn(en.Current);
    public override bool MoveNext() => en.MoveNext();
    public override void Reset() => en.Reset();
    public override void Dispose() => en.Dispose();
  }
}
