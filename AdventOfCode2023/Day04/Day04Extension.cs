namespace AdventOfCode2023.Day04
{
    public static class Day04Extension
    {
        private const string FilePath = "Day04\\data.txt";
        public static double Solution()
        {
            string[] lines = File.ReadAllLines(FilePath);
            double total = 0;

            foreach (var line in lines)
            {
                var countMatchingNumbers = 0;
                var numbers = line.Split(':')[1].Split("|");
                var winningNumbers = SplitNums(numbers[0]);
                var myNumbers = SplitNums(numbers[1]);

                foreach (var number in winningNumbers)
                {
                    if(myNumbers.Contains(number))
                    {
                        countMatchingNumbers++;
                    }
                }

                total += CalculatePoints(countMatchingNumbers);
            }



            return total;
        }
        private static double CalculatePoints(int matches)
        {
            if (matches == 0) //Catch if there is no matching numbers
            {
                return 0;
            }

            double points = Math.Pow(2, (matches - 1));
            return points;
        }

        private static List<int> SplitNums(string line)
        {
            string[] numsTemp = line.Split(" ");
            List<int> nums = new();
            foreach (var item in numsTemp)
            {
                if (int.TryParse(item, out int number))
                {
                    nums.Add(number);
                }
            }
            return nums;
        }

    }

}
