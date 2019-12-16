using System;
using System.Collections.Generic;

namespace BlackJack.Entities
{
    public class Deck
    {
        public Stack<Card> Cards { get; private set; }

        public Deck(List<Card> cardsForDeck)
        {
            Cards = new Stack<Card>(cardsForDeck);
        }

        // https://stackoverflow.com/questions/41095545/c-sharp-card-shuffle-in-card-deck-52-cards
        public void Shuffle()
        {
            Card[] cardsAsArray = Cards.ToArray();
            Random randomGenerator = new Random();

            for (int i = 0; i < cardsAsArray.Length; i++)
            {
                int idx = randomGenerator.Next(i, cardsAsArray.Length);
                Card temp = cardsAsArray[idx];
                cardsAsArray[idx] = cardsAsArray[i];
                cardsAsArray[i] = temp;
            }

            Cards = new Stack<Card>(cardsAsArray);
        }        
    }
}
