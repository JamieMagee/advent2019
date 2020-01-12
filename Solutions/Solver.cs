using System.Collections.Generic;

namespace AdventOfCode.Lib
{
  interface Solver
  {
    IEnumerable<object> Solve(string input);
  }
}