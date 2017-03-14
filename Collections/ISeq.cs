namespace NetCore.Collections {
  /// <summary>
  /// An ordered sequence of values with efficient random access to the elements
  /// </summary>
  public interface ISeq : ICollection {
  }

  /// <summary>
  /// An ordered sequence of values with efficient random access to the elements
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface ISeq<out T> : ISeq, ICollection<T> {
    T UnsafeFirst { get; }
    T UnsafeNth(long index);
    IOption<T> this[long index] { get; }

    /// <summary>
    /// Returns a slice of this sequence.
    /// 
    /// Note that this method is lazy and doesn't copy the elements from this stream so if this stream changes the slice will change too. 
    /// Use ISeq.Strict() to make a copy of the slice.
    /// </summary>
    /// <param name="start">Start index of the slice</param>
    /// <param name="count">Maximum number of elements in the slice, might be less if this sequence doesn't contain enough elements</param>
    /// <returns></returns>
    ISeq<T> Slice(long start, long count);

    /// <summary>
    /// Returns a sequence that contains the same elements as this one and doesn't hold any references to unreachable elements.
    /// </summary>
    /// <returns></returns>
    ISeq<T> StrictSeq();
  }
}
