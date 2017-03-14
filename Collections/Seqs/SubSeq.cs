using System;
using System.Collections.Generic;
using NetCore.Utils;

namespace NetCore.Collections.Seqs {
  public class SubSeq<T> : AbstractSeq<T> {
    private readonly ISeq<T> seq;
    private readonly long start;
    private readonly long count;

    public SubSeq(ISeq<T> seq, long start, long count) {
      this.seq = seq;
      this.start = start;
      this.count = count;
    }

    public override bool IsEmpty => start >= seq.Count;
    public override long Count => count.Min(seq.Count - start).Max(0);

    public override T UnsafeNth(long index) {
      if (index >= 0 && index < count)
        return seq.UnsafeNth(start + index);
      else
        throw new IndexOutOfRangeException();
    }

    public override IOption<T> this[long index] => index >= 0 && index < count ? seq[start + index] : Option.Empty<T>();
    public override IEnumerator<T> GetEnumerator() => seq.GetEnumerator().Skip(start).Take(count);

    public override ISeq<T> Slice(long start, long count) {
      if (start < 0 || count < 0)
        throw new IndexOutOfRangeException();

      return count == 0 ? Seq.Empty<T>() : start == 0 && count == Count ? this : new SubSeq<T>(seq, this.start + start, count);
    }
  }
}
