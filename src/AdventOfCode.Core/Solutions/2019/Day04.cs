

using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace AdventOfCode.Core.Y2019
{
  public sealed class Day04 : SolutionBase
  {

    public override int PartOne(string input)
    {
      var (min, max) = ParseRange(input);
      return Enumerable.Range(min, max - min)
        .Select(NumToChars)
        .Where((x) => HasAnyDoubleDigits(x) && HasIncreasingDigits(x))
        .Count();
    }

    public override int PartTwo(string input)
    {
      var (min, max) = ParseRange(input);
      return Enumerable.Range(min, max - min)
        .Select(NumToChars)
        .Where((x) => HasOnlyOneDoubleDigits(x) && HasIncreasingDigits(x))
        .Count();
    }

    private char[] NumToChars(int input) => input.ToString().ToArray();

    private bool HasOnlyOneDoubleDigits(char[] input)
    {
      var inputList = new List<char>(input);
      inputList.Insert(0, ' ');
      inputList.Add(' ');
      return inputList.Window(4).Any(x => x[0] != x[1] && x[1] == x[2] && x[2] != x[3]);
    }

    private bool HasAnyDoubleDigits(char[] input) => input.Window(2).Any(x => x[0] == x[1]);

    private bool HasIncreasingDigits(char[] input) => input.Window(2).All(x => x[0] <= x[1]);

    private static (int lower, int upper) ParseRange(string input)
    {
      var minMax = input.Split("-").Select(x => Convert.ToInt32(x)).ToArray();
      return (minMax[0], minMax[1]);
    }
  }
}
