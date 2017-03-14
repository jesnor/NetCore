using System;

namespace NetCore.Utils {
  public static class Util {
    public static bool SafeEquals<T, U>(this T v1, U v2) => v1 == null ? v2 == null : v1.Equals(v2);
    public static int SafeHashCode(this object v) => v == null ? 0 : v.GetHashCode();
    public static string SafeToString(this object v) => v == null ? "null" : v.ToString();
    public static int HashWith(this object v1, object v2) => v1.SafeHashCode() * 37 + v2.SafeHashCode();
    public static int HashWith(this object v1, object v2, object v3) => v1.HashWith(v2) * 37 + v3.SafeHashCode();
    public static int HashWith(this object v1, object v2, object v3, object v4) => v1.HashWith(v2, v3) * 37 + v4.SafeHashCode();
    public static int Min(this int a, int b) => Math.Min(a, b);
    public static long Min(this long a, long b) => Math.Min(a, b);
    public static int Max(this int a, int b) => Math.Max(a, b);
    public static long Max(this long a, long b) => Math.Max(a, b);

    public static U Use<T, U>(this T d, Func<T, U> fn) where T : IDisposable {
      using (d) {
        return fn(d);
      }
    }
  }
}
