using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Core
{
  public class SolutionHandler : ISolutionHandler
  {
    public IReadOnlyDictionary<int, Type> Solutions { get; }

    public SolutionHandler()
    {
      Solutions = GatherPuzzleSolutions();
    }

    private static Dictionary<int, Type> GatherPuzzleSolutions()
    {
      var solutionsByDay = new Dictionary<int, Type>();
      var solutionInterface = typeof(ISolution);
      var solutionTypes = solutionInterface.Assembly.GetTypes()
          .Where(x => solutionInterface.IsAssignableFrom(x) && !x.IsAbstract)
          .OrderBy(x => x.FullName)
          .ToList();

      foreach (var item in solutionTypes.Select((solution, i) => new { i, solution }))
      {
        solutionsByDay.Add(item.i + 1, item.solution);
      }

      return solutionsByDay;
    }
  }
}