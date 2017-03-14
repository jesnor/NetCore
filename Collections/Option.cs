using System;
using NetCore.Collections.Options;

namespace NetCore.Collections {
  public static class Option {
    public static IOption<T> Where<T>(this IOption<T> o, Func<T, bool> pred) => o.IsEmpty || !pred(o.UnsafeFirst) ? Option.Empty<T>() : o;
    public static IOption<U> Select<T, U>(this IOption<T> o, Func<T, U> fn) => o.IsEmpty ? Option.Empty<U>() : fn(o.UnsafeFirst).ToOption();
    public static IOption<U> SelectMany<T, U>(this IOption<T> o, Func<T, IOption<U>> fn) => o.IsEmpty ? Option.Empty<U>() : fn(o.UnsafeFirst);
    public static ISeq<U> SelectMany<T, U>(this IOption<T> o, Func<T, ISeq<U>> fn) => o.IsEmpty ? Option.Empty<U>() : fn(o.UnsafeFirst);

    public static IOption<T> Empty<T>() => None<T>.Instance;
    public static IOption<T> ToOption<T>(this T value) => new Some<T>(value);
  }
}
