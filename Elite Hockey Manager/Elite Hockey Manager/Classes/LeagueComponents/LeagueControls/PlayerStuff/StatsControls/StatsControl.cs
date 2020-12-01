namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    using Elite_Hockey_Manager.Classes.Players;

    /// <summary>
    /// The stats control. Shows the top statistical positions of players in a set
    /// </summary>
    public partial class StatsControl : UserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StatsControl"/> class.
        /// </summary>
        public StatsControl()
        {
            this.InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Triggers when the stats page button is clicked
        /// </summary>
        public event Action OpenStatsPageEvent;

        /// <summary>
        /// Gets or sets a value indicating whether each player will also show their team abbreviation
        /// </summary>
        public bool DisplayTeamAbbreviation
        {
            get => this.playerStatsControl.DisplayTeamAbbreviation;
            set => this.playerStatsControl.DisplayTeamAbbreviation = value;
        }

        /// <summary>
        /// Gets or sets whether the display is showing skater or goalie stats
        /// </summary>
        public StatsDisplayType DisplayType
        {
            get => this.playerStatsControl.DisplayType;
            set
            {
                // Gets the width of the playerStatsControl within this control before it is redrawn with a new size
                int pastWidth = this.playerStatsControl.Width;

                // Sets the new Display type which goes to child PlayerStatsControl and redraws it using childs logic
                this.playerStatsControl.DisplayType = value;

                // Adjusts controls within this control to the resized playerStatsControl
                this.AdjustDisplayForDisplayTypeChange(pastWidth);
                this.AdjustButtonsToNewDisplayType(value);
            }
        }

        /// <summary>
        /// Gets or sets the title label's text at the top of the control
        /// </summary>
        public string Title
        {
            get => this.titleLabel.Text;
            set => this.titleLabel.Text = value;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets desired array of goalies to be stored and sorted within child playerStatsControl class
        /// Only updates display if goalie display type is active
        /// </summary>
        /// <param name="goalies">Array of goalies to have stats displayed</param>
        public void InsertGoalieList(Goalie[] goalies)
        {
            // Logic handled within PlayerStatsControl class
            this.playerStatsControl.StoredGoalies = goalies;
        }

        /// <summary>
        /// Helper function that takes an array of players and sorts them into skaters and goalies.
        /// Takes those 2 sorted new arrays and places them into InsertSkaterList and InsertGoalieList functions
        /// </summary>
        /// <param name="players">Array of Player objects to be sorted into Skaters and Goalies and sorted by their respective statistics</param>
        public void InsertPlayerList(Player[] players)
        {
            // Sorts the list of players that are skaters, casts them to skater, converts to array
            this.InsertSkaterList(players.Where(player => player is Skater).Cast<Skater>().ToArray());

            // Sorts the list of players that are goalies, casts them to goalie, converts to array
            this.InsertGoalieList(players.Where(player => player is Goalie).Cast<Goalie>().ToArray());
        }

        /// <summary>
        /// Sets desired array of skaters to be stored and sorted within child playerStatsControl class
        /// Only updates display if skater display type is active
        /// </summary>
        /// <param name="skaters">Array of skaters to have stats displayed</param>
        public void InsertSkaterList(Skater[] skaters)
        {
            // Logic handled within PlayerStatsControl class
            this.playerStatsControl.StoredSkaters = skaters;
        }

        /// <summary>
        /// Sets which buttons are enabled based on whether the control is showing goalie or skater stats
        /// </summary>
        /// <param name="newDisplayType">The new display state that is being set</param>
        private void AdjustButtonsToNewDisplayType(StatsDisplayType newDisplayType)
        {
            // If the display is set to show goalies, the goalieButton can be disabled
            if (newDisplayType == StatsDisplayType.Goalie)
            {
                this.skaterStatsButton.Enabled = true;
                this.goalieStatsButton.Enabled = false;
            }
            else
            {
                this.skaterStatsButton.Enabled = false;
                this.goalieStatsButton.Enabled = true;
            }
        }

        /// <summary>
        /// Adjusts the size of the control based on new display type
        /// </summary>
        /// <param name="pastWidth">The width of the control before being changed</param>
        private void AdjustDisplayForDisplayTypeChange(int pastWidth)
        {
            // Adjusts the width of the titleLabel so that it will be center aligned again, and adjust size for auto size
            this.titleLabel.Width = this.playerStatsControl.Width;

            // Sets the location of the statsFormButton to align with the right side of the control
            this.statsFormButton.Location = new Point(
                this.playerStatsControl.Width + this.playerStatsControl.Location.X - this.statsFormButton.Size.Width, this.statsFormButton.Location.Y);

            // Moves the entire control so that the autosize difference will stay aligned with the right side of where it was initially placed
            this.Location = new Point(this.Location.X + (pastWidth - this.Width), this.Location.Y);
        }

        /// <summary>
        /// Switches the view to show goalie stats
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void GoalieStatsButton_Click(object sender, EventArgs e)
        {
            this.DisplayType = StatsDisplayType.Goalie;
            this.skaterStatsButton.Enabled = true;
            this.goalieStatsButton.Enabled = false;
            this.playerStatsControl.UpdateStats();
        }

        /// <summary>
        /// Switches the view to show skater stats
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SkaterStatsButton_Click(object sender, EventArgs e)
        {
            this.DisplayType = StatsDisplayType.Skater;
            this.skaterStatsButton.Enabled = false;
            this.goalieStatsButton.Enabled = true;
            this.playerStatsControl.UpdateStats();
        }

        /// <summary>
        /// Handles when the stats page button is pressed
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void StatsFormButton_Click(object sender, EventArgs e)
        {
            this.OpenStatsPageEvent?.Invoke();
        }

        #endregion Methods
    }
}