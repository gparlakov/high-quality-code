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

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestHandCreationWithSixCards_ExpectException()
        {
            IList<ICard> cards = GetTestHandSixCards();
            Hand hand = new Hand(cards);           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestHandCreationWithFourCards_ExpectException()
        {
            IList<ICard> cards = GetTestHandFourCards();
            Hand hand = new Hand(cards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHandCreationWith2ExactSameCardsExpectException()
        {
            IList<ICard> cards = GetTestHandPairWithTwoExactSameCards();
            Hand hand = new Hand(cards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHandCreationWithNull_ExpectException()
        {
            IList<ICard> cards = GetTestHandNull();
            Hand hand = new Hand(cards);
        }

        #region private methods
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

        private List<ICard> GetTestHandPairWithTwoExactSameCards()
        {
            List<ICard> hand = new List<ICard> {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Spades)
            };

            return hand;
        }

        private IList<ICard> GetTestHandNull()
        {
            List<ICard> hand = null;

            return hand;
        }

        private List<ICard> GetTestHandSixCards()
        {
            List<ICard> hand = new List<ICard> {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds)
            };

            return hand;
        }

        private List<ICard> GetTestHandFourCards()
        {
            List<ICard> hand = new List<ICard> {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts)
            };

            return hand;
        }
        #endregion
    }
}
