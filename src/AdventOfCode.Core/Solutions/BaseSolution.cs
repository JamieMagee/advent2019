using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Core
{
  public abstract class SolutionBase : ISolution
  {

    public virtual int PartOne(string input) => throw new NotImplementedException();

    public virtual int PartTwo(string input) => throw new NotImplementedException();

    public virtual Task<int> PartOneAsync(string input) => Task.FromResult(PartOne(input));

    public virtual Task<int> PartTwoAsync(string input) => Task.FromResult(PartTwo(input));

    public async IAsyncEnumerable<int> Solve(string input)
    {
      yield return await PartOneAsync(input);
      yield return await PartTwoAsync(input);
    }

    /// <summary>
    /// Breaks the input into lines and removes empty lines at the end.
    /// </summary>
    public static List<string> GetLines(string input)
    {
      return input.Replace("\r", string.Empty).Split('\n').ToList();
    }

  }
}
