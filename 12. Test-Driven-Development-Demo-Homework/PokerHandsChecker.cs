using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            bool isValidHand = true;

            if (hand.Cards.Count != 5)
            {
                isValidHand = false;
            }

            if (this.HasDuplicateCards(hand.Cards))
            {
                isValidHand = false;
            }
            
            return isValidHand;
        }

        public bool IsStraightFlush(IHand hand)
        {
            bool isStraightFlush = false;
            if (this.IsFlush(hand) && this.IsStraight(hand))
            {
                isStraightFlush = true;
            }
            
            return isStraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            bool isFourOfAKind = this.TestForEqualFaces(hand, 4);
            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            bool isFullHouse = false;

            //test the two cases when first 2 and next 3 are same
            // and when first 3 then 2 are same
            if (this.TestForEqualFaces(hand, 2, 0) && this.TestForEqualFaces(hand, 3, 2))
            {
                isFullHouse = true;
            }
            else if (this.TestForEqualFaces(hand, 3, 0) && this.TestForEqualFaces(hand, 2, 3))
            {
                isFullHouse = true;
            }

            return isFullHouse;
        }

        public bool IsFlush(IHand hand)
        {
            bool isFlush = true;
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (hand.Cards[i + 1].Suit != hand.Cards[i].Suit)
                {
                    isFlush = false;
                    break;
                }
            }

            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            bool isStraight = true;
            var orderedHan = OrderCards(hand);
            for (int i = 0; i < orderedHan.Cards.Count - 1; i++)
            {
                var difference = orderedHan.Cards[i + 1].Face - orderedHan.Cards[i].Face;
                if (difference != 1)
                {
                    isStraight = false;
                    break;
                }
            }

            return isStraight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            bool isThreeOfAKind = this.TestForEqualFaces(hand, 3);
            return isThreeOfAKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            bool isTwoPair = false;
            var orderedHand = this.OrderCards(hand);

            //two cases - first - first two cards card 0 and card 1 make a pair - then check the rest 3
            //second case card 1 and card 2 make pair - then check remaining 2
            if (orderedHand.Cards[0].Face == orderedHand.Cards[1].Face)
            {
                if (this.TestForEqualFaces(hand, 2, 2))
                {
                    isTwoPair = true;
                }
            }
            else if (orderedHand.Cards[1].Face == orderedHand.Cards[2].Face)
            {
                if (this.TestForEqualFaces(hand, 2, 3))
                {
                    isTwoPair = true;
                }
            }

            return isTwoPair;
        }

        public bool IsOnePair(IHand hand)
        {
            var isOnePair = this.TestForEqualFaces(hand, 2);
            return isOnePair;
        }

        //any poker hand is minimum High Card Hand even when highest card is 2
        public bool IsHighCard(IHand hand)
        {
            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        #region private methods
        
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
        
        private Hand OrderCards(IHand unorderedHand)
        {
            var handOrdered = unorderedHand.Cards.OrderBy(x => x.Suit);
            handOrdered = handOrdered.OrderBy(x => x.Face);
            Hand orderedHand = new Hand((IList<ICard>)handOrdered.ToList<ICard>());
            
            return orderedHand;
        }
        
        /// <summary>
        /// Orders hand by faces and then checks if 2,3,4 adjacent 
        /// cards have same faces starting at given index
        /// </summary>
        /// <param name="hand">Hand to be checked</param>
        /// <param name="lenghtOfTest">How many adjacent cards with same face do we look for</param>
        /// <param name="startIndex">At what index to stat the search</param>
        /// <returns>True if it finds as <paramref name="lenghtOfTest"/> many adjacent same faced cards</returns>
        private bool TestForEqualFaces(IHand hand, int lenghtOfTest, int startIndex = 0)
        {
            var orderedHand = this.OrderCards(hand);           
            bool areEqual = false;
            
            for (int i = startIndex; i <= hand.Cards.Count - lenghtOfTest; i++)
            {
                bool insideTestLenghtAreEqual = true;
                for (int j = i + 1; j < i + lenghtOfTest; j++)
                {
                    if (orderedHand.Cards[i].Face != orderedHand.Cards[j].Face)
                    {
                        insideTestLenghtAreEqual = false;
                        break;
                    }
                }
                
                if (insideTestLenghtAreEqual)
                {
                    areEqual = true;
                }
            }
            
            return areEqual;
        }
        
        #endregion
    }
}