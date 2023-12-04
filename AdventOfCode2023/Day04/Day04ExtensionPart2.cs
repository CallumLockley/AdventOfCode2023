namespace AdventOfCode2023.Day04
{
    public static class Day04ExtensionPart2
    {
        private const string FilePath = "Day04\\data.txt";
        private new static List<Card> cards = new List<Card>(); 
        public static int Solution()
        {
            StreamReader sr = new StreamReader(FilePath);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                string[] splitCard = SplitCard(line);
                List<int> listWinningNumbers = SplitNumbers(splitCard[0]);
                List<int> listMyNumbers = SplitNumbers(splitCard[1]);

                int countMatchingNumbers = listWinningNumbers.Intersect(listMyNumbers).Count();

                Card newCard = new Card(listWinningNumbers, listMyNumbers, countMatchingNumbers);

                cards.Add(newCard);
            }
            sr.Close();
            AddCopies();

            int totalCards = 0;
            foreach (Card card in cards)
            {
                totalCards += card.copies;
            }
            return totalCards;
        }

        private static string[] SplitCard(string line)
        {
            string[] removeCardTag = line.Split(":");

            string[] dividedCard = removeCardTag[1].Split("|");
            return dividedCard;
        }

        private static List<int> SplitNumbers(string line)
        {
            string[] numbersTemp = line.Split(" ");
            List<int> numbers = new List<int>();

            foreach (string word in numbersTemp)
            {
                if (int.TryParse(word, out int number))
                {
                    numbers.Add(number);
                }
            }

            return numbers;
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

        private static void AddCopies()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                for (int j = i + 1; j <= i + cards[i].matches; j++)
                {
                    cards[j].copies += cards[i].copies;
                }
            }
        }


    }

    public class Card
    {
        public int matches;
        public int copies;
        public List<int> winningNumbers;
        public List<int> cardNumbers;

        public Card(List<int> winningNumbers, List<int> cardNumbers, int matches)
        {
            this.copies = 1;
            this.winningNumbers = winningNumbers;
            this.cardNumbers = cardNumbers;
            this.matches = matches;
        }
    }
}
