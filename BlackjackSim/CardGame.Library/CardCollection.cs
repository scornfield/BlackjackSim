using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornfield.CardGame.Library
{
    public class CardCollection : System.Collections.ObjectModel.Collection<CardBase>
    {
        public CardCollection() : base()
        {

        }

        public override string ToString()
        {
            return string.Join(" ", this);
        }

    }
}
