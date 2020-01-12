using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode.Core
{
  public interface ISolution
  {
    Task<int> PartOneAsync(string input);

    Task<int> PartTwoAsync(string input);

    IAsyncEnumerable<int> Solve(string input);

  }
}