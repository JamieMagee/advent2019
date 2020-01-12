

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Core.Y2019
{
  public sealed class Day03 : SolutionBase
  {

    public override int PartOne(string input)
    {
      var (wireA, wireB) = ParseWires(input);
      var intersections = GetIntersections(wireA, wireB);
      return intersections.Keys.Select(Manhattan).OrderBy(d => d).First();
    }

    public override int PartTwo(string input)
    {
      var (wireA, wireB) = ParseWires(input);
      var intersections = GetIntersections(wireA, wireB);

      return intersections.Values.OrderBy(d => d).First();
    }

    private Dictionary<Point, int> GetIntersections(Point[] wireA, Point[] wireB)
    {
      var intersectionDistances = new Dictionary<Point, int>();
      var distanceA = 0;
      for (var i = 0; i < wireA.Length - 1; i++)
      {
        var (startA, endA) = (wireA[i], wireA[i + 1]);
        var sectionA = (startA, endA);

        var distanceB = 0;
        for (var j = 0; j < wireB.Length - 1; j++)
        {
          var (startB, endB) = (wireB[j], wireB[j + 1]);
          var sectionB = (startB, endB);

          if (TryGetIntersection(sectionA, sectionB, out var intersection) && intersection != Point.Empty)
          {
            if (!intersectionDistances.ContainsKey(intersection))
            {
              intersectionDistances.Add(intersection,
                  distanceA + Manhattan(startA, intersection) +
                  distanceB + Manhattan(startB, intersection));
            }
          }
          distanceB += Manhattan(startB, endB);
        }
        distanceA += Manhattan(startA, endA);
      }

      return intersectionDistances;
    }

    private static int Manhattan(Point a) => Manhattan(a, Point.Empty);

    private static int Manhattan(Point a, Point b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

    private static bool TryGetIntersection((Point A, Point B) sectionA, (Point A, Point B) sectionB, out Point intersection)
    {
      intersection = default;

      if (sectionA.A.X == sectionA.B.X && sectionB.A.X == sectionB.B.X ||
          sectionA.A.Y == sectionA.B.Y && sectionB.A.Y == sectionB.B.Y)
      {
        return false;
      }

      // Section A is the horizontal section
      if (sectionB.A.Y == sectionB.B.Y) { (sectionA, sectionB) = (sectionB, sectionA); }
      var (x, y) = (sectionB.A.X, sectionA.A.Y);

      // Are sections intersecting
      if (x >= Math.Min(sectionA.A.X, sectionA.B.X) && x <= Math.Max(sectionA.A.X, sectionA.B.X) &&
          y >= Math.Min(sectionB.A.Y, sectionB.B.Y) && y <= Math.Max(sectionB.A.Y, sectionB.B.Y))
      {
        intersection = new Point(x, y);
        return true;
      }

      return false;
    }

    private (Point[] WireA, Point[] WireB) ParseWires(string input)
    {
      var regex = new Regex(@"(?'direction'[URDL])(?'distance'[0-9]+)");
      var lines = GetLines(input);
      var wires = new List<List<Point>>();
      foreach (var line in lines)
      {
        var pos = new Point(0, 0);
        var wire = new List<Point> { pos };
        foreach (var match in regex.Matches(line).OfType<Match>())
        {
          var direction = match.Groups["direction"].Value.First();
          var distance = Convert.ToInt32(match.Groups["distance"].Value);
          switch (direction)
          {
            case 'U': pos = new Point(pos.X, pos.Y + distance); break;
            case 'R': pos = new Point(pos.X + distance, pos.Y); break;
            case 'D': pos = new Point(pos.X, pos.Y - distance); break;
            case 'L': pos = new Point(pos.X - distance, pos.Y); break;
          }
          wire.Add(pos);
        }
        wires.Add(wire);
      }

      return (wires[0].ToArray(), wires[1].ToArray());
    }
  }
}
