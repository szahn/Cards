using System;
using System.Linq;

namespace Cards
{
    public class RandomCardFactory : ICardFactory
    {
        private readonly Random _random = new Random();
        private readonly bool[] _matrix = new bool[CardConstants.Ranks.Length * CardConstants.Suites.Length];

        /// <summary>
        /// Shuffle the deck so that cards are randomly distributed (each run of the program should produce a different random distribution).
        /// </summary>
        public Card Next()
        {
            if (!_matrix.Any(m => m == false)) return null;

            int index = _random.Next(0, _matrix.Length);
            while (_matrix[index] == true)
            {
                index = _random.Next(0, _matrix.Length);
            }

            _matrix[index] = true;

            var suite = Math.DivRem(index, CardConstants.Ranks.Length, out int rank);
            return new Card(rank, suite);
        }
    }
}
