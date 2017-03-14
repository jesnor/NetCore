using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Utils.Tuples {
  public class Tuple<T1, T2> : AbstractTuple<T1, T2> {
    private readonly T1 item1;
    private readonly T2 item2;

    public Tuple(T1 item1, T2 item2) {
      this.item1 = item1;
      this.item2 = item2;
    }

    public override T1 Item1 => item1;
    public override T2 Item2 => item2;
  }

  public class Tuple<T1, T2, T3> : AbstractTuple<T1, T2, T3> {
    private readonly T1 item1;
    private readonly T2 item2;
    private readonly T3 item3;

    public Tuple(T1 item1, T2 item2, T3 item3) {
      this.item1 = item1;
      this.item2 = item2;
      this.item3 = item3;
    }

    public override T1 Item1 => item1;
    public override T2 Item2 => item2;
    public override T3 Item3 => item3;
  }
}
