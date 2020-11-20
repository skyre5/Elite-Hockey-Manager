using Elite_Hockey_Manager.Classes.Players.PlayerComponents;
using System;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public abstract class Forward : Skater
    {
        public ForwardPlayerStatus PlayerStatus
        {
            get;
            protected set;
        } = ForwardPlayerStatus.Unset;

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

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PlayerStatus", this.PlayerStatus);
            base.GetObjectData(info, context);
        }

        public override int PlayerStatusID
        {
            get
            {
                return (int)PlayerStatus;
            }
        }

        public override void GenerateStats(int playerStatus)
        {
            ForwardPlayerStatus status = (ForwardPlayerStatus)playerStatus;
            PlayerStatus = status;
            _attributes.GenerateForwardStatRanges(status, _age);
        }
    }
}