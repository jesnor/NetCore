using System.Collections;
using System.Collections.Generic;

namespace NetCore.Collections.Enumerables {
  public abstract class AbstractEnumerable<T> : IEnumerable<T> {
    public abstract IEnumerator<T> GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}
