using BlackJack.Entities;
using System;
using System.Collections.Generic;

namespace BlackJack.Helpers
{
    public class DeckFactory
    {
        public Deck Create()
        {
            List<Card> defaultCards = new List<Card>(GetDefaultCards());
            return new Deck(defaultCards);
        }

        private List<Card> GetDefaultCards()
        {
            List<Card> cardsToReturn = new List<Card>();

            Suit[] suits = (Suit[])Enum.GetValues(typeof(Suit));
            FaceName[] faceNames = (FaceName[])Enum.GetValues(typeof(FaceName));

            foreach (Suit suit in suits)
            {
                foreach (FaceName faceName in faceNames)
                {
                    Card card = new Card(suit, faceName, GetFaceValue(faceName));
                    cardsToReturn.Add(card);
                }
            }

            return cardsToReturn;
        }

        private FaceValue GetFaceValue(FaceName face)
        {
            switch (face)
            {
                case FaceName.Ace:
                    return new FaceValue(1, 11);                    
                case FaceName.Two:
                    return new FaceValue(2);
                case FaceName.Three:
                    return new FaceValue(3);
                case FaceName.Four:
                    return new FaceValue(4);
                case FaceName.Five:
                    return new FaceValue(5);
                case FaceName.Six:
                    return new FaceValue(6);
                case FaceName.Seven:
                    return new FaceValue(7);
                case FaceName.Eight:
                    return new FaceValue(8);
                case FaceName.Nine:
                    return new FaceValue(9);
                case FaceName.Ten:                    
                case FaceName.Jack:                    
                case FaceName.Queen:                    
                case FaceName.King:
                    return new FaceValue(10);
                default:
                    throw new ArgumentException(nameof(face));
            }
        }
    }
}
