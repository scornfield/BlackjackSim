using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library
{
    public class BlackjackDeck : Deck
    {
        public int NumDecks { get; private set; }
        public int Cut { get; private set; }

        public BlackjackDeck(int inNumDecks) : base()
        {
            NumDecks = inNumDecks;
            this.Initialize();
        }

        /// <summary>
        /// Initializes the deck to be a standard blackjack deck
        /// </summary>
        public void Initialize()
        {
            Clear();

            for(int deck = 0; deck < NumDecks; deck++)
            {
                AddStandardDeck();
            }

            Random rng = new Random();
            Cut = rng.Next(Convert.ToInt32(this.Count() * 0.5), Convert.ToInt32(this.Count() * 0.9));
        }
    }
}
