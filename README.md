# Advent Of Code
Base template for Advent Of Code solutions. Updated yearly to reflect the latest .NET / C# versions.

## To use

Each day's solution will be implemented in the `Solution` class located in each day's respective folder.  The "day" integer property has already been filled out since that is known ahead of time, you will have to fill in the "title" since that is unknown until the day of. Each solution has two parts (methods) and they will return a string.

Solution inputs are in the Resources.resx file, the keys are already there just replace the value with your own input.  The `BaseSolution` abstract class has a `GetResourceString()` method that will return the input as a string for you.

By default when running the project it will iterate through all days that have the `Title` filled out, this will essentially run all your answers up to the day that you are currently on. However there is a `GetSolutionByDay(int day)` method in the `SolutionRepository` class that will return the solution instance for a specific day if preferred. 

I have also included a solutions section in the README below that allows you to quickly link to the question and the answer in your repo.  Maintenance is required every year (I will try to remember to update the template yearly) but if you already have it locally make sure you change the "/[YEAR]/" in the Question URL's below.

## Solutions

1. [Day 1 Question](https://adventofcode.com/2023/day/1)
   * [Solution](/Source/Day01/Solution.cs)
2. [Day 2 Question](https://adventofcode.com/2023/day/2)
   * [Solution](/Source/Day02/Solution.cs)
3. [Day 3 Question](https://adventofcode.com/2023/day/3)
   * [Solution](/Source/Day03/Solution.cs)
4. [Day 4 Question](https://adventofcode.com/2023/day/4)
   * [Solution](/Source/Day04/Solution.cs)
5. [Day 5 Question](https://adventofcode.com/2023/day/5)
   * [Solution](/Source/Day05/Solution.cs)
6. [Day 6 Question](https://adventofcode.com/2023/day/6)
   * [Solution](/Source/Day06/Solution.cs)
7. [Day 7 Question](https://adventofcode.com/2023/day/7)
   * [Solution](/Source/Day07/Solution.cs)
8. [Day 8 Question](https://adventofcode.com/2023/day/8)
   * [Solution](/Source/Day08/Solution.cs)
9. [Day 9 Question](https://adventofcode.com/2023/day/9)
   * [Solution](/Source/Day09/Solution.cs)
10. [Day 10 Question](https://adventofcode.com/2023/day/10)
    * [Solution](/Source/Day10/Solution.cs)
11. [Day 11 Question](https://adventofcode.com/2023/day/11)
    * [Solution](/Source/Day11/Solution.cs)
12. [Day 12 Question](https://adventofcode.com/2023/day/12)
    * [Solution](/Source/Day12/Solution.cs)
13. [Day 13 Question](https://adventofcode.com/2023/day/13)
    * [Solution](/Source/Day13/Solution.cs)
14. [Day 14 Question](https://adventofcode.com/2023/day/14)
    * [Solution](/Source/Day14/Solution.cs)
15. [Day 15 Question](https://adventofcode.com/2023/day/15)
    * [Solution](/Source/Day15/Solution.cs)
16. [Day 16 Question](https://adventofcode.com/2023/day/16)
    * [Solution](/Source/Day16/Solution.cs)
17. [Day 17 Question](https://adventofcode.com/2023/day/17)
    * [Solution](/Source/Day17/Solution.cs)
18. [Day 18 Question](https://adventofcode.com/2023/day/18)
    * [Solution](/Source/Day18/Solution.cs)
19. [Day 19 Question](https://adventofcode.com/2023/day/19)
    * [Solution](/Source/Day19/Solution.cs)
20. [Day 20 Question](https://adventofcode.com/2023/day/20) 
    * [Solution](/Source/Day20/Solution.cs)
21. [Day 21 Question](https://adventofcode.com/2023/day/21) 
    * [Solution](/Source/Day21/Solution.cs)
22. [Day 22 Question](https://adventofcode.com/2023/day/22) 
    * [Solution](/Source/Day22/Solution.cs)
23. [Day 24 Question](https://adventofcode.com/2023/day/23) 
    * [Solution](/Source/Day23/Solution.cs)
24. [Day 24 Question](https://adventofcode.com/2023/day/24) 
    * [Solution](/Source/Day24/Solution.cs)
25. [Day 25 Question](https://adventofcode.com/2023/day/25) 
    * [Solution](/Source/Day25/Solution.cs)
