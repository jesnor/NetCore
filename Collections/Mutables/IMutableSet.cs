namespace NetCore.Collections.Mutables {
  public interface IMutableSet<T> : ISet<T> {
    bool Add(T item);
    bool Remove(T item);
  }
}
