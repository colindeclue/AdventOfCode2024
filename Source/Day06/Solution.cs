using System.Linq;

namespace AdventOfCode.Day06;

public class Solution : BaseSolution
{
    private readonly string _input = """
                                     ....#.....
                                     .........#
                                     ..........
                                     ..#.......
                                     .......#..
                                     ..........
                                     .#..^.....
                                     ........#.
                                     #.........
                                     ......#...
                                     """;
    
    private readonly char[] guardPositions = ['^', '>', 'v', '<'];
    public Solution() : base(6, "")
    {
    }

    public override string GetPart1Answer()
    {
        var startPosition = (0, 0);
        var map = _input.Split("\n").Select(c => c.ToCharArray().ToList()).ToList();

        for(var y = 0; y < map.Count; y++)
        {
            for(var x = 0; x < map[y].Count; x++)
            {
                if(guardPositions.Contains(map[y][x]))
                {
                    startPosition = (y, x);
                    break;
                }
            }
        }

        var direction = (0, 0);
        var numberOfVisited = 0;
        
        while (true)
        {
            var currentChar = map[startPosition.Item1][startPosition.Item2];
            direction = currentChar switch
            {
                '^' => (-1, 0),
                'v' => (1, 0),
                '<' => (0, -1),
                '>' => (0, 1),
                _ => direction
            };
            if (!(startPosition.Item1 + direction.Item1 >= 0 && startPosition.Item1 + direction.Item1 < map.Count && startPosition.Item2+ direction.Item2 >= 0 &&
                  startPosition.Item2 + direction.Item2 < map[0].Count))
            {
                break;
            }
            switch (map[startPosition.Item1 + direction.Item1][startPosition.Item2 + direction.Item2])
            {
                case '.':
                case 'X':
                {
                    if (map[startPosition.Item1 + direction.Item1][startPosition.Item2 + direction.Item2] == '.')
                    {
                        numberOfVisited++;
                    }
                    map[startPosition.Item1][startPosition.Item2] = 'X';
                    startPosition = (startPosition.Item1 + direction.Item1, startPosition.Item2 + direction.Item2);
                    map[startPosition.Item1][startPosition.Item2] = currentChar;

                    break;
                }
                case '#':
                    // Turn to the right
                    currentChar = guardPositions[(Array.IndexOf(guardPositions, currentChar) + 1) % 4];
                    map[startPosition.Item1][startPosition.Item2] = currentChar;
                    break;
            }
            
            // PrintMap(map);
        }
        
        return numberOfVisited.ToString();
    }
    
    private static void PrintMap(List<List<char>> map)
    {
        foreach (var _ in map[0])
        {
            Console.Write('_');
        }
        Console.WriteLine();
        foreach (var row in map)
        {
            Console.WriteLine(string.Join("", row));
        }
    }

    public override string GetPart2Answer()
    {
        var map = _input.Split("\n").Select(c => c.ToCharArray().ToList()).ToList();
        var startPosition = (0, 0);
        for(var y = 0; y < map.Count; y++)
        {
            for(var x = 0; x < map[y].Count; x++)
            {
                if(guardPositions.Contains(map[y][x]))
                {
                    startPosition = (y, x);
                    break;
                }
            }
        }

        var stuckCount = 0;
        for (var y = 0; y < map.Count; y++)
        {
            for(var x = 0; x < map[y].Count; x++)
            {
                if (startPosition == (y, x) || map[y][x] == '#')
                {
                    continue;
                }

                var thisMap = map.Select(row => row.ToList()).ToList();
                thisMap[y][x] = '#';
                var thisPosition = (startPosition.Item1, startPosition.Item2);
                if (StuckInLoop(thisMap, thisPosition))
                {
                    stuckCount++;
                }
            }
        }
        
        return stuckCount.ToString();
    }

    private bool StuckInLoop(List<List<char>> map, (int,int) startPosition)
    {
        var direction = (0, 0);
        HashSet<(int, int, char)> positions = [];
        
        while (true)
        {
            var currentChar = map[startPosition.Item1][startPosition.Item2];
            if(positions.Contains((startPosition.Item1, startPosition.Item2, currentChar)))
            {
                // PrintMap(map);
                return true;
            }
            direction = currentChar switch
            {
                '^' => (-1, 0),
                'v' => (1, 0),
                '<' => (0, -1),
                '>' => (0, 1),
                _ => direction
            };
            if (!(startPosition.Item1 + direction.Item1 >= 0 && startPosition.Item1 + direction.Item1 < map.Count && startPosition.Item2+ direction.Item2 >= 0 &&
                  startPosition.Item2 + direction.Item2 < map[0].Count))
            {
                // PrintMap(map);
                return false;
            }
            switch (map[startPosition.Item1 + direction.Item1][startPosition.Item2 + direction.Item2])
            {
                case '.':
                case 'X':
                {
                    positions.Add((startPosition.Item1, startPosition.Item2, currentChar));
                    map[startPosition.Item1][startPosition.Item2] = 'X';
                    startPosition = (startPosition.Item1 + direction.Item1, startPosition.Item2 + direction.Item2);
                    map[startPosition.Item1][startPosition.Item2] = currentChar;

                    break;
                }
                case '#':
                    // Turn to the right
                    currentChar = guardPositions[(Array.IndexOf(guardPositions, currentChar) + 1) % 4];
                    map[startPosition.Item1][startPosition.Item2] = currentChar;
                    break;
            }
        }

        return false;
    }
}
