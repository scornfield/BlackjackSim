using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cornfield.CardGame.Library.Test
{
    [TestClass]
    public class SuitTests
    {
        [TestMethod]
        public void Suits_InitializedTest()
        {
            // Make sure our suits were initialized correctly
            Assert.AreEqual(new CardSuit("S", "Spades"), Suits.Spades, "Equality Comparison Failed: {0} <> {1}", Suits.Spades, new CardSuit("S", "Spades"));
            Assert.AreEqual(new CardSuit("D", "Diamonds"), Suits.Diamonds, "Equality Comparison Failed: {0} <> {1}", Suits.Diamonds, new CardSuit("D", "Diamonds"));
            Assert.AreEqual(new CardSuit("H", "Hearts"), Suits.Hearts, "Equality Comparison Failed: {0} <> {1}", Suits.Hearts, new CardSuit("H", "Hearts"));
            Assert.AreEqual(new CardSuit("C", "Clubs"), Suits.Clubs, "Equality Comparison Failed: {0} <> {1}", Suits.Clubs, new CardSuit("Clubs", "Clubs"));
        }

        [TestMethod]
        public void Suit_EqualsTest()
        {
            Assert.AreNotEqual(Suits.Spades, Suits.Diamonds, "Equality Comparison Failed: {0} == {1}", Suits.Spades, Suits.Diamonds);
            Assert.AreEqual(false, Suits.Spades.Equals(null), "Comparison to null should return false.");
        }

        [TestMethod]
        public void Suit_HashCodeTest()
        {
            Assert.AreEqual(Suits.Spades.GetHashCode(), Suits.Spades.GetHashCode(), "HashCode Equality Comparison Failed: {0} <> {1}", Suits.Spades.GetHashCode(), new CardSuit("S", "Spades").GetHashCode());
            Assert.AreNotEqual(Suits.Spades.GetHashCode(), Suits.Diamonds.GetHashCode(), "HashCode Equality Comparison Failed: {0} == {1}", Suits.Spades.GetHashCode(), Suits.Diamonds.GetHashCode());
        }

        [TestMethod]
        public void Suit_ToStringTest()
        {
            Assert.AreEqual(Suits.Spades.ToString(), Suits.Spades.ToString(), "String Equality Comparison Failed: {0} <> {1}", Suits.Spades.ToString(), new CardSuit("S", "Spades").ToString());
            Assert.AreNotEqual(Suits.Spades.ToString(), Suits.Diamonds.ToString(), "String Equality Comparison Failed: {0} == {1}", Suits.Spades.ToString(), Suits.Diamonds.ToString());
        }

        [TestMethod]
        public void Suit_OperatorsTest()
        {
            CardSuit SpadesInstance = Suits.Spades;

            Assert.AreEqual(true, SpadesInstance == SpadesInstance, "Operator== Equality Comparison of Same Object Failed: {0} <> {1}", Suits.Spades, Suits.Spades);

            Assert.AreEqual(true, Suits.Spades == new CardSuit("S", "Spades"), "Operator== Equality Comparison Failed: {0} <> {1}", Suits.Spades, Suits.Spades);
            Assert.AreEqual(false, Suits.Spades == Suits.Diamonds, "Operator== Equality Comparison Failed: {0} == {1}", Suits.Spades, Suits.Diamonds);

            Assert.AreEqual(false, Suits.Spades != Suits.Spades, "Operator!= Equality Comparison Failed: {0} <> {1}", Suits.Spades, Suits.Spades);
            Assert.AreEqual(true, Suits.Spades != Suits.Diamonds, "Operator!= Equality Comparison Failed: {0} == {1}", Suits.Spades, Suits.Diamonds);

            Assert.AreEqual(false, Suits.Spades == null, "Operator== Equality Comparison Failed: Comparison to null should return false");
            Assert.AreEqual(false, null == Suits.Spades, "Operator== Equality Comparison Failed: Comparison to null should return false");
        }
    }
}
