using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day03;

public class Solution : BaseSolution
{
    private readonly string _input = """
                                     xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
                                     """;
    
    public Solution() : base(3, "")
    {
    }

    public override string GetPart1Answer()
    {
        var regex = new Regex(@"mul\(\d+,\d+\)");
        var matches = regex.Matches(_input);
        var sum = 0;
        foreach (Match match in matches)
        {
            var parts = match.Value.Split(",");
            sum += int.Parse(parts[0][4..]) * int.Parse(parts[1][..^1]);
        }
        return sum.ToString();
    }

    public override string GetPart2Answer()
    {
        var modified = new StringBuilder();
        var addToModified = true;
        var searchString = "don't()";
        var index = 0;
        while (_input.Substring(index).Contains(searchString))
        {
            var subString = _input.IndexOf(searchString, index);
            if (addToModified)
            {
                modified.Append(_input.Substring(index, subString - index));
            }
            index = subString + searchString.Length;
            addToModified = !addToModified;
            searchString = searchString == "don't()" ? "do()" : "don't()";
        }
        var lastPart = _input.Substring(index);
        if (addToModified)
        {
            modified.Append(lastPart);
        }

        var output = modified.ToString();
        var regex = new Regex(@"mul\(\d+,\d+\)");
        var matches = regex.Matches(output);
        var sum = 0;
        foreach (Match match in matches)
        {
            var parts = match.Value.Split(",");
            sum += int.Parse(parts[0][4..]) * int.Parse(parts[1][..^1]);
        }
        return sum.ToString();
    }
}
