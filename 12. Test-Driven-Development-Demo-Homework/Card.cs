using System;

namespace Poker
{
    public class Card : ICard
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            String result = string.Format("{0}{1}", this.GetCardSuitSymbol(), this.GetCardFace());

            return result;
        }

        private string GetCardFace()
        {
            string face;
            if (this.Face - CardFace.Two < 9)
            {
                face = (this.Face - CardFace.Two + 2).ToString();
            }
            else
            {
                face = this.Face.ToString().Substring(0, 1);
            }

            return face;
        }

        private char GetCardSuitSymbol()
        {
            char suitSymbol = '0';
        
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    {
                        suitSymbol = '♣';
                        break;
                    }
                case CardSuit.Diamonds:
                    {
                        suitSymbol = '♦';
                        break;
                    }
                case CardSuit.Hearts:
                    {
                        suitSymbol = '♥';
                        break;
                    }
                case CardSuit.Spades:
                    {
                        suitSymbol = '♠';
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Trying to get a non-existent card suit in method GetCardSuitSymbol.");
                    }
            }

            return suitSymbol;
        }
    }
}