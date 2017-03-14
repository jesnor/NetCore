using System.Collections.Generic;
using NetCore.Collections.Mutables;
using NetCore.Collections.ObservableMutables;
using NetCore.Collections.Observables;
using NetCore.Observables;

namespace NetCore.Collections.Test {
  public static class Test {
    public static void TestOption() {
      TestObservable();
      var o1 = Option.Empty<int>();
      var o2 = 10.ToOption();
      IOption<int> o3 = o2.Select(v => v * 2);
      var a = Seq.Of(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);

      var b = from x in a
              where (x & 1) == 1
              select x * 3;

      var c = b.Strict();

      System.Console.WriteLine(o1);
      System.Console.WriteLine(o2);
    }

    public static void TestObservable() {
      var s = MutableSet.Of(1, 2, 3, 4).ToObservable();
      s.Subscribe(c => System.Console.WriteLine(c));
      s.Add(6);
      s.Add(3);
      s.Add(7);
      s.Remove(3);
      s.Add(3);
      System.Console.WriteLine(s);
    }
  }
}
