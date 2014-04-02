using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornfield.Blackjack.Library
{
    public interface IBlackjackOutcomeCounter
    {
        int Wins { get; set; }
        int Losses { get; set; }
        int Busts { get; set; }
        int Pushes { get; set; }
        int Blackjacks { get; set; }
        Dictionary<string, object> OtherInfo { get; set; }

        object[] ObjectArray { get; }
    }

    public static class BlackjackOutcomeCounterExtentions
    {
        public static void CountOutcomes(this IBlackjackOutcomeCounter obj, BlackjackHandFlags outcome)
        {
            if (outcome.HasFlag(BlackjackHandFlags.Win))
                obj.Wins += 1;
            if (outcome.HasFlag(BlackjackHandFlags.Lose))
                obj.Losses += 1;
            if (outcome.HasFlag(BlackjackHandFlags.Push))
                obj.Pushes += 1;
            if (outcome.HasFlag(BlackjackHandFlags.Bust))
                obj.Busts += 1;
            if (outcome.HasFlag(BlackjackHandFlags.Blackjack))
                obj.Blackjacks += 1;
        }

        public static void ClearOutcomes(this IBlackjackOutcomeCounter obj)
        {
            obj.Wins = obj.Losses = obj.Pushes = obj.Busts = obj.Blackjacks = 0;
        }
    }
}
