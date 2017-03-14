using System;
using System.Collections.Generic;
using NetCore.Utils;

namespace NetCore.Observables {
  public class Transaction : ITransaction {
    private readonly Dictionary<ITransactionObservable, object> changes = new Dictionary<ITransactionObservable, object>();

    public void AddChange<C>(ITransactionObservable<C> obs, C change) {
      if (changes.TryGetValue(obs, out var v) && v is C c) {
        changes[obs] = obs.MergeChanges(c, change);
      }
      else
        changes[obs] = change;
    }

    public void Commit() {
      foreach (var kv in changes) {
        kv.Key.Fire(this, kv.Value);
      }
    }

    public O With<O, C>(O obs)
      where O : IObservable<C>
      where C : IMonoid<C> => throw new NotImplementedException();
  }
}
