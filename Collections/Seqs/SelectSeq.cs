using System;
using System.Collections.Generic;

namespace NetCore.Collections.Seqs {
  public class SelectSeq<T, U> : AbstractSeq<U> {
    private readonly ISeq<T> seq;
    private readonly Func<T, U> fn;

    public SelectSeq(ISeq<T> seq, Func<T, U> fn) {
      this.seq = seq;
      this.fn = fn;
    }

    public override U UnsafeNth(long index) => fn(seq.UnsafeNth(index));
    public override bool IsEmpty => seq.IsEmpty;
    public override long Count => seq.Count;
    public override IOption<U> this[long index] => seq[index].Select(fn);
    public override IEnumerator<U> GetEnumerator() => seq.GetEnumerator().Select(fn);
  }
}
