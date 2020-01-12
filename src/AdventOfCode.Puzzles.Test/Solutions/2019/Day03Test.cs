
using System.Threading.Tasks;
using AdventOfCode.Core;
using AdventOfCode.Core.Y2019;
using Xunit;

namespace AdventOfCode.Puzzles.Test.Solutions.Y2019
{
  public class Day03Test : IClassFixture<SolutionFixture<Day03>>
  {

    SolutionBase Solution;

    public Day03Test(SolutionFixture<Day03> solutionFixture)
    {
      Solution = solutionFixture.Solution;
    }

    [Fact]
    public async Task PartOne()
    {
      Assert.Equal(159, await Solution.PartOneAsync(input1));
      Assert.Equal(135, await Solution.PartOneAsync(input2));
    }

    [Fact]
    public async Task PartTwo()
    {
      Assert.Equal(610, await Solution.PartTwoAsync(input1));
      Assert.Equal(410, await Solution.PartTwoAsync(input2));
    }

    private readonly string input1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72\nU62,R66,U55,R34,D71,R55,D58,R83";
    private readonly string input2 = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51\nU98,R91,D20,R16,D67,R40,U7,R15,U6,R7";
  }
}