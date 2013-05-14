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

                this.cards = value;
            }
        }
       
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var card in this.Cards)
            {
                result.AppendFormat("{0} ", card.ToString());
            }

            result.Remove(result.Length - 1, 1);

            return result.ToString();
        }
    }
}