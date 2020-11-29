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

        public Forward(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            try
            {
                this.PlayerStatus = (ForwardPlayerStatus)info.GetValue("PlayerStatus", typeof(ForwardPlayerStatus));
            }
            catch
            {
                this.PlayerStatus = ForwardPlayerStatus.Unset;
            }
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

        public override int PlayerStatusID
        {
            get
            {
                return (int)PlayerStatus;
            }
        }

        #endregion Properties

        #region Methods

        public override void GenerateStats(int playerStatus)
        {
            ForwardPlayerStatus status = (ForwardPlayerStatus)playerStatus;
            PlayerStatus = status;
            SkaterAttributes.GenerateForwardStatRanges(status, _age);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PlayerStatus", this.PlayerStatus);
            base.GetObjectData(info, context);
        }

        #endregion Methods
    }
}