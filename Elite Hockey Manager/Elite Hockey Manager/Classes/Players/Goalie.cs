namespace Elite_Hockey_Manager.Classes.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Goalie player object
    /// </summary>
    [Serializable]
    public class Goalie : Player
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Goalie"/> class.
        /// </summary>
        /// <param name="first">
        /// Player's first name
        /// </param>
        /// <param name="last">
        /// Player's last name
        /// </param>
        /// <param name="age">
        /// Player's age
        /// </param>
        /// <param name="attributes">
        /// Player's base attributes
        /// </param>
        public Goalie(string first, string last, int age, GoalieAttributes attributes) : base(first, last, age)
        {
            this.GoalieAttributes = attributes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Goalie"/> class.
        /// </summary>
        /// <param name="first">
        /// Player's first name
        /// </param>
        /// <param name="last">
        /// Player's last name
        /// </param>
        /// <param name="age">
        /// Player's age
        /// </param>
        /// <param name="contract">
        /// Player's base contract
        /// </param>
        /// <param name="attributes">
        /// Player's base attributes
        /// </param>
        public Goalie(string first, string last, int age, Contract contract, GoalieAttributes attributes) : base(first, last, age, contract)
        {
            this.GoalieAttributes = attributes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Goalie"/> class.
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
        public Goalie(string first, string last, int age) : base(first, last, age)
        {
            this.GoalieAttributes = new GoalieAttributes();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Goalie"/> class.
        /// </summary>
        /// <param name="first">
        /// Player's first name
        /// </param>
        /// <param name="last">
        /// Player's last name
        /// </param>
        /// <param name="age">
        /// Player's age
        /// </param>
        /// <param name="contract">
        /// Player's base contract
        /// </param>
        public Goalie(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
            this.GoalieAttributes = new GoalieAttributes();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Goalie"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public Goalie(JToken token) : base(token)
        {
            this.GoalieAttributes = new GoalieAttributes();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the player's base attributes
        /// </summary>
        public override BaseAttributes Attributes => this.GoalieAttributes;

        /// <summary>
        /// Gets the player's goalie attributes
        /// </summary>
        public GoalieAttributes GoalieAttributes { get; private set; }

        /// <summary>
        /// Gets the player's overall, uniquely calculated for goalie
        /// </summary>
        public override int Overall => this.GoalieAttributes.GoalieOverall();

        /// <summary>
        /// Gets or sets the Goalie's playerStatus(Talent level)
        /// </summary>
        public GoaliePlayerStatus PlayerStatus
        {
            get;
            protected set;
        }
            = GoaliePlayerStatus.Unset;

        /// <summary>
        /// Gets the Goalie's status id and returns it into the base playerStatusId
        /// </summary>
        public override int PlayerStatusId => (int)this.PlayerStatus;

        /// <summary>
        /// Gets the player's positional abbreviation
        /// </summary>
        public override string PositionAbbreviation => "G";

        /// <summary>
        /// Gets the player's latest season's stats
        /// </summary>
        public GoalieStats Stats
        {
            get
            {
                if (this.StatsList.Count == 0)
                {
                    Console.WriteLine(@"Unset goalie stats added\n" + new System.Diagnostics.StackTrace());
                    this.StatsList.Add(new GoalieStats(-1, -1));
                }

                return this.StatsList.Last();
            }
        }

        /// <summary>
        /// Gets the player's goalie stats history
        /// </summary>
        public List<GoalieStats> StatsList { get; private set; } = new List<GoalieStats>();

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds a new season of stats to a player's stats history
        /// </summary>
        /// <param name="year">year of new stats season</param>
        /// <param name="teamId">id of team the player plays for</param>
        /// <param name="playoffs">Whether the new stats season is for playoffs</param>
        public override void AddStats(int year, int teamId, bool playoffs)
        {
            this.StatsList.Add(new GoalieStats(year, teamId, playoffs));
        }

        /// <summary>
        /// Generates goalie's attributes based on talent level in playerStatus
        /// </summary>
        /// <param name="playerStatus">Goalie talent level id</param>
        public override void GenerateAttributes(int playerStatus)
        {
            GoaliePlayerStatus status = (GoaliePlayerStatus)playerStatus;
            this.PlayerStatus = status;
            this.GoalieAttributes.GenerateGoalieStatRanges(status, this.Age);
        }

        #endregion Methods
    }
}