using System;
using AdventOfCode.Core;

namespace AdventOfCode.Puzzles.Test
{
  public class SolutionFixture<TSolution> where TSolution : ISolution
  {
    public TSolution Solution { get; }

    public SolutionFixture()
    {
      Solution = Activator.CreateInstance<TSolution>();
    }
  }
}
