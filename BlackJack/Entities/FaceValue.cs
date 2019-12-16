using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Entities
{
    public class FaceValue
    {
        public int Value { get; private set; }

        public int? AdditionalValue { get; private set; }

        public FaceValue(int value, int? addtionalValue = null)
        {
            Value = value;
            AdditionalValue = addtionalValue;
        }
    }
}
