using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Entities
{
    public class Card
    {
        public Suit Suit { get; private set; }

        public FaceValue FaceValue { get; private set; }

        public FaceName FaceName { get; private set; }

        public Card(Suit suit, FaceName faceName, FaceValue faceValue)
        {
            Suit = suit;
            FaceValue = faceValue;
            FaceName = faceName;
        }
    }
}
