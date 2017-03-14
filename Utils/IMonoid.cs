namespace NetCore.Utils {
  public interface IMonoid<T> where T : IMonoid<T> {
    T Append(T v);
  }
}
