using System;
using System.Collections.Generic;
using NetCore.Utils;

namespace NetCore.Collections.Seqs {
  public class ArraySeq<T> : AbstractSeq<T> {
    private readonly T[] a;
    private readonly int start;
    private readonly int count;

    public ArraySeq(T[] a) : this(a, 0, a.Length) {
    }

    public ArraySeq(T[] a, int start, int count) {
      this.a = a;
      this.start = start;
      this.count = count;
    }

    public override IEnumerator<T> GetEnumerator() => a.GetTypedEnumerator(start, count);
    public override bool IsEmpty => false;
    public override long Count => count;

    public override T UnsafeNth(long index) {
      if (index < 0 || index > count)
        throw new IndexOutOfRangeException();

      return a[start + index];
    }

    public override IOption<T> this[long index] => index >= 0 && index < count ? a[start + index].ToOption() : Option.Empty<T>();

    public override ISeq<T> StrictSeq() {
      var dst = new T[count];
      Array.Copy(a, start, dst, 0, count);
      return dst.ToSeq();
    }

    public override ISeq<T> Slice(long start, long count) => 
      start == 0 && count >= this.count ? this : a.ToSeq(this.start + (int) start, (int) count.Min(this.count - start).Max(0));
  }
}
