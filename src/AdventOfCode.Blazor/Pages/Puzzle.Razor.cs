using AdventOfCode.Blazor.Services;
using AdventOfCode.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventOfCode.Blazor.Pages
{
  public sealed partial class Puzzle : ComponentBase
  {
    [Parameter]
    public int Year { get; set; } = 2019;
    [Parameter]
    public int Day { get; set; }

    [Inject]
    private ISolutionHandler SolutionHandler { get; set; }

    [Inject]
    private IInputHandler InputHandler { get; set; }

    private ISolution SolutionInstance { get; set; }

    private object[] Results { get; set; }

    protected override Task OnParametersSetAsync() => InitAsync();

    private async Task InitAsync()
    {
      Results = InputHandler.GetResults(Year, Day);
      if (SolutionHandler.Solutions.TryGetValue(Day, out var solutionType))
      {
        SolutionInstance = Activator.CreateInstance(solutionType) as ISolution;
      }
      InputHandler.GetResults(Year, Day);
    }

    private async Task SolveAsync()
    {
      foreach (var (part, index) in new Func<string, Task<int>>[] { SolutionInstance.PartOneAsync, SolutionInstance.PartTwoAsync }.Select((x, i) => (x, i)))
      {
        Results[index] = await ExceptionToResult(part);
      }
    }

    private async Task<object> ExceptionToResult(Func<string, Task<int>> func)
    {
      var input = await InputHandler.GetInputAsync(Year, Day);
      try
      {
        return await (func(input) ?? Task.FromResult<int>(0));
      }
      catch (Exception exception)
      {
        return exception;
      }
    }
  }
}