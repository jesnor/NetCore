using System;
using System.Collections.Generic;
using NetCore.Collections.Mutables.Sets;

namespace NetCore.Collections.Mutables {
  public static class MutableSet {
    public static IMutableSet<T> Of<T>(params T[] items) => new SetWrapper<T>(new HashSet<T>(items));
  }
}
