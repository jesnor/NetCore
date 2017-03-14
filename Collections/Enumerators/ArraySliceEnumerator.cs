namespace NetCore.Collections.Enumerators {
  public class ArraySliceEnumerator<T> : AbstractEnumerator<T> {
    private readonly T[] array;
    private readonly int start;
    private readonly int count;
    private int index;

    public ArraySliceEnumerator(T[] array, int start, int count) {
      this.array = array;
      this.start = start;
      this.count = count;
      index = start - 1;
    }

    public override T Current => array[index];

    public override bool MoveNext() {
      index++;
      return index < start + count;
    }

    public override void Reset() => index = start - 1;
  }
}
