using System.Linq;

namespace AdventOfCode.Day01;

public class Solution : BaseSolution
{
    private static readonly string _input = """
                                            3   4
                                            4   3
                                            2   5
                                            1   3
                                            3   9
                                            3   3
                                            """; 
    
    public Solution() : base(1, "")
    {
    }

    public override string GetPart1Answer()
    {
        List<int> first = [];
        List<int> second = [];
        var lines = _input.Split("\n");
        foreach (var line in lines)
        {
            var parts = line.Split().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            first.Add(int.Parse(parts[0]));
            second.Add(int.Parse(parts[1]));
        }
        first.Sort();
        second.Sort();
        var sum =first.Zip(second, (f, s) => Math.Abs(f - s)).Sum();
        return sum.ToString();
    }

    public override string GetPart2Answer()
    {
        List<int> first = [];
        List<int> second = [];
        var lines = _input.Split("\n");
        foreach (var line in lines)
        {
            var parts = line.Split().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            first.Add(int.Parse(parts[0]));
            second.Add(int.Parse(parts[1]));
        }
        var similarityScore = 0;
        foreach (var t in first)
        {
            var countInSecond = second.Count(x => x == t);
            similarityScore += countInSecond * t;
        }
        return similarityScore.ToString();
    }
}