using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class Defender : Skater
    {
        public DefensePlayerStatus PlayerStatus
        {
            get;
            protected set;
        } = DefensePlayerStatus.Unset;
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
        public Defender(SerializationInfo info, StreamingContext context): base(info, context)
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
        protected override void GenerateInitialContract()
        {
            throw new NotImplementedException();
        }
        public override int Overall
        {
            get
            {
                return _attributes.DefenseRating();
            }
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
            DefensePlayerStatus status = (DefensePlayerStatus)playerStatus;
            PlayerStatus = status;
            _attributes.GenerateDefenseStatRanges(status, _age);
        }
        protected override void GenerateYoungContract()
        {
            int years = YearsForEntryContract();
            double amount = 0;
            switch (PlayerStatus)
            {
                case DefensePlayerStatus.Generational:
                    amount = 2.5;
                    break;
                case DefensePlayerStatus.Superstar:
                    amount = 2;
                    break;
                case DefensePlayerStatus.FirstPairing:
                    amount = 1.5;
                    break;
                case DefensePlayerStatus.SecondPairing:
                    amount = 1;
                    break;
                case DefensePlayerStatus.BottomPairing:
                    amount = .5;
                    break;
                case DefensePlayerStatus.Role:
                    amount = 0;
                    break;
                case DefensePlayerStatus.Unset:
                    amount = 0;
                    break;
            }
            Contract contract = new Contract(1, years, amount);
            _careerContracts.Add(contract);
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PlayerStatus", this.PlayerStatus);
            base.GetObjectData(info, context);
        }
    }
}
