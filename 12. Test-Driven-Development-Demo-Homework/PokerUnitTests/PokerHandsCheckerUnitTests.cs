using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerUnitTests
{
    [TestClass]
    public class PokerHandsCheckerUnitTests
    {
        private readonly PokerHandsChecker handsChecker;

        public PokerHandsCheckerUnitTests()
        {
            PokerHandsChecker handChecker = new PokerHandsChecker();
            this.handsChecker = handChecker;
        }

        #region IsValidHandTests
        
        [TestMethod]              
        public void TestIsValidHandWithValidHand()
        {
            IList<ICard> cards = TestHandsCreator.HandOnePairAces();
            Hand hand = new Hand(cards);
        
            Assert.IsTrue(this.handsChecker.IsValidHand(hand));
        }
        
        [TestMethod]
        public void TestIsValidHandWithFourCardsHand()
        {
            IList<ICard> cards = TestHandsCreator.HandFourCards();
            Hand hand = new Hand(cards);
        
            Assert.IsFalse(this.handsChecker.IsValidHand(hand));
        }
        
        [TestMethod]
        public void TestIsValidHandWithSixCardsHand()
        {
            IList<ICard> cards = TestHandsCreator.HandSixCards();
            Hand hand = new Hand(cards);
        
            Assert.IsFalse(this.handsChecker.IsValidHand(hand));
        }
        
        [TestMethod]
        public void TestIsValidHandWithTwoDuplicateCards()
        {
            IList<ICard> cards = TestHandsCreator.HandPairWithTwoExactSameCards();
            Hand hand = new Hand(cards);
        
            Assert.IsFalse(this.handsChecker.IsValidHand(hand));
        }

        #endregion
        
        #region IsOnePairTests
        
        [TestMethod]
        public void TestIsOnePair_WithOnePairHand()
        {
            IList<ICard> cards = TestHandsCreator.HandOnePairAces();
            Hand hand = new Hand(cards);

            Assert.IsTrue(this.handsChecker.IsOnePair(hand));
        }
        
        [TestMethod]
        public void TestIsOnePair_WithNoPairHand()
        {
            IList<ICard> cards = TestHandsCreator.HandFiveCardsHighCard();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsOnePair(hand));
        }
        
        [TestMethod]
        public void TestIsOnePair_WithThreeOfAKindHand()
        {
            IList<ICard> cards = TestHandsCreator.HandThreeOfAKind();
            Hand hand = new Hand(cards);

            Assert.IsTrue(this.handsChecker.IsOnePair(hand));
        }
        
        #endregion
        
        #region IsTwoPairTests
            
        [TestMethod]
        public void TestIsTwoPair_WithTwoPairHand()
        {
            IList<ICard> cards = TestHandsCreator.HandTwoPair();
            Hand hand = new Hand(cards);
        
            Assert.IsTrue(this.handsChecker.IsTwoPair(hand));
        }
            
        [TestMethod]
        public void TestIsTwoPair_WithFourOfAKindHandLow()
        {
            IList<ICard> cards = TestHandsCreator.HandFourOfAKindLow();
            Hand hand = new Hand(cards);
        
            Assert.IsTrue(this.handsChecker.IsTwoPair(hand));
        }
            
        [TestMethod]
        public void TestIsTwoPair_WithFourOfAKindHandHigh()
        {
            IList<ICard> cards = TestHandsCreator.HandFourOfAKindHigh();
            Hand hand = new Hand(cards);
        
            Assert.IsTrue(this.handsChecker.IsTwoPair(hand));
        }
            
        [TestMethod]
        public void TestIsTwoPair_WithOnePairHand()
        {
            IList<ICard> cards = TestHandsCreator.HandOnePairAces();
            Hand hand = new Hand(cards);
        
            Assert.IsFalse(this.handsChecker.IsTwoPair(hand));
        }
            
        [TestMethod]
        public void TestIsTwoPair_WithNoPairHand()
        {
            IList<ICard> cards = TestHandsCreator.HandFiveCardsHighCard();
            Hand hand = new Hand(cards);
        
            Assert.IsFalse(this.handsChecker.IsTwoPair(hand));
        }
            
        [TestMethod]
        public void TestIsTwoPair_WithThreeOfAKindHand()
        {
            IList<ICard> cards = TestHandsCreator.HandThreeOfAKind();
            Hand hand = new Hand(cards);
        
            Assert.IsFalse(this.handsChecker.IsTwoPair(hand));
        }

        #endregion

        #region IsStraight
        [TestMethod]
        public void TestIsStraight_WithStraightLow()
        {
            IList<ICard> cards = TestHandsCreator.HandStraightLow();
            Hand hand = new Hand(cards);

            Assert.IsTrue(this.handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraight_WithStraightHigh()
        {
            IList<ICard> cards = TestHandsCreator.HandStraightHigh();
            Hand hand = new Hand(cards);

            Assert.IsTrue(this.handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraight_WithStraightFlushLow()
        {
            IList<ICard> cards = TestHandsCreator.HandStraightFlushLow();
            Hand hand = new Hand(cards);

            Assert.IsTrue(this.handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraight_WithStraightFlushHigh()
        {
            IList<ICard> cards = TestHandsCreator.HandStraightFlushHigh();
            Hand hand = new Hand(cards);

            Assert.IsTrue(this.handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraight_WithOnePair()
        {
            IList<ICard> cards = TestHandsCreator.HandOnePairAces();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraight_WithFlushLow()
        {
            IList<ICard> cards = TestHandsCreator.HandFlushLow();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraight_WithFullHouseTwoThree()
        {
            IList<ICard> cards = TestHandsCreator.HandFullHouseTwoThenThree();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraight_WithFullHouseThreeTwo()
        {
            IList<ICard> cards = TestHandsCreator.HandFullHouseThreeThenTwo();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsStraight(hand));
        }

        #endregion
        
        #region IsThreeOfAkindTests
            
        [TestMethod]
        public void TestIsThreeOfAkind_WithThreeOfAKindHand()
        {
            IList<ICard> cards = TestHandsCreator.HandThreeOfAKind();
            Hand hand = new Hand(cards);
        
            Assert.IsTrue(this.handsChecker.IsThreeOfAKind(hand));
        }
            
        [TestMethod]
        public void TestIsThreeOfAkind_WithOnePairHand()
        {
            IList<ICard> cards = TestHandsCreator.HandOnePairAces();
            Hand hand = new Hand(cards);
        
            Assert.IsFalse(this.handsChecker.IsThreeOfAKind(hand));
        }
            
        [TestMethod]
        public void TestIsThreeOfAkind_WithTwoPairHand()
        {
            IList<ICard> cards = TestHandsCreator.HandTwoPair();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsThreeOfAKind(hand));
        }
        
        #endregion

        #region IsFlush
        [TestMethod]
        public void TestIsFlush_WithFlush()
        {
            IList<ICard> cards = TestHandsCreator.HandFlushLow();
            Hand hand = new Hand(cards);

            Assert.IsTrue(this.handsChecker.IsFlush(hand));
        }

        public void TestIsFlush_WithStraightFlush()
        {
            IList<ICard> cards = TestHandsCreator.HandStraightFlushLow();
            Hand hand = new Hand(cards);

            Assert.IsTrue(this.handsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsFlush_WithPair()
        {
            IList<ICard> cards = TestHandsCreator.HandOnePairAces();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsFlush_WithStraight()
        {
            IList<ICard> cards = TestHandsCreator.HandStraightLow();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsFlush(hand));
        }
        #endregion

        #region IsFullHouse
        [TestMethod]
        public void TestIsFullHouse_WithFullHouseTwoThree()
        {
            IList<ICard> cards = TestHandsCreator.HandFullHouseTwoThenThree();
            Hand hand = new Hand(cards);

            Assert.IsTrue(this.handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_WithFullHouseThreeTwo()
        {
            IList<ICard> cards = TestHandsCreator.HandFullHouseThreeThenTwo();
            Hand hand = new Hand(cards);

            Assert.IsTrue(this.handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_WithOnePair()
        {
            IList<ICard> cards = TestHandsCreator.HandOnePairAces();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_WithTwoPair()
        {
            IList<ICard> cards = TestHandsCreator.HandTwoPair();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_WithStraight()
        {
            IList<ICard> cards = TestHandsCreator.HandStraightLow();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_WithThreeOfAKind()
        {
            IList<ICard> cards = TestHandsCreator.HandThreeOfAKind();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_WithFourOfAKind()
        {
            IList<ICard> cards = TestHandsCreator.HandFourOfAKindLow();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_WithFlush()
        {
            IList<ICard> cards = TestHandsCreator.HandFlushLow();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_WithStraightFlush()
        {
            IList<ICard> cards = TestHandsCreator.HandStraightFlushLow();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsFullHouse(hand));
        }
        #endregion

        #region IsFourOfAKind

        [TestMethod]
        public void TestIsFourOfAkind_WithFourOfAKindHand()
        {
            IList<ICard> cards = TestHandsCreator.HandFourOfAKindLow();
            Hand hand = new Hand(cards);
            
            Assert.IsTrue(this.handsChecker.IsFourOfAKind(hand));
        }
            
        [TestMethod]
        public void TestIsFourOfAkind_WithFourOfAKindHandVariantTwo()
        {
            IList<ICard> cards = TestHandsCreator.HandFourOfAKindHigh();
            Hand hand = new Hand(cards);
            
            Assert.IsTrue(this.handsChecker.IsFourOfAKind(hand));
        }
            
        [TestMethod]
        public void TestIsFourOfAkind_WithThreeOfAKindHand()
        {
            IList<ICard> cards = TestHandsCreator.HandThreeOfAKind();
            Hand hand = new Hand(cards);
            
            Assert.IsFalse(this.handsChecker.IsFourOfAKind(hand));
        }
            
        [TestMethod]
        public void TestIsFourOfAkind_WithOnePairHand()
        {
            IList<ICard> cards = TestHandsCreator.HandOnePairAces();
            Hand hand = new Hand(cards);
            
            Assert.IsFalse(this.handsChecker.IsFourOfAKind(hand));
        }
            
        [TestMethod]
        public void TestIsFourOfAkind_WithTwoPairHand()
        {
            IList<ICard> cards = TestHandsCreator.HandTwoPair();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsFourOfAKind(hand));
        }
        
        #endregion

        #region IsStraightFlush
        [TestMethod]
        public void TestIsStraightFlush_WithStraightFlush()
        {
            IList<ICard> cards = TestHandsCreator.HandStraightFlushLow();
            Hand hand = new Hand(cards);

            Assert.IsTrue(this.handsChecker.IsStraightFlush(hand));
        }

        public void TestIsStraightFlush_WithFlush()
        {
            IList<ICard> cards = TestHandsCreator.HandFlushLow();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestIsStraightFlush_WithPair()
        {
            IList<ICard> cards = TestHandsCreator.HandOnePairAces();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestIsStraightFlush_WithStraight()
        {
            IList<ICard> cards = TestHandsCreator.HandStraightLow();
            Hand hand = new Hand(cards);

            Assert.IsFalse(this.handsChecker.IsStraightFlush(hand));
        }
        #endregion

        #region CompareHands
        [TestMethod]
        public void TestCompareHands_WithPairAndTwoPair()
        {
            IList<ICard> cardsLeft = TestHandsCreator.HandOnePairAces();
            Hand handLeft = new Hand(cardsLeft);
            IList<ICard> cardsRight = TestHandsCreator.HandOnePairAces();
            Hand handRight = new Hand(cardsRight);

            Assert.AreEqual(-1,this.handsChecker.CompareHands(handLeft, handRight));
        }

        #endregion
    }
}