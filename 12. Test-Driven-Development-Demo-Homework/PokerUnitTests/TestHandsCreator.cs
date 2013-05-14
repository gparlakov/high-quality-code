using System;
using System.Collections.Generic;
using System.Linq;
using Poker;

namespace PokerUnitTests
{
    internal static class TestHandsCreator
    {
        internal static List<ICard> HandFiveCardsHighCard()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds)
            };

            return hand;
        }

        internal static List<ICard> HandOnePairAces()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Spades)
            };

            return hand;
        }

        internal static List<ICard> HandTwoPair()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            };

            return hand;
        }

        internal static List<ICard> HandThreeOfAKind()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds)
            };

            return hand;
        }

        internal static List<ICard> HandStraightLow()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five,CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Six,CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs)
            };

            return hand;
        }

        internal static List<ICard> HandStraightHigh()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen,CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };

            return hand;
        }

        internal static List<ICard> HandFullHouseTwoThenThree()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds)
            };

            return hand;
        }

        internal static List<ICard> HandFullHouseThreeThenTwo()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds)
            };

            return hand;
        }

        internal static List<ICard> HandFourOfAKindLow()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four,CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds)
            };

            return hand;
        }

        internal static List<ICard> HandFourOfAKindHigh()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Jack,CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            };

            return hand;
        }

        internal static List<ICard> HandFlushLow()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five,CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Six,CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            return hand;
        }

        internal static List<ICard> HandFlushMiddle()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five,CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Six,CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            return hand;
        }

        internal static List<ICard> HandFlushHigh()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five,CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Six,CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            return hand;
        }

        internal static List<ICard> HandStraightFlushLow()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five,CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Six,CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts)
            };

            return hand;
        }

        internal static List<ICard> HandStraightFlushHigh()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };

            return hand;
        }

        #region invalid hands

        internal static List<ICard> HandNull()
        {
            List<ICard> hand = null;

            return hand;
        }

        internal static List<ICard> HandSixCards()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds)
            };

            return hand;
        }

        internal static List<ICard> HandFourCards()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts)
            };

            return hand;
        }

        internal static List<ICard> HandPairWithTwoExactSameCards()
        {
            List<ICard> hand = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Spades)
            };

            return hand;
        }

        #endregion
    }
}