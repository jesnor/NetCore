using System;
using System.Collections.Generic;

namespace NetCore.Observables {
  public class Signal<T> : IObservable<T> {
    private class Subscription : IDisposable {
      private Signal<T> signal;
      private IObserver<T> obs;

      public Subscription(Signal<T> signal, IObserver<T> obs) {
        this.signal = signal;
        this.obs = obs;
      }

      public IObserver<T> Observer => obs;

      public void Dispose() {
        if (obs != null) {
          signal.Remove(this);
          obs = null;
        }
      }
    }

    private List<Subscription> subscriptions;

    public IDisposable Subscribe(IObserver<T> obs) {
      if (subscriptions == null)
        subscriptions = new List<Subscription>();

      var s = new Subscription(this, obs);
      subscriptions.Add(s);
      return s;
    }

    public void Fire(T v) {
      if (subscriptions != null) {
        foreach (var s in subscriptions)
          s.Observer.OnNext(v);
      }
    }

    private void Remove(Subscription s) {
      subscriptions.Remove(s);
    }
  }
}
