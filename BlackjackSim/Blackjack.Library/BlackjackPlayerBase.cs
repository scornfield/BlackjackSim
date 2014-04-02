using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library
{
    public enum BlackjackActions
    {
        None,
        Hit,
        Stand,
        DoubleDown,
        Split,
        Surrender
    }

    public abstract class BlackjackPlayerBase
    {
        public string Name { get; protected set; }
        public double Bet { get; protected set; }

        protected double _baseBet;

        public BlackjackPlayerBase(string inName, double inBet = 10)
        {
            Name = inName;
            Bet = _baseBet = inBet;
        }

        public virtual BlackjackActions Play(BlackjackHand hand, BlackjackTableInfo info)
        {
            throw new NotImplementedException("You need to implement this function when you create a new Blackjack Player.");
        }

        public virtual double PlaceBet(double inChips)
        {
            Bet = _baseBet;
            return Bet;
        }

        public virtual void HandComplete(BlackjackHandFlags outcome)
        {

        }
    }
}
