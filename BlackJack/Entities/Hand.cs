using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Entities
{
    public class Hand
    {
        private readonly List<Card> _cards = new List<Card>();
                       
        public int Total()
        {
            return _cards.Select(card => card.FaceValue.Value).Sum();
        }       

        public void Add(Card card)
        {
            _cards.Add(card);
        }
    }
}
