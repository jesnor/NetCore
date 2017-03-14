namespace NetCore.Collections.Enumerators {
  public class SingletonEnumerator<T> : AbstractEnumerator<T> {
    private readonly T value;
    private bool hasValue = true;

    public SingletonEnumerator(T value) {
      this.value = value;
    }

    public override T Current => value;

    public override bool MoveNext() {
      var h = hasValue;
      hasValue = false;
      return hasValue;
    }

    public override void Reset() {
      hasValue = true;
    }
  }
}
