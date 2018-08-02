using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    public class PlayerCollection : List<Player>
    {
        public PlayerCollection(int numPlayers) : base(numPlayers)
        {
            for (var p = 0; p < numPlayers; p++) Add(new Player($"Player #{1 + p}"));
        }
    }
}
