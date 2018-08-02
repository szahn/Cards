using System;

namespace Cards
{
    public class Card : IComparable
    {
        public int RankIndex { get; private set; }

        public string Rank => CardConstants.Ranks[RankIndex];
        public int SuitIndex { get; private set; }

        public char Suite => CardConstants.Suites[SuitIndex];

        public Card(int rank, int suit)
        {
            RankIndex = rank;
            SuitIndex = suit;
        }

        public override int GetHashCode() => RankIndex ^ SuitIndex;

        public override bool Equals(Object obj)
        {
            if (!(obj is Card)) return false;
            Card c = (Card)obj;
            return RankIndex == c.RankIndex && SuitIndex == c.SuitIndex;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Card)) return -1;
            Card c = (Card)obj;

            var rank = RankIndex - c.RankIndex;
            return (rank == 0) ? SuitIndex - c.SuitIndex : rank;
        }

        public override string ToString() => $"{Rank}{Suite}";
    }
}
