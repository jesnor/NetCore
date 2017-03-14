using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NetCore.Collections.Enumerators;
using NetCore.Utils;

namespace NetCore.Collections {
  public static class Enumerator {
    public static IEnumerator<T> Empty<T>() => EmptyEnumerator<T>.Instance;
    public static IEnumerator<T> Of<T>(T value) => new SingletonEnumerator<T>(value);
    public static IEnumerator<T> Where<T>(this IEnumerator<T> en, Func<T, bool> pred) => new WhereEnumerator<T>(en, pred);
    public static IEnumerator<U> Select<T, U>(this IEnumerator<T> en, Func<T, U> fn) => new SelectEnumerator<T, U>(en, fn);
    public static IEnumerator<U> SelectMany<T, U>(this IEnumerator<T> en, Func<T, IEnumerable<U>> fn) => new SelectManyEnumerator<T, U>(en, fn);

    public static bool IsEmpty(this IEnumerator en) => !en.MoveNext();
    public static bool ContainsJust(this IEnumerator en, object value) => en.MoveNext() && value.SafeEquals(en.Current) && !en.MoveNext();

    public static bool Contains(this IEnumerator en, object value) {
      while (en.MoveNext()) {
        if (en.Current.SafeEquals(value))
          return true;
      }

      return false;
    }

    public static IOption<T> Nth<T>(this IEnumerator<T> en, long index) {
      if (index < 0)
        return Option.Empty<T>();

      for (long i = 0; i <= index; i++) {
        if (!en.MoveNext())
          return Option.Empty<T>();
      }

      return en.Current.ToOption();
    }

    public static bool ElementEquals(this IEnumerator e1, IEnumerator e2) {
      while (e1.MoveNext()) {
        if (!e2.MoveNext() || !e1.Current.SafeEquals(e2.Current))
          return false;
      }

      return !e2.MoveNext();
    }

    public static long LongSize(this IEnumerator e) {
      long s = 0;

      while (e.MoveNext())
        s++;

      return s;
    }

    public static int ElementHashCode(this IEnumerator e) {
      var x = 0;

      while (e.MoveNext()) {
        x = x * 37 + e.Current.SafeHashCode();
      }

      return x;
    }

    public static string ElementToString(this IEnumerator e, int maxSize, string delim = ", ") {
      var x = new StringBuilder();
      var size = 0;

      while (e.MoveNext()) {
        if (x.Length > 0)
          x.Append(delim);

        size++;

        if (size > maxSize) {
          x.Append("...");
          break;
        }

        x.Append(e.Current.SafeToString());
      }

      return x.ToString();
    }

    public static IEnumerator<T> GetTypedEnumerator<T>(this T[] array) => new ArrayEnumerator<T>(array);
    public static IEnumerator<T> GetTypedEnumerator<T>(this T[] array, int start, int count) => new ArraySliceEnumerator<T>(array, start, count);
    public static IEnumerator<T> Skip<T>(this IEnumerator<T> en, long count) => new SkipEnumerator<T>(en, count);
    public static IEnumerator<T> Take<T>(this IEnumerator<T> en, long count) => new TakeEnumerator<T>(en, count);
  }
}
