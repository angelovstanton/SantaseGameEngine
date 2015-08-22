﻿namespace Santase.Logic.Cards
{
    public class Card
    {
        public Card(CardSuit suit, CardType type)
        {
            this.Suit = suit;
            this.Type = type;
        }

        public CardSuit Suit { get; }

        public CardType Type { get; }

        public int GetValue()
        {
            switch(this.Type)
            {
                case CardType.Nine:
                    return 0;
                case CardType.Jack:
                    return 2;
                case CardType.Queen:
                    return 3;
                case CardType.King:
                    return 4;
                case CardType.Ten:
                    return 10;
                case CardType.Ace:
                    return 11;
                default:
                    throw new InternalGameException("Invalid card type in GetValue()");
            }
        }

        public override bool Equals(object obj)
        {
            var anotherCard = obj as Card;
            if (anotherCard == null)
            {
                return false;
            }

            return this.Equals(anotherCard);
        }

        private bool Equals(Card other)
        {
            return this.Suit == other.Suit && this.Type == other.Type;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)this.Suit * 397) ^ (int)this.Type;
            }
        }

        public override string ToString()
        {
            return $"{this.Type.ToFriendlyString()}{this.Suit.ToFriendlyString()}";
        }
    }
}