
using System.Threading.Tasks;
using AdventOfCode.Core;
using AdventOfCode.Core.Y2019;
using Xunit;

namespace AdventOfCode.Puzzles.Test.Solutions.Y2019
{
  public class Day04Test : IClassFixture<SolutionFixture<Day04>>
  {

    SolutionBase Solution;

    public Day04Test(SolutionFixture<Day04> solutionFixture)
    {
      Solution = solutionFixture.Solution;
    }

    [Fact]
    public async Task PartOne()
    {
      Assert.Equal(1929, await Solution.PartOneAsync(input));
    }

    [Fact]
    public async Task PartTwo()
    {
      Assert.Equal(1306, await Solution.PartTwoAsync(input));
    }

    private readonly string input = "134564-585159";
  }
}