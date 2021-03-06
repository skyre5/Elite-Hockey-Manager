﻿namespace Elite_Hockey_Manager.Classes.Players
{
    using System;

    using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The base forward player class, base class for left winger, right winger, and center
    /// </summary>
    [Serializable]
    public abstract class Forward : Skater
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Forward"/> class.
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
        protected Forward(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Forward"/> class.
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
        protected Forward(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Forward"/> class.
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
        protected Forward(string first, string last, int age) : base(first, last, age)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Forward"/> class.
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
        protected Forward(string first, string last, int age, Contract contract) : base(first, last, age, contract)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Forward"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        protected Forward(JToken token) : base(token)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the player's forwardStatusId(Talent Level)
        /// </summary>
        public ForwardPlayerStatus PlayerStatus
        {
            get;
            protected set;
        }
            = ForwardPlayerStatus.Unset;

        /// <summary>
        /// Gets the player's base status id
        /// </summary>
        public override int PlayerStatusId => (int)this.PlayerStatus;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Generates forward's attributes based on forward status id
        /// </summary>
        /// <param name="playerStatus">Forward player status id</param>
        public override void GenerateAttributes(int playerStatus)
        {
            ForwardPlayerStatus status = (ForwardPlayerStatus)playerStatus;
            this.PlayerStatus = status;
            this.SkaterAttributes.GenerateForwardStatRanges(status, this.Age);
        }

        #endregion Methods
    }
}