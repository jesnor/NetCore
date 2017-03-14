using System;
using System.Collections;
using System.Collections.Generic;

namespace NetCore.Collections {
  /// <summary>
  /// A collection with a size
  /// </summary>
  public interface ICollection : IEnumerable {
    long Count { get; }
    bool IsEmpty { get; }
    bool Contains(object value);
  }

  /// <summary>
  /// A collection with a size
  /// </summary>
  public interface ICollection<out T> : ICollection, IEnumerable<T> {
    /// <summary>
    /// Returns a collection that contains the same elements as this one and doesn't hold any references to other elements.
    /// </summary>
    /// <returns></returns>
    ICollection<T> Strict();
  }
}
