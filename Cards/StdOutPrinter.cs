using System;

namespace Cards
{
    public class StdOutPrinter : IPlayerCollectionPrinter
    {
        private readonly Action<string> WriteLine;
        public StdOutPrinter(Action<string> writeLine)
        {
            WriteLine = writeLine;
        }
        public void Print(PlayerCollection players, Func<Hand, string> handAggregator)
        {
            foreach (var player in players)
            {
                WriteLine($"{player.Name}: {handAggregator(player.Cards)}");
            }
        }
    }
}
