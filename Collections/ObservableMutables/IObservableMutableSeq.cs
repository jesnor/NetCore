using NetCore.Collections.Mutables;
using NetCore.Collections.Observables;

namespace NetCore.Collections.ObservableMutables {
  public interface IObservableMutableSeq<T> : IMutableSeq<T>, IObservableSeq<T> {
  }
}
