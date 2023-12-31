﻿namespace AdventOfCode2023.Day02
{
    public static class Day02Extension
    {
        private class Game
        {
            public Game(string gameInput)
            {
                Id = ParseId(gameInput);
                var reveals = gameInput.Split(": ")[1].Split(';');
                foreach (var reveal in reveals)
                {
                    var colors = ParseCubes(reveal);
                    foreach (var (color, count) in colors)
                    {
                        if (!_knownCubeCount.TryGetValue(color, out var current))
                            _knownCubeCount.Add(color, count);
                        else if (count > current)
                            _knownCubeCount[color] = count;
                    }
                }
            }

            private static int ParseId(string game)
            {
                var space = game.IndexOf(' ');
                var colon = game.IndexOf(':');
                var strId = game[space..colon];
                return int.Parse(strId);
            }

            private static Dictionary<string, int> ParseCubes(string reveal)
            {
                var result = new Dictionary<string, int>();
                var colorSplit = reveal.Split(',');
                foreach (var cs in colorSplit)
                {
                    var split = cs.Trim().Split(' ');
                    var num = int.Parse(split[0]);
                    result.Add(split[1], num);
                }

                return result;
            }

            public bool IsPossible(
                IReadOnlyDictionary<string, int> maxAllowedCubes)
            {
                return !_knownCubeCount.Any(e =>
                    maxAllowedCubes.TryGetValue(e.Key, out var maxValue) &&
                    e.Value > maxValue);
            }

            public int Power =>
                _knownCubeCount.Values.Aggregate((x, y) => x * y);

            public int Id { get; }
            private readonly Dictionary<string, int> _knownCubeCount = new();
        }

        public static int Part1(string inputPath)
        {
            var maxCubes = new Dictionary<string, int>()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };
            return File.ReadLines(inputPath).Sum(line =>
            {
                var game = new Game(line);
                return game.IsPossible(maxCubes) ? game.Id : 0;
            });
        }

        public static int Part2(string inputPath)
        {
            return File.ReadLines(inputPath).Sum(line => new Game(line).Power);
        }
    }
}