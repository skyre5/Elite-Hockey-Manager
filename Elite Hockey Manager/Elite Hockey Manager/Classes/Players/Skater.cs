namespace Elite_Hockey_Manager.Classes.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
    using Elite_Hockey_Manager.Classes.Stats;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The skater. Abstract class for all players besides the goalie
    /// </summary>
    [Serializable]
    public abstract class Skater : Player
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Skater"/> class
        /// </summary>
        /// <param name="first">
        /// player first name
        /// </param>
        /// <param name="last">
        /// player last name
        /// </param>
        /// <param name="age">
        /// player age
        /// </param>
        /// <param name="attributes">
        /// player's skater attributes
        /// </param>
        protected Skater(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age)
        {
            this.SkaterAttributes = attributes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Skater"/> class.
        /// </summary>
        /// <param name="first">
        /// The first name
        /// </param>
        /// <param name="last">
        /// The last name
        /// </param>
        /// <param name="age">
        /// The age
        /// </param>
        /// <param name="contract">
        /// The contract
        /// </param>
        /// <param name="attributes">
        /// The attributes
        /// </param>
        protected Skater(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract)
        {
            this.SkaterAttributes = attributes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Skater"/> class.
        /// </summary>
        /// <param name="first">
        /// The first.
        /// </param>
        /// <param name="last">
        /// The last.
        /// </param>
        /// <param name="age">
        /// The age.
        /// </param>
        protected Skater(string first, string last, int age) : base(first, last, age)
        {
            this.SkaterAttributes = new SkaterAttributes();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Skater"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        protected Skater(JToken token) : base(token)
        {
            this.SkaterAttributes = new SkaterAttributes();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Skater"/> class.
        /// </summary>
        /// <param name="first">
        /// The first.
        /// </param>
        /// <param name="last">
        /// The last.
        /// </param>
        /// <param name="age">
        /// The age.
        /// </param>
        /// <param name="contract">
        /// The contract.
        /// </param>
        protected Skater(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
            this.SkaterAttributes = new SkaterAttributes();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the attributes in base form
        /// </summary>
        public override BaseAttributes Attributes => this.SkaterAttributes;

        /// <summary>
        /// Gets or sets the skater attributes
        /// </summary>
        public SkaterAttributes SkaterAttributes { get; protected set; }

        /// <summary>
        /// Gets the current skater stats for this season
        /// </summary>
        public SkaterStats Stats
        {
            get
            {
                // If there are no stats on list add a new invalid SkaterStats object
                if (this.StatsList.Count == 0)
                {
                    Console.WriteLine(@"Unset skater stats added\n" + new System.Diagnostics.StackTrace());
                    this.StatsList.Add(new SkaterStats(-1, -1));
                }

                return this.StatsList.Last();
            }
        }

        /// <summary>
        /// Gets or sets the stats list. Holds all the players seasons of regular season and playoffs
        /// </summary>
        public List<SkaterStats> StatsList { get; protected set; } = new List<SkaterStats>();

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds a new season of stats to be tracked. Either a new season of regular season play or playoffs
        /// </summary>
        /// <param name="year">year of stats to be tracked</param>
        /// <param name="teamId">id for team the player is playing on</param>
        /// <param name="playoffs">whether the stats are for playoffs or regular season</param>
        public override void AddStats(int year, int teamId, bool playoffs)
        {
            this.StatsList.Add(new SkaterStats(year, teamId, playoffs));
        }

        /// <summary>
        /// Gets the all time stats of the player
        /// </summary>
        /// <returns>AllTimeSkaterStats object is returned</returns>
        public AllTimeSkaterStats GetAllTimeSkaterStats()
        {
            AllTimeSkaterStats allTimeStats = new AllTimeSkaterStats();
            foreach (SkaterStats stats in this.StatsList)
            {
                // Only add regular season stats
                if (stats.Playoff == false)
                {
                    allTimeStats.AddSeasonalStats(stats);
                }
            }

            return allTimeStats;
        }

        #endregion Methods
    }
}