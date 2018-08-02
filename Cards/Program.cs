namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildDeck().Deal(new PlayerCollection(numPlayers: 5)).Print();
        }

        /// <summary>
        /// Construct a valid 52 card deck, with 4 suits and 13 cards (Ace through King) of each suit.
        /// </summary>
        private static Deck BuildDeck() => DeckBuilder.Build(new RandomCardFactory());
    }
}
