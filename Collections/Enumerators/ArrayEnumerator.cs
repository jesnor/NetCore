namespace NetCore.Collections.Enumerators {
  public class ArrayEnumerator<T> : AbstractEnumerator<T> {
    private readonly T[] array;
    private int index = -1;

    public ArrayEnumerator(T[] array) {
      this.array = array;
    }

    public override T Current => array[index];

    public override bool MoveNext() {
      index++;
      return index < array.Length;
    }

    public override void Reset() => index = -1;
  }
}
