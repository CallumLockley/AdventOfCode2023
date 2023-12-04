using AdventOfCode2023.Day01;
using AdventOfCode2023.Day02;
using AdventOfCode2023.Day04;

Console.WriteLine("Hello, World!");

Console.WriteLine("Day01 - " + Day01Extension.Solution().ToString());
Console.WriteLine("Day02 - Part 1: " + Day02Extension.Part1("Day02\\data.txt").ToString() + " - Part 2: " + Day02Extension.Part2("Day02\\data.txt").ToString());

Console.WriteLine($"Day04 - Part 1: " + Day04Extension.Solution());
Console.WriteLine($"Day04 - Part 2: " + Day04ExtensionPart2.Solution());

Console.WriteLine("Done!");