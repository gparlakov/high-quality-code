using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerUnitTests
{
    /// <summary>
    /// Summary description for HandUnitTests
    /// </summary>
    [TestClass]
    public class HandUnitTests
    {
        public HandUnitTests()
        {
        }
                 
        [TestMethod]              
        public void TestHandCreation()
        {
            IList<ICard> cards = TestHandsCreator.HandOnePairAces();
            Hand hand = new Hand(cards);

            Assert.AreEqual("♠A ♣4 ♥A ♥3 ♠8", hand.ToString());
        }

        [TestMethod]
        public void TestHandCreationWithSixCards()
        {
            IList<ICard> cards = TestHandsCreator.HandSixCards();
            Hand hand = new Hand(cards);
            Assert.AreEqual(6, hand.Cards.Count);
            Assert.AreEqual("♣A ♣4 ♥A ♥3 ♠8 ♦5", hand.ToString());
        }

        [TestMethod]
        public void TestHandCreationWithFourCards()
        {
            IList<ICard> cards = TestHandsCreator.HandFourCards();
            Hand hand = new Hand(cards);
            Assert.AreEqual(4, hand.Cards.Count);
            Assert.AreEqual("♣A ♣4 ♥A ♥3", hand.ToString());
        }

        [TestMethod]
        public void TestHandCreationWith2ExactSameCards()
        {
            IList<ICard> cards = TestHandsCreator.HandPairWithTwoExactSameCards();
            Hand hand = new Hand(cards);
            Assert.AreEqual(5, hand.Cards.Count);
            Assert.AreEqual("♣A ♣4 ♣A ♥3 ♠8", hand.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHandCreationWithNull_ExpectException()
        {
            IList<ICard> cards = TestHandsCreator.HandNull();
            Hand hand = new Hand(cards);
        }
    }
}