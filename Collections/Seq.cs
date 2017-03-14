using System;
using System.Collections.Generic;
using NetCore.Collections.Seqs;

namespace NetCore.Collections {
  public static partial class Seq {
    public static T FirstOrElse<T>(this ISeq<T> seq, T v) => seq.IsEmpty ? v : seq.UnsafeFirst;
    public static IOption<T> FirstOpt<T>(this ISeq<T> seq) => seq[0];
    public static ISeq<T> Take<T>(this ISeq<T> seq, long count) => seq.Slice(0, count);
    public static ISeq<T> Skip<T>(this ISeq<T> seq, long count) => seq.Slice(count, seq.Count - count);
    public static ISeq<T> Tail<T>(this ISeq<T> seq) => seq.Skip(1);

    public static ISeq<U> Select<T, U>(this ISeq<T> s, Func<T, U> fn) => new SelectSeq<T, U>(s, fn);

    public static ISeq<T> Of<T>(params T[] values) => new ArraySeq<T>(values);
    public static ISeq<T> ToSeq<T>(this T[] array) => new ArraySeq<T>(array);

    public static ISeq<T> ToSeq<T>(this T[] array, int start, int count) {
      if (start < 0 || count < 0)
        throw new IndexOutOfRangeException();

      return 
        start >= array.Length || count == 0 ? Empty<T>() : 
        start == 0 && count >= array.Length ? new ArraySeq<T>(array) : 
        new ArraySeq<T>(array, start, Math.Min(array.Length - start, count));
    }

    public static ISeq<T> Empty<T>() => Option.Empty<T>();
  }
}
