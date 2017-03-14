using System;
using System.Collections.Generic;

namespace NetCore.Collections.Enumerators {
  public class WhereEnumerator<T> : AbstractEnumerator<T> {
    private readonly IEnumerator<T> en;
    private readonly Func<T, bool> pred;

    public WhereEnumerator(IEnumerator<T> en, Func<T, bool> pred) {
      this.en = en;
      this.pred = pred;
    }

    public override T Current => en.Current;

    public override bool MoveNext() {
      do {
        if (!en.MoveNext())
          return false;
      } while (!pred(en.Current));

      return true;
    }

    public override void Reset() => en.Reset();
    public override void Dispose() => en.Dispose();
  }
}
