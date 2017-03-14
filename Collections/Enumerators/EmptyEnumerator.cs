using System;

namespace NetCore.Collections.Enumerators {
  public class EmptyEnumerator<T> : AbstractEnumerator<T> {
    public static readonly EmptyEnumerator<T> Instance = new EmptyEnumerator<T>();

    public override T Current => throw new IndexOutOfRangeException();
    public override bool MoveNext() => false;
    public override void Reset() { }
  }
}
