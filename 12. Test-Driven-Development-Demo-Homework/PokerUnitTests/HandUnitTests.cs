using System;
using System.Text;
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
            //
            // TODO: Add constructor logic here
            //
        }

        //private TestContext testContextInstance;

        ///// <summary>
        /////Gets or sets the test context which provides
        /////information about and functionality for the current test run.
        /////</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        // ♦
        // ♥
        // ♠
        // ♣
        #endregion
                                  
        [TestMethod]              
        public void TestHandCreation()
        {
            IList<ICard> cards = GetTestHandPairAces();
            Hand hand = new Hand(cards);

            Assert.AreEqual("♣A ♣4 ♥A ♥3 ♠8", hand.ToString());
        }

        private IList<ICard> GetTestHandPairAces()
        {
            List<ICard> hand = new List<ICard> {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Spades)
            };

            return hand;
        }

        private List<Card> GetTestHandPairWithTwoExactSameCards()
        {
            List<Card> hand = new List<Card> {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Spades)
            };

            return hand;
        }

        private List<Card> GetTestHandNull()
        {
            List<Card> hand = null;

            return hand;
        }

        private List<Card> GetTestHandSixCards()
        {
            List<Card> hand = new List<Card> {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds)
            };

            return hand;
        }

        private List<Card> GetTestHandFourCards()
        {
            List<Card> hand = new List<Card> {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts)
            };

            return hand;
        }
    }
}
