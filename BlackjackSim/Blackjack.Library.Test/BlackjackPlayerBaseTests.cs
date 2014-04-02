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

            Assert.AreEqual(0, player.Wins, "Player has not played any hands yet, should have 0 wins.");
            Assert.AreEqual(0, player.Losses, "Player has not played any hands yet, should have 0 losses.");
            Assert.AreEqual(0, player.Busts, "Player has not played any hands yet, should have 0 busts.");
            Assert.AreEqual(0, player.Pushes, "Player has not played any hands yet, should have 0 pushes.");
            Assert.AreEqual(0, player.Blackjacks, "Player has not played any hands yet, should have 0 blackjacks.");
            Assert.AreEqual(string.Empty, player.OtherInfo, "Player has not played any hands yet, should have no other info.");
        }

        [TestMethod]
        public void BlackjackPlayer_PlaceBetTest()
        {
            TestBlackjackPlayerBase player = new TestBlackjackPlayerBase();

            Assert.AreEqual(10, player.PlaceBet(0), "The player base should never change its bet.");
        }

        [TestMethod]
        public void BlackjackPlayer_CountOutcomesTest()
        {
            TestBlackjackPlayerBase player = new TestBlackjackPlayerBase();

            player.CountOutcomes(BlackjackHandFlags.Win);
            Assert.AreEqual(1, player.Wins, "Player should have 1 win.");

            player.CountOutcomes(BlackjackHandFlags.Win | BlackjackHandFlags.Blackjack);
            Assert.AreEqual(2, player.Wins, "Player should have 2 wins and 1 blackjack.");
            Assert.AreEqual(1, player.Blackjacks, "Player should have 2 wins and 1 blackjack.");

            player.CountOutcomes(BlackjackHandFlags.Push);
            Assert.AreEqual(2, player.Wins, "Player should have 2 wins, 1 blackjack, and 1 push.");
            Assert.AreEqual(1, player.Blackjacks, "Player should have 2 wins, 1 blackjack, and 1 push.");
            Assert.AreEqual(1, player.Pushes, "Player should have 2 wins, 1 blackjack, and 1 push.");

            player.CountOutcomes(BlackjackHandFlags.Lose | BlackjackHandFlags.Bust);
            Assert.AreEqual(2, player.Wins, "Player should have 2 wins, 1 blackjack, 1 push, 1 loss, and 1 bust.");
            Assert.AreEqual(1, player.Blackjacks, "Player should have 2 wins, 1 blackjack, 1 push, 1 loss, and 1 bust.");
            Assert.AreEqual(1, player.Pushes, "Player should have 2 wins, 1 blackjack, 1 push, 1 loss, and 1 bust.");
            Assert.AreEqual(1, player.Losses, "Player should have 2 wins, 1 blackjack, 1 push, 1 loss, and 1 bust.");
            Assert.AreEqual(1, player.Busts, "Player should have 2 wins, 1 blackjack, 1 push, 1 loss, and 1 bust.");

            Assert.AreEqual(string.Format("{0,-12}{1,8}{2,8}{3,8}{4,8}{5,8}", "Test", 2, 1, 1, 1, 1), player.ToString(), "Unexpected output from player.toString");

            player.ClearOutcomes();
            Assert.AreEqual(0, player.Wins, "Player has cleared its outcomes, should have 0 wins.");
            Assert.AreEqual(0, player.Losses, "Player has cleared its outcomes, should have 0 losses.");
            Assert.AreEqual(0, player.Busts, "Player has cleared its outcomes, should have 0 busts.");
            Assert.AreEqual(0, player.Pushes, "Player has cleared its outcomes, should have 0 pushes.");
            Assert.AreEqual(0, player.Blackjacks, "Player has cleared its outcomes, should have 0 blackjacks.");
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

        [TestMethod]
        public void BlackjackPlayer_PrintStatsTest()
        {
            TestBlackjackPlayerBase player = new TestBlackjackPlayerBase();

            player.PrintStats();
        }
    }
}
