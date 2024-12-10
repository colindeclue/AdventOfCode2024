using System.Linq;

namespace AdventOfCode.Day10;

public class Solution() : BaseSolution(11, "")
{
    private readonly string _input = """
                                     89010123
                                     78121874
                                     87430965
                                     96549874
                                     45678903
                                     32019012
                                     01329801
                                     10456732
                                     """;

    public override string GetPart1Answer()
    {
        var map = _input.Split().Select(row => row.Select(c =>c == '.' ? 11 : int.Parse(new string(new[] { c }))).ToList()).ToList();;
        var endpoints = new Dictionary<(int x, int y), int>();
        var trailHeads = new List<(int x, int y)>();
        for (var y = 0; y < map.Count; y++)
        {
            for (var x = 0; x < map[y].Count; x++)
            {
                if (map[y][x] == 0)
                {
                    trailHeads.Add((x, y));
                }
            }
        }

        foreach (var trailHead in trailHeads)
        {
            // BFS
            var queue = new Queue<(int x, int y)>();
            var visited = new HashSet<(int x, int y)>();
            queue.Enqueue(trailHead);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (!visited.Add(current))
                {
                    continue;
                }
                
                if (map[current.y][current.x] == 9)
                {
                    if (endpoints.TryGetValue(current, out var value))
                    {
                        endpoints[current] = value + 1;
                    }
                    else
                    {
                        endpoints[current] = 1;
                    }
                }

                var (x, y) = current;
                var currentValue = map[y][x];
                if (x + 1 < map[0].Count && map[y][x + 1] == currentValue + 1)
                {
                    queue.Enqueue((x + 1, y));
                }

                if (x - 1 >= 0 && map[y][x - 1] == currentValue + 1)
                {
                    queue.Enqueue((x - 1, y));
                }

                if (y + 1 < map.Count && map[y + 1][x] == currentValue + 1)
                {
                    queue.Enqueue((x, y + 1));
                }

                if (y - 1 >= 0 && map[y - 1][x] == currentValue + 1)
                {
                    queue.Enqueue((x, y - 1));
                }
            }
        }
        
        return endpoints.Select(x => x.Value).Sum().ToString();
    }

    public override string GetPart2Answer()
    {
        var map = _input.Split().Select(row => row.Select(c =>c == '.' ? 11 : int.Parse(new string(new[] { c }))).ToList()).ToList();;
        var endpoints = new List<(int x, int y)>();
        var trailHeads = new List<(int x, int y)>();
        for (var y = 0; y < map.Count; y++)
        {
            for (var x = 0; x < map[y].Count; x++)
            {
                if (map[y][x] == 0)
                {
                    trailHeads.Add((x, y));
                }
            }
        }

        foreach (var trailHead in trailHeads)
        {
            // BFS
            var queue = new Queue<(int x, int y)>();
            queue.Enqueue(trailHead);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                
                if (map[current.y][current.x] == 9)
                {
                    endpoints.Add(current);
                }

                var (x, y) = current;
                var currentValue = map[y][x];
                if (x + 1 < map[0].Count && map[y][x + 1] == currentValue + 1)
                {
                    queue.Enqueue((x + 1, y));
                }

                if (x - 1 >= 0 && map[y][x - 1] == currentValue + 1)
                {
                    queue.Enqueue((x - 1, y));
                }

                if (y + 1 < map.Count && map[y + 1][x] == currentValue + 1)
                {
                    queue.Enqueue((x, y + 1));
                }

                if (y - 1 >= 0 && map[y - 1][x] == currentValue + 1)
                {
                    queue.Enqueue((x, y - 1));
                }
            }
        }
        
        return endpoints.Count.ToString();
    }
}
