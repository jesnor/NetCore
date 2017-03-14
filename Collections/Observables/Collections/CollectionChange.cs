using NetCore.Utils;

namespace NetCore.Collections.Observables.Collections {
  public class CollectionChange<T> : ICollectionChange<T> {
    private readonly ICollection<T> added;
    private readonly ICollection<T> removed;

    public CollectionChange(ICollection<T> added, ICollection<T> removed) {
      this.added = added;
      this.removed = removed;
    }

    public ICollection<T> Added => added;
    public ICollection<T> Removed => removed;

    public override bool Equals(object obj) => obj is ICollectionChange<T> sc && added.SafeEquals(sc.Added) && removed.SafeEquals(sc.Removed);
    public override int GetHashCode() => added.HashWith(removed);
    public override string ToString() => "CollectionChange(Added = " + added + ", Removed = " + removed + ")";
  }
}
