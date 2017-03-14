using System;

namespace NetCore.Collections.Mutables.Sets {
  public class SetWrapper<T> : NetCore.Collections.Sets.SetWrapper<T>, IMutableSet<T> {
    public SetWrapper(System.Collections.Generic.ISet<T> set) : base(set) { }

    public bool Add(T item) => set.Add(item);
    public bool Remove(T item) => set.Remove(item);
  }
}
