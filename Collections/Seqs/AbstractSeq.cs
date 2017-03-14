using System;
using NetCore.Collections.Collections;

namespace NetCore.Collections.Seqs {
  public abstract class AbstractSeq<T> : AbstractCollection<T>, ISeq<T> {
    public virtual T UnsafeFirst => UnsafeNth(0);
    public virtual T UnsafeNth(long index) => this.Nth(index).UnsafeNth(0);
    public virtual IOption<T> this[long index] => this.Nth(index);
    public override ICollection<T> Strict() => StrictSeq();

    public virtual ISeq<T> StrictSeq() {
      if (Count > int.MaxValue)
        throw new IndexOutOfRangeException();

      var a = new T[Count];
      var i = 0;

      foreach (var v in this) {
        a[i++] = v;
      }

      return a.ToSeq();
    }

    public virtual ISeq<T> Slice(long start, long count) {
      if (start < 0 || count < 0)
        throw new IndexOutOfRangeException();

      return count == 0 ? Seq.Empty<T>() : new SubSeq<T>(this, start, count);
    }

    public override bool Equals(object obj) => obj is ISeq && this.ElementEquals((ISeq) obj);
    public override int GetHashCode() => this.ElementHashCode();
    public override string ToString() => "Seq(" + this.ElementToString() + ")";
  }
}
