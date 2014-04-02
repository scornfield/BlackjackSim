using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornfield.Blackjack.Library
{
    public class BlackjackSeat
    {
        public BlackjackPlayerBase Player { get; set; }
        public BlackjackHandCollection Hands { get; set; }
        public double Chips { get; set; }

        public BlackjackSeat(BlackjackPlayerBase player, double inChips)
        {
            Player = player;
            Hands = new BlackjackHandCollection();
            Chips = inChips;
        }

        public object[] ObjectArray
        {
            get{
                object[] objs = new object[8];
                objs[0] = Player.Name;
                objs[1] = Chips;
                objs[2] = Player.Wins;
                objs[3] = Player.Losses;
                objs[4] = Player.Pushes;
                objs[5] = Player.Busts;
                objs[6] = Player.Blackjacks;
                objs[7] = Player.OtherInfo;

                return objs;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}{1,14:N0}", Player, Chips);
        }
    }
}
