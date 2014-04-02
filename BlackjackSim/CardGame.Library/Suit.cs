using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornfield.CardGame.Library
{
    public class CardSuit
    {
        public string Name { get; set; }
        public string Abbrev { get; set; }

        public CardSuit(string inAbbrev, string inName)
        {
            Name = inName;
            Abbrev = inAbbrev;
        }

        public override string ToString()
        {
            return Abbrev;
        }

        /* Code for comparisons */
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(CardSuit a, CardSuit b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
                return false;

            return a.Abbrev == b.Abbrev && a.Name == b.Name;
        }

        public static bool operator !=(CardSuit a, CardSuit b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            // If parameter cannot be cast, return false:
            CardSuit suit = obj as CardSuit;
            if ((object)suit == null)
            {
                return false;
            }

            // Return true if the fields match:
            return Abbrev == suit.Abbrev && Name == suit.Name;
        }
    }

    public static class Suits
    {
        public static System.Collections.ObjectModel.Collection<CardSuit> getAllSuits() 
        {
            System.Collections.ObjectModel.Collection<CardSuit> suitList = new System.Collections.ObjectModel.Collection<CardSuit>();
            suitList.Add(Spades);
            suitList.Add(Diamonds);
            suitList.Add(Hearts);
            suitList.Add(Clubs);

            return suitList;
        }


        public static CardSuit Spades {
            get
            {
                return new CardSuit("S", "Spades");
            }
        }

        public static CardSuit Diamonds
        {
            get
            {
                return new CardSuit("D", "Diamonds");
            }
        }

        public static CardSuit Hearts
        {
            get
            {
                return new CardSuit("H", "Hearts");
            }
        }

        public static CardSuit Clubs
        {
            get
            {
                return new CardSuit("C", "Clubs");
            }
        }
    }
}
