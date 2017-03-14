using System;
using NetCore.Utils;

namespace NetCore.Observables {
  public interface ITransaction {
    O With<O, C>(O obs) where O : IObservable<C> where C : IMonoid<C>;
  }
}
