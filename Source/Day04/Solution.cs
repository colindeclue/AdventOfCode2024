using System.Linq;
using System.Text;

namespace AdventOfCode.Day04;

public class Solution : BaseSolution
{
    private readonly string _input = """
                                     MMMSXXMASM
                                     MSAMXMSMSA
                                     AMXSXMAAMM
                                     MSAMASMSMX
                                     XMASAMXAMM
                                     XXAMMXXAMA
                                     SMSMSASXSS
                                     SAXAMASAAA
                                     MAMMMXMMMM
                                     MXMXAXMASX
                                     """;
    
    public Solution() : base(4, "")
    {
    }

    public override string GetPart1Answer()
    {
        var sum = 0;
        const string forward = "XMAS";
        const string backward = "SAMX";
        var lines = _input.Split("\n");
        
        // left-right
        var index = 0;
        for(var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            index = 0;
            while (index < line.Length && (index = line.IndexOf(forward, index, StringComparison.InvariantCulture)) != -1)
            {
                index += forward.Length;
                ++sum;
            }
            
            index = 0;
            while (index < line.Length && (index = line.IndexOf(backward, index, StringComparison.InvariantCulture)) != -1)
            {
                index += backward.Length;
                ++sum;
            }
        }
        
        // up-down
        for (var i = 0; i < lines[0].Length; i++)
        {
            var column = new StringBuilder();
            foreach (var line in lines)
            {
                column.Append(line[i]);
            }
            var columnString = column.ToString();
            index = 0;
            while (index < columnString.Length && (index = columnString.IndexOf(forward, index, StringComparison.InvariantCulture)) != -1)
            {
                index += forward.Length;
                ++sum;
            }
            index = 0;
            while (index < columnString.Length && (index = columnString.IndexOf(backward, index, StringComparison.InvariantCulture)) != -1)
            {
                index += forward.Length;
                ++sum;
            }
        }
        
        // downright
        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                if (lines[y][x] == forward[0])
                {
                    // check the other letters to the downright
                    for (var i = 1; i < forward.Length; i++)
                    {
                        if (y + i >= lines.Length || x + i >= lines[y].Length || lines[y + i][x + i] != forward[i])
                        {
                            break;
                        }
                        if (i == forward.Length - 1)
                        {
                            sum++;
                        }
                    }
                }
                if (lines[y][x] == backward[0])
                {
                    // check the other letters to the downright
                    for (var i = 1; i < backward.Length; i++)
                    {
                        if (y + i >= lines.Length || x + i >= lines[y].Length || lines[y + i][x + i] != backward[i])
                        {
                            break;
                        }
                        if (i == backward.Length - 1)
                        {
                            sum++;
                        }
                    }
                }
            }
        }
        
        // downleft
        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                if (lines[y][x] == forward[0])
                {
                    // check the other letters to the downleft
                    for (var i = 1; i < forward.Length; i++)
                    {
                        if (y + i >= lines.Length || x - i < 0 || lines[y + i][x - i] != forward[i])
                        {
                            break;
                        }

                        if (i == forward.Length - 1)
                        {
                            sum++;
                        }
                    }
                }

                if (lines[y][x] == backward[0])
                {
                    // check the other letters to the downleft
                    for (var i = 1; i < backward.Length; i++)
                    {
                        if (y + i >= lines.Length || x - i < 0 || lines[y + i][x - i] != backward[i])
                        {
                            break;
                        }

                        if (i == backward.Length - 1)
                        {
                            sum++;
                        }
                    }
                }
            }
        }

        return sum.ToString();
    }

    public override string GetPart2Answer()
    {
        var lines = _input.Split("\n");
        var count = 0;
        for(var y = 0; y + 2 < lines.Length; y++)
        {
            for(var x = 0; x + 2 < lines[y].Length; x++)
            {
                if (lines[y + 1][x + 1] == 'A' &&
                    ((lines[y][x] == 'M' && lines[y + 2][x + 2] == 'S') ||
                     (lines[y][x] == 'S' && lines[y + 2][x + 2] == 'M')) &&
                    ((lines[y][x + 2] == 'M' && lines[y + 2][x] == 'S') ||
                     (lines[y][x + 2] == 'S' && lines[y + 2][x] == 'M')))
                {
                    count++;
                }
            }
        }
        
        return count.ToString();
    }
}
