using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.Players.PlayerComponents;

namespace Elite_Hockey_Manager.Classes
{

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
        protected override void GenerateInitialContract()
        {
            //If other contracts are found doesn't generate one
            if (_careerContracts.Count == 0)
            {
                if (_age <= 21)
                {
                    GenerateYoungContract();
                    int overall = this.Overall;
                    switch (overall)
                    {
                        case int o when (o > 95):
                        //    break;
                    }
                }
            }
        }
        protected override void GenerateYoungContract()
        {
            int years = YearsForEntryContract();
            double amount = 0;
            switch (PlayerStatus)
            {
                case ForwardPlayerStatus.Generational:
                    amount = 2;
                    break;
                case ForwardPlayerStatus.Superstar:
                    amount = 1.5;
                    break;
                case ForwardPlayerStatus.FirstLine:
                    amount = 1;
                    break;
                case ForwardPlayerStatus.TopSix:
                    amount = .5;
                    break;
                case ForwardPlayerStatus.TopNine:
                    amount = .5;
                    break;
                case ForwardPlayerStatus.BottomSix:
                    amount = .5;
                    break;
                case ForwardPlayerStatus.RolePlayer:
                    amount = 0;
                    break;
                case ForwardPlayerStatus.Unset:
                    amount = 0;
                    break;
            }
            Contract contract = new Contract(1, years, amount);
            _careerContracts.Add(contract);
        }
    }
}
