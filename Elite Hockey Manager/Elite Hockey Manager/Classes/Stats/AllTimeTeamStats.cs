namespace Elite_Hockey_Manager.Classes.Stats
{
    /// <summary>
    /// The all time team stats
    /// </summary>
    public class AllTimeTeamStats
    {
        #region Properties

        /// <summary>
        /// Gets the goals against
        /// </summary>
        public int GoalsAgainst { get; private set; }

        /// <summary>
        /// Gets the goals for
        /// </summary>
        public int GoalsFor { get; private set; }

        /// <summary>
        /// Gets the overtime losses
        /// </summary>
        public int OvertimeLosses { get; private set; }

        /// <summary>
        /// Gets the presidents trophy wins
        /// </summary>
        public int PresidentsTrophies { get; private set; }

        /// <summary>
        /// Gets the regulation losses
        /// </summary>
        public int RegulationLosses { get; private set; }

        /// <summary>
        /// Gets the amount of stanley cups
        /// </summary>
        public int StanleyCups { get; private set; }

        /// <summary>
        /// Gets the amount of wins
        /// </summary>
        public int Wins { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds a season stats to the cumulative stats
        /// </summary>
        /// <param name="stats">A team stats of either a regular season or playoff</param>
        public void AddSeasonalStats(TeamStats stats)
        {
            // If the team has playoff stats and they won the championship, they won the stanley cup
            if (stats.Playoff)
            {
                if (stats.Champion)
                {
                    this.StanleyCups++;
                }

                return;
            }

            this.Wins += stats.Wins;
            this.RegulationLosses += stats.Losses - stats.OvertimeLosses;
            this.OvertimeLosses += stats.OvertimeLosses;
            this.GoalsFor += stats.GoalsFor;
            this.GoalsAgainst += stats.GoalsAgainst;

            // If the player won a championship during the regular season, add a presidents trophy
            if (stats.Champion)
            {
                this.PresidentsTrophies++;
            }
        }

        #endregion Methods
    }
}