namespace NetCore.Collections.Mutables {
  public interface IMutableSeq<T> : ISeq<T> {
    void Insert(long index, T item);
    void InsertSeq(long index, ISeq<T> seq);
    T Remove(long index);
    void RemoveSeq(long index, long count);
  }
}
