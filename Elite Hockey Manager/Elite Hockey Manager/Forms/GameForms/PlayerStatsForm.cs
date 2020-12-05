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
                this.SetAllTimeSeasonStats(league);
            }
            else
            {
                // Checks if the league is currently in playoffs or offseason where the latest stats to display will be playoff stats
                bool isPlayoffStats = league.State == LeagueState.Offseason || league.State == LeagueState.Playoffs;

                // Adds playoff to string if appropriate
                this.Text = $@"{league.LeagueName}: Year {league.Year} {(isPlayoffStats ? "Playoff " : "")}Skater Stats";
                this.SetCurrentSeasonStats(league);
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Sets the dataGridView to the all time stats of the players
        /// </summary>
        /// <param name="league">League containing all players that ever played</param>
        private void SetAllTimeSeasonStats(League league)
        {
            List<Skater> allSkaters = league.Players.OfType<Skater>().ToList();
            var playerAndCareerStatsQuery =
                from p in allSkaters select new { p.FullName, AllTimeStats = p.GetAllTimeSkaterStats() };
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
            List<Skater> baseSkaters;

            // If the league is currently in the playoffs then display all playoff player's playoff stats
            // If the league is in offseason, then the latest stats are still playoffs
            if (league.State == LeagueState.Playoffs || league.State == LeagueState.Offseason)
            {
                baseSkaters = league.currentPlayoff.GetAllPlayoffPlayers().OfType<Skater>().ToList();
            }
            else
            {
                // Show every signed players regular season stats
                baseSkaters = league.SignedPlayers.OfType<Skater>().ToList();
            }

            var query = from p in baseSkaters
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

        #endregion Methods
    }
}