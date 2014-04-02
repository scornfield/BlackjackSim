using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cornfield.Blackjack.Library;

namespace Cornfield.Blackjack.Players
{
    public class DealerPlayer: BlackjackPlayerBase
    {
        public DealerPlayer(string inName, double inBet = 10) : base(inName, inBet) { }

        public sealed override BlackjackActions Play(BlackjackHand hand, BlackjackTableInfo info)
        {
            if (hand.Score <= 16 || (hand.Score == 17 && hand.Flags.HasFlag(BlackjackHandFlags.Soft)))
                return BlackjackActions.Hit;
            else
                return BlackjackActions.Stand;
        }
    }
}
