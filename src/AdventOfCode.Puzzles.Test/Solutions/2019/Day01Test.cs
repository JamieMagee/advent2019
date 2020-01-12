
using System.Threading.Tasks;
using AdventOfCode.Core;
using AdventOfCode.Core.Y2019;
using Xunit;

namespace AdventOfCode.Puzzles.Test.Solutions.Y2019
{
  public class Day01Test : IClassFixture<SolutionFixture<Day01>>
  {

    SolutionBase Solution;

    public Day01Test(SolutionFixture<Day01> solutionFixture)
    {
      this.Solution = solutionFixture.Solution;
    }

    [Fact]
    public async Task PartOne()
    {
      Assert.Equal(2, await Solution.PartOneAsync("12"));
      Assert.Equal(2, await Solution.PartOneAsync("14"));
      Assert.Equal(654, await Solution.PartOneAsync("1969"));
      Assert.Equal(33583, await Solution.PartOneAsync("100756"));
    }

    [Fact]
    public async Task PartTwo()
    {
      Assert.Equal(2, await Solution.PartTwoAsync("12"));
      Assert.Equal(966, await Solution.PartTwoAsync("1969"));
      Assert.Equal(50346, await Solution.PartTwoAsync("100756"));
    }
  }
}