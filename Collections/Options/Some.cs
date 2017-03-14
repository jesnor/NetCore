using System;
using System.Collections;
using System.Collections.Generic;
using NetCore.Collections.Seqs;
using NetCore.Utils;

namespace NetCore.Collections.Options {
  public class Some<T> : AbstractSeq<T>, IOption<T> {
    private readonly T value;

    public Some(T value) {
      this.value = value;
    }

    public override T UnsafeNth(long index) {
      if (index != 0)
        throw new IndexOutOfRangeException();

      return value;
    }

    public override bool IsEmpty => false;
    public override long Count => 1;
    public override IEnumerator<T> GetEnumerator() => Enumerator.Of(value);

    public override bool Equals(object obj) => obj is IEnumerable && ((IEnumerable) obj).ContainsJust(value);
    public override int GetHashCode() => value.HashWith(1);
    public override string ToString() => "Some(" + value + ")";
    public override ISeq<T> StrictSeq() => this;
  }
}
