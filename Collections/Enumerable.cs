using System.Collections;
using System.Collections.Generic;
using NetCore.Utils;

namespace NetCore.Collections {
  public static class Enumerable {
    public static T FirstOrElse<T>(this IEnumerable<T> e, T v) => e.GetEnumerator().Use(en => en.MoveNext() ? en.Current : v);

    public static bool IsEmpty(this IEnumerable e) => e.GetEnumerator().IsEmpty();
    public static bool IsEmpty<T>(this IEnumerable<T> e) => e.GetEnumerator().Use(en => en.IsEmpty());

    public static bool ContainsJust(this IEnumerable e, object value) => e.GetEnumerator().ContainsJust(value);
    public static bool ContainsJust<T>(this IEnumerable<T> e, object value) => e.GetEnumerator().Use(en => en.ContainsJust(value));

    public static bool ElementEquals(this IEnumerable e1, IEnumerable e2) => e1.GetEnumerator().ElementEquals(e1.GetEnumerator());
    public static bool ElementEquals<T, U>(this IEnumerable<T> e1, IEnumerable<U> e2) => e1.GetEnumerator().Use(en1 => e2.GetEnumerator().Use(en2 => en1.ElementEquals(en2)));

    public static int ElementHashCode(this IEnumerable e) => e.GetEnumerator().ElementHashCode();
    public static int ElementHashCode<T, U>(this IEnumerable<T> e) => e.GetEnumerator().Use(en => en.ElementHashCode());

    public static string ElementToString(this IEnumerable e, int maxSize = 10, string delim = ", ") => e.GetEnumerator().ElementToString(maxSize, delim);
    public static string ElementToString<T, U>(this IEnumerable<T> e, int maxSize = 10, string delim = ", ") => e.GetEnumerator().Use(en => en.ElementToString(maxSize, delim));

    public static IOption<T> Nth<T>(this IEnumerable<T> e, long index) => e.GetEnumerator().Use(en => en.Nth(index));
  }
}
