using System.Collections.Generic;

namespace NetCore.Collections.Enumerators {
  public class SkipEnumerator<T> : AbstractEnumerator<T> {
    private readonly IEnumerator<T> en;
    private readonly long count;
    private bool atEnd;

    public SkipEnumerator(IEnumerator<T> en, long count) {
      this.en = en;
      this.count = count;
      Skip();
    }

    public override T Current => en.Current;
    public override bool MoveNext() => !atEnd && en.MoveNext();

    public override void Reset() {
      en.Reset();
      Skip();
    }

    private void Skip() {
      atEnd = false;

      for (long i = 0; i < count; i++) {
        if (!en.MoveNext()) {
          atEnd = true;
          break;
        }
      }
    }
  }
}
