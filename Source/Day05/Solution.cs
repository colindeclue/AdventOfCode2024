using System.Linq;

namespace AdventOfCode.Day05;

public class Solution : BaseSolution
{
      private readonly string _input = """
                                       47|53
                                       97|13
                                       97|61
                                       97|47
                                       75|29
                                       61|13
                                       75|53
                                       29|13
                                       97|29
                                       53|29
                                       61|53
                                       97|53
                                       61|29
                                       47|13
                                       75|47
                                       97|75
                                       47|61
                                       75|61
                                       47|29
                                       75|13
                                       53|13

                                       75,47,61,53,29
                                       97,61,53,29,13
                                       75,29,13
                                       75,97,47,61,53
                                       61,13,29
                                       97,13,75,29,47
                                       """;

    public Solution() : base(5, "")
    {
    }

    public override string GetPart1Answer()
    {
        var rulesAndPages = _input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var rules = rulesAndPages[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var pages = rulesAndPages[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var ruleMap = rules.Select(x => x.Split("|").Select(int.Parse).ToArray()).ToList();
        var pagesMap = pages.Select(x => x.Split(",").Select(int.Parse).ToList());
        List<int> middlePages = [];
        foreach (var page in pagesMap)
        {
            var goodRow = true;
            for (var index = 0; index < page.Count; index++)
            {
                var p = page[index];
                var afterRules = ruleMap.Where(pair => p == pair[1]).ToList();
                if (page.Skip(index + 1).Any(x => afterRules.Any(pair => x == pair[0])))
                {
                    goodRow = false;
                    break;
                }
            }

            if (goodRow)
            {
                middlePages.Add(page[page.Count / 2]);
            }
        }
        
        return middlePages.Sum().ToString();
    }

    public override string GetPart2Answer()
    {
        var rulesAndPages = _input.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var rules = rulesAndPages[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var pages = rulesAndPages[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var ruleMap = rules.Select(x => x.Split("|").Select(int.Parse).ToArray()).ToList();
        var pagesMap = pages.Select(x => x.Split(",").Select(int.Parse).ToList()).ToList();
        List<int> middlePages = [];
        HashSet<List<int>> badPages = [];
        for (var i = 0; i < pagesMap.Count; i++)
        {
            var goodPage = true;
            var page = pagesMap[i];
            for (var index = 0; index < page.Count; index++)
            {
                var p = page[index];
                var afterRules = ruleMap.Where(pair => p == pair[1]).ToList();
                var badPage = page.Skip(index + 1).FirstOrDefault(x => afterRules.Any(pair => x == pair[0]));
                if(badPage != 0)
                {
                    // swap bad page with current page and rerun from here
                    var temp = page[index];
                    var badPageIndex = page.IndexOf(badPage);
                    page[index] = badPage;
                    page[badPageIndex] = temp;
                    index--;
                    badPages.Add(page);
                    goodPage = false;
                }
            }

            if (!goodPage)
            {
                middlePages.Add(page[page.Count / 2]);
            }
        }
        
        return middlePages.Sum().ToString();
    }
}
