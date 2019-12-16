namespace BlackJack.Entities
{
    public class Player
    {
        public string Name { get; set; }

        public Hand Hand { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }       
    }
}
