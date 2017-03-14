using System;
using System.Collections.Generic;

namespace NetCore.Collections.Enumerators {
  public class TakeEnumerator<T> : AbstractEnumerator<T> {
    private readonly IEnumerator<T> en;
    private readonly long count;
    private long index = -1;

    public TakeEnumerator(IEnumerator<T> en, long count) {
      this.en = en;
      this.count = count;
    }

    public override T Current => en.Current;

    public override void Reset() {
      en.Reset();
      index = -1;
    }

    public override bool MoveNext() => ++index < count && en.MoveNext();
  }
}
