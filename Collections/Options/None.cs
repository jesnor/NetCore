using System;
using System.Collections;
using System.Collections.Generic;
using NetCore.Collections.Seqs;

namespace NetCore.Collections.Options {
  public class None<T> : AbstractSeq<T>, IOption<T> {
    public static readonly None<T> Instance = new None<T>();

    private None() {
    }

    public override long Count => 0;
    public override bool IsEmpty => true;
    public override T UnsafeNth(long index) => throw new IndexOutOfRangeException();

    public override IEnumerator<T> GetEnumerator() => Enumerator.Empty<T>();

    public override bool Equals(object obj) => obj is IEnumerable && ((IEnumerable) obj).IsEmpty();
    public override int GetHashCode() => 0;
    public override string ToString() => "None";
    public override ISeq<T> StrictSeq() => this;
  }
}
