using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    public interface IPlayerCollectionPrinter
    {
        void Print(PlayerCollection players, Func<Hand, string> handAggregator);
    }
}
