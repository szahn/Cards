namespace Cards
{
    public class Player
    {
        public string Name { get; private set; }
        public Hand Cards { get; private set; }

        public Player(string name)
        {
            Name = name;
            Cards = new Hand();
        }
    }
}
