using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerUnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class CardUnitTests
    {
        public CardUnitTests()
        {
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

        #endregion
        
        [TestMethod]
        public void TestCardToStringASpades()
        {
            Card aceSpades = new Card(CardFace.Ace, CardSuit.Spades);
        
            Assert.AreEqual("♠A", aceSpades.ToString());
        }
        
        [TestMethod]
        public void TestCardToStringTenHears()
        {
            Card tenHearts = new Card(CardFace.Ten, CardSuit.Hearts);
        
            Assert.AreEqual("♥10", tenHearts.ToString());
        }
        
        [TestMethod]
        public void TestCardToStringTwoDiamonds()
        {
            Card twoDiamonds = new Card(CardFace.Two, CardSuit.Diamonds);
        
            Assert.AreEqual("♦2", twoDiamonds.ToString());
        }
        
        [TestMethod]
        public void TestCardToStringJackClubs()
        {
            Card jackClubs = new Card(CardFace.Jack, CardSuit.Clubs);
        
            Assert.AreEqual("♣J", jackClubs.ToString());
        }
        
        [TestMethod]
        public void TestCardToStringKingClubs()
        {
            Card jackClubs = new Card(CardFace.King, CardSuit.Clubs);
        
            Assert.AreEqual("♣K", jackClubs.ToString());
        }
        
        [TestMethod]
        public void TestCardToStringQueenHearts()
        {
            Card tenHearts = new Card(CardFace.Queen, CardSuit.Hearts);
        
            Assert.AreEqual("♥Q", tenHearts.ToString());
        }
    }
}