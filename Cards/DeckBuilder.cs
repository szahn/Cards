using System.Linq;

namespace Cards
{
    public class DeckBuilder
    {
        public static Deck Build(ICardFactory cardFactory)
        {
            var deck = new Deck();

            Card card = null;
            while ((card = cardFactory.Next()) != null)
            {
                deck.Push(card);
            }

            return deck;
        }
    }
}
