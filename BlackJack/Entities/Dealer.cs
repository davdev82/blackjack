namespace BlackJack.Entities
{
    public class Dealer : IDealer
    {
        public Hand Hand { get; set; }

        public Deck Deck { get; set; }

        public Dealer(Deck deck)
        {
            Deck = deck;            
            Hand = new Hand();            
        }

        public void Init(Player player)
        {
            Deck.Shuffle();
            DealPlayer(player);
            Deal();
            DealPlayer(player);
            Deal();
        }

        public void Deal()
        {
            Hand.Add(Deck.Cards.Pop());
        }

        public void DealPlayer(Player player)
        {
            player.Hand.Add(Deck.Cards.Pop());
        }        
    }
}
