using System.Linq;

namespace AdventOfCode.Day07;

public class Solution : BaseSolution
{
    private readonly string _input = """
                                     190: 10 19
                                     3267: 81 40 27
                                     83: 17 5
                                     156: 15 6
                                     7290: 6 8 6 15
                                     161011: 16 10 13
                                     192: 17 8 14
                                     21037: 9 7 18 13
                                     292: 11 6 16 20
                                     """;
    
    public Solution() : base(7, "")
    {
    }

    public override string GetPart1Answer()
    {
        var equations = _input.Split("\n").ToList();
        var sum = 0L;
        foreach (var equation in equations)
        {
            var parts = equation.Split(":");
            var equals = parts[0];
            var numbers = parts[1].Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            // Loop through the numbers to add them or multiply them and see if they equal the equals
            // If they do, add the equals to the sum
            List<long> sumsOrProducts = [numbers[0]];
            sumsOrProducts = Calculate(numbers.Skip(1).ToList(), sumsOrProducts);
            if (sumsOrProducts.Contains(long.Parse(equals)))
            {
                sum += long.Parse(equals);
            }
        }
        return sum.ToString();
    }

    private static List<long> Calculate(List<long> remainingNumbers, List<long> currentSumsOrProducts, bool useThird = false)
    {
        while (true)
        {
            if (remainingNumbers.Count == 0) return currentSumsOrProducts;
            var remainingNumber = remainingNumbers[0];
            var ourCurrentSums = currentSumsOrProducts.ToList();
            currentSumsOrProducts.AddRange(ourCurrentSums.Select(x => x + remainingNumber));
            currentSumsOrProducts.AddRange(ourCurrentSums.Select(x => x * remainingNumber));
            if (useThird)
            {
                currentSumsOrProducts.AddRange(ourCurrentSums.Select(x => long.Parse($"{x}{remainingNumber}")));
            }
            currentSumsOrProducts = currentSumsOrProducts.Skip(ourCurrentSums.Count).ToList();
            remainingNumbers = remainingNumbers.Skip(1).ToList();
        }
    }

    public override string GetPart2Answer()
    {
        var equations = _input.Split("\n").ToList();
        var sum = 0L;
        foreach (var equation in equations)
        {
            var parts = equation.Split(":");
            var equals = parts[0];
            var numbers = parts[1].Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            // Loop through the numbers to add them or multiply them and see if they equal the equals
            // If they do, add the equals to the sum
            List<long> sumsOrProducts = [numbers[0]];
            sumsOrProducts = Calculate(numbers.Skip(1).ToList(), sumsOrProducts, true);
            if (sumsOrProducts.Contains(long.Parse(equals)))
            {
                sum += long.Parse(equals);
            }
        }
        return sum.ToString();
    }
}
