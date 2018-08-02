using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Cards
{
    public static class Extensions
    {

        /// <summary>
        /// Deal a hand of five cards to five different players (build the hands by dealing one card from the deck to each hand, passing around the players 5 times).
        /// </summary>
        public static PlayerCollection Deal(this Deck deck, PlayerCollection players, int cardsPerPlayer = 5)
        {
            for (var i = 0; i < cardsPerPlayer; i++)
            {
                foreach (var player in players)
                {
                    player.Cards.Push(deck.Pop());
                }
            }

            return players;
        }


        /// <summary>
        /// Write the hands out to a text file with each hand sorted by value in ascending order (with Ace being the highest value)
        /// Each card should be separated by a dash.
        /// </summary>
        public static void Print(this PlayerCollection players, string filename = "players.txt", string cardDelimeter = "-")
        {
            var path = Path.Combine(Environment.CurrentDirectory, filename);
            using (var stream = File.OpenWrite(path))
            {
                BuildPrinter(stream).Print(players, AggregateByCardValue(cardDelimeter));
            }
        }

        private static Func<Hand, string> AggregateByCardValue(string cardDelimeter)
        {
            return cards => string.Join(cardDelimeter, cards.OrderBy(card => card));
        }

        private static StreamPrinter BuildPrinter(FileStream stream) => new StreamPrinter(stream, Debugger.IsAttached
                                ? new StdOutPrinter(s => Debug.WriteLine(s))
                                : new StdOutPrinter(Console.WriteLine));
    }
}
