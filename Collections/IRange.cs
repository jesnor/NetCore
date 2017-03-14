using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Collections {
  public interface IRange<out T> : ISeq<T> {
    T Start { get; }
  }
}
