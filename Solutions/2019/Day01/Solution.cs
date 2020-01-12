using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Lib;
using static System.Math;

namespace AdventOfCode.Y2019.Day01
{
  class Solution : Solver
  {

    public IEnumerable<object> Solve(string input)
    {
      yield return Solve(input, false);
      yield return Solve(input, true);
    }

    private int Solve(string input, bool recursive)
    {
      var weights = new Queue<int>(input.Split("\n").Select(x => int.Parse(x)));
      var total = 0;
      while (weights.Any())
      {
        var fuel = (int)(Floor(weights.Dequeue() / 3.0) - 2);
        if (fuel > 0)
        {
          if (recursive)
          {
            weights.Enqueue(fuel);
          }
          total += fuel;
        }
      }
      return total;
    }
  }
}
