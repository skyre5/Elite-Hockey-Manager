namespace Elite_Hockey_Manager.Classes.Stats
{
    using System;

    /// <summary>
    /// A players all time stats culminating all their seasons in the league
    /// </summary>
    [Serializable]
    public class AllTimeSkaterStats
    {
        #region Properties

        /// <summary>
        /// Gets the total number of career assists
        /// </summary>
        public int Assists { get; private set; }

        /// <summary>
        /// Gets the total number of career games played
        /// </summary>
        public int GamesPlayed { get; private set; }

        /// <summary>
        /// Gets the total number of career goals
        /// </summary>
        public int Goals { get; private set; }

        /// <summary>
        /// Gets the total number of career penalty minutes
        /// </summary>
        public int PenaltyMinutes { get; private set; }

        /// <summary>
        /// Gets the total number of career plus minus
        /// </summary>
        public int PlusMinus { get; private set; }

        /// <summary>
        /// Gets the total number of career points
        /// </summary>
        public int Points => this.Goals + this.Assists;

        /// <summary>
        /// Gets the total number of playing seasons player played
        /// </summary>
        public int Seasons { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds a season of a players stats to his career stats
        /// </summary>
        /// <param name="stats">A stats object for a year of play</param>
        public void AddSeasonalStats(SkaterStats stats)
        {
            // If the season of stats has 0 games played, don't count it in their all time stats
            if (stats.GamesPlayed == 0)
            {
                return;
            }

            this.Seasons++;
            this.GamesPlayed += stats.GamesPlayed;
            this.Goals += stats.Goals;
            this.Assists += stats.Assists;
            this.PlusMinus += stats.PlusMinus;
            this.PenaltyMinutes += stats.PenaltyMinutes;
        }

        #endregion Methods
    }
}