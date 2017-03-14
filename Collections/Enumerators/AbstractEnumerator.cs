using System.Collections;
using System.Collections.Generic;

namespace NetCore.Collections.Enumerators {
  public abstract class AbstractEnumerator<T> : IEnumerator<T> {
    public abstract T Current { get; }
    public abstract bool MoveNext();
    public abstract void Reset();

    object IEnumerator.Current => Current;
    public virtual void Dispose() { }
  }
}
