using System.Linq;

namespace AdventOfCode.Day02;

public class Solution : BaseSolution
{
    private static readonly string _input = """
                                            7 6 4 2 1
                                            1 2 7 8 9
                                            9 7 6 2 1
                                            1 3 2 4 5
                                            8 6 4 4 1
                                            1 3 6 7 9
                                            """;
    
    public Solution() : base(2, "")
    {
    }

    public override string GetPart1Answer()
    {
        var lines = _input.Split("\n");
        var safe = 0;
        foreach (var line in lines)
        {
            var parts = line.Split().Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToArray();
            var currentlySafe = Safe(parts);
            if (currentlySafe)
            {
                Console.WriteLine(line);
                safe++;
            }
        }
        return safe.ToString();
    }

    private static bool Safe(int[] parts)
    {
        var currentlySafe = true;
        var currentIncrease = parts[0] - parts[1];
        for (var i = 1; i < parts.Length - 1; i++)
        {
            // previous
            var previousDiff = parts[i - 1] - parts[i];
            if(previousDiff == 0 || (currentIncrease > 0 ? previousDiff is < 0 or > 3 : previousDiff is > 0 or < -3))
            {
                currentlySafe = false;
                break;
            }
            // next
            var nextDiff = parts[i] - parts[i + 1];
            if(nextDiff == 0 || (currentIncrease > 0 ? nextDiff is < 0 or > 3 : nextDiff is > 0 or < -3))
            {
                currentlySafe = false;
                break;
            }
        }

        return currentlySafe;
    }

    public override string GetPart2Answer()
    {
        var lines = _input.Split("\n");
        var safe = 0;
        foreach (var line in lines)
        {
            var parts = line.Split().Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToArray();
            var currentlySafe = Safe(parts);
            if (currentlySafe) safe++;
            if (!currentlySafe)
            {
                for(var i = 0; i < parts.Length; i++)
                {
                    var currentParts = parts.ToList();
                    currentParts.RemoveAt(i);
                    if (Safe(currentParts.ToArray()))
                    {
                        safe++;
                        break;
                    }
                }
            }
        }
        return safe.ToString();
    }
}
