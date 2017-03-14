namespace NetCore.Collections.Observables {
  public interface ICollectionChange<out T> {
    ICollection<T> Added { get; }
    ICollection<T> Removed { get; }
  }
}
