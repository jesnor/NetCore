using System;
using System.Collections.Generic;
using NetCore.Collections.Collections;
using NetCore.Utils;

namespace NetCore.Collections.Sets {
  public abstract class AbstractSet<T> : AbstractCollection<T>, ISet<T> {
    public override ICollection<T> Strict() => StrictSet();
    public virtual ISet<T> StrictSet() => new HashSet<T>(this).ToISet();

    public override int GetHashCode() { 
      int s = 0;

      // Order invariant hash code
      foreach (var e in this)
        s += e.SafeHashCode();

      return s;
    }

    public override bool Equals(object obj) {
      if (obj is ISet<T> s) {
        if (s.Count != Count)
          return false;

        foreach (var e in this) {
          if (!s.Contains(e))
            return false;
        }

        return true;
      }
      else
        return false;
    }

    public override string ToString() => "Set(" + this.ElementToString() + ")";
  }
}
