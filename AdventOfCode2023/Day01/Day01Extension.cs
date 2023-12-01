namespace AdventOfCode2023.Day01
{
    public static class Day01Extension
    {
        private const string FilePath = "Day01\\data.txt";
        public static int Solution()
        {
            string[] lines = File.ReadAllLines(FilePath);
            int total = 0;

            foreach (var item in lines)
            {
                var numbers = string.Concat(item.Where(Char.IsNumber));
                var result = Convert.ToInt32(numbers[0].ToString() + numbers.Last().ToString());
                total += result;
            }

            return total;
        }
    }
}
