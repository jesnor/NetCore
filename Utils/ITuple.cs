namespace NetCore.Utils {
  public interface ITuple<out T1, out T2> {
    T1 Item1 { get; }
    T2 Item2 { get; }
  }

  public interface ITuple<out T1, out T2, out T3> {
    T1 Item1 { get; }
    T2 Item2 { get; }
    T3 Item3 { get; }
  }
}
