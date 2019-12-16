namespace BlackJack.Entities
{
    public interface IDealer
    {
        Hand Hand { get; set; }

        Deck Deck { get; set; }

        void Deal();

        void DealPlayer(Player player);

        void Init(Player player);     
    }
}