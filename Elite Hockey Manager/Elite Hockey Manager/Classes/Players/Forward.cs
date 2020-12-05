using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    using Elite_Hockey_Manager.Classes.Players;

    using Newtonsoft.Json.Linq;

    [Serializable]
    public abstract class Forward : Skater
    {
        #region Constructors

        public Forward(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }

        public Forward(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }

        public Forward(string first, string last, int age) : base(first, last, age)
        {
        }

        public Forward(string first, string last, int age, Contract contract) : base(first, last, age, contract)
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

        public ForwardPlayerStatus PlayerStatus
        {
            get;
            protected set;
        } = ForwardPlayerStatus.Unset;

        public override int PlayerStatusId
        {
            get
            {
                return (int)PlayerStatus;
            }
        }

        #endregion Properties

        #region Methods

        public override void GenerateAttributes(int playerStatus)
        {
            ForwardPlayerStatus status = (ForwardPlayerStatus)playerStatus;
            PlayerStatus = status;
            SkaterAttributes.GenerateForwardStatRanges(status, this.Age);
        }

        #endregion Methods
    }
}