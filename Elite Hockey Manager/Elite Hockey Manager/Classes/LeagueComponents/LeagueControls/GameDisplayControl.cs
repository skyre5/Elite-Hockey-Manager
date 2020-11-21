namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    using Elite_Hockey_Manager.Classes.GameComponents;
    using Elite_Hockey_Manager.Forms.GameForms;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The game display control.
    /// </summary>
    public partial class GameDisplayControl : UserControl
    {
        #region Fields

        // If the player simmed a game, update the standingscontrol/playoffs control. Wont go of if simmed in batch
        public EventHandler PlayerSimmedGameEvent;

        private Game _game;

        #endregion Fields

        #region Constructors

        public GameDisplayControl(Game game)
        {
            InitializeComponent();
            Game = game;
        }

        #endregion Constructors

        #region Properties

        public Game Game
        {
            get
            {
                return _game;
            }
            private set
            {
                _game = value;
                SetGameText();
            }
        }

        #endregion Properties

        #region Methods

        public void DisableButtons()
        {
            // Enabled to let players view game results
            autoSimButton.Enabled = false;
            // viewSimButton.Enabled = false;
        }

        private void autoSimButton_Click(object sender, EventArgs e)
        {
            _game.PlayGame();
            SetGameText();
            DisableButtons();
            // Sends event to update view of team in season or playoffs
            PlayerSimmedGameEvent?.Invoke(Game, null);
        }

        private void SetGameText()
        {
            // TODO
            // Include record along with team name
            gameDisplayLabel.Text = $@"{_game.AwayTeam.FullName} @ {_game.HomeTeam.FullName}";
            if (_game.Finished)
            {
                scoreLabel.Text = $@"{_game.AwayScore}-{_game.HomeScore}";
                if (_game.Overtime)
                {
                    scoreLabel.Text += @" (OT)";
                }
            }
        }

        private void viewSimButton_Click(object sender, EventArgs e)
        {
            GameForm form = new GameForm(_game);
            form.ShowDialog();
            // If the player started simming the game but closed the window, finish the game
            if (_game.Period != 1 || _game.TimeInterval != 0)
            {
                _game.PlayGame();
                DisableButtons();
            }
            // If game is finished update the text
            if (_game.Finished)
            {
                SetGameText();
                // Sends event to update view of team in season or playoffs
                PlayerSimmedGameEvent?.Invoke(Game, null);
            }
        }

        #endregion Methods
    }
}