namespace NetCore.Utils.Tuples {
  public abstract class AbstractTuple<T1, T2> : ITuple<T1, T2> {
    public abstract T1 Item1 { get; }
    public abstract T2 Item2 { get; }

    public override bool Equals(object obj) => obj is ITuple<T1, T2> t && t.Item1.SafeEquals(Item1) && t.Item2.SafeEquals(Item2);
    public override int GetHashCode() => Item1.HashWith(Item2);
    public override string ToString() => Item1 + " -> " + Item2;
  }

  public abstract class AbstractTuple<T1, T2, T3> : ITuple<T1, T2, T3> {
    public abstract T1 Item1 { get; }
    public abstract T2 Item2 { get; }
    public abstract T3 Item3 { get; }

    public override bool Equals(object obj) => obj is ITuple<T1, T2> t && t.Item1.SafeEquals(Item1) && t.Item2.SafeEquals(Item2) && t.Item2.SafeEquals(Item3);
    public override int GetHashCode() => Item1.HashWith(Item2, Item3);
    public override string ToString() => "(" + Item1 + ", " + Item2 + ", " + Item3 + ")";
  }
}
