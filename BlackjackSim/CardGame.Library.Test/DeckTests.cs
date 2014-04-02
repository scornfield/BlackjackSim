using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cornfield.CardGame.Library;

namespace Cornfield.CardGame.Library.Test
{
    [TestClass]
    public class DeckTests
    {
        public const double SHUFFLE_TOLERANCE = 0.1;

        [TestMethod]
        public void Deck_AddTest()
        {
            CardBase AceOfSpades = new CardBase(SuitlessCards.Ace, Suits.Spades);
            CardBase TwoOfSpades = new CardBase(SuitlessCards.Two, Suits.Spades);
            CardBase ThreeOfSpades = new CardBase(SuitlessCards.Three, Suits.Spades);

            Deck deck = new Deck();
            deck.Add(AceOfSpades);
            deck.Add(TwoOfSpades);
            deck.Add(ThreeOfSpades);

            Assert.AreEqual(3, deck.Count, "The deck does not have the expected number of cards.");
        }

        [TestMethod]
        public void Deck_PopTest()
        {
            CardBase AceOfSpades = new CardBase(SuitlessCards.Ace, Suits.Spades);
            CardBase TwoOfSpades = new CardBase(SuitlessCards.Two, Suits.Spades);
            CardBase ThreeOfSpades = new CardBase(SuitlessCards.Three, Suits.Spades);

            Deck deck = new Deck();
            deck.Add(AceOfSpades);
            deck.Add(TwoOfSpades);
            deck.Add(ThreeOfSpades);

            ICard card = deck.Pop();
            Assert.AreEqual(AceOfSpades, card, "The deck did not pull the expected Ace of Spades card.");

            card = deck.Pop();
            Assert.AreEqual(TwoOfSpades, card, "The deck did not pull the expected Two of Spades card.");

            card = deck.Pop();
            Assert.AreEqual(ThreeOfSpades, card, "The deck did not pull the expected Three of Spades card.");

            Assert.AreEqual(0, deck.Count, "The deck should not have any cards left.");
        }

        [TestMethod]
        public void Deck_AddStandardDeckTest()
        {
            Deck deck = new Deck();
            deck.AddStandardDeck();

            Assert.AreEqual(52, deck.Count, "The deck should have 52 cards in it.");
        }

        [TestMethod]
        public void Deck_ShuffleTest()
        {
            Deck orderedDeck = new Deck();
            orderedDeck.AddStandardDeck();

            Deck shuffledDeck = new Deck();
            shuffledDeck.AddStandardDeck();
            shuffledDeck.Shuffle();

            Assert.AreEqual(orderedDeck.Count, shuffledDeck.Count, "The shuffled deck should have the same number of cards as the ordered deck.");
            Assert.AreEqual(52, shuffledDeck.Count, "The shuffled deck should have 52 cards in it.");
            Assert.AreEqual(52, orderedDeck.Count, "The ordered deck should have 52 cards in it.");

            int matchedCards = 0;
            for(int i = 0; i < orderedDeck.Count; i++)
            {
                if (orderedDeck[i].Equals(shuffledDeck[i]))
                    matchedCards += 1; // This code won't be executed on every run of the test, because it's possible for all cards to be in a new position.
            }
            double matchedPercent = (Convert.ToDouble(matchedCards) / Convert.ToDouble(orderedDeck.Count));
            Assert.AreEqual(0.0, matchedPercent, SHUFFLE_TOLERANCE, "The shuffled deck left {0:p} of the cards in their original position.", matchedPercent);
        }

        [TestMethod]
        public void Deck_ToStringTest()
        {
            CardBase AceOfSpades = new CardBase(SuitlessCards.Ace, Suits.Spades);
            CardBase TwoOfSpades = new CardBase(SuitlessCards.Two, Suits.Spades);
            CardBase ThreeOfSpades = new CardBase(SuitlessCards.Three, Suits.Spades);

            Deck deck = new Deck();
            deck.Add(AceOfSpades);
            deck.Add(TwoOfSpades);
            deck.Add(ThreeOfSpades);

            Assert.AreEqual("AS 2S 3S", deck.ToString(), "Unexpected results from Deck.ToString(): {0}", deck.ToString());
        }
    }
}
