namespace Elite_Hockey_Manager.Classes.Players
{
    using System;

    using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The right defender
    /// </summary>
    [Serializable]
    public class RightDefender : Defender
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RightDefender"/> class.
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
        public RightDefender(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RightDefender"/> class.
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
        public RightDefender(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RightDefender"/> class.
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
        public RightDefender(string first, string last, int age) : base(first, last, age)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RightDefender"/> class.
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
        public RightDefender(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RightDefender"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public RightDefender(JToken token) : base(token)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Player's positional abbreviation
        /// </summary>
        public override string PositionAbbreviation => "RD";

        #endregion Properties
    }
}