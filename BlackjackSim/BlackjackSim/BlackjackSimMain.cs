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
        private bool _initialized = false;
        private int _numHands;
        private int _interval;

        public BlackjackSimMain()
        {
            InitializeComponent();
        }

        private void BlackjackSimMain_Load(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void btnRun_Click(object sender, EventArgs run_e)
        {
            // Initialize the Game
            InitializeGame();

            // Create the main game thread and start it
            System.Threading.Thread gameThread = new System.Threading.Thread(StartGameThread);
            gameThread.Start();
        }

        // This method is a wrapper so that we don't need to pass parameters to our thread call
        private void StartGameThread()
        {
            UpdateStatusBar("Running Simulation...");
            _game.Play(_numHands, _interval);
        }

        // This method initializes the game and the UI
        private void InitializeGame()
        {
            UpdateStatusBar("Initializing Game...");
            _game = new BlackjackGame(Convert.ToInt32(txtNumDecks.Text));

            // Add our UpdateStats methods to our event handlers
            _game.PlayIntervalReached += UpdateStats;
            _game.BlackjackGameComplete += UpdateStats;

            // Add Players
            _game.AddPlayer(new DealerPlayer("Dealer1"), 0);
            _game.AddPlayer(new WizardOfOddsPlayer("WizardOfOdds1"), 0);

            // Set our number of hands and update inverval
            _numHands = Convert.ToInt32(txtNumHands.Text);
            _interval = Convert.ToInt32(txtNumInterval.Text);

            // Initialize the status bar
            statusProgressBar.Value = 0;
            statusProgressBar.Maximum = _numHands;

            // Initialize labels
            lblNumDecks.Text = string.Format("{0:N0}", _game.Table.Deck.NumDecks);
            lblNumHands.Text = string.Format("{0:N0}", _numHands);
            lblNumPlayers.Text = string.Format("{0:N0}", _game.Table.Seats.Count());

            InitializeGrid();
            UpdateStats();

            UpdateStatusBar("Game Ready.");
        }

        private void InitializeGrid()
        {
            // Perform 1 time setup of the grid
            if (!_initialized)
            {
                SourceGrid.Cells.Editors.TextBoxNumeric currencyEditor = new SourceGrid.Cells.Editors.TextBoxCurrency(typeof(double));
                currencyEditor.TypeConverter = new DevAge.ComponentModel.Converter.CurrencyTypeConverter(typeof(double));
                currencyEditor.AllowNull = true;

                SourceGrid.Cells.Editors.TextBoxNumeric numericEditor = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(int));
                numericEditor.TypeConverter = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(int), "N0");
                numericEditor.AllowNull = true;

                _initialized = true;
                gridStats.Columns.Add("Name", "Player Name", typeof(string));
                gridStats.Columns.Add("Chips", "Chips", currencyEditor);
                gridStats.Columns.Add("Wins", "Wins", numericEditor);
                gridStats.Columns.Add("Losses", "Losses", numericEditor);
                gridStats.Columns.Add("Pushes", "Pushes", numericEditor);
                gridStats.Columns.Add("Busts", "Busts", numericEditor);
                gridStats.Columns.Add("Blackjacks", "Blackjacks", numericEditor);

                gridStats.Columns.StretchToFit();
            }
            
            // Bind the grid to our data source
            gridStats.DataSource = new DevAge.ComponentModel.BoundList<BlackjackSeat>(_game.Table.Seats);
        }

        // This method handles the PlayIntervalReached event of the BlackjackGame
        private void UpdateStats(object Sender, BlackjackGamePlayIntervalReachedArgs e)
        {
            UpdateStats(e.HandsPlayed, e.StartTime);
        }

        // This method handles the BlackjackGameComplete event of the BlackjackGame
        private void UpdateStats(object Sender, BlackjackGameCompleteArgs e)
        {
            UpdateStatusBar("Simulation Complete.");
            UpdateStats(e.HandsPlayed, e.StartTime, e.EndTime);
        }

        // This method performs UI updates in a background thread
        private void UpdateStats(int i = 0, DateTime start = new DateTime(), DateTime curr = new DateTime())
        {
            this.BeginInvoke(new Action(() =>
            {
                gridStats.Refresh();

                statusProgressBar.Value = i;
                statusHandCount.Text = string.Format("{0:N0}/{1:N0}", i, _numHands);
                if (i == 0)
                    statusTimer.Text = "00:00";
                else
                {
                    if (curr == new DateTime())
                        curr = DateTime.Now;
                    statusTimer.Text = (curr - start).ToString(@"mm\:ss\.ff");
                }

                statusToolStrip.Refresh();
            }));
        }

        // This method updates the status bar in a background thread
        private void UpdateStatusBar(string message)
        {
            this.BeginInvoke(new Action(() =>
            {
                lblStatus.Text = message;
                statusToolStrip.Refresh();
            }));
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
            UpdateStats();
        }

        private void txtNumHands_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumHands.Text))
                txtNumInterval.Text = Convert.ToInt32(Convert.ToInt32(txtNumHands.Text) / 100).ToString();
        }

    }
}
