using System.Diagnostics;

namespace AdventOfCode;

public abstract class BaseSolution(int day, string title) : ISolution
{
    public int Day { get; } = day;

    public string Title { get; } = title;

    public abstract string GetPart1Answer();

    public abstract string GetPart2Answer();

    protected string GetResourceString() => Resources.ResourceManager.GetString($"Day{Day:D2}");

    public void ConsoleDump(bool showDiagnostics = false)
    {
        Console.WriteLine($"Day {Day} | {Title}");

        if (showDiagnostics)
        {
            var sw = new Stopwatch();

            sw.Start();
            var answer1 = GetPart1Answer();
            sw.Stop();
            Console.WriteLine($"Solution Part 1: {answer1} | Time: {sw.Elapsed}");

            sw.Reset();
            sw.Start();
            var answer2 = GetPart2Answer();
            sw.Stop();
            Console.WriteLine($"Solution Part 2: {answer2} | Time: {sw.Elapsed}");
        }
        else
        {
            Console.WriteLine($"Solution Part 1: {GetPart1Answer()}");
            Console.WriteLine($"Solution Part 2: {GetPart2Answer()}");
        }
    }
}