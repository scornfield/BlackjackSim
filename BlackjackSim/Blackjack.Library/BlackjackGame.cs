using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library
{
    #region Custom Event Args
    public class BlackjackGamePlayIntervalReachedArgs : EventArgs
    {
        public BlackjackGamePlayIntervalReachedArgs(int handsPlayed, DateTime startTime)
        {
            _handsPlayed = handsPlayed;
            _startTime = startTime;
        }

        private int _handsPlayed;
        private DateTime _startTime;
        
        public int HandsPlayed
        {
            get { return _handsPlayed; }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
        }
    }

    public class BlackjackGameCompleteArgs : EventArgs
    {
        public BlackjackGameCompleteArgs(int handsPlayed, DateTime startTime, DateTime endTime)
        {
            _handsPlayed = handsPlayed;
            _startTime = startTime;
            _endTime = endTime;
        }

        private int _handsPlayed;
        private DateTime _startTime;
        private DateTime _endTime;

        public int HandsPlayed
        {
            get { return _handsPlayed; }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
        }

        public DateTime EndTime
        {
            get { return _endTime; }
        }
    }
    #endregion

    public class BlackjackGame
    {
        private DateTime _start;
        private DateTime _end;

        public BlackjackTable Table { get; private set; }
        public BlackjackGame(int inNumDecks)
        {
            Table = new BlackjackTable(inNumDecks);
        }

        public void AddPlayer(BlackjackPlayerBase player, int chips)
        {
            Table.AddPlayer(player, chips);
        }

        #region Event Handlers
        public event EventHandler<BlackjackGamePlayIntervalReachedArgs> PlayIntervalReached;
        public event EventHandler<BlackjackGameCompleteArgs> BlackjackGameComplete;
        protected virtual void OnRaisePlayIntervalReached(BlackjackGamePlayIntervalReachedArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler<BlackjackGamePlayIntervalReachedArgs> handler = PlayIntervalReached;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, e);
            }
        }

        protected virtual void OnRaiseBlackjackGameComplete(BlackjackGameCompleteArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler<BlackjackGameCompleteArgs> handler = BlackjackGameComplete;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, e);
            }
        }
        #endregion

        #region Public Game Methods
        // This method plays the game for a given number of hands, and raises an event at specified intervals
        public void Play(int numHands, int interval)
        {

            _start = System.DateTime.Now;
            for (int i = 1; i <= numHands; i++)
            {
                StartHand();
                PlayHands();

                if (i % interval == 0)
                {
                    OnRaisePlayIntervalReached(new BlackjackGamePlayIntervalReachedArgs(i, _start));
                }
            }
            _end = System.DateTime.Now;
            OnRaiseBlackjackGameComplete(new BlackjackGameCompleteArgs(numHands, _start, _end));
        }
        #endregion

        #region Private Game Methods
        // This method starts the hand for all of the players and the dealer
        private void StartHand()
        {
            ICard card;

            Table.ClearHands();
            Table.PlaceBets();

            if (Table.Deck.Count() < Table.Deck.Cut)
                Table.ReshuffleDeck();

            for (int i = 0; i < 2; i++)
            {
                foreach (BlackjackSeat seat in Table.Seats)
                {
                    card = Table.Deck.Pop();
                    Table.CountCard(card);
                    seat.Hands[0].DealCard(card);
                }
                card = Table.Deck.Pop();
                Table.CountCard(card);
                Table.Dealer.Hand.AddCard(card);
            }

            foreach (BlackjackSeat seat in Table.Seats)
                seat.Hands[0].CalculateScore();

            Table.Info.DealerUpCard = Table.Dealer.VisibleCard;
        }

        // This method plays one round of hands for all players and the dealer
        private void PlayHands()
        {
            foreach (BlackjackSeat seat in Table.Seats)
            {
                PlaySeatHand(seat);
            }

            PlayDealerHand();

            foreach (BlackjackSeat seat in Table.Seats)
            {
                foreach (BlackjackHand hand in seat.Hands)
                {
                    FinishHand(seat, hand);
                }
            }

            Table.Dealer.CountOutcomes(Table.Dealer.Hand.Flags);
        }

        // This method plays one hand for one seat at the table
        private void PlaySeatHand(BlackjackSeat seat, int handIndex = 0)
        {
            BlackjackActions action = BlackjackActions.None;
            
            // If the player stood or double'd down then they are done playing for this hand.
            while (action != BlackjackActions.Stand && action != BlackjackActions.DoubleDown && !seat.Hands[handIndex].Flags.HasFlag(BlackjackHandFlags.Bust))
            {
                action = seat.Player.Play(seat.Hands[handIndex], Table.Info);

                PlayHandAction(seat, handIndex, action);
            }

            if (seat.Hands[handIndex].Flags.HasFlag(BlackjackHandFlags.Split))
            {
                for (int i = handIndex + 1; i < seat.Hands.Count(); i++)
                {
                    // Player must take at least 1 card after the split
                    ICard card = Table.Deck.Pop();
                    Table.CountCard(card);
                    seat.Hands[i].AddCard(card);
                    PlaySeatHand(seat, i);
                }
            }
        }

        // This method takes one action on one hand during a players turn
        private void PlayHandAction(BlackjackSeat seat, int handIndex, BlackjackActions action)
        {
            ICard card;

            switch (action)
            {
                case BlackjackActions.Hit:
                    card = Table.Deck.Pop();
                    Table.CountCard(card);
                    seat.Hands[handIndex].Hit(card);
                    break;
                case BlackjackActions.DoubleDown:
                    if (!BlackjackRules.CanDouble(seat.Hands[handIndex]))
                        throw new BlackjackRulesViolationException(seat.Hands[handIndex], action);
                    card = Table.Deck.Pop();
                    Table.CountCard(card);
                    seat.Chips -= seat.Hands[handIndex].Bet;
                    seat.Hands[handIndex].DoubleDown(card);
                    seat.Hands[handIndex].Flags |= BlackjackHandFlags.DoubleDown;
                    break;
                case BlackjackActions.Split:
                    if (!BlackjackRules.CanSplit(seat.Hands[handIndex]))
                        throw new BlackjackRulesViolationException(seat.Hands[handIndex], action);
                    seat.Hands.Add(new BlackjackHand(seat.Hands[handIndex].Bet));
                    seat.Chips -= seat.Hands[handIndex].Bet;
                    seat.Hands[seat.Hands.Count() - 1].AddCard(seat.Hands[handIndex].Split());
                    seat.Hands[handIndex].Flags |= BlackjackHandFlags.Split;
                    // Player must take at least 1 card after the split
                    card = Table.Deck.Pop();
                    Table.CountCard(card);
                    seat.Hands[handIndex].AddCard(card);
                    break;
            }
        }

        // This method plays the dealer's hand
        private void PlayDealerHand()
        {
            BlackjackActions action = BlackjackActions.None;
            while (action != BlackjackActions.Stand && Table.Dealer.Hand.Flags != BlackjackHandFlags.Bust)
            {
                action = Table.Dealer.Play();

                PlayDealerAction(action);
            }
        }

        // This method takes an action on the dealer's hand
        private void PlayDealerAction(BlackjackActions action)
        {
            switch (action)
            {
                case BlackjackActions.Hit:
                    ICard card = Table.Deck.Pop();
                    Table.CountCard(card);
                    Table.Dealer.Hand.AddCard(card);
                    break;
                case BlackjackActions.DoubleDown:
                    throw new BlackjackRulesViolationException("The Dealer Cannot Double Down.");
                case BlackjackActions.Split:
                    throw new BlackjackRulesViolationException("The Dealer Cannot Split.");
            }
        }

        // This method finishes a hand for a seat at the table by distributing winnings and counting the outcomes
        private void FinishHand(BlackjackSeat seat, BlackjackHand hand)
        {
            BlackjackHandEvaluator.CompareHands(hand, Table.Dealer.Hand);

            if (hand.Flags.HasFlag(BlackjackHandFlags.Blackjack) && Table.Dealer.Hand.Flags.HasFlag(BlackjackHandFlags.Blackjack))
                seat.Chips += hand.Bet * 2;
            else if (hand.Flags.HasFlag(BlackjackHandFlags.Blackjack))
                seat.Chips += hand.Bet * 2.5;
            else if (hand.Flags.HasFlag(BlackjackHandFlags.Win))
                seat.Chips += hand.Bet * 2;

            seat.CountOutcomes(hand.Flags);
        }
        #endregion

        #region Debug Print Methods
        public void PrintStats()
        {
            Console.WriteLine("{0,-12}{1,8}{2,8}{3,8}{4,8}{5,8}{6,14}", "Name", "Wins", "Losses", "Pushes", "Busts", "BJacks", "Chips");
            foreach (BlackjackSeat seat in Table.Seats)
            {
                Console.WriteLine(seat);
            }

            Console.WriteLine(Table.Dealer);
        }

        public void PrintChips()
        {
            Console.WriteLine("Name\tChips");
            foreach (BlackjackSeat seat in Table.Seats)
            {
                Console.WriteLine(string.Format("{0}\t{1}", seat.Player.Name, seat.Chips));
            }
        }
        #endregion
    }
}
