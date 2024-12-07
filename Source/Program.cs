global using AdventOfCode;
global using AdventOfCode.Properties;
global using System;
global using System.Collections.Generic;

const bool withStats = true;

// foreach (var solution in SolutionRepository.GetAllSolutions())
// {
//     if (!string.IsNullOrWhiteSpace(solution.Title))
//     {        
//         solution.ConsoleDump(withStats);
//     }
// }

var solution = SolutionRepository.GetSolutionByDay(7);
solution.ConsoleDump(withStats);

Console.ReadLine();