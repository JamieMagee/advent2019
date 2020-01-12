using System;
using System.Collections.Generic;

namespace AdventOfCode.Core
{
  public interface ISolutionHandler
  {
    IReadOnlyDictionary<int, Type> Solutions { get; }
  }
}