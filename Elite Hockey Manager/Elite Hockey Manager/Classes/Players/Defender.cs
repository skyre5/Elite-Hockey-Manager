using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    using Elite_Hockey_Manager.Classes.Players;

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

        public Defender(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            try
            {
                this.PlayerStatus = (DefensePlayerStatus)info.GetValue("PlayerStatus", typeof(DefensePlayerStatus));
            }
            catch
            {
                this.PlayerStatus = DefensePlayerStatus.Unset;
            }
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
            DefensePlayerStatus status = (DefensePlayerStatus)playerStatus;
            PlayerStatus = status;
            SkaterAttributes.GenerateDefenseStatRanges(status, _age);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PlayerStatus", this.PlayerStatus);
            base.GetObjectData(info, context);
        }

        #endregion Methods
    }
}