using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Cornfield.Blackjack.Library.Test
{
    public class TestBlackjackOutcomeCounter : IBlackjackOutcomeCounter
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Busts { get; set; }
        public int Pushes { get; set; }
        public int Blackjacks { get; set; }
        public Dictionary<string, object> OtherInfo { get; set; }

        public TestBlackjackOutcomeCounter()
        {
            OtherInfo = new Dictionary<string,object>();
        }

        public void HandComplete(BlackjackHandFlags outcome)
        {

        }
    }

    [TestClass]
    public class BlackjackOutcomeCounterTests
    {
        [TestMethod]
        public void BlackjackOutcomeCounter_CountOutcomesTest()
        {
            TestBlackjackOutcomeCounter counter = new TestBlackjackOutcomeCounter();

            Assert.AreEqual(0, counter.Wins, "Counter has not played any hands yet, should have 0 wins.");
            Assert.AreEqual(0, counter.Losses, "Counter has not played any hands yet, should have 0 losses.");
            Assert.AreEqual(0, counter.Busts, "Counter has not played any hands yet, should have 0 busts.");
            Assert.AreEqual(0, counter.Pushes, "Counter has not played any hands yet, should have 0 pushes.");
            Assert.AreEqual(0, counter.Blackjacks, "Counter has not played any hands yet, should have 0 blackjacks.");
            Assert.AreEqual(0, counter.OtherInfo.Count, "Counter has not played any hands yet, should have no other info.");

            counter.CountOutcomes(BlackjackHandFlags.Win);
            Assert.AreEqual(1, counter.Wins, "Counter should have 1 win.");

            counter.CountOutcomes(BlackjackHandFlags.Win | BlackjackHandFlags.Blackjack);
            Assert.AreEqual(2, counter.Wins, "Counter should have 2 wins and 1 blackjack.");
            Assert.AreEqual(1, counter.Blackjacks, "Counter should have 2 wins and 1 blackjack.");

            counter.CountOutcomes(BlackjackHandFlags.Push);
            Assert.AreEqual(2, counter.Wins, "Counter should have 2 wins, 1 blackjack, and 1 push.");
            Assert.AreEqual(1, counter.Blackjacks, "Counter should have 2 wins, 1 blackjack, and 1 push.");
            Assert.AreEqual(1, counter.Pushes, "Counter should have 2 wins, 1 blackjack, and 1 push.");
            
            counter.CountOutcomes(BlackjackHandFlags.Lose | BlackjackHandFlags.Bust);
            Assert.AreEqual(2, counter.Wins, "Counter should have 2 wins, 1 blackjack, 1 push, 1 loss, and 1 bust.");
            Assert.AreEqual(1, counter.Blackjacks, "Counter should have 2 wins, 1 blackjack, 1 push, 1 loss, and 1 bust.");
            Assert.AreEqual(1, counter.Pushes, "Counter should have 2 wins, 1 blackjack, 1 push, 1 loss, and 1 bust.");
            Assert.AreEqual(1, counter.Losses, "Counter should have 2 wins, 1 blackjack, 1 push, 1 loss, and 1 bust.");
            Assert.AreEqual(1, counter.Busts, "Counter should have 2 wins, 1 blackjack, 1 push, 1 loss, and 1 bust.");

            counter.ClearOutcomes();
            Assert.AreEqual(0, counter.Wins, "Counter has cleared its outcomes, should have 0 wins.");
            Assert.AreEqual(0, counter.Losses, "Counter has cleared its outcomes, should have 0 losses.");
            Assert.AreEqual(0, counter.Busts, "Counter has cleared its outcomes, should have 0 busts.");
            Assert.AreEqual(0, counter.Pushes, "Counter has cleared its outcomes, should have 0 pushes.");
            Assert.AreEqual(0, counter.Blackjacks, "Counter has cleared its outcomes, should have 0 blackjacks.");
        }
    }
}
