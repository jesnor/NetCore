namespace NetCore.Collections {
  public interface ISet : ICollection {
  }

  public interface ISet<out T> : ISet, ICollection<T> {
    ISet<T> StrictSet();
  }
}
