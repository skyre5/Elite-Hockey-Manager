using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    using Elite_Hockey_Manager.Classes.Players;

    using Newtonsoft.Json.Linq;

    [Serializable]
    public abstract class Defender : Skater
    {
        #region Constructors

        public Defender(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {
        }

        public Defender(string first, string last, int age, Contract contract, SkaterAttributes attributes) : base(first, last, age, contract, attributes)
        {
        }

        public Defender(string first, string last, int age) : base(first, last, age)
        {
        }

        public Defender(string first, string last, int age, Contract contract) : base(first, last, age, contract)
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

        public override int Overall
        {
            get
            {
                return SkaterAttributes.DefenseRating();
            }
        }

        public DefensePlayerStatus PlayerStatus
        {
            get;
            protected set;
        } = DefensePlayerStatus.Unset;

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
            DefensePlayerStatus status = (DefensePlayerStatus)playerStatus;
            PlayerStatus = status;
            SkaterAttributes.GenerateDefenseStatRanges(status, this.Age);
        }

        #endregion Methods
    }
}