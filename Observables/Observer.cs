using System;

namespace NetCore.Observables {
  public static class Observer {
    private class ActionObserver<T> : IObserver<T> {
      private readonly Action<T> onNext;

      public ActionObserver(Action<T> onNext) {
        this.onNext = onNext;
      }

      public void OnCompleted() {}
      public void OnError(Exception error) { }
      public void OnNext(T value) => onNext(value);
    }

    public static IObserver<T> Of<T>(Action<T> a) => new ActionObserver<T>(a);
    public static IDisposable Subscribe<T>(this IObservable<T> obs, Action<T> a) => obs.Subscribe(new ActionObserver<T>(a));
  }
}
