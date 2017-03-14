using System;
using NetCore.Utils;

namespace NetCore.Observables {
  public interface ITransactionObservable {
    void Fire(ITransaction tr, object change);
  }

  public interface ITransactionObservable<C> : IObservable<ITuple<ITransaction, C>>, ITransactionObservable {
    C MergeChanges(C c1, C c2);
  }
}
