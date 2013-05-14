using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Passed null (invalid argument) in the constructor of Hand.");
                }

                if (value.Count < 5 || 5 < value.Count)
                {
                    throw new ArgumentOutOfRangeException(
                        "Passed invalid number of cards in Hand.Cards setter." + 
                        " 5 cards make a hand - no more no less.");
                }

                if(HasDuplicateCards(value))
                {
                    throw new ArgumentException(
                        "Passed cards list with duplicate cards in Hads.Setter" +
                        "No duplicates are allowed");
                }

                this.cards = value;
            }
        }

       
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var card in this.Cards)
            {
                result.Append(card.ToString() + " ");
            }

            result.Remove(result.Length - 1, 1);

            return result.ToString();
        }

        private bool HasDuplicateCards(IList<ICard> cards)
        {
            bool hasDuplicates = false;
            int cardsCount = cards.Count;

            for (int i = 0; i < cardsCount; i++)
            {
                for (int j = i + 1; j < cardsCount; j++)
                {
                    if (cards[i].ToString().Equals(cards[j].ToString()))
                    {
                        hasDuplicates = true;
                        break;
                    }
                }

                if (hasDuplicates)
                {
                    break;
                }
            }

            return hasDuplicates;
        }
    }
}
