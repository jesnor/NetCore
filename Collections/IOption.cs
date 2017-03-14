namespace NetCore.Collections {
  /// <summary>
  /// Either empty or contains one value
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IOption<out T> : ISeq<T> {
  }
}
