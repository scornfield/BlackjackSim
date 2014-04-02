using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cornfield.CardGame.Library.Test
{
    [TestClass]
    public class CardBaseTests
    {
        CardBase AceOfSpades = new CardBase(SuitlessCards.Ace, Suits.Spades);
        CardBase TwoOfSpades = new CardBase(SuitlessCards.Two, Suits.Spades);

        [TestMethod]
        public void SuitlessCards_InitializedTest()
        {
            // Make sure our cards were initialized correctly
            Assert.AreEqual(new SuitlessCardBase("A", "Ace"), SuitlessCards.Ace, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Ace, new SuitlessCardBase("A", "Ace"));
            Assert.AreEqual(new SuitlessCardBase("2", "Two"), SuitlessCards.Two, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Two, new SuitlessCardBase("2", "Two"));
            Assert.AreEqual(new SuitlessCardBase("3", "Three"), SuitlessCards.Three, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Three, new SuitlessCardBase("3", "Three"));
            Assert.AreEqual(new SuitlessCardBase("4", "Four"), SuitlessCards.Four, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Four, new SuitlessCardBase("4", "Four"));
            Assert.AreEqual(new SuitlessCardBase("5", "Five"), SuitlessCards.Five, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Five, new SuitlessCardBase("5", "Five"));
            Assert.AreEqual(new SuitlessCardBase("6", "Six"), SuitlessCards.Six, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Six, new SuitlessCardBase("6", "Six"));
            Assert.AreEqual(new SuitlessCardBase("7", "Seven"), SuitlessCards.Seven, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Seven, new SuitlessCardBase("7", "Seven"));
            Assert.AreEqual(new SuitlessCardBase("8", "Eight"), SuitlessCards.Eight, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Eight, new SuitlessCardBase("8", "Eight"));
            Assert.AreEqual(new SuitlessCardBase("9", "Nine"), SuitlessCards.Nine, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Nine, new SuitlessCardBase("9", "Nine"));
            Assert.AreEqual(new SuitlessCardBase("10", "Ten"), SuitlessCards.Ten,  "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Ten, new SuitlessCardBase("10", "Ten"));
            Assert.AreEqual(new SuitlessCardBase("J", "Jack"), SuitlessCards.Jack, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Jack, new SuitlessCardBase("J", "Jack"));
            Assert.AreEqual(new SuitlessCardBase("Q", "Queen"), SuitlessCards.Queen, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.Queen, new SuitlessCardBase("Q", "Queen"));
            Assert.AreEqual(new SuitlessCardBase("K", "King"), SuitlessCards.King, "Equality Comparison Failed: {0} <> {1}", SuitlessCards.King, new SuitlessCardBase("K", "King"));
        }

        [TestMethod]
        public void SuitlessCard_EqualsTest()
        {
            Assert.AreNotEqual(SuitlessCards.Ace, SuitlessCards.Two, "Equality Comparison Failed: {0} == {1}", SuitlessCards.Ace, SuitlessCards.Two);
            Assert.AreEqual(false, SuitlessCards.Ace.Equals(null), "Comparison to null should return false.");
        }

        [TestMethod]
        public void SuitlessCard_HashCodeTest()
        {
            Assert.AreEqual(SuitlessCards.Ace.GetHashCode(), SuitlessCards.Ace.GetHashCode(), "HashCode Equality Comparison Failed: {0} <> {1}", SuitlessCards.Ace.GetHashCode(), new CardSuit("S", "Spades").GetHashCode());
            Assert.AreNotEqual(SuitlessCards.Ace.GetHashCode(), SuitlessCards.Two.GetHashCode(), "HashCode Equality Comparison Failed: {0} == {1}", SuitlessCards.Ace.GetHashCode(), SuitlessCards.Two.GetHashCode());
        }

        [TestMethod]
        public void SuitlessCard_ToStringTest()
        {
            Assert.AreEqual(SuitlessCards.Ace.ToString(), SuitlessCards.Ace.ToString(), "String Equality Comparison Failed: {0} <> {1}", SuitlessCards.Ace.ToString(), new CardSuit("S", "Spades").ToString());
            Assert.AreNotEqual(SuitlessCards.Ace.ToString(), SuitlessCards.Two.ToString(), "String Equality Comparison Failed: {0} == {1}", SuitlessCards.Ace.ToString(), SuitlessCards.Two.ToString());
        }

        [TestMethod]
        public void SuitlessCard_OperatorsTest()
        {
            SuitlessCardBase AceInstance = SuitlessCards.Ace;

            Assert.AreEqual(true, AceInstance == AceInstance, "Operator== Equality Comparison of Same Object Failed: {0} <> {1}", SuitlessCards.Ace, SuitlessCards.Ace);

            Assert.AreEqual(true, SuitlessCards.Ace == new SuitlessCardBase("A", "Ace"), "Operator== Equality Comparison Failed: {0} <> {1}", SuitlessCards.Ace, SuitlessCards.Ace);
            Assert.AreEqual(false, SuitlessCards.Ace == SuitlessCards.Two, "Operator== Equality Comparison Failed: {0} == {1}", SuitlessCards.Ace, SuitlessCards.Two);

            Assert.AreEqual(false, SuitlessCards.Ace != new SuitlessCardBase("A", "Ace"), "Operator!= Equality Comparison Failed: {0} <> {1}", SuitlessCards.Ace, SuitlessCards.Ace);
            Assert.AreEqual(true, SuitlessCards.Ace != SuitlessCards.Two, "Operator!= Equality Comparison Failed: {0} == {1}", SuitlessCards.Ace, SuitlessCards.Two);

            Assert.AreEqual(false, SuitlessCards.Ace == null, "Operator== Equality Comparison Failed: Comparison to null should return false");
            Assert.AreEqual(false, null == SuitlessCards.Ace, "Operator== Equality Comparison Failed: Comparison to null should return false");
        }

        [TestMethod]
        public void CardBase_EqualsTest()
        {
            Assert.AreEqual(AceOfSpades, new CardBase(SuitlessCards.Ace, Suits.Spades), "Equality Comparison Failed: {0} <> {1}", AceOfSpades, new CardBase(SuitlessCards.Ace, Suits.Spades));
            Assert.AreNotEqual(AceOfSpades, TwoOfSpades, "Equality Comparison Failed: {0} == {1}", AceOfSpades, TwoOfSpades);
            Assert.AreEqual(false, AceOfSpades.Equals(null), "Comparison to null should return false.");
        }

        [TestMethod]
        public void CardBase_HashCodeTest()
        {
            Assert.AreEqual(AceOfSpades.GetHashCode(), new CardBase(SuitlessCards.Ace, Suits.Spades).GetHashCode(), "HashCode Equality Comparison Failed: {0} <> {1}", AceOfSpades.GetHashCode(), new CardBase(SuitlessCards.Ace, Suits.Spades).GetHashCode());
            Assert.AreNotEqual(AceOfSpades.GetHashCode(), TwoOfSpades.GetHashCode(), "HashCode Equality Comparison Failed: {0} == {1}", AceOfSpades.GetHashCode(), TwoOfSpades.GetHashCode());
        }

        [TestMethod]
        public void CardBase_ToStringTest()
        {
            Assert.AreEqual(AceOfSpades.ToString(), new CardBase(SuitlessCards.Ace, Suits.Spades).ToString(), "String Equality Comparison Failed: {0} <> {1}", AceOfSpades.ToString(), new CardBase(SuitlessCards.Ace, Suits.Spades).ToString());
            Assert.AreNotEqual(AceOfSpades.ToString(), TwoOfSpades.ToString(), "String Equality Comparison Failed: {0} == {1}", AceOfSpades.ToString(), TwoOfSpades.ToString());
        }

        [TestMethod]
        public void CardBase_OperatorsTest()
        {
            Assert.AreEqual(true, AceOfSpades == AceOfSpades, "Operator== Equality Comparison of Same Object Failed: {0} <> {1}", AceOfSpades, AceOfSpades);

            Assert.AreEqual(true, AceOfSpades == new CardBase(SuitlessCards.Ace, Suits.Spades), "Operator== Equality Comparison Failed: {0} <> {1}", AceOfSpades, new CardBase(SuitlessCards.Ace, Suits.Spades));
            Assert.AreEqual(false, AceOfSpades == TwoOfSpades, "Operator== Equality Comparison Failed: {0} == {1}", AceOfSpades, TwoOfSpades);

            Assert.AreEqual(false, AceOfSpades != new CardBase(SuitlessCards.Ace, Suits.Spades), "Operator!= Equality Comparison Failed: {0} <> {1}", AceOfSpades, new CardBase(SuitlessCards.Ace, Suits.Spades));
            Assert.AreEqual(true, AceOfSpades != TwoOfSpades, "Operator!= Equality Comparison Failed: {0} == {1}", AceOfSpades, TwoOfSpades);

            Assert.AreEqual(false, AceOfSpades == null, "Operator== Equality Comparison Failed: Comparison to null should return false");
            Assert.AreEqual(false, null == AceOfSpades, "Operator== Equality Comparison Failed: Comparison to null should return false");
        }
    }
}
