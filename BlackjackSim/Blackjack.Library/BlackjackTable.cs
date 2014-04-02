using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library
{
    public class BlackjackTable
    {
        
        public List<BlackjackSeat> Seats { get; private set; }
        public BlackjackDealer Dealer { get; private set; }
        public BlackjackDeck Deck { get; private set; }
        public BlackjackTableInfo Info { get; private set; }

        public BlackjackTable(int inNumDecks)
        {
            Info = new BlackjackTableInfo(inNumDecks);
            Deck = new BlackjackDeck(inNumDecks);
            Seats = new List<BlackjackSeat>();
            Dealer = new BlackjackDealer();

            Deck.Shuffle();
        }

        public void AddPlayer(BlackjackPlayerBase player, int chips)
        {
            Seats.Add(new BlackjackSeat(player, chips));
        }

        public void ClearHands()
        {
            Dealer.Hand.Clear();
            foreach (BlackjackSeat seat in Seats)
            {
                seat.Hands.Clear();
            }
        }

        public void ReshuffleDeck()
        {
            Deck.Initialize();
            Deck.Shuffle();

            Info.CardCounts.Clear();
        }

        public void PlaceBets()
        {
            double bet;
            foreach(BlackjackSeat seat in Seats) 
            {
                bet = seat.Player.PlaceBet(seat.Chips);
                seat.Chips -= bet;
                seat.Hands.Add(new BlackjackHand(bet));
            }
        }

        public void CountCard(ICard card)
        {
            if (Info.CardCounts.ContainsKey(card.Card))
                Info.CardCounts[card.Card] += 1;
            else
                Info.CardCounts.Add(card.Card, 1);
        }

        public void ClearStats()
        {
            foreach(BlackjackSeat seat in Seats)
            {
                seat.ClearOutcomes();
            }
        }
    }

    public class BlackjackTableInfo
    {
        public int NumDecks { get; private set; }
        public Dictionary<SuitlessCardBase, int> CardCounts { get; private set; }
        public ICard DealerUpCard { get; set; }

        public BlackjackTableInfo(int inNumDecks)
        {
            NumDecks = inNumDecks;
            CardCounts = new Dictionary<SuitlessCardBase, int>();
        }

    }
}
