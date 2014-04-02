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
        public int Wins { get; protected set; }
        public int Losses { get; protected set; }
        public int Busts { get; protected set; }
        public int Pushes { get; protected set; }
        public int Blackjacks { get; protected set; }
        public string OtherInfo { get; protected set; }

        public string Name { get; protected set; }
        public double Bet { get; protected set; }

        protected double _baseBet;

        public BlackjackPlayerBase(string inName, double inBet = 10)
        {
            Name = inName;
            Bet = _baseBet = inBet;

            ClearOutcomes();
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

        public void CountOutcomes(BlackjackHandFlags outcome)
        {
            if (outcome.HasFlag(BlackjackHandFlags.Win))
                Wins += 1;
            if (outcome.HasFlag(BlackjackHandFlags.Lose))
                Losses += 1;
            if (outcome.HasFlag(BlackjackHandFlags.Push))
                Pushes += 1;
            if (outcome.HasFlag(BlackjackHandFlags.Bust))
                Busts += 1;
            if (outcome.HasFlag(BlackjackHandFlags.Blackjack))
                Blackjacks += 1;
        }

        public void ClearOutcomes()
        {
            Wins = Losses = Pushes = Busts = Blackjacks = 0;
            OtherInfo = string.Empty;
        }

        public override string ToString()
        {
            return string.Format("{0,-12}{1,8}{2,8}{3,8}{4,8}{5,8}", Name, Wins, Losses, Pushes, Busts, Blackjacks);
        }

        public void PrintStats()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
