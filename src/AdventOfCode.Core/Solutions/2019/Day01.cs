using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Core.Y2019
{
  public sealed class Day01 : SolutionBase
  {

    public override int PartOne(string input)
    {
      return GetModules(input).Sum(mass => mass / 3 - 2);
    }

    public override int PartTwo(string input)
    {
      return GetModules(input).Sum(mass =>
      {
        var sum = 0;
        while ((mass = mass / 3 - 2) > 0)
        {
          sum += mass;
        }

        return sum;
      });
    }

    private static IEnumerable<int> GetModules(string input) => GetLines(input).Select(x => Convert.ToInt32(x));
  }
}