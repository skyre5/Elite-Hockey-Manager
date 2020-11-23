namespace Elite_Hockey_Manager.Forms.GameForms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using Elite_Hockey_Manager.Classes;
    using Elite_Hockey_Manager.Classes.Utility;

    /// <summary>
    /// The team stats form.
    /// </summary>
    public partial class TeamStatsForm : Form
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamStatsForm"/> class.
        /// </summary>
        public TeamStatsForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamStatsForm"/> class.
        /// </summary>
        /// <param name="league">
        /// The league that contains the teams
        /// </param>
        /// <param name="allTime">
        /// whether to display the current seasons team stats or the all time stats of the teams
        /// </param>
        public TeamStatsForm(League league, bool allTime) : this()
        {
            if (allTime)
            {
                this.SetAllTimeSeasonStats(league);
            }
            else
            {
                this.SetCurrentSeasonStats(league);
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Sets the dataGridView for the all time team stats of all the teams in the league
        /// </summary>
        /// <param name="league">League that holds the teams</param>
        private void SetAllTimeSeasonStats(League league)
        {
            // Creates an object with the team name and the all time stats for each team
            var teamTotalStatsQuery = from t in league.AllTeams
                                      select new { t.TeamName, AllTimeStats = t.GetAllTimeTeamStats() };
            var displayQuery = from t in teamTotalStatsQuery
                               orderby t.AllTimeStats.Wins descending
                               select new
                               {
                                   t.TeamName,
                                   t.AllTimeStats.StanleyCups,
                                   t.AllTimeStats.PresidentsTrophies,
                                   t.AllTimeStats.Wins,
                                   t.AllTimeStats.RegulationLosses,
                                   t.AllTimeStats.OvertimeLosses,
                                   t.AllTimeStats.GoalsFor,
                                   t.AllTimeStats.GoalsAgainst
                               };
            var allTimeStatsBindingList = displayQuery.ToList().ToSortableBindingList();
            this.dataGridView1.DataSource = allTimeStatsBindingList;
        }

        /// <summary>
        /// Sets the dataGridView for the stats of the current season
        /// </summary>
        /// <param name="league">League that holds the teams</param>
        private void SetCurrentSeasonStats(League league)
        {
            List<Team> allTeams = league.AllTeams;
            var teamQuery = from t in allTeams
                            orderby t.CurrentRegularSeasonStats.Points descending
                            select new
                            {
                                t.TeamName,
                                Record = t.CurrentRegularSeasonStats.Record(),
                                t.CurrentRegularSeasonStats.Points,
                                t.CurrentRegularSeasonStats.GoalsFor,
                                t.CurrentRegularSeasonStats.GoalsAgainst,
                                t.CurrentRegularSeasonStats.ShotsFor,
                                t.CurrentRegularSeasonStats.ShotsAgainst
                            };
            var bindingList = teamQuery.ToList().ToSortableBindingList();
            this.dataGridView1.DataSource = bindingList;
        }

        #endregion Methods
    }
}