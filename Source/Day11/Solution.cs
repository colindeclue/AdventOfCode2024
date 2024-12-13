using System.Linq;

namespace AdventOfCode.Day11;

public class Solution() : BaseSolution(11, "")
{
    // private readonly string _input = """
    //                                  125 17
    //                                  """;

    private readonly string _input = """
                                     4 4841539 66 5279 49207 134 609568 0
                                     """;
    public override string GetPart1Answer()
    {
        var stones = _input.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        var stoneDictionary = new Dictionary<long, Dictionary<int, long>>();
        var results = stones.Select(stone => Calculate(stone, stoneDictionary, 25)).ToList();
        return results.Sum().ToString();
    }

    private long Calculate(long stone, Dictionary<long, Dictionary<int, long>> stoneDictionary, int blinks)
    {
        if (blinks == 0) return 1;
        if (stoneDictionary.TryGetValue(stone, out var value))
        {
            if (value.TryGetValue(blinks, out var endResult))
            {
                return endResult;
            }
        }
        var result = 0L;
        var stoneAsString = stone.ToString();
        if (stone == 0)
        {
            result = Calculate(1, stoneDictionary, blinks - 1);
        }
        else if (stoneAsString.Length % 2 == 0)
        {
            var first = long.Parse(stoneAsString[..(stoneAsString.Length / 2)]);
            var second = long.Parse(stoneAsString[(stoneAsString.Length / 2)..]);
            result = Calculate(first, stoneDictionary, blinks - 1) + Calculate(second, stoneDictionary, blinks - 1);
        }
        else
        {
            result = Calculate(stone * 2024, stoneDictionary, blinks - 1);
        }

        if (!stoneDictionary.ContainsKey(stone)) stoneDictionary[stone] = [];
        stoneDictionary[stone][blinks] = result;
        return result;
    }

    public override string GetPart2Answer()
    {
        var stones = _input.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        var stoneDictionary = new Dictionary<long, Dictionary<int, long>>();
        var results = stones.Select(stone => Calculate(stone, stoneDictionary, 25)).ToList();
        return results.Sum().ToString();
    }
}
