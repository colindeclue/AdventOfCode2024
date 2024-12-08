using System.Linq;

namespace AdventOfCode.Day08;

public class Solution : BaseSolution
{
    private readonly string _input = """
                                     ............
                                     ........0...
                                     .....0......
                                     .......0....
                                     ....0.......
                                     ......A.....
                                     ............
                                     ............
                                     ........A...
                                     .........A..
                                     ............
                                     ............
                                     """;
    
    public Solution() : base(8, "")
    {
    }

    public override string GetPart1Answer()
    {
        var map = _input.Split("\n").Select(c => c.ToCharArray().ToList()).ToList();
        var antennaList = new HashSet<char>();
        var antennasInMap = map.SelectMany((row, y) =>row.Select((c, x) =>
        {
            antennaList.Add(c);
            return (c, x, y);
        })).Where(x => x.c != '.').ToList();
        var count = 0;
        var countInvalid = 0;
        HashSet<(int x, int y)> points = new();
        foreach (var antennaPairs in antennaList.Select(antenna => antennasInMap.Where(x => x.c == antenna).ToList()).Where(antennaPairs => antennaPairs.Count > 1))
        {
            // We need to find the slopes between each of the antennas in the map
            // And find the points that are twice as far from the two antennas
            // And add them to the count
            for (var i = 0; i < antennaPairs.Count - 1; i++)
            {
                foreach (var other in antennaPairs.Skip(i+1))
                {
                    var first = antennaPairs[i];
                    var difference = (other.x - first.x, other.y - first.y);
                    var before = (first.x - difference.Item1, first.y - difference.Item2);
                    var after = (other.x + difference.Item1, other.y + difference.Item2);
                    if(before.Item1 >= 0 && before.Item1 < map[0].Count && before.Item2 >= 0 && before.Item2 < map.Count)
                    {
                        points.Add(before);
                    }
                    else
                    {
                        countInvalid++;
                        // Check if the point is in the map
                    }
                    if(after.Item1 >= 0 && after.Item1 < map[0].Count && after.Item2 >= 0 && after.Item2 < map.Count)
                    {
                        points.Add(after);
                    }
                    else
                    {
                        countInvalid++;
                    }
                }
            }
        }
        return points.Count.ToString();
    }

    public override string GetPart2Answer()
    {
        var map = _input.Split("\n").Select(c => c.ToCharArray().ToList()).ToList();
        var antennaList = new HashSet<char>();
        var antennasInMap = map.SelectMany((row, y) =>row.Select((c, x) =>
        {
            antennaList.Add(c);
            return (c, x, y);
        })).Where(x => x.c != '.').ToList();
        var count = 0;
        var countInvalid = 0;
        HashSet<(int x, int y)> points = new();
        foreach (var antennaPairs in antennaList.Select(antenna => antennasInMap.Where(x => x.c == antenna).ToList()).Where(antennaPairs => antennaPairs.Count > 1))
        {
            // We need to find the slopes between each of the antennas in the map
            // And find the points that are twice as far from the two antennas
            // And add them to the count
            for (var i = 0; i < antennaPairs.Count - 1; i++)
            {
                foreach (var other in antennaPairs.Skip(i+1))
                {
                    var first = antennaPairs[i];
                    points.Add((first.x, first.y));
                    points.Add((other.x, other.y));
                    var difference = (other.x - first.x, other.y - first.y);
                    var before = (first.x - difference.Item1, first.y - difference.Item2);
                    var after = (other.x + difference.Item1, other.y + difference.Item2);
                    while(before.Item1 >= 0 && before.Item1 < map[0].Count && before.Item2 >= 0 && before.Item2 < map.Count)
                    {
                        points.Add(before);
                        before = (before.Item1 - difference.Item1, before.Item2 - difference.Item2);
                    }
                    while(after.Item1 >= 0 && after.Item1 < map[0].Count && after.Item2 >= 0 && after.Item2 < map.Count)
                    {
                        points.Add(after);
                        after = (after.Item1 + difference.Item1, after.Item2 + difference.Item2);
                    }
                }
            }
        }
        return points.Count.ToString();
    }
}
