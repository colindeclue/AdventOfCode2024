namespace AdventOfCode;

public interface ISolution
{
    int Day { get; }

    string Title { get; }

    string GetPart1Answer();

    string GetPart2Answer();

    void ConsoleDump(bool showDiagnostics = false);
}