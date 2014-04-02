using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library.Test
{
    [TestClass]
    public class MockCardsTests
    {
        [TestMethod]
        public void MockCards_CardTests()
        {
            Assert.AreEqual(SuitlessCards.Ace, MockCards.Ace.Card);
            Assert.AreEqual(SuitlessCards.Two, MockCards.Two.Card);
            Assert.AreEqual(SuitlessCards.Three, MockCards.Three.Card);
            Assert.AreEqual(SuitlessCards.Four, MockCards.Four.Card);
            Assert.AreEqual(SuitlessCards.Five, MockCards.Five.Card);
            Assert.AreEqual(SuitlessCards.Six, MockCards.Six.Card);
            Assert.AreEqual(SuitlessCards.Seven, MockCards.Seven.Card);
            Assert.AreEqual(SuitlessCards.Eight, MockCards.Eight.Card);
            Assert.AreEqual(SuitlessCards.Nine, MockCards.Nine.Card);
            Assert.AreEqual(SuitlessCards.Ten, MockCards.Ten.Card);
            Assert.AreEqual(SuitlessCards.Jack, MockCards.Jack.Card);
            Assert.AreEqual(SuitlessCards.Queen, MockCards.Queen.Card);
            Assert.AreEqual(SuitlessCards.King, MockCards.King.Card);
        }
    }
}
