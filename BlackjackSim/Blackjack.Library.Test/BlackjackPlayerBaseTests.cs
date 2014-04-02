using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library.Test
{
    // Test class to test methods implemented by the BlackjackPlayerBase
    public sealed class TestBlackjackPlayerBase : BlackjackPlayerBase
    {
        public TestBlackjackPlayerBase()
            : base("Test", 10)
        {
            
        }
    }

    [TestClass]
    public class BlackjackPlayerBaseTests
    {
        [TestMethod]
        public void BlackjackPlayer_CreationTest()
        {
            TestBlackjackPlayerBase player = new TestBlackjackPlayerBase();

            Assert.AreNotEqual(null, player, "New player should not be null.");
            Assert.AreEqual("Test", player.Name, "Player forgot their name.");
            Assert.AreEqual(10, player.Bet, "Player forgot their bet.");
        }

        [TestMethod]
        public void BlackjackPlayer_PlaceBetTest()
        {
            TestBlackjackPlayerBase player = new TestBlackjackPlayerBase();

            Assert.AreEqual(10, player.PlaceBet(0), "The player base should never change its bet.");
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "The play method shouldn't be implemented in the BlackjackPlayerBase")]
        public void BlackjackPlayer_PlayTest()
        {
            TestBlackjackPlayerBase player = new TestBlackjackPlayerBase();

            BlackjackActions a = player.Play(new BlackjackHand(player.PlaceBet(0)), new BlackjackTableInfo(8));
        }

        [TestMethod]
        public void BlackjackPlayer_HandCompleteTest()
        {
            TestBlackjackPlayerBase player = new TestBlackjackPlayerBase();

            player.HandComplete(BlackjackHandFlags.None);
        }
    }
}
