using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cornfield.Blackjack.Library;
using Cornfield.CardGame.Library;
using Cornfield.Blackjack.Players;

namespace BlackjackSim
{
    public partial class BlackjackSimMain : Form
    {
        private BlackjackGame _game;
        private int _numHands;
        private int _interval;

        public BlackjackSimMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            InitializeGame();
            
            UpdateStatusBar("Running Simulation...");

            DateTime start = System.DateTime.Now;
            for (int i = 1; i <= _numHands; i++)
            {
                _game.StartHand();
                _game.PlayHands();

                if (i % _interval == 0)
                {
                    UpdateStats(i, start);
                }
            }

            UpdateStats(_numHands, start);
            UpdateStatusBar("Simulation Complete.");
        }

        private void InitializeGame()
        {
            UpdateStatusBar("Initializing Game...");
            _game = new BlackjackGame(Convert.ToInt32(txtNumDecks.Text));

            _game.AddPlayer(new DealerPlayer("Dealer1"), 0);
            _game.AddPlayer(new WizardOfOddsPlayer("WizardOfOdds1"), 0);

            _numHands = Convert.ToInt32(txtNumHands.Text);
            _interval = Convert.ToInt32(txtNumInterval.Text);

            statusProgressBar.Value = 0;
            statusProgressBar.Maximum = _numHands;

            lblNumDecks.Text = string.Format("{0:N0}", _game.Table.Deck.NumDecks);
            lblNumHands.Text = string.Format("{0:N0}", _numHands);
            lblNumPlayers.Text = string.Format("{0:N0}", _game.Table.Seats.Count());

            UpdateStats();

            UpdateStatusBar("Game Ready.");
        }

        private void UpdateStats(int i = 0, DateTime start = new DateTime()) {
            
            gridStats.Rows.Clear();
            foreach(BlackjackSeat seat in _game.Table.Seats)
                gridStats.Rows.Add(seat.ObjectArray);
            gridStats.Rows.Add(new BlackjackSeat(_game.Table.Dealer, 0).ObjectArray);
            gridStats.Refresh();

            statusProgressBar.Value = i;
            statusHandCount.Text = string.Format("{0:N0}/{1:N0}", i, _numHands);
            if (i == 0)
                statusTimer.Text = "00:00";
            else
                statusTimer.Text = (System.DateTime.Now - start).ToString(@"mm\:ss\.ff");

            statusToolStrip.Refresh();
        }

        private void UpdateStatusBar(string message)
        {
            lblStatus.Text = message;
            statusToolStrip.Refresh();
        }

        private string GameDetail 
        { 
            get
            {
                return string.Format("{0} Deck{1}, {2} Player{3}, {4} Hand{5}.", _game.Table.Deck.NumDecks, s(_game.Table.Deck.NumDecks), _game.Table.Seats.Count(), s(_game.Table.Seats.Count()), _numHands, s(_numHands));
            }
        }

        private string s(int number)
        {
            return (number > 1 ? "s" : "");
        }

        private void btnClearStats_Click(object sender, EventArgs e)
        {
            _game.Table.ClearStats();
        }

        private void txtNumHands_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumHands.Text))
                txtNumInterval.Text = Convert.ToInt32(Convert.ToInt32(txtNumHands.Text) / 100).ToString();
        }

    }
}
