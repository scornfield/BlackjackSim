using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cornfield.Blackjack.Library.Test
{
    [TestClass]
    public class BlackjackDeckTests
    {
        public const int NUM_DECKS = 8;

        [TestMethod]
        public void BlackjackDeck_InitTest()
        {
            BlackjackDeck deck = new BlackjackDeck(NUM_DECKS);

            deck.Initialize();

            Assert.AreEqual(deck.Count, 52 * NUM_DECKS, "Expected {0} cards in blackjack deck, found {1}", 52 * NUM_DECKS, deck.Count);
        }
    }
}
