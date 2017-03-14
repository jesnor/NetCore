using NetCore.Collections.Mutables;
using NetCore.Collections.Observables;

namespace NetCore.Collections.ObservableMutables {
  public interface IObservableMutableSet<T> : IMutableSet<T>, IObservableCollection<T> {
  }
}
