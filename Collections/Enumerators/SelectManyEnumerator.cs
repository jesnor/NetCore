using System;
using System.Collections.Generic;

namespace NetCore.Collections.Enumerators {
  public class SelectManyEnumerator<T, U> : AbstractEnumerator<U> {
    private readonly IEnumerator<T> en;
    private readonly Func<T, IEnumerable<U>> fn;
    private IEnumerator<U> currentEn = Enumerator.Empty<U>();

    public SelectManyEnumerator(IEnumerator<T> en, Func<T, IEnumerable<U>> fn) {
      this.en = en;
      this.fn = fn;
    }

    public override U Current => currentEn.Current;

    public override bool MoveNext() {
      while (!currentEn.MoveNext()) {
        if (!en.MoveNext())
          return false;

        currentEn = fn(en.Current).GetEnumerator();
      }

      return true;
    }

    public override void Reset() {
      currentEn = Enumerator.Empty<U>();
      en.Reset();
    }

    public override void Dispose() {
      currentEn = Enumerator.Empty<U>();
      en.Dispose();
    }
  }
}
