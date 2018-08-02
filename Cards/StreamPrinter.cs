using System;
using System.IO;

namespace Cards
{
    public class StreamPrinter : IPlayerCollectionPrinter
    {
        private readonly IPlayerCollectionPrinter _printer;
        private readonly Stream _stream;
        public StreamPrinter(Stream stream, IPlayerCollectionPrinter printer = null)
        {
            _printer = printer;
            _stream = stream;
        }

        public void Print(PlayerCollection players, Func<Hand, string> handAggregator)
        {
            _printer?.Print(players, handAggregator);

            using (var writer = new StreamWriter(_stream))
            {
                foreach (var player in players)
                {
                    writer.WriteLine($"{player.Name}: {handAggregator(player.Cards)}");
                }
            }
        }
    }
}
