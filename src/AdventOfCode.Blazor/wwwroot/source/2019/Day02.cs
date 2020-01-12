using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

namespace AdventOfCode.Core.Y2019
{
  public sealed class Day02 : SolutionBase
  {

    public override int PartOne(string input)
    {
      return ExecIntCode(new IntCodeMachine(input), 12, 2);
    }

    public override int PartTwo(string input)
    {
      var icm = new IntCodeMachine(input);

      for (var sum = 0; ; sum++)
      {
        for (var verb = 0; verb <= sum; verb++)
        {
          var noun = sum - verb;
          var res = ExecIntCode(icm, noun, verb);
          if (res == 19690720)
          {
            return 100 * noun + verb;
          }
        }
      }
      throw new Exception();
    }

    private int ExecIntCode(IntCodeMachine icm, int noun, int verb)
    {
      icm.Reset();
      icm.memory[1] = noun;
      icm.memory[2] = verb;
      icm.Run();
      return icm.memory[0];
    }
  }
}
