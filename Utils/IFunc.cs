using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Utils {
  public interface IFunc<in I, out O> {
    O Apply(I a);
  }
}
