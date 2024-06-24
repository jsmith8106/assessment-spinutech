namespace Assessments.Models
{
    public class Card
    {
        public string Value { get; set; }
        public char Suit { get; set; }

        public Card(string value, char suit)
        {
            Value = value;
            Suit = suit;
        }

        public int GetValue()
        {
            return Value switch
            {
                "A" => 14,
                "K" => 13,
                "Q" => 12,
                "J" => 11,
                "10" => 10,
                "9" => 9,
                "8" => 8,
                "7" => 7,
                "6" => 6,
                "5" => 5,
                "4" => 4,
                "3" => 3,
                "2" => 2,
                _ => 0,
            };
        }
    }

    public class Hand
    {
        public List<Card> Cards { get; set; }

        public Hand(List<Card> cards)
        {
            Cards = cards;
        }

        public string EvaluateHandRank()
        {
            if (IsStraightFlush())
                return "Straight Flush";
            if (IsFourOfAKind())
                return "Four of a Kind";
            if (IsFullHouse())
                return "Full House";
            if (IsFlush())
                return "Flush";
            if (IsStraight())
                return "Straight";
            if (IsThreeOfAKind())
                return "Three of a Kind";
            if (IsTwoPair())
                return "Two Pair";
            if (IsPair())
                return "Pair";
            return "High Card";
        }

        private bool IsFlush()
        {
            return Cards.All(c => c.Suit == Cards[0].Suit);
        }

        private bool IsStraight()
        {
            var orderedValues = Cards.Select(c => c.GetValue()).OrderBy(v => v).ToList();
            for (int i = 0; i < orderedValues.Count - 1; i++)
            {
                if (orderedValues[i + 1] - orderedValues[i] != 1)
                    return false;
            }
            return true;
        }

        private bool IsStraightFlush()
        {
            return IsStraight() && IsFlush();
        }

        private bool IsFourOfAKind()
        {
            var values = Cards.Select(c => c.Value).ToList();
            return values.GroupBy(v => v).Any(g => g.Count() == 4);
        }

        private bool IsFullHouse()
        {
            var values = Cards.Select(c => c.Value).ToList();
            var groups = values.GroupBy(v => v).ToList();
            return groups.Count == 2 && groups.Any(g => g.Count() == 3);
        }

        private bool IsThreeOfAKind()
        {
            var values = Cards.Select(c => c.Value).ToList();
            return values.GroupBy(v => v).Any(g => g.Count() == 3);
        }

        private bool IsTwoPair()
        {
            var values = Cards.Select(c => c.Value).ToList();
            return values.GroupBy(v => v).Count(g => g.Count() == 2) == 2;
        }

        private bool IsPair()
        {
            var values = Cards.Select(c => c.Value).ToList();
            return values.GroupBy(v => v).Any(g => g.Count() == 2);
        }
    }

}
