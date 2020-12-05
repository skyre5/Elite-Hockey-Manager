namespace Elite_Hockey_Manager.Classes.Players
{
    using System;

    using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Player class for the defender type, makes up the left and right defender
    /// </summary>
    [Serializable]
    public abstract class Defender : Skater
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Defender"/> class.
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
        protected Defender(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Defender"/> class.
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
        protected Defender(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Defender"/> class.
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
        protected Defender(string first, string last, int age) : base(first, last, age)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Defender"/> class.
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
        protected Defender(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Defender"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        protected Defender(JToken token) : base(token)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the players overall, uniquely calculated for a defender
        /// </summary>
        public override int Overall => this.SkaterAttributes.DefenseRating();

        /// <summary>
        /// Gets or sets the player's defensePlayerStatus(Talent level)
        /// </summary>
        public DefensePlayerStatus PlayerStatus
        {
            get;
            protected set;
        }
            = DefensePlayerStatus.Unset;

        /// <summary>
        /// Gets the player's base PlayerStatusId
        /// </summary>
        public override int PlayerStatusId => (int)this.PlayerStatus;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Generates attributes for a defender based on their DefenderPlayerStatus
        /// </summary>
        /// <param name="playerStatus">Player status(Talent Level)</param>
        public override void GenerateAttributes(int playerStatus)
        {
            DefensePlayerStatus status = (DefensePlayerStatus)playerStatus;
            this.PlayerStatus = status;
            this.SkaterAttributes.GenerateDefenseStatRanges(status, this.Age);
        }

        #endregion Methods
    }
}