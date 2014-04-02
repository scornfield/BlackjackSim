using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornfield.Blackjack.Library
{
    public class BlackjackSeat: IBlackjackOutcomeCounter
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Busts { get; set; }
        public int Pushes { get; set; }
        public int Blackjacks { get; set; }
        public Dictionary<string, object> OtherInfo { get; set; }

        public BlackjackPlayerBase Player { get; set; }
        public BlackjackHandCollection Hands { get; set; }
        public double Chips { get; set; }

        public string Name
        {
            get
            {
                return Player.Name;
            }
        }

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
                objs[2] = Wins;
                objs[3] = Losses;
                objs[4] = Busts;
                objs[5] = Pushes;
                objs[6] = Blackjacks;
                objs[7] = OtherInfo;

                return objs;
            }
        }

        public override string ToString()
        {
            return string.Format("{0,-12}{1,8}{2,8}{3,8}{4,8}{5,8}{1,14:N0}", Name, Wins, Losses, Pushes, Busts, Blackjacks, Chips);
        }

        public void PrintStats()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
