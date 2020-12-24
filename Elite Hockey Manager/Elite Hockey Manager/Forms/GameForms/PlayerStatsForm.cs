namespace Elite_Hockey_Manager.Forms.GameForms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using Elite_Hockey_Manager.Classes;
    using Elite_Hockey_Manager.Classes.Players;
    using Elite_Hockey_Manager.Classes.Utility;

    /// <summary>
    /// The player stats form
    /// </summary>
    public sealed partial class PlayerStatsForm : Form
    {
        #region Fields

        /// <summary>
        /// Stores the list of all the players for the relevant season
        /// </summary>
        private List<Skater> skaters;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerStatsForm"/> class.
        /// </summary>
        public PlayerStatsForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerStatsForm"/> class.
        /// </summary>
        /// <param name="league">
        /// League containing players
        /// </param>
        /// <param name="allTime">
        /// Whether the stats are for career stats or stats of the current season
        /// </param>
        public PlayerStatsForm(League league, bool allTime) : this()
        {
            if (allTime)
            {
                this.Text = $@"{league.LeagueName}: All Time Skater Stats";

                // Team selection disabled when viewing all time stats
                this.teamSelectionComboBox.Visible = false;
                this.teamSelectionComboBox.Enabled = false;
                this.SetAllTimeSeasonStats(league);
            }
            else
            {
                // Checks if the league is currently in playoffs or offseason where the latest stats to display will be playoff stats
                bool isPlayoffStats = league.State == LeagueState.Offseason || league.State == LeagueState.Playoffs;

                // Adds playoff to string if appropriate
                this.Text = $@"{league.LeagueName}: Year {league.Year} {(isPlayoffStats ? "Playoff " : "")}Skater Stats";

                // Adds all playoff teams to the team selection combo box if in playoffs, all teams otherwise
                this.LoadTeamsIntoComboBox(isPlayoffStats ? league.CurrentPlayoff.PlayoffTeams : league.AllTeams);
                this.SetCurrentSeasonStats(league);
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Fills the data grid view by a list of skaters and also a team if the user is sorting by a specific team
        /// Used on the stats of the current season whether playoff or regular season
        /// </summary>
        /// <param name="matchingTeam">Specific team to view players on, null shows all relevant teams</param>
        private void FillViewByTeam(Team matchingTeam = null)
        {
            var query = from p in this.skaters
                        where matchingTeam == null || matchingTeam == p.CurrentTeam
                        where p.Stats.GamesPlayed > 0
                        orderby p.Stats.Points descending
                        select new
                        {
                            p.FullName,
                            p.Overall,
                            Position = p.PositionAbbreviation,
                            p.Age,
                            p.Stats.Points,
                            p.Stats.Goals,
                            p.Stats.Assists,
                            p.Stats.PlusMinus
                        };

            // Creates sortableBindingList from extension method in SortableBindingList class file
            var bindingList = query.ToList().ToSortableBindingList();
            this.playerStatsDataGridView.DataSource = bindingList;
        }

        /// <summary>
        /// Loads all the relevant teams into a combo box for user selection to sort by team. Only used when viewing current season stats
        /// </summary>
        /// <param name="teams">Teams that the user can sort by</param>
        private void LoadTeamsIntoComboBox(List<Team> teams)
        {
            foreach (Team team in teams)
            {
                this.teamSelectionComboBox.Items.Add(team);
            }

            this.teamSelectionComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Sets the dataGridView to the all time stats of the players
        /// </summary>
        /// <param name="league">League containing all players that ever played</param>
        private void SetAllTimeSeasonStats(League league)
        {
            this.skaters = league.Players.OfType<Skater>().ToList();
            var playerAndCareerStatsQuery =
                from p in this.skaters select new { p.FullName, AllTimeStats = p.GetAllTimeSkaterStats() };
            var displayQuery = from p in playerAndCareerStatsQuery
                               where p.AllTimeStats.GamesPlayed > 0
                               orderby p.AllTimeStats.Points descending
                               select new
                               {
                                   p.FullName,
                                   p.AllTimeStats.Seasons,
                                   p.AllTimeStats.GamesPlayed,
                                   p.AllTimeStats.Points,
                                   p.AllTimeStats.Goals,
                                   p.AllTimeStats.Assists,
                                   p.AllTimeStats.PlusMinus
                               };
            var allTimeStatsBindingList = displayQuery.ToList().ToSortableBindingList();
            this.playerStatsDataGridView.DataSource = allTimeStatsBindingList;
        }

        /// <summary>
        /// Sets the DataGridView to the stats of the current season
        /// </summary>
        /// <param name="league">League containing the signed players from this season</param>
        private void SetCurrentSeasonStats(League league)
        {
            // If the league is currently in the playoffs then display all playoff player's playoff stats
            // If the league is in offseason, then the latest stats are still playoffs
            if (league.State == LeagueState.Playoffs || league.State == LeagueState.Offseason)
            {
                this.skaters = league.CurrentPlayoff.GetAllPlayoffPlayers().OfType<Skater>().ToList();
            }
            else
            {
                // Show every signed players regular season stats
                this.skaters = league.SignedPlayers.OfType<Skater>().ToList();
            }

            // Fills the view with all the skaters from the current season
            this.FillViewByTeam();
        }

        #endregion Methods

        /// <summary>
        /// Event when TeamSelectionComboBox selection is changed
        /// </summary>
        /// <param name="sender">combo box sender</param>
        /// <param name="e">event args</param>
        private void TeamSelectionComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.SelectedIndex == 0)
            {
                this.FillViewByTeam();
            }
            else
            {
                // Fills the view with only players of that team
                this.FillViewByTeam((Team)box.SelectedItem);
            }
        }
    }
}